using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgilityConfig;
namespace Handiness2.Schema.Exporter.Windows
{
    public class ExcelExportTemplateConfig : ConfigBase
    {
        [ConfigTag(Name = "模板项集合", Description = "模板项集合", IsFindable = true)]
        public ExcelExportTemplateItem[] TemplateItems { get; set; }
    }
    public class ExcelExportTemplateItem: ConfigBase
    {
        /// <summary>
        /// 模板名称
        /// </summary>
        [ConfigTag(Name="名称",Description ="模板的名称",IsFindable =true)]
        public String Name { get; set; }
        /// <summary>
        /// 模板路径
        /// </summary>
        [ConfigTag(Name = "路径", Description = "模板文件的路径", IsFindable = true)]
        public String Path { get; set; }
     
    }
}
