using System;

namespace Handiness.Orm
{
    /// <summary>
    /// 附加在类上的特性，以映射到数据库的表或视图
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class TableAttribute : Attribute
    {
        public TableAttribute(String name)
        {
            this.Name = name;
        }
        /// <summary>
        /// 在数据库中表的名字
        /// </summary>
        public String Name { get; set; }
    }
}
