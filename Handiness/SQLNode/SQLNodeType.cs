using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handiness
{
    /// <summary>
    /// <see cref="SQLNode"/> 结点的类型
    /// </summary>
    public enum SQLNodeType
    {
        /// <summary>
        /// 主节点
        /// </summary>
        Primary=3,
        /// <summary>
        /// 条件节点
        /// </summary>
        Where=2,
        /// <summary>
        /// 辅节点
        /// </summary>
        Assist=1
    }
}
