using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Handiness.Metadata;
using System.Data.Common;
using MySql.Data.MySqlClient;
using System.ComponentModel.Composition;
using System.Data;
using System.Text.RegularExpressions;

namespace Handiness.MySql
{
    [Export(TextResource.Guid, typeof(IMetadataProvider))]
    public class MySqlMetadataProvider : MetadataProvider
    {
        public override String Version => "MySql1.0";
        public override String Explain => "用于获取MySql或者其分支数据库的元数据信息提供类";
        /********************/
        /// <summary>
        /// 用于提取列长度信息字符串的正则表达式
        /// </summary>
        private Regex _regexExtractLength= new Regex(@"(?<=\()\d+(?<!\))");

        /********************/
        public MySqlMetadataProvider() : base()
        {
            this.Connection = new MySqlConnection();
        }

        /********************/
        public override IList<ColumnSchema> GetColumnSchemas(String tableName)
        {
            IList<ColumnSchema> columnSchemas = new List<ColumnSchema>();
            //元数据查询条件限制的集合
            String[] restrictions = new String[] { null, null, null, null };

            if (!String.IsNullOrWhiteSpace(tableName)) restrictions[2] = tableName;
            DataTable originalMetadata = this.Connection.GetSchema(TextResource.CollectionNameForColumn, restrictions);
            foreach (DataRow row in originalMetadata.Rows)
            {
                ColumnSchema schema = this.MetadataToColumnSechma(row);
                if (schema != null) columnSchemas.Add(schema);
            }
            return columnSchemas;
        }

        /********************/

        protected override ColumnSchema MetadataToColumnSechma(DataRow row)
        {
            ColumnSchema schema = new ColumnSchema
            (
                 name: row[TextResource.ColumnInfoForName] as String,
                 tableName: row[TextResource.ColumnInfoForTableName] as String,
                 type: row[TextResource.ColumnInfoForDbType] as String,
                 isPrimekey: this.IsPrimaryKey(row),
                 isNullable: this.IsNullable(row),
                 explain: this.GetExplain(row),
                 length: this.GetLength(row)
            );
            return schema;
        }

        public override IList<TableSchema> GetTableSchemas()
        {
            throw new NotImplementedException();
        }



        protected override Boolean IsPrimaryKey(DataRow row)
        {
            Boolean isPrimaryKey = false;
            String primaryKeyInfo = row[TextResource.ColumnInfoForKey] as String;
            if (!String.IsNullOrWhiteSpace(primaryKeyInfo) &&
                TextResource.KeyTypeForPrimary==primaryKeyInfo)
            {
                isPrimaryKey = true;
            }
            return isPrimaryKey;
        }

        protected override Int32 GetLength(DataRow row)
        {
            Int32 length = 0;
            String columnType = row[TextResource.ColumnInfoForColType] as String;
            if (!String.IsNullOrWhiteSpace(columnType))
            {
                Match macth = this._regexExtractLength.Match(columnType);
                if (macth.Success)
                {
                    String lengthStr = macth.Value;
                    Int32.TryParse(lengthStr, out length);
                }
            }
            return length;
        }

        protected override Boolean IsNullable(DataRow row)
        {
            Boolean isNullable = false;
            String nullableStr = row[TextResource.ColumnInfoForNullable] as String;
            if (!String.IsNullOrWhiteSpace(nullableStr) && nullableStr == TextResource.NullableForYes)
            {
                isNullable=true;
            }
            return isNullable;
        }

        protected override String GetExplain(DataRow row)
        {
            String explain = row[TextResource.ColumnInfoForCommit] as String;
            return explain;
        }



        /********************/

    }
}
