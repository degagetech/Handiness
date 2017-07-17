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
    [Export(TextResources.Guid, typeof(IDbObjectCreationService))]
    public class MySqlDbCreationService : IDbObjectCreationService
    {
        public DbCommand GetDbCommand() => new MySqlCommand();
        public DbConnection GetDbConnection() => new MySqlConnection();
        public DbParameter GetDbParameter() => new MySqlParameter();
    }
}
