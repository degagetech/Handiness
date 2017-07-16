using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Handiness.Metadata
{
    /// <summary>
    /// 用于存储表结构信息
    /// </summary>
    [XmlType(TypeName = nameof(TableSchema))]
    public class TableSchema
    {
        /// <summary>
        /// 表名称
        /// </summary>
        [XmlAttribute]
        public String Name { get; set; }
        /// <summary>
        ///列的计数
        /// </summary>
        [XmlAttribute]
        public Int32 Count { get; set; }
        /// <summary>
        /// 主键名称的集合
        /// </summary>
        [XmlArray]
        [XmlArrayItem(typeof(String),
        ElementName = "Name")]
        public String[] PrimekeyNames { get; set; }
        /// <summary>
        /// 列名称的集合
        /// </summary>
        [XmlArray]
        [XmlArrayItem(typeof(String),
        ElementName = "Name")]
        public String[] ColumnNames { get; set; }
        /// <summary>
        /// 表的注释信息
        /// </summary>
        [XmlAttribute]
        public String Explain { get; set; }
        public TableSchema() { }
        public TableSchema(
            String name,
            Int32 count,
            String[] primekeyNames,
            String[] columnNames,
            String explain
            )
        {
            this.Name = name;
            this.Count = count;
            this.PrimekeyNames = primekeyNames;
            this.ColumnNames = columnNames;
            this.Explain = explain;
        }
    }
}
