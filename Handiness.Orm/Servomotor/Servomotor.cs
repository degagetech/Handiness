using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq.Expressions;
using static Handiness.Orm.OrmToolkit;
namespace Handiness.Orm
{

    public class Servomotor<T> : IServomotor<T> where T : class
    {
        public Expression<Func<T, dynamic>> Selector { get; set; }
        public String CurrentContainedSql { get; private set; } = String.Empty;

        public DbConnection Connection { get; set; }
        public DbProvider DbProvider { get; private set; }
        public DbCommand Command { get; set; }
        public List<DbParameter> DbParameterCollection { get; private set; } = new List<DbParameter>();



        public Servomotor(DbProvider dbProvider)
        {
            this.DbProvider = dbProvider;
        }

        public void AppendSql(String sql)
        {
            this.CurrentContainedSql += sql;
        }

        public void AppendDbParameters(IEnumerable<DbParameter> dbParameters)
        {
            if (dbParameters != null)
            {
                this.DbParameterCollection.AddRange(dbParameters);
            }
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
            this.Command.CommandText = this.CurrentContainedSql;
            this.Command.Parameters.AddRange(this.DbParameterCollection.ToArray());
        }
        private void ExecutePrepare(String connectionString = null)
        {
            if (null == connectionString && null == (connectionString = this.DbProvider.ConnectionString))
            {
                throw new ArgumentException("Db connection is invalied in Handiness 'ExecutePrepare'");
            }
            this.Connection = this.DbProvider.DbConnectionFactroy(connectionString);
            this.Command = this.DbProvider.DbCommandFactroy();
            this.Command.CommandText = this.CurrentContainedSql;
            this.Command.Connection = this.Connection;
            this.Command.Parameters.Clear();
            this.Command.Parameters.AddRange(this.DbParameterCollection.ToArray());
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
        public ISelectResultVector<T> ExecuteReader(String connectionString = null)
        {
            this.ExecutePrepare(connectionString);
            DbDataReader dbDataReader = null;
            this.OpenConnection();
            DataTable dataTable = new DataTable();
            dbDataReader = this.Command.ExecuteReader(CommandBehavior.CloseConnection);
            ISelectResultVector<T> selectResultVector = new SelectResultVector<T>(dbDataReader, this.Selector);
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

        public IServomotor<T> Where(Expression<Func<T, Boolean>> predicate)
        {

            if (!HasSqlKeyword(this.CurrentContainedSql, SqlKeyWord.Where))
            {
                this.AppendSql(SqlKeyWord.Where.Describe(true));
            }
            else
            {
                this.AppendSql(SqlKeyWord.And.Describe(true, true));
            }
            String whereSql = String.Empty;
            List<DbParameter> dbParameters = new List<DbParameter>();
            whereSql = LambdaToSqlConverter<T>.WhereConvert(this.DbProvider, predicate, dbParameters);
            this.AppendSql(whereSql);
            this.AppendDbParameters(dbParameters);
            return this;
        }

        public IServomotor<T> Where(String whereSql, IEnumerable<DbParameter> dbParameters = null)
        {
            if (!HasSqlKeyword(this.CurrentContainedSql, SqlKeyWord.Where))
            {
                this.AppendSql(SqlKeyWord.Where.Describe(true));
            }
            else
            {
                this.AppendSql(SqlKeyWord.And.Describe(true, true));
            }
            this.AppendSql(whereSql);
            this.AppendDbParameters(dbParameters);
            return this;
        }
    }
}
