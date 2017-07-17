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
    [Export(TextResources.Guid, typeof(IMetadataProvider))]
    public class MySqlMetadataProvider : MetadataProvider
    {
        public override String Version => TextResources.Version;
        public override String Explain => TextResources.MetadataProviderExplain;


        private String _databaseName = String.Empty;
        /********************/
        /// <summary>
        /// 用于提取列长度信息字符串的正则表达式
        /// </summary>
        private Regex _regexExtractLength = new Regex(@"(?<=\()\d+(?<!\))");

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
            DataTable originalMetadata = this.Connection.GetSchema(TextResources.CollectionNameForColumn, restrictions);
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
                 name: row[TextResources.ColumnInfoForName] as String,
                 tableName: row[TextResources.ColumnInfoForTableName] as String,
                 type: row[TextResources.ColumnInfoForDbType] as String,
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
            String primaryKeyInfo = row[TextResources.ColumnInfoForKey] as String;
            if (!String.IsNullOrWhiteSpace(primaryKeyInfo) &&
                TextResources.KeyTypeForPrimary == primaryKeyInfo)
            {
                isPrimaryKey = true;
            }
            return isPrimaryKey;
        }

        protected override Int32 GetLength(DataRow row)
        {
            Int32 length = 0;
            String columnType = row[TextResources.ColumnInfoForColType] as String;
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
            String nullableStr = row[TextResources.ColumnInfoForNullable] as String;
            if (!String.IsNullOrWhiteSpace(nullableStr) && nullableStr == TextResources.NullableForYes)
            {
                isNullable = true;
            }
            return isNullable;
        }

        protected override String GetExplain(DataRow row)
        {
            String explain = row[TextResources.ColumnInfoForCommit] as String;
            return explain;
        }

        protected override String GetDatabaseName()
        {
            String datebaseName = null;
            if (this.Connection.ConnectionString != null)
            {
                MySqlConnectionStringBuilder stringBuilder = new MySqlConnectionStringBuilder(this.Connection.ConnectionString);
                datebaseName = stringBuilder.Database;
            }
            return datebaseName;
        }



        /********************/

    }
}
