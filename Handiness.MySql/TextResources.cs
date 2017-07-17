using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handiness.MySql
{
    /// <summary>
    /// 提供一系列的说明型文本资源
    /// </summary>
    internal static class TextResources
    {
        /// <summary>
        /// 此数据库适配层的标识符
        /// </summary>
        public const String Guid = "41668F3A-DE95-4E1D-8213-0BCAAAA912C6";
        public const String Version = "1.0.0.0";
        /// <summary>
        /// 此适配层中元数据提供者的描述信息
        /// </summary>
        public const String MetadataProviderExplain = "用于Mysql，Mariadb等数据库的元数据获取";
        /// <summary>
        /// 此适配层名称
        /// </summary>
        public const String AdaptiveName = "Mysql";
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
