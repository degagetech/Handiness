using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Handiness.Metadata;
using System.Data.Common;
using System.ComponentModel.Composition;
using System.Data;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data.Sql;
namespace Handiness.SQLServer
{

    [Export(SQLServerAdaptiveExplain.ALGuid, typeof(IMetadataProvider))]
    public class SQLServerMetadataProvider : MetadataProvider
    {
        /// <summary>
        /// 此<see cref="MetadataProvider"/> 的描述信息
        /// </summary>
        internal const String ProviderExplain = "SQL Server";

        // 架构名称用于查询指定架构
        internal const String CollectionNameOfColumn = "Columns";
        internal const String CollectionNameOfTable = "Tables";
        internal const String CollectionNameOfIndexColumn = "IndexColumns";

        // 辅助字段用于一些条件的判断
        internal const String KeyTypeOfPrimary = "PRI";
        internal const String NullableOfYes = "Y";

        //元数据信息-列架构字段名称
        internal const String ColumnOfName = "COLUMN_NAME";
        internal const String ColumnOfTableName = "TABLE_NAME";
        internal const String ColumnOfDbType = "DATA_TYPE";
        internal const String ColumnOfKey = "COLUMN_KEY";
        internal const String ColumnOfLength = "COLUMN_LENGTH";
        internal const String ColumnOfNullable = "IS_NULLABLE";
        internal const String ColumnOfComment = "COLUMN_COMMENT";


        //元数据信息-表架构字段名称
        internal const String TableOfName = "TABLE_NAME";
        internal const String TableOfDbName = "TABLE_CATALOG";
        internal const String TableOfComment = "TABLE_COMMENT";



        /**************************************************************/
        public override String Version => SQLServerAdaptiveExplain.ALVersion;
        public override String Explain => ProviderExplain;


        private String _databaseName = String.Empty;
        private SqlConnectionStringBuilder _stringBuilder = new SqlConnectionStringBuilder();
        private DataTable _schemaTable = null;


        /********************/
        public SQLServerMetadataProvider() : base()
        {
            this.Connection = new SqlConnection();
        }
        public override void Open(string connectionString)
        {
            base.Open(connectionString);
            _stringBuilder.ConnectionString = this.Connection.ConnectionString;
            this._databaseName = _stringBuilder.InitialCatalog;
            this.LoadSchemaInfo();
        }

        public void LoadSchemaInfo()
        {
            String sql = @"SELECT
                        TABLE_NAME= d.name,
                        TABLE_COMMENT=case  when   a.colorder=1   then   f.value   else   ''   end,
                        COLUMN_NAME=a.name,
                        DATA_TYPE=b.name,
                        COLUMN_LENGTH=COLUMNPROPERTY(a.id,a.name,'PRECISION'),
                        COLUMN_KEY=case   when   exists(SELECT   1   FROM   sysobjects   where   xtype='PK'   and   name   in   (
                            SELECT   name   FROM   sysindexes   WHERE   indid   in(
                            SELECT   indid   FROM   sysindexkeys   WHERE   id   =   a.id   AND   colid=a.colid
                            )))   then   'PRI'   else   ''   end,
                        IS_NULLABLE=case   when   a.isnullable=1   then   'Y' else 'N'   end,
                        DEFAULT_VALUE=isnull(e.text,''),
                        COLUMN_COMMENT=isnull(g.[value],'')
                        FROM   syscolumns  a
                        left   join   systypes b on a.xusertype=b.xusertype
                        inner  join   sysobjects   d on a.id=d.id and d.xtype='U' and  d.name<>'dtproperties'
                        left   join   syscomments   e   on   a.cdefault=e.id
                        left   join   sys.extended_properties   g  on  a.id=g.major_id   and   a.colid=g.minor_id
                        left   join   sys.extended_properties   f  on  d.id=f.major_id   and   f.minor_id=0";
            sql = sql.Replace("\r\n","");
            this._schemaTable = this.SQLQuery(sql);
        }
        /********************/
        public override IEnumerable<ColumnSchema> GetColumnSchemas(String tableName)
        {
            //元数据查询条件限制的集合
            //String[] restrictions = new String[] { null, null, null, null };
            List<ColumnSchema> result = new List<ColumnSchema>();
            //if (!String.IsNullOrWhiteSpace(tableName)) restrictions[2] = tableName;
            //if (!String.IsNullOrWhiteSpace(this._databaseName)) restrictions[0] = this._databaseName;
            //DataTable originalMetadata = this.Connection.GetSchema(CollectionNameOfColumn, restrictions);
            //  var rows = originalMetadata.Rows;
            var rows = this._schemaTable.Select($"{TableOfName}='{tableName}'");
            foreach (DataRow row in rows)
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
            String[] restrictions = new String[] { null, null, null, null };
            if (!String.IsNullOrWhiteSpace(this._databaseName)) restrictions[0] = this._databaseName;
            DataTable dt = this.Connection.GetSchema(CollectionNameOfTable, restrictions);
            foreach (DataRow row in dt.Rows)
            {
                TableSchema schema = this.TableMetadataToSechma(row);
                if (schema != null)
                {
                    yield return schema;
                }
            }
        }
        protected DataTable SQLQuery(String sql)
        {
            DataTable table = null;
            if (!String.IsNullOrWhiteSpace(sql))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = (SqlConnection)this.Connection;
                command.CommandText = sql;
                DbDataReader dbReader = command.ExecuteReader(CommandBehavior.Default);
                table = new DataTable();
                table.Load(dbReader);
            }
            return table;
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

        protected override String GetLength(DataRow row)
        {
            String length = String.Empty;
            length = row[ColumnOfLength].ToString();

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

            String explain = null;
            explain = row[ColumnOfComment] as String;
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

        protected override String GetTableExplain(DataRow row)
        {
            String tableName = row[TableOfName] as String;
            String explain = String.Empty;
            String queryStr = $"{TableOfName}='{tableName}' AND {TableOfComment}<>'' ";
            var rows = this._schemaTable.Select(queryStr);
            if (rows.Length > 0)
            {
                explain = rows[0][TableOfComment] as String;
            }
            return explain;
        }



        /********************/

    }
}
