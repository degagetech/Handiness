using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handiness2.Schema.Exporter.Windows
{
    public class ExcelExportConfig : ExportConfig
    {
        /// <summary>
        /// 是否适用自定义分组
        /// </summary>
        public Boolean IsCustomGroup { get; set; }


        /// <summary>
        /// 分组信息
        /// </summary>

        public GroupInfoCollection GroupInfo { get; set; }

        /// <summary>
        /// 是否将相同组的 Schema 信息导出到 同一 Sheet
        /// </summary>
        public Boolean IsMergeGroupToSheet { get; set; }

        /// <summary>
        /// Excel 模板的路径
        /// </summary>
        public String ExcelTemplatePath { get; set; }
    }
}
