using System;
using System.Data;

namespace  Handiness.Orm
{
    /// <summary>
    /// 附加在类的属性上的特性，以映射到数据库的表的字段
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        /// <summary>
        ///在数据库中列的名字
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// 作为参数添加时选择的类型
        /// </summary>
        public DbType Type { get; set; }
        /// <summary>
        /// 是否是主键
        /// </summary>
        public Boolean IsPrimaryKey { get; set; }
        /// <summary>
        /// 是否不可以为空
        /// </summary>
        public Boolean IsNotNullable { get; set; }
        /// <summary>
        /// 默认值
        /// </summary>
        public Object DefalutValue { get; set; } = null;
    }
}
