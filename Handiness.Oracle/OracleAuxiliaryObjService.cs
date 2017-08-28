using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using Handiness;
using System.Data.Common;
using Oracle.ManagedDataAccess.Client;
using Handiness.Services;
namespace Handiness.Oracle
{
    [Export(OracleAdaptiveExplain.ALGuid, typeof(IAuxiliaryObjService))]
    public class OracleAuxiliaryObjService : IAuxiliaryObjService
    {
        /// <summary>
        /// Oracle参数前导区分符
        /// </summary>
        internal const String OracleSpecificator = ":";
        public String Specificator => OracleSpecificator;

        public DbCommand GenerateDbCommand()
        {
            OracleCommand command = new OracleCommand();
            command.BindByName = true;
            return command;
        }
        public DbConnection GenerateDbConnection() => new OracleConnection();
        public DbParameter GenerateDbParameter() => new OracleParameter();
    }
}
