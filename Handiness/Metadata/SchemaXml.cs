using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
namespace Handiness.Metadata
{
    public class SchemaXml
    {
        public String DbName { get; set; }
        public TableSchemaXml[] Tables { get; set; }
    }
    [XmlType(TypeName = "Table")]
    public class TableSchemaXml
    {
        [XmlAttribute]
        public String Key { get; set; }
        public TableSchema Schema { get; set; }
        public ColumnSchemaXml[] Columns { get; set; }
    }
    [XmlType(TypeName = "Column")]
    public class ColumnSchemaXml
    {
        [XmlAttribute]
        public String Key { get; set; }
        public ColumnSchema Schema { get; set; }
    }
}
