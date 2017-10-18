using System;
using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Data;

namespace Handiness.Orm
{
    public class MySqlDbProvider : DbProvider
    {
        public MySqlDbProvider(String name, String connectionString, Boolean replaced = false, Boolean saved = false) : base(name, connectionString, replaced, saved) { }

        public override DbConnection DbConnectionFactroy(String connectionString = null, Boolean isRelevance = false)
        {
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = connectionString ?? this.ConnectionString;
            if (isRelevance)
            {
                this.ConnectionString = connection.ConnectionString;
            }
            return connection;
        }
        public override DbCommand DbCommandFactroy(String commandText = null, DbParameter[] dbParameterArray = null)
        {
            MySqlCommand mysqlCommand = new MySqlCommand();
            if (!String.IsNullOrEmpty(commandText))
            {
                mysqlCommand.CommandText = commandText;
            }
            if (null != dbParameterArray)
            {
                mysqlCommand.Parameters.AddRange(dbParameterArray);
            }
            return mysqlCommand;
        }
        public override DbParameter DbParameterFactroy(String name = null, DbType dbType = DbType.Object, object value = null)
        {
            MySqlParameter parameter = new MySqlParameter(name, value);
            return parameter;
        }
        public override String PrefixParameterName
        {
            get
            {
                return "?";
            }
        }
    }
}
