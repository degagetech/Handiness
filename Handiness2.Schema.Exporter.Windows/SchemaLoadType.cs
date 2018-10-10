using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handiness2.Schema.Exporter.Windows
{
    /// <summary>
    /// Schema 信息加载类型
    /// </summary>
    public enum SchemaLoadType
    {
        /// <summary>
        /// 通过数据连接
        /// </summary>
        Connection = 0,
        /// <summary>
        /// 通过包含结构信息的文件
        /// </summary>
        SchemaFile
    }
}
