using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handiness2.Schema
{
    /// <summary>
    /// 映射存储过程的结构信息
    /// </summary>
    [Serializable]
    public class ProcedureSchema : SchemaBase, IObjectSchema
    {
        /// <summary>
        /// 存储过程的说明信息
        /// </summary>
        public String Explain { get; set; }

        /// <summary>
        /// 存储过程的定义信息
        /// </summary>
        public String Definition { get; set; }
    }
}
