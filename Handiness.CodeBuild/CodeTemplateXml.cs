using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Handiness.CodeBuild
{
    /*-------------------------------------------------------------------------
 * 版权所有：王浪静
 * 作者：王浪静
 * 联系方式：932444208@qq.com
 * 创建时间： 2017/7/25 20:24:15
 * 版本号：v1.0
 * .NET 版本：4.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/
    [XmlRoot("CodeTemplate")]
    public class CodeTemplateXml
    {
        /// <summary>
        /// 模板说明
        /// </summary>
        public String Explain { get; set; }
        /// <summary>
        /// 根据模板生成的文件的后缀名
        /// </summary>
        public String Postfix { get; set; }
        /// <summary>
        /// 头部信息，例如程序集的引用 
        /// </summary>
        public String Header { get; set; }
        public String Body { get; set; }
        public LoopGroupXml[] LoopGroups { get; set; }
    }
    /// <summary>
    /// 循环组中的格式会应用到不同列信息上，这些被填充的格式信息会被拼接起来，并填充到对应的占位符中 [Key]
    /// </summary>
    [XmlType(TypeName = "LoopGroup")]
    public class LoopGroupXml
    {
        [XmlAttribute]
        public String Key { get; set; }
        public String Format { get; set; }
    }
}
