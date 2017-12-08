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

        public IDriver<T> Driver { get; private set; }

        public DbConnection Connection { get; private set; }

        /// <summary>
        /// 表示是否需要手动关闭Connection
        /// </summary>
        private Boolean _needClose = false;
        private String _connectionString;
        public SelectVector(IDriver<T> driver, String connectionString = null)
        {
            this.Driver = driver;
            this._connectionString = connectionString;
            this._needClose = true;
        }
        public SelectVector(IDriver<T> driver, DbConnection connection)
        {
            this.Driver = driver;
            this.Connection = connection;

        }
        public DataTable ToDataTable()
        {
            DataTable result = new DataTable();
            try
            {
                var reader = this.GetReader();
                result.Load(reader);
            }
            finally
            {
                this.Close();
            }
            return result;
        }

        public T[] ToArray()
        {
            List<T> result = this.ToList();
            return result.ToArray();
        }

        private DbDataReader GetReader()
        {
            if (this._needClose)
            {
                this.Connection = this.Driver.DbProvider.DbConnection(this._connectionString);
                this.Connection.Open();
            }
            else if(this.Connection==null)
            {
                this.Connection = this.Driver.DbProvider.DbConnection(this._connectionString);
                this._needClose = true;
            }
            DbCommand command = this.Driver.DbProvider.DbCommand(
                  this.Driver.SQLComponent.SQL,
                  this.Driver.SQLComponent.Parameters.ToArray()
                  );
            command.Connection = this.Connection;
            DbDataReader reader = command.ExecuteReader();
            command.Parameters.Clear();
            return reader;
        }

        public List<T> ToList()
        {
            List<T> result = new List<T>();
            try
            {
                var reader = this.GetReader();
                result = DataExtractor<T>.ToList(reader);
            }
            finally
            {
                this.Close();
            }
            return result;
        }

        public void Dispose()
        {
            this.Close();
        }
        public void Close()
        {
            if (this._needClose && this.Connection != null && this.Connection.State==ConnectionState.Open)
            {
                this.Connection.Close();
                this.Connection = null;
            }
        }
        public T Single()
        {
            return this.ToList().Single();
        }
        public T FirstOrDefault()
        {
            return this.ToList().FirstOrDefault();
        }

     
    }
}
