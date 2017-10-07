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
    [Export(OracleAdaptiveExplain.ALGuid, typeof(AuxiliaryObjService))]
    public class OracleAuxiliaryObjService : AuxiliaryObjService
    {
        /// <summary>
        /// Oracle参数前导区分符
        /// </summary>
        internal const String OracleSpecificator = ":";
        public override String Specificator => OracleSpecificator;

        public override DbCommand DbCommand()
        {
            OracleCommand command = new OracleCommand();
            command.BindByName = true;
            return command;
        }
        public override DbConnection DbConnection() => new OracleConnection();
        public override DbParameter DbParameter() => new OracleParameter();
    }
}
