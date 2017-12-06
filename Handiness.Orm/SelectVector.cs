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

    /// <summary>
    /// 查询容器基础实现类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SelectVector<T> : ISelectVector<T> where T : class
    {

        public DbDataReader DbDataReader { get; set; }


        private List<T> _convertedObjs = null;
        /// <summary>
        /// 用户判断查询结果中是否存在指定列
        /// </summary>
        private HashSet<String> _columnNameSet = new HashSet<String>();


        public SelectVector(DbDataReader dbDataReader)
        {
            this.DbDataReader = dbDataReader;
        }


        protected virtual T GenerateInstanceFromReader(DbDataReader dr)
        {
            T obj = Activator.CreateInstance(Table<T>.Schema.Type) as T;
            String columnName = null;
            Int32 length = Table<T>.Schema.Properties.Length;
            for (Int32 i = 0; i < length; ++i)
            {
                PropertyInfo info = Table<T>.Schema.Properties[i];
                columnName = Table<T>.Schema[info.Name];
                if (this.IsExistedOfColumn(dr, columnName))
                {
                    Object value = dr[columnName];
                    value = value == DBNull.Value ? null : value;
                    Table<T>.Schema.PropertyAccessor.SetValue(i, obj, value);
                }
            }
            return obj;
        }
        /// <summary>
        /// 判断 <see cref="DbDataReader"/>对象中是否存在指定名称的列
        /// </summary>
        /// <param name="columnName">列名</param>
        private Boolean IsExistedOfColumn(DbDataReader dr, String columnName)
        {
            Boolean isExisted = false;
            if (String.IsNullOrEmpty(columnName))
            {
                return isExisted;
            }
            if (this._columnNameSet.Contains(columnName))
            {
                isExisted = true;
            }
            else
            {
                Int32 count = dr.FieldCount;
                for (int i = 0; i < count; ++i)
                {
                    if (dr.GetName(i).Equals(columnName))
                    {
                        isExisted = true;
                        this._columnNameSet.Add(columnName);
                        break;
                    }
                }
            }
            return isExisted;
        }
        //protected virtual T GenerateInstanceFromRow(DataRow row)
        //{
        //    T obj = Activator.CreateInstance(Table<T>.TableReflectionCache.Type) as T;
        //    String columnName = null;
        //    foreach (PropertyInfo property in Table<T>.TableReflectionCache.ColumnPropertyCollection)
        //    {
        //        columnName = Table<T>.TableReflectionCache.ColumnAttributeCollection[property.Name].Name;
        //        if (row.Table.Columns.Contains(columnName))
        //        {
        //            Object value = row[columnName];
        //            value = value == DBNull.Value ? null : value;
        //            Table<T>.TableReflectionCache.PropertyAccessor.SetProperityValue(obj, property.Name, value);
        //        }
        //    }
        //    return obj;
        //}
        public Boolean HasRows
        {
            get
            {
                if (this.DbDataReader != null)
                    return this.DbDataReader.HasRows;
                return false;
            }
        }



        public T[] ToArray()
        {
            if (this._convertedObjs != null)
            {
                return this._convertedObjs.ToArray();
            }
            List<T> result = this.ToList();
            return result.ToArray();
        }



        public List<T> ToList()
        {
            List<T> result = new List<T>();
            if (this.HasRows)
            {
                try
                {
                    while (this.DbDataReader.Read())
                    {
                        T obj = this.GenerateInstanceFromReader(this.DbDataReader);
                        result.Add(obj);
                    }
                }
                finally
                {
                    if (!this.DbDataReader.IsClosed)
                        this.DbDataReader.Close();
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
                this._convertedObjs.Clear();
                this._convertedObjs = null;
            }
        }

        public T FirstOrDefault()
        {
            return this.ToList().FirstOrDefault();
        }
    }
}
