using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handiness2.Schema.Exporter.Windows
{
    public class ExcelSchemaExporter : ISchemaExporter
    {
        public event Action<Object, SchemaExportEventArgs> ExportProgressChanged;
        public event  Action<Object, SchemaExportCompletedEventArgs> ExportCompleted;
        public void Export(String exportDirectory, IList<SchemaInfoTuple> schemas, ExportConfig config)
        {
          
        }
    }
}
