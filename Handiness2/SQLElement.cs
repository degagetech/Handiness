using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
namespace Handiness2
{
    /// <summary>
    /// 基础的SQL元素 ，包含 SQL描述以及相关的 SQL参数信息
    /// </summary>
    public class SQLElement
    {
        /// <summary>
        /// 元素包含的 SQL  描述字符串
        /// </summary>
        public String SQL { get; set; }

        /// <summary>
        /// 元素包含的 SQL参数信息
        /// </summary>
        public IList<ParameterElement> ParameterElements { get; set; }
    }
}
