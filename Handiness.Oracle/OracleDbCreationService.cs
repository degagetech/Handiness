using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using Handiness;
using System.Data.Common;
using Oracle.ManagedDataAccess.Client;
using Handiness.Services;
namespace Handiness.MySql
{
    [Export(TextResources.Guid, typeof(IDbObjectCreationService))]
    public class MySqlDbCreationService : IDbObjectCreationService
    {
        public DbCommand GetDbCommand()
        {
            OracleCommand command = new OracleCommand();
            command.BindByName = true;
            return command;
        }
     
        public DbConnection GetDbConnection() => new OracleConnection();
        public DbParameter GetDbParameter() => new OracleParameter();
    }
}
