using System;
using System.Collections.Generic;
using System.IO;
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
 * 创建时间： 2017/7/21 15:17:16
 * 版本号：v1.0
 * .NET 版本：4.0
 * 本类主要用途描述：此类的实例对应一个记录了各项数据库类型到实体属性类型映射的信息文件
 *  -------------------------------------------------------------------------*/
    /// <summary>
    /// 类的实例对应一个记录了各项数据库类型到实体属性类型映射的信息文件
    /// </summary>
    [XmlRoot("TypeMapping")]
    public class TypeMappingXml
    {
        /// <summary>
        /// 映射描述
        /// </summary>
        public String Explain { get; set; }
        [XmlArray]
        public TypeMappingNodeXml[] MappingNodes { get; set; }

        /********************/
        internal const String TypeMappingXmlFilePattern = "*.tm";
        public static IEnumerable<TypeMappingXml> Search(String directory = null)
        {
            return TKXmlSerializer.Search<TypeMappingXml>(TypeMappingXmlFilePattern, directory);
        }
        public static IEnumerable<TypeMappingXml> Load(params String[] files)
        {
            return TKXmlSerializer.Load<TypeMappingXml>(files);
        }
    }
    [XmlType(TypeName = "MappingNode")]
    public class TypeMappingNodeXml
    {
        [XmlAttribute]
        public String DbType { get; set; }
        [XmlAttribute]
        public String MappingType { get; set; }
        [XmlAttribute]
        public Boolean? IsNullable { get; set; } 
        [XmlAttribute]
        public String Length { get; set; } 
    }
}
