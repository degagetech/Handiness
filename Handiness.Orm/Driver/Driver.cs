using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq.Expressions;

namespace Handiness.Orm
{

    /// <summary>
    /// 传动器的基础实现类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Driver<T> : IDriver<T> where T : class
    {
        public Expression<Func<T, dynamic>> Selector { get; set; }


        public DbConnection Connection { get; set; }
        public DbProvider DbProvider { get; private set; }
        public DbCommand Command { get; set; }
 

        public SQLComponent SQLComponent { get; set; } = new SQLComponent();

        /// <summary>
        /// 使用指定 DbProvider 初始化传动器
        /// </summary>
        /// <param name="dbProvider"></param>
        public Driver(DbProvider dbProvider)
        {
            this.DbProvider = dbProvider;
        }


        public Int32 ExecuteNonQuery(String connectionString = null)
        {
            this.ExecutePrepare(connectionString);
            try
            {
                this.OpenConnection();
                Int32 affact = 0;
                affact = this.Command.ExecuteNonQuery();
                return affact;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public Int32 ExecuteNonQuery(DbConnection connection)
        {
            this.ExecutePrepare(connection);
            Int32 affact = 0;
            affact = this.Command.ExecuteNonQuery();
            return affact;
        }
        private void ExecutePrepare(DbConnection connection)
        {
            this.Command = connection.CreateCommand();
            this.Command.CommandText = this.SQLComponent.SQL;
            this.Command.Parameters.AddRange(this.SQLComponent.Parameters.ToArray());
        }
        private void ExecutePrepare(String connectionString = null)
        {
            if (null == connectionString && null == (connectionString = this.DbProvider.ConnectionString))
            {
                throw new ArgumentException("connection string is invalied");
            }
            this.Connection = this.DbProvider.DbConnection(connectionString);
            this.Command = this.DbProvider.DbCommand();
            this.Command.CommandText = this.SQLComponent.SQL;
            this.Command.Connection = this.Connection;
            this.Command.Parameters.Clear();
            this.Command.Parameters.AddRange(this.SQLComponent.Parameters.ToArray());
        }

        private void OpenConnection()
        {
            switch (this.Command.Connection.State)
            {
                case ConnectionState.Broken:
                case ConnectionState.Closed:
                    {
                        this.Command.Connection.Open();
                    }
                    break;
                default:
                    break;
            }
        }
        private void CloseConnection()
        {
            this.Command.Connection.Close();
        }
        public ISelectVector<T> ExecuteReader(String connectionString = null)
        {
            this.ExecutePrepare(connectionString);
            DbDataReader dbDataReader = null;
            this.OpenConnection();
            DataTable dataTable = new DataTable();
            dbDataReader = this.Command.ExecuteReader(CommandBehavior.CloseConnection);
            ISelectVector<T> selectResultVector = ObjectFactory._.SelectVector<T>(dbDataReader);
            return selectResultVector;
        }

        public Object ExecuteScalar(String connectionString = null)
        {
            this.ExecutePrepare(connectionString);
            try
            {
                this.OpenConnection();
                return this.Command.ExecuteScalar();
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public IDriver<T> Where(Expression<Func<T, Boolean>> predicate)
        {
            this.SQLComponent.AppendWhere();
            String whereSql = String.Empty;
            List<DbParameter> dbParameters = new List<DbParameter>();
            whereSql = LambdaToSqlConverter<T>.WhereConvert(this.DbProvider, predicate, dbParameters);
            this.SQLComponent.Append(whereSql, dbParameters);
            return this;
        }

        public IDriver<T> Where(String whereSql, IEnumerable<DbParameter> dbParameters = null)
        {
            this.SQLComponent.AppendWhere();
            this.SQLComponent.Append(whereSql, dbParameters);
            return this;
        }
    }
}
