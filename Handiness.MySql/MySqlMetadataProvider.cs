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

    [Export(TextResources.Guid,typeof(IMetadataProvider))]
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
        public override IEnumerable<ColumnSchema> GetColumnSchemas(String tableName)
        {
            //元数据查询条件限制的集合
            String[] restrictions = new String[] { null, null, null, null };
            List<ColumnSchema> result = new List<ColumnSchema>();
            if (!String.IsNullOrWhiteSpace(tableName)) restrictions[2] = tableName;
            DataTable originalMetadata = this.Connection.GetSchema(TextResources.CollectionNameOfColumn, restrictions);
            foreach (DataRow row in originalMetadata.Rows)
            {
                ColumnSchema schema = this.ColumnMetadataToSechma(row);
                if (schema != null) result.Add(schema);
            }
            return result;
        }

        /********************/

        protected override ColumnSchema ColumnMetadataToSechma(DataRow row)
        {
            ColumnSchema schema = new ColumnSchema
            (
                 name: row[TextResources.ColumnOfName] as String,
                 tableName: row[TextResources.ColumnOfTableName] as String,
                 type: row[TextResources.ColumnOfDbType] as String,
                 isPrimekey: this.IsPrimaryKey(row),
                 isNullable: this.IsNullable(row),
                 explain: this.GetExplain(row),
                 length: this.GetLength(row)
            );
            return schema;
        }

        public override IEnumerable<TableSchema> GetTableSchemas()
        {
            DataTable dt = this.Connection.GetSchema(TextResources.CollectionNameOfTable, null);
            foreach (DataRow row in dt.Rows)
            {
                TableSchema schema = this.TableMetadataToSechma(row);
                if (schema != null)
                {
                    yield return schema;
                }
            }
        }



        protected override Boolean IsPrimaryKey(DataRow row)
        {
            Boolean isPrimaryKey = false;
            String primaryKeyInfo = row[TextResources.ColumnOfKey] as String;
            if (!String.IsNullOrWhiteSpace(primaryKeyInfo) &&
                TextResources.KeyTypeOfPrimary == primaryKeyInfo)
            {
                isPrimaryKey = true;
            }
            return isPrimaryKey;
        }

        protected override Int32 GetLength(DataRow row)
        {
            Int32 length = 0;
            String columnType = row[TextResources.ColumnOfColType] as String;
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
            String nullableStr = row[TextResources.ColumnOfNullable] as String;
            if (!String.IsNullOrWhiteSpace(nullableStr) && nullableStr == TextResources.NullableOfYes)
            {
                isNullable = true;
            }
            return isNullable;
        }

        protected override String GetExplain(DataRow row)
        {
            String explain = row[TextResources.ColumnOfComment] as String;
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

        protected override TableSchema TableMetadataToSechma(DataRow row)
        {
            TableSchema schema = new TableSchema(
                row[TextResources.TableOfName] as String,
                row[TextResources.TableOfDbName] as String,
                this.GetTableExplain(row)
                );
            return schema;
        }

        protected override string GetTableExplain(DataRow row)
        {
            return row[TextResources.TableOfComment] as String;
        }



        /********************/

    }
}
