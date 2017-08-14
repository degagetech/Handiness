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
        public const String Guid = "442157DA-5F41-40F9-9979-F75648B65024";
        public const String Version = "1.0.0.0";
        /// <summary>
        /// 此适配层中元数据提供者的描述信息
        /// </summary>
        public const String MetadataProviderExplain = "Oracle";
        /// <summary>
        /// 此适配层名称
        /// </summary>
        public const String AdaptiveName = "Oracle";
        /// <summary>
        /// 列架构名称
        /// </summary>
        public const String CollectionNameOfColumn = "Columns";
        /// <summary>
        /// 表架构名称
        /// </summary>
        public const String CollectionNameOfTable = "Tables";

        public const String KeyTypeOfPrimary = "PRI";

        public const String NullableOfYes = "Y";

        #region  列元数据信息字段名称
        public const String ColumnOfName = "COLUMN_NAME";
        public const String ColumnOfTableName = "TABLE_NAME";
        public const String ColumnOfDbType = "DATATYPE";
        public const String ColumnOfKey = "COLUMN_KEY";
        public const String ColumnOfColType = "COLUMN_TYPE";
        public const String ColumnOfNullable = "NULLABLE";
        public const String ColumnOfComment = "COLUMN_COMMENT";
        public const String ColumnOfLength = "LENGTH";
        #endregion

        #region  表元数据信息字段名称
        public const String TableOfName = "Table_NAME";
        public const String TableOfDbName = "TABLE_SCHEMA";
        public const String TableOfComment = "TABLE_COMMENT";
        #endregion
    }
}
