using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Handiness2.Schema
{
    /// <summary>
    /// 映射目标对象的列结构信息
    /// </summary>
    [Serializable]
    public class ColumnSchema : SchemaBase
    {
        /// <summary>
        /// 是否为主键
        /// </summary>
        public Boolean IsPrimaryKey { get; set; }

        /// <summary>
        /// 数据类型
        /// </summary>
        public DbType DbType { get; set; } = DbType.Object;

        /// <summary>
        /// 长度
        /// </summary>
        public Int32 Length { get; set; }

        /// <summary>
        /// 是否可为空
        /// </summary>
        public Boolean IsNullable { get; set; } = true;

    }
}
