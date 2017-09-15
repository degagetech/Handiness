using System;

namespace Handiness.Orm
{
    /// <summary>
    /// 附加在表上的特性，以映射到数据库的表
    /// </summary>
    [AttributeUsage(AttributeTargets.Class,Inherited =true)]
    public class TableAttribute : Attribute
    {
        /// <summary>
        /// 在数据库中表的名字
        /// </summary>
        public String Name { get; set; } 
        /// <summary>
        /// 绑定的数据库提供者的名称
        /// </summary>
        public String BindingDbProviderName { get; set; } 
    }
}
