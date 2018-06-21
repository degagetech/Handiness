using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handiness2.Schema.Exporter.Windows
{
    public class ExcelSchemaExporter : ISchemaExporter
    {
        public event Action<Object, SchemaExportEventArgs> ExportProgressChanged;

        public void Export(ISchemaExporter exporter, IList<SchemaInfoTuple> schemas, ExportConfig config)
        {
          
        }
    }
}
