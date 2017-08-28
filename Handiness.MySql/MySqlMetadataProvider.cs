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

    [Export(MysqlAdaptiveExplain.ALGuid, typeof(IMetadataProvider))]
    public class MySqlMetadataProvider : MetadataProvider
    {
        /// <summary>
        /// 此<see cref="MetadataProvider"/> 的描述信息
        /// </summary>
        internal const String ProviderExplain = "Mysql,MariaDb";

        // 架构名称用于查询指定架构
        internal const String CollectionNameOfColumn = "Columns";
        internal const String CollectionNameOfTable = "Tables";


        // 辅助字段用于一些条件的判断
        internal const String KeyTypeOfPrimary = "PRI";
        internal const String NullableOfYes = "YES";

        //元数据信息-列架构字段名称
        internal const String ColumnOfName = "COLUMN_NAME";
        internal const String ColumnOfTableName = "TABLE_NAME";
        internal const String ColumnOfDbType = "DATA_TYPE";
        internal const String ColumnOfKey = "COLUMN_KEY";
        internal const String ColumnOfColType = "COLUMN_TYPE";
        internal const String ColumnOfNullable = "IS_NULLABLE";
        internal const String ColumnOfComment = "COLUMN_COMMENT";
      

       //元数据信息-表架构字段名称
        internal const String TableOfName = "Table_NAME";
        internal const String TableOfDbName = "TABLE_SCHEMA";
        internal const String TableOfComment = "TABLE_COMMENT";
       


        /**************************************************************/
        public override String Version => MysqlAdaptiveExplain.ALVersion;
        public override String Explain => ProviderExplain;


        private String _databaseName = String.Empty;
        private MySqlConnectionStringBuilder _stringBuilder = new MySqlConnectionStringBuilder();

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
            DataTable originalMetadata = this.Connection.GetSchema(CollectionNameOfColumn, restrictions);
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
                 name: row[ColumnOfName] as String,
                 tableName: row[ColumnOfTableName] as String,
                 type: row[ColumnOfDbType] as String,
                 isPrimekey: this.IsPrimaryKey(row),
                 isNullable: this.IsNullable(row),
                 explain: this.GetExplain(row),
                 length: this.GetLength(row)
            );
            return schema;
        }

        public override IEnumerable<TableSchema> GetTableSchemas()
        {
            DataTable dt = this.Connection.GetSchema(CollectionNameOfTable, null);
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
            String primaryKeyInfo = row[ColumnOfKey] as String;
            if (!String.IsNullOrWhiteSpace(primaryKeyInfo) &&
                KeyTypeOfPrimary == primaryKeyInfo)
            {
                isPrimaryKey = true;
            }
            return isPrimaryKey;
        }

        protected override Int32 GetLength(DataRow row)
        {
            Int32 length = 0;
            String columnType = row[ColumnOfColType] as String;
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
            String nullableStr = row[ColumnOfNullable] as String;
            if (!String.IsNullOrWhiteSpace(nullableStr) && nullableStr == NullableOfYes)
            {
                isNullable = true;
            }
            return isNullable;
        }

        protected override String GetExplain(DataRow row)
        {
            String explain = row[ColumnOfComment] as String;
            return explain;
        }

        protected override String GetDatabaseName()
        {
            String datebaseName = null;
            datebaseName = this.Connection.Database;
            return datebaseName;
        }

        protected override TableSchema TableMetadataToSechma(DataRow row)
        {
            TableSchema schema = new TableSchema(
                row[TableOfName] as String,
                row[TableOfDbName] as String,
                this.GetTableExplain(row)
                );
            return schema;
        }

        protected override string GetTableExplain(DataRow row)
        {
            return row[TableOfComment] as String;
        }



        /********************/

    }
}
