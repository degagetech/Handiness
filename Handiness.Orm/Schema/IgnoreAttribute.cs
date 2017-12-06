using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handiness.Orm
{
    /// <summary>
    /// 使用ORM框架忽略类的指定属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class IgnoreAttribute : System.Attribute
    {
    }
}
