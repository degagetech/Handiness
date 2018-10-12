using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handiness2.Schema.SQLServer
{
    public partial class SQLServerSchemaProvider : ISchemaProvider
    {
        public IList<ProcedureSchema> LoadProcedureSchemaList()
        {
            throw new NotImplementedException();
        }
    }
}
