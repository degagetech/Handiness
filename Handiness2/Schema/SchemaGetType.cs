using System;
using System.Collections.Generic;
using System.Text;

namespace Handiness2.Schema
{
    public enum SchemaGetType
    {
        /// <summary>
        /// 从文件获取
        /// </summary>
        File = 1,
        /// <summary>
        /// 从特性获取
        /// </summary>
        Attribute = 2,
        /// <summary>
        /// 框架推导
        /// </summary>
        AutoDeduce = 3
    }
}
