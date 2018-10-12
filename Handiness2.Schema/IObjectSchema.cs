using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handiness2.Schema
{
    /// <summary>
    /// 映射数据库对象的结构信息
    /// </summary>
    public interface IObjectSchema
    {
        /// <summary>
        /// 对象的名称
        /// </summary>
        String Name { get; set; }
        /// <summary>
        /// 对象的说明
        /// </summary>
        String Explain { get; set; }
    }
}
