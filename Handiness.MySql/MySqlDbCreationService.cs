using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using Handiness;
using System.Data.Common;
using MySql.Data.MySqlClient;
namespace Handiness.MySql
{
    [Export(TextResource.Guid, typeof(IDbObjectCreationService))]
    public class MySqlDbCreationService : IDbObjectCreationService
    {
        public DbCommand GetDbCommand() => new MySqlCommand();
        public DbConnection GetDbConnection() => new MySqlConnection();
        public DbParameter GetDbParameter() => new MySqlParameter();
    }
}
