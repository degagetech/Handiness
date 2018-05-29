using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
namespace Handiness2.Schema.Exporter
{
    /// <summary>
    /// Office 导出命令
    /// </summary>
    public class OfficeExportCommand : ExportCommand
    {
        internal const String ExportTypeExcel = "excel";
        internal const String ExportTypeWord = "word";
        internal const String TemplateFileName = "template.xlsx";
        /// <summary>
        ///导出模板
        /// </summary>
        [CommandArgs("template", "t", HelpText = "源模板的位置")]
        public String Template { get; set; }
        /// <summary>
        /// 导出类型
        /// </summary>
        [CommandArgs("type", "type", HelpText = "导出类型，" + ExportTypeExcel + "|" + ExportTypeWord)]
        public String Type { get; set; }

        public OfficeExportCommand() : base()
        {
            String path = Assembly.GetExecutingAssembly().Location;
            path = Path.GetDirectoryName(path);
            this.Template =Path.Combine(path,TemplateFileName);
        }
    }
}
