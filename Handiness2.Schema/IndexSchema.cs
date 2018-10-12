using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handiness2.Schema
{
    /// <summary>
    /// 映射表的索引结构信息
    /// </summary>
    [Serializable]
    public class IndexSchema : SchemaBase, IObjectSchema
    {
        /// <summary>
        /// 索引的说明信息
        /// </summary>
        public String Explain { get; set; }
        /// <summary>
        /// 索引列的名称
        /// </summary>
        public String ColumnNames { get; set; }
    }
}
