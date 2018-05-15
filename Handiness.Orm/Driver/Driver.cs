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


        public DbConnection Connection { get; private set; }
        public DbProvider DbProvider { get; private set; }
        public DbCommand Command { get; private set; }


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
        public Int32 ExecuteNonQuery(DbConnection connection,DbTransaction transaction)
        {

            Int32 affact = 0;
            try
            {
                this.ExecutePrepare(connection);
                this.Command.Transaction = transaction;
                affact = this.Command.ExecuteNonQuery();
            }
            finally
            {
                this.Command.Parameters.Clear();
                this.Command = null;
                this.Connection = null;
            }
            return affact;
        }
        private void ExecutePrepare(DbConnection connection)
        {
            this.Command = this.DbProvider.DbCommand(this.SQLComponent.SQL, this.SQLComponent.Parameters.ToArray());
            this.Command.Connection = connection;
        }
        private void ExecutePrepare(String connectionString = null)
        {
            if (null == connectionString && null == (connectionString = this.DbProvider.ConnectionString))
            {
                throw new ArgumentException("connection string is invalied");
            }
            this.Connection = this.DbProvider.DbConnection(connectionString);
            this.Command = this.DbProvider.DbCommand(this.SQLComponent.SQL, this.SQLComponent.Parameters.ToArray());
            this.Command.Connection = this.Connection;
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
            this.Command?.Connection?.Close();
            this.Command?.Parameters.Clear();
            this.Command = null;
            this.Connection = null;
        }


        public Object ExecuteScalar(String connectionString = null)
        {

            try
            {
                this.ExecutePrepare(connectionString);
                this.OpenConnection();
                return this.Command.ExecuteScalar();
            }
            finally
            {
                this.CloseConnection();
            }
        }

        
        public ISelectVector<T> ExecuteReader(String connectionString = null)
        {

            ISelectVector<T> selectResultVector = ObjectFactory._.SelectVector<T>(this, connectionString);
            return selectResultVector;
        }
        public ISelectVector<T> ExecuteReader(DbConnection connection)
        {
            ISelectVector<T> selectResultVector = ObjectFactory._.SelectVector<T>(this, connection);
            return selectResultVector;
        }
        public ISelectVector<T> ExecuteReader(DbConnection connection,DbTransaction transaction)
        {
            ISelectVector<T> selectResultVector = ObjectFactory._.SelectVector<T>(this, connection, transaction);
            return selectResultVector;
        }

        public Object ExecuteScalar(DbConnection connection)
        {
            Object result = null;
            try
            {
                this.ExecutePrepare(connection);
                result = this.Command.ExecuteScalar();
            }
            finally
            {
                this.Command?.Parameters.Clear();
                this.Command = null;
                this.Connection = null;
            }
            return result;
        }

        public IDriver<T> JoinOn<T1>(Expression<Func<T, T1, Boolean>> predicate) where T1 : class
        {
            this.SQLComponent.AppendSQLFormat(CommonFormat.JOIN_ON_FORMAT,Table<T1>.Schema.TableName,String.Empty);
             LambdaToSqlConverter<T>.JoinOn<T1>(this.DbProvider, predicate, this.SQLComponent);
            return this;
        }

        public IDriver<T> JoinWhere<T1>(Expression<Func<T, T1, Boolean>> predicate) where T1 : class
        {
            this.SQLComponent.AppendWhere();
            LambdaToSqlConverter<T>.JoinWhere<T1>(this.DbProvider, predicate, this.SQLComponent);
            return this;
        }
        public IDriver<T> Where(Expression<Func<T, Boolean>> predicate)
        {
            this.SQLComponent.AppendWhere();
            SQLComponent component = new SQLComponent();
            LambdaToSqlConverter<T>.WhereConvert(this.DbProvider, predicate, component);
            this.SQLComponent.AppendSQLFormat(CommonFormat.BRACKET_FORMAT, component.SQL);
            this.SQLComponent.AddParameters(component.Parameters);
            return this;
        }

        public IDriver<T> Where(String whereSql, IEnumerable<DbParameter> dbParameters = null)
        {
            this.SQLComponent.AppendWhere();
            this.SQLComponent.AppendSQLFormat(CommonFormat.BRACKET_FORMAT, whereSql);
            this.SQLComponent.AddParameters(dbParameters);

            return this;
        }
        public IDriver<T> OrWhere(Expression<Func<T, Boolean>> predicate)
        {
            this.SQLComponent.AppendWhere(false);
            SQLComponent component = new SQLComponent();
            LambdaToSqlConverter<T>.WhereConvert(this.DbProvider, predicate, component);
            this.SQLComponent.AppendSQLFormat(CommonFormat.BRACKET_FORMAT, component.SQL);
            this.SQLComponent.AddParameters(component.Parameters);
            return this;
        }

     
    }
}
