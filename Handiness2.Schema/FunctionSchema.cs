using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handiness2.Schema
{
    /// <summary>
    /// 映射函数结构的信息
    /// </summary>
    public class FunctionSchema : SchemaBase, IObjectSchema
    {
        /// <summary>
        /// 函数的说明信息
        /// </summary>
        public String Explain { get; set; }
    }
}
