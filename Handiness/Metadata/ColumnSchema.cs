using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Xml.Serialization;
namespace Handiness.Metadata
{
    /// <summary>
    /// 用于存储列结构信息
    /// </summary>
    [XmlType(TypeName = nameof(ColumnSchema))]
    public class ColumnSchema
    {
        /// <summary>
        /// 列名
        /// </summary>
        [XmlAttribute]
        public String Name { get; set; }
        /// <summary>
        /// 是否主键
        /// </summary>
        [XmlAttribute]
        public Boolean IsPrimeKey { get; set; }
        /// <summary>
        /// 列的数据长度
        /// </summary>
        [XmlAttribute]
        public Int32 Length { get;  set; }
        /// <summary>
        /// 列类型
        /// </summary>
        [XmlAttribute]
        public String Type { get;  set; }
        /// <summary>
        /// 所属表的名称
        /// </summary>
        [XmlAttribute]
        public String TableName { get;  set; }
        /// <summary>
        /// 表示列是否可以为空
        /// </summary>
        [XmlAttribute]
        public Boolean IsNullable { get; set; }
        /// <summary>
        /// 列的注释信息
        /// </summary>
        [XmlAttribute]
        public String Explain { get; set; }
        public ColumnSchema() { }
        public ColumnSchema(
            String name,
            Boolean isPrimekey,
            String type,
            Int32 length,
            Boolean isNullable,
            String tableName,
            String explain
            )
        {
            this.Name = name;
            this.IsPrimeKey = isPrimekey;
            this.Type = type;
            this.Length = length;
            this.IsNullable = isNullable;
            this.TableName = tableName;
            this.Explain = explain;
        }
    }
}
