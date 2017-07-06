using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handiness.Metadata
{
    /// <summary>
    /// 用于存储表结构信息
    /// </summary>
    public class TableSchema
    {
        /// <summary>
        /// 表名称
        /// </summary>
        public String Name { get; }
        /// <summary>
        ///列的计数
        /// </summary>
        public Int32 Count { get; }
        /// <summary>
        /// 主键名称的集合
        /// </summary>
        public IList<String> PrimekeyNames { get; }
        /// <summary>
        /// 列名称的集合
        /// </summary>
        public IList<String> ColumnNames { get; }
        public TableSchema(
            String name,
            Int32 count,
            IList<String> primekeyNames,
            IList<String> columnNames
            )
        {
            this.Name = name;
            this.Count = count;
            this.PrimekeyNames = primekeyNames;
            this.ColumnNames = columnNames;
        }
    }
}
