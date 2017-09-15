using System;
using System.Data.SQLite;
using System.Data.Common;
using System.Data;

namespace Handiness.Orm
{
    public class SQLiteDbProvider : DbProvider
    {
        public SQLiteDbProvider(String name, String connectionString, Boolean replaced = false, Boolean saved = false) : base(name, connectionString, replaced, saved) { }

        public override DbConnection DbConnectionFactroy(String connectionString = null, Boolean isRelevance = false)
        {
           
            SQLiteConnection connection = new SQLiteConnection();
            connection.ConnectionString = connectionString ?? this.ConnectionString;
            if (isRelevance)
            {
                this.ConnectionString = connection.ConnectionString;
            }
            return connection;
        }
        public override DbCommand DbCommandFactroy(String commandText = null, DbParameter[] dbParameterArray = null)
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
        public override DbParameter DbParameterFactroy(String name = null, DbType dbType = DbType.Object, object value = null)
        {
            SQLiteParameter parameter = new SQLiteParameter(name, value);
            return parameter;
        }
        public override String PrefixParameterName
        {
            get
            {
                return "@";
            }
        }
    }
}
