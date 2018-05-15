
#if SQLITE_ENABLE_NO
using System;
using System.Data.SQLite;
using System.Data.Common;
using System.Data;

namespace Handiness.Orm
{
    public class SQLiteDbProvider : DbProvider
    {
        public SQLiteDbProvider(String name, String connectionString) : base(name, connectionString) { }

        public override DbConnection DbConnection(String connectionString = null, Boolean isRelevance = false)
        {

            SQLiteConnection connection = new SQLiteConnection
            {
                ConnectionString = connectionString ?? this.ConnectionString
            };
            if (isRelevance)
            {
                this.ConnectionString = connection.ConnectionString;
            }
            return connection;
        }
        public override DbCommand DbCommand(String commandText = null, DbParameter[] dbParameterArray = null)
        {
            SQLiteCommand sqliteCommand = new SQLiteCommand();
            if (!String.IsNullOrEmpty(commandText))
            {
                sqliteCommand.CommandText = commandText;
            }
            if (null != dbParameterArray)
            {
                sqliteCommand.Parameters.AddRange(dbParameterArray);
            }
            return sqliteCommand;
        }
        public override DbParameter DbParameter(String name = null, Object value = null, DbType dbType = DbType.Object)
        {
            SQLiteParameter parameter = new SQLiteParameter(name, value);
            if (dbType != DbType.Object)
            {
                parameter.DbType = dbType;
            }
            return parameter;
        }
        public override String Prefix
        {
            get
            {
                return "@";
            }
        }
    }
}
#endif