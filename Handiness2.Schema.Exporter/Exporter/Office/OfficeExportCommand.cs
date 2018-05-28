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
        /// <summary>
        ///导出模板
        /// </summary>
        [CommandArgs("template", "t", HelpText = "源模板的位置")]
        public String Template { get; set; }
        /// <summary>
        /// 导出类型
        /// </summary>
        [CommandArgs("type", "type", HelpText = "导出类型" + ExportTypeExcel + "|" + ExportTypeWord)]
        public String Type { get; set; }

        public OfficeExportCommand() : base()
        {
            String path = Assembly.GetExecutingAssembly().CodeBase;
            path = Path.GetDirectoryName(path);
            this.Template = path + "table template.xlsx";
        }
    }
}
