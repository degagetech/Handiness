using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Handiness.Orm
{
    /// <summary>
    /// 用于表示列的结构信息
    /// </summary>
    public class ColumnSchema
    {
        /// <summary>
        /// 列名称
        /// </summary>
        public String Name { get; set; }
        public Boolean IsPrimaryKey { get; set; }
        public DbType DbType { get; set; } = DbType.Object;
        /// <summary>
        /// 在生成列名时，是否禁用更明确的指示，例如：不使用 表a.name 而是单纯使用 name
        /// </summary>
        public Boolean DisableColumnSpecifically { get;  set; }
    }
}
