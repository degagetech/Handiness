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
    [Export(MysqlAdaptiveExplain.ALGuid, typeof(AuxiliaryObjService))]
    public class MySqlAuxiliaryObjService : AuxiliaryObjService
    {
        /// <summary>
        /// MySql参数前导区分符
        /// </summary>
        internal const String MySqlSpecificator = ":";
        public override String Specificator => MySqlSpecificator;

        public override DbCommand DbCommand() => new MySqlCommand();
        public override DbConnection DbConnection() => new MySqlConnection();
        public override DbParameter DbParameter() => new MySqlParameter();
    }
}
