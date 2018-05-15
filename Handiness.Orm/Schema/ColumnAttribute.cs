using System;
using System.Data;

namespace Handiness.Orm
{
    /// <summary>
    /// 附加在类的属性上的特性，以映射到数据库的表的字段
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ColumnAttribute : Attribute
    {
        public ColumnAttribute() { }
        public ColumnAttribute(String name)
        {
            this.Name = name;
        }
        /// <summary>
        ///在数据库中列的名字
        /// </summary>
        public String Name { get; set; }
 
        public DbType DbType { get; set; } =DbType.Object;
        /// <summary>
        /// 是否是主键
        /// </summary>
        public Boolean IsPrimaryKey { get; set; }
        /// <summary>
        /// 是否可空
        /// </summary>
        public Boolean IsNullable { get; set; }
        /// <summary>
        /// 默认值
        /// </summary>
        public Object DefalutValue { get; set; } = null;

        /// <summary>
        /// 在生成列名时，是否禁用更明确的指示，例如：不使用 表a.name 而是单纯使用 name
        /// </summary>
        public Boolean DisableColumnSpecifically { get; set; }
    }
}
