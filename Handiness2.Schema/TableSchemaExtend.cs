using System;
using System.Collections.Generic;
using System.Text;

namespace Handiness2.Schema
{
    /// <summary>
    /// 对 <see cref="TableSchema"/> 包含信息的扩展，此类通常为例如模型类的生成、数据库结构的导出等操作提供基本信息
    /// </summary>
    [Serializable]
    public class TableSchemaExtend : TableSchema, IObjectSchema
    {
        /// <summary>
        /// 表的说明
        /// </summary>
        public String Explain { get; set; }
    }
}
