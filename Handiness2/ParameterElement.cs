using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Handiness2
{
    /// <summary>
    /// 参数信息
    /// </summary>
    public class ParameterElement
    {
        /// <summary>
        /// 参数的名称
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// 参数包含的值
        /// </summary>
        public Object Value { get; set; }
        /// <summary>
        /// 参数的数据类型
        /// </summary>
        public DbType Type { get; set; }
    }

}
