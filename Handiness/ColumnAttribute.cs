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
 * 创建时间： 2017/7/6 10:41:07
 * 版本号：v1.0
 * .NET 版本：4.0
 * 本类主要用途描述：用于显式提供列的结构信息
 *  -------------------------------------------------------------------------*/
    /// <summary>
    /// 显式提供列的结构信息
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    class ColumnAttribute : Attribute
    {
        public String Name { get;  }
        public Boolean IsPrimaryKey { get; set; }
        public Boolean IsNullable { get; set; }
        public ColumnAttribute(String name,
            Boolean isPrimaryKey = false,
           Boolean isNullable = false) : base()
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(Resources.EmptyColumnName);
            }
            this.Name = name;
            this.IsPrimaryKey = isPrimaryKey;
            this.IsNullable = isNullable;

        }
    }
}
