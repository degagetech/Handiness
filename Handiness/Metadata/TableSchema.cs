using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handiness.Metadata
{
    /// <summary>
    /// 表结构
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
        /// 主键名称的枚举集合
        /// </summary>
        public IEnumerable<String> PrimekeyNames { get; }
        /// <summary>
        /// 列名称的枚举集合
        /// </summary>
        public IEnumerable<String> ColumnNames { get; }

        public TableSchema(
            String name,
            Int32 count,
            IEnumerable<String> primekeyNames,
            IEnumerable<String> columnNames
            )
        {
            this.Name = name;
            this.Count = count;
            this.PrimekeyNames = primekeyNames;
            this.ColumnNames = columnNames;
        }
    }
}
