using System;
using System.Collections.Generic;
using System.Text;

namespace Handiness2.Schema.Exporter
{
    public class ExportCommand
    {
        /// <summary>
        /// 导出结构信息的输出路径
        /// </summary>
        [CommandArgs("output", "o", Required = true, HelpText = "导出结构信息的输出路径")]
        public String Output { get; set; } 
    }
}
