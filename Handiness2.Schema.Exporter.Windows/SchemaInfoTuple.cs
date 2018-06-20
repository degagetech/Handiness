using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handiness2.Schema.Exporter.Windows
{
    public class SchemaInfoTuple
    {
        public TableSchemaExtend TableSchema { get; set; }
        public IList<ColumnSchemaExtend> ColumnSchems { get; set; }
    }
}
