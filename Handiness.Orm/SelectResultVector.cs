using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Handiness.Orm
{

    /********/
    public class SelectResultVector<T> : ISelectResultVector<T> where T : class
    {


        /****************私有字段****************/
        private DataTable _dataTable = null;
        private List<T> _convertedObjs = null;


        /// <summary>
        /// 调用此属性会 将DbDataReader中的数据加载到DataTable 中并会关闭DbDataReader
        /// </summary>
        public DataTable DataTable
        {
            get
            {
                if (this._dataTable == null && this.DbDataReader != null && this.DbDataReader.HasRows)
                {
                    this._dataTable = new DataTable();
                    try
                    {
                        this._dataTable.Load(this.DbDataReader);
                    }
                    finally
                    {
                        this.DbDataReader.Close();
                    }
                }
                return this._dataTable;
            }
        }
        public SelectResultVector() { }
        public SelectResultVector(DbDataReader dbDataReader, Expression<Func<T, dynamic>> selector = null)
        {
            this.DbDataReader = dbDataReader;
            this.Selector = selector;
        }
        public DbDataReader DbDataReader
        {
            get; set;
        }
        protected virtual T GenerateObjFromReader(DbDataReader dr)
        {
            T obj = Activator.CreateInstance(Table<T>.TableReflectionCache.Type) as T;
            String columnName = null;
            foreach (PropertyInfo property in Table<T>.TableReflectionCache.ColumnPropertyCollection)
            {
                columnName = Table<T>.TableReflectionCache.ColumnAttributeCollection[property.Name].Name;
                if (this.IsColumnExistFromReader(dr, columnName))
                {
                    Object value = dr[columnName];
                    property.SetValue(obj, value == DBNull.Value ? null : value, null);
                }
            }
            return obj;
        }
        /// <summary>
        /// 判断DbReader中是否存在指定名称的列
        /// </summary>
        /// <param name="columnName">列名</param>
        private Boolean IsColumnExistFromReader(DbDataReader dr, String columnName)
        {
            Boolean isExisted = false;
            if (String.IsNullOrEmpty(columnName))
            {
                return isExisted;
            }
            Int32 count = dr.FieldCount;
            for (int i = 0; i < count; ++i)
            {
                if (dr.GetName(i).Equals(columnName))
                {
                    isExisted = true;
                    break;
                }
            }
            return isExisted;
        }
        protected virtual T GenerateObjFromRow(DataRow row)
        {
            T obj = Activator.CreateInstance(Table<T>.TableReflectionCache.Type) as T;
            String columnName = null;
            foreach (PropertyInfo property in Table<T>.TableReflectionCache.ColumnPropertyCollection)
            {
                columnName = Table<T>.TableReflectionCache.ColumnAttributeCollection[property.Name].Name;
                if (row.Table.Columns.Contains(columnName))
                {
                    Object value = row[columnName];
                    property.SetValue(obj, value == DBNull.Value ? null : value, null);

                }
            }
            return obj;
        }
        public Boolean HasRows
        {
            get
            {
                if (this._dataTable != null)
                {
                    return (this._dataTable.Rows.Count >= 0);
                }
                else if (this.DbDataReader != null)
                {
                    return this.DbDataReader.HasRows;
                }
                return false;
            }
        }

        public Boolean HasSelector
        {
            get
            {
                return (this.Selector != null);
            }
        }

        public Expression<Func<T, dynamic>> Selector
        {
            get;
            set;
        } = null;

        public T[] ToArray()
        {
            if (this._convertedObjs != null)
            {
                return this._convertedObjs.ToArray();
            }
            List<T> result = this.ToList();
            return result.ToArray();
        }

        public dynamic[] ToDynamicArray()
        {
            return this.ToDynamicList().ToArray();
        }
        /// <summary>
        /// 当选择器为空时请不要使用此函数，否则会一直返回一个包含零个元素的List,
        /// 可以先使用HasSelector属性查看是否有选择器
        /// </summary>
        public List<dynamic> ToDynamicList()
        {
            List<dynamic> result = new List<dynamic>();
            if (!this.HasSelector)
            {
                return result;
            }
            if (this._convertedObjs == null)
            {
                this._convertedObjs = this.ToList();
            }
            Func<T, dynamic> converter = this.Selector.Compile();
            foreach (T obj in this._convertedObjs)
            {
                result.Add(converter(obj));
            }
            return result;
        }

        public List<T> ToList()
        {
            List<T> result = new List<T>();
            if (this.HasRows)
            {
                if (this._dataTable == null)
                {
                    try
                    {
                        while (this.DbDataReader.Read())
                        {
                            T obj = this.GenerateObjFromReader(this.DbDataReader);
                            result.Add(obj);
                        }
                    }
                    finally
                    {
                        if (!this.DbDataReader.IsClosed)
                            this.DbDataReader.Close();
                    }
                }
                else
                {
                    foreach (DataRow row in this._dataTable.Rows)
                    {
                        T obj = this.GenerateObjFromRow(row);
                        result.Add(obj);
                    }
                }
            }
            return result;
        }

        public void Dispose()
        {
            this.Close();
        }
        public void Close()
        {
            if (this.DbDataReader != null && !this.DbDataReader.IsClosed)
            {
                this.DbDataReader.Close();
                this._dataTable = null;
                this._convertedObjs = null;
            }
        }

        public T FirstOrDefault()
        {
            return this.ToList().FirstOrDefault();
        }
    }
}
