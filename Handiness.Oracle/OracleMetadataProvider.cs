using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Handiness.Metadata;
using System.Data.Common;
using Oracle.ManagedDataAccess.Client;
using System.ComponentModel.Composition;
using System.Data;
using System.Text.RegularExpressions;
using System.Threading;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace Handiness.Oracle
{

    [Export(OracleAdaptiveExplain.ALGuid, typeof(IMetadataProvider))]
    public class OracleMetadataProvider : MetadataProvider
    {
        /// <summary>
        /// 此<see cref="MetadataProvider"/> 的描述信息
        /// </summary>
        internal const String ProviderExplain = "Oracle";

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
        internal const String ColumnOfDbType = "DATATYPE";
        internal const String ColumnOfKey = "COLUMN_KEY";
        internal const String ColumnOfColType = "COLUMN_TYPE";
        internal const String ColumnOfNullable = "NULLABLE";
        internal const String ColumnOfComment = "COLUMN_COMMENT";
        internal const String ColumnOfLength = "LENGTH";


        //元数据信息-表架构字段名称
        internal const String TableOfName = "TABLE_NAME";
        internal const String TableOfDbName = "TABLE_SCHEMA";
        internal const String TableOfComment = "TABLE_COMMENT";
    
/************************************************/
        public override String Version => OracleAdaptiveExplain.ALVersion;
        public override String Explain => ProviderExplain;

        protected virtual String CurrentUserId
        {
            get
            {
                return this._connStrBuilder.UserID.ToUpper();
            }
        }

        private OracleConnectionStringBuilder _connStrBuilder = new OracleConnectionStringBuilder();
 

        private String _databaseName = String.Empty;
      
        /********************/
        private Dictionary<String, String> _tableExplains = new Dictionary<String, String>();
        private Dictionary<String, String> _columnExplains = new Dictionary<String, String>();

        /********************/
        public OracleMetadataProvider() : base()
        {
            var connection = new OracleConnection();
            this.Connection = connection;
        }

        /********************/
        public override void Open(string connectionString)
        {
            base.Open(connectionString);
            this._connStrBuilder.Clear();
            this._connStrBuilder.ConnectionString = connectionString;
            this.LoadColumnExplain();
            this.LoadTableExplain();
        }
        public override IEnumerable<ColumnSchema> GetColumnSchemas(String tableName)
        {
            //元数据查询条件限制的集合
            String[] restrictions = new String[] { null, null, null};
            List<ColumnSchema> result = null;
            if (!String.IsNullOrWhiteSpace(tableName))
            {
                result = new List<ColumnSchema>();
                restrictions[0] = this.CurrentUserId;
                restrictions[1] = tableName;
                DataTable originalMetadata = this.Connection.GetSchema(CollectionNameOfColumn, restrictions);
                foreach (DataRow row in originalMetadata.Rows)
                {
                    ColumnSchema schema = this.ColumnMetadataToSechma(row);
                    if (schema != null) result.Add(schema);
                }
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
            //TODO: ORACLE DbProvider表架构名称限制
            DataTable dt = this.Connection.GetSchema(CollectionNameOfTable, new String[] {  this.CurrentUserId, null});
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
            String tableName = row[ColumnOfTableName] as String;
            String columnName = row[ColumnOfName] as String;
            String[] restrictions = new String[] {this.CurrentUserId,null,null, tableName, columnName };
            Boolean isPrimaryKey = false;
            DataTable dt = this.Connection.GetSchema(CollectionNameOfIndexColumn, restrictions);
            if (dt.Rows.Count > 0)
            {
                isPrimaryKey = true;
            }
            return isPrimaryKey;
        }

        protected override String GetLength(DataRow row)
        {
            Decimal colLength = (Decimal)row[ColumnOfLength];
            return colLength.ToString();
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
            String tableName = row[TableOfName] as String;
            String columnName = row[ColumnOfName] as String;
            String key = this.GenerationKey(tableName, columnName);
            if (this._columnExplains.ContainsKey(key))
            {
                explain = this._columnExplains[key];
            }
            return explain;
        }

        protected override String GetDatabaseName()
        {
            String datebaseName = ((OracleConnection)this.Connection).InstanceName;
            return datebaseName;
        }

        protected override TableSchema TableMetadataToSechma(DataRow row)
        {
            TableSchema schema = new TableSchema(
                row[TableOfName] as String,
                this.GetDatabaseName(),
                this.GetTableExplain(row)
                );
            return schema;
        }

        protected override String GetTableExplain(DataRow row)
        {
            String tableName = row[TableOfName] as String;
            String key = this.GenerationKey(tableName);
            String explain = null;
            if (this._tableExplains.ContainsKey(key))
            {
                explain = this._tableExplains[key];
            }
            return explain;
        }
        protected DataTable SQLQuery(String sql)
        {
            DataTable table = null;
            if (!String.IsNullOrWhiteSpace(sql))
            {
                OracleCommand command = new OracleCommand();
                command.Connection = (OracleConnection)this.Connection;
                command.CommandText = sql;
                DbDataReader dbReader = command.ExecuteReader(CommandBehavior.Default);
                table = new DataTable();
                table.Load(dbReader);
            }
            return table;
        }

        /// <summary>
        /// 加载表注释
        /// </summary>
        [MethodImpl(MethodImplOptions.Synchronized)]
        protected void LoadTableExplain()
        {
            this._tableExplains.Clear();
            String sql = @" SELECT * FROM user_tab_comments ";
            DataTable table = this.SQLQuery(sql);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    String tableName = row[0] as String;
                    String explain = row[2] as String;
                    if (explain != null)
                    {
                        String key = this.GenerationKey(tableName);
                        if (key != null && !this._tableExplains.ContainsKey(key))
                            this._tableExplains.Add(key, explain);
                    }
                }
            }
        }
        /// <summary>
        /// 加载列注释
        /// </summary>
        [MethodImpl(MethodImplOptions.Synchronized)]
        protected void LoadColumnExplain()
        {
            this._columnExplains.Clear();
           String sql = @" SELECT * FROM user_col_comments ";
            DataTable table = this.SQLQuery(sql);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    String tableName = row[0] as String;
                    String columnName = row[1] as String;
                    String explain = row[2] as String;
                    if (explain != null)
                    {
                        String key = this.GenerationKey(tableName, columnName);
                        if (key != null && !this._columnExplains.ContainsKey(key))
                            this._columnExplains.Add(key, explain);
                    }
                }
            }
        }
        private String GenerationKey(params String[] strs)
        {
            String key = String.Empty;
            foreach (String str in strs)
            {
                if (str != null)
                {
                    key += str.Trim().ToLower();
                }
                else
                {
                    key = null;
                    break;
                }
            }
            return key;
        }

        /********************/

    }
}
