using System;
using System.Collections.Generic;
using System.Text;

namespace Handiness2.Schema
{
    /// <summary>
    /// 对 <see cref="ColumnSchema"/> 包含信息的扩展，此类通常为例如模型类的生成、数据库结构的导出等操作提供基本信息
    /// </summary>
    [Serializable]
    public class ColumnSchemaExtend : ColumnSchema,IObjectSchema
    {
        /// <summary>
        /// 列的说明
        /// </summary>
        public String Explain { get; set; }
        /// <summary>
        /// 列的数据类型的字符串描述：例如 varchar、bit 等
        /// </summary>
        public String DbTypeString { get; set; }
    }
}
