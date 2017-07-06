using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Handiness.Properties;

namespace Handiness
{
    /*-------------------------------------------------------------------------
 * 版权所有：王浪静
 * 作者：王浪静
 * 联系方式：932444208@qq.com
 * 创建时间： 2017/7/6 10:49:47
 * 版本号：v1.0
 * .NET 版本：4.0
 * 本类主要用途描述：用于显示提供表结构信息
 *  -------------------------------------------------------------------------*/
    /// <summary>
    /// 用于显示提供表结构信息
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    class TableAttribute : Attribute
    {
        public String Name { get; }
        public TableAttribute(String name) : base()
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(Resources.EmptyTableName);
            }
            this.Name = name;
        }
    }
}
