using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgilityConfig;
namespace Handiness2.Schema.Exporter.Windows
{
    public class GlobalConfig : ConfigBase
    {
        [ConfigTag(IsEncrypted = true)]
        public String ConnectionString { get; set; }
        [ConfigTag]
        public List<String> SelectedSchemaInfo { get; set; }
        [ConfigTag]
        public String ExcelExportConfigString { get; set; }
        [ConfigTag]
        public String OutputDirecotry { get; set; }

        [ConfigTag]
        public ExportType SelectExportType { get; set; }

 
    }
}
