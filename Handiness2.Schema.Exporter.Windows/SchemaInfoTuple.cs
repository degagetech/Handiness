using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handiness2.Schema.Exporter.Windows
{
    public class SchemaInfoTuple
    {
        public TableSchemaExtend TableSchema { get; set; }
        public List<ColumnSchemaExtend> ColumnSchemas { get; set; }
        public List<ColumnSchemaExtend> IndexColumnSchemas { get; set; }

        public SchemaType SchemaType { get; set; }
    }
}
