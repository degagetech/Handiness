using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using Handiness;
using System.Data.Common;
using MySql.Data.MySqlClient;
using Handiness.Services;
namespace Handiness.MySql
{
    [Export(MysqlAdaptiveExplain.ALGuid, typeof(IAuxiliaryObjService))]
    public class MySqlAuxiliaryObjService : IAuxiliaryObjService
    {
        /// <summary>
        /// MySql参数前导区分符
        /// </summary>
        internal const String MySqlSpecificator = ":";
        public String Specificator => MySqlSpecificator;

        public DbCommand GenerateDbCommand() => new MySqlCommand();
        public DbConnection GenerateDbConnection() => new MySqlConnection();
        public DbParameter GenerateDbParameter() => new MySqlParameter();
    }
}
