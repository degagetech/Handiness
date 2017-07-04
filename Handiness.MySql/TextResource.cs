using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handiness.MySql
{
    /// <summary>
    /// 一系列文本资源
    /// </summary>
    public static class TextResource
    {
        /// <summary>
        /// 此数据库适配层的标识符
        /// </summary>
        public const String Guid = "#M1";
        /// <summary>
        /// 列架构名称
        /// </summary>
        public const String CollectionNameForColumn = "Columns";
        public const String KeyTypeForPrimary = "PRI";
        public const String NullableForYes = "YES";
        #region  列元数据信息字段名称
        public const String ColumnInfoForName = "COLUMN_NAME";
        public const String ColumnInfoForTableName = "TABLE_NAME";
        public const String ColumnInfoForDbType = "DATA_TYPE";
        public const String ColumnInfoForKey = "COLUMN_KEY";
        public const String ColumnInfoForColType = "COLUMN_TYPE";
        public const String ColumnInfoForNullable = "IS_NULLABLE";
        public const String ColumnInfoForCommit = "COLUMN_COMMENT";
        #endregion
    }
}
