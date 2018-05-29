using System;
using System.Collections.Generic;
#if NETCOREAPP20
using System.Composition;
#endif
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Data.Common;
#if NET40
using System.ComponentModel.Composition;
#endif

namespace Handiness2.Schema.SQLServer
{
#if NET40
    [Export(typeof(ISchemaProvider))]
#endif
    public class SQLServerSchemaProvider : ISchemaProvider
    {
        public String Name { get; } = "SQL Server";

        public String Explain { get; } = "适用于 SQL Server 数据库";

        public String ConnectionString { get; private set; }


        // 辅助字段用于一些条件的判断
        internal const String KeyTypeOfPrimary = "PRI";
        internal const String NullableOfYes = "Y";
        internal const String NullableOfNo = "N";
        //元数据信息-列架构字段名称
        internal const String ColumnOfName = "COLUMN_NAME";
        internal const String ColumnOfTableName = "TABLE_NAME";
        internal const String ColumnOfDbType = "DATA_TYPE";
        internal const String ColumnOfKey = "COLUMN_KEY";
        internal const String ColumnOfLength = "COLUMN_LENGTH";
        internal const String ColumnOfNullable = "IS_NULLABLE";
        internal const String ColumnOfComment = "COLUMN_COMMENT";
        internal const String ColumnOfDefaultType = "DEFAULT_VALUE";

        //元数据信息-表架构字段名称
        internal const String TableOfName = "TABLE_NAME";
        internal const String TableOfDbName = "TABLE_CATALOG";
        internal const String TableOfComment = "TABLE_COMMENT";

        internal static String SQLForTableSachema = $"SELECT a.name as {TableOfName},max(b.[value]) as {TableOfComment} FROM sysobjects a LEFT JOIN sys.extended_properties b ON a.id=b.major_id AND b.minor_id = 0 where a.xtype='U'   GROUP BY a.name";
        internal static String SQLForTableSachemaWithWhere = $"SELECT a.name as {TableOfName},max(b.[value]) as {TableOfComment} FROM sysobjects a LEFT JOIN sys.extended_properties b ON a.id=b.major_id where a.xtype='U' AND b.minor_id=0  AND a.name=" + "'{0}' GROUP BY a.name";
        internal static String SQLForColumnSchemaWithWhere = $@"SELECT
                            {ColumnOfName}=a.name,
                            {ColumnOfDbType}=b.name,
                            {ColumnOfLength}=COLUMNPROPERTY(a.id, a.name,'PRECISION'),
                            {ColumnOfKey}=case   when exists(SELECT   1   FROM sysobjects   where xtype = 'PK'   and name   in (
                                SELECT name   FROM   sysindexes WHERE   indid   IN (
                                SELECT indid   FROM   sysindexkeys WHERE   id   = a.id   AND colid = a.colid
                                )))   THEN   '{KeyTypeOfPrimary}'   ELSE   ''   end,
                            {ColumnOfNullable}=CASE   WHEN a.isnullable=1  THEN   '{NullableOfYes}' ELSE '{NullableOfNo}'   END,
                            {ColumnOfDefaultType}= isnull(e.text, ''),
                            {ColumnOfComment}= isnull(g.[value], '')
                            FROM syscolumns  a
                            LEFT   JOIN systypes b ON a.xusertype= b.xusertype
                            INNER JOIN   sysobjects d ON a.id= d.id and d.xtype= 'U' AND d.name<>'dtproperties'
                            LEFT JOIN   syscomments e   ON a.cdefault= e.id
                            LEFT JOIN   sys.extended_properties g  ON a.id= g.major_id   AND a.colid= g.minor_id
                            LEFT JOIN   sys.extended_properties f  ON d.id= f.major_id  AND f.minor_id= 0 WHERE d.name=" + "'{0}'";



        private SqlConnection _connection = null;


        public void Open(String connectionString)
        {
            this._connection = new SqlConnection(connectionString);
            try
            {
                this._connection.Open();
            }
            catch (Exception exc)
            {
                this._connection = null;
                ProviderConnectException exception = new ProviderConnectException(exc);
                exception.ConnectionString = connectionString;
                exception.ErrorExplain = exc.Message;
                throw exception;
            }
        }

        public void Close()
        {
            if (this._connection != null && _connection.State == ConnectionState.Open)
            {
                this._connection.Close();
            }
            this._connection = null;
        }

        public void Dispose()
        {
            this.Close();
        }

        private DataTable ExecuteQuery(String sql)
        {
            DataTable table = null;
            if (!String.IsNullOrWhiteSpace(sql))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = this._connection;
                command.CommandText = sql;
                DbDataReader dbReader = command.ExecuteReader(CommandBehavior.Default);
                table = new DataTable();
                table.Load(dbReader);
            }
            return table;
        }

        public (TableSchemaExtend table, IList<ColumnSchemaExtend> column) GetTableSchemaTuple(String tableName)
        {
            throw new NotImplementedException();
        }

        public IList<ColumnSchemaExtend> LoadColumnSchemaList(String tableName)
        {
            List<ColumnSchemaExtend> columnSchemas = new List<ColumnSchemaExtend>();
            String SQL = String.Format(SQLForColumnSchemaWithWhere, tableName);
            DataTable info = this.ExecuteQuery(SQL);
            if (info.Rows.Count > 0)
            {
                foreach (DataRow row in info.Rows)
                {
                    ColumnSchemaExtend schema = this.GetColumnSchemaFromRow(row);
                    columnSchemas.Add(schema);
                }
            }
            return columnSchemas;
        }

        public IList<TableSchemaExtend> LoadTableSchemaList()
        {
            List<TableSchemaExtend> tableSchemas = new List<TableSchemaExtend>();
            DataTable info = this.ExecuteQuery(SQLForTableSachema);
            if (info.Rows.Count > 0)
            {
                foreach (DataRow row in info.Rows)
                {
                    TableSchemaExtend schema = this.GetTableSchemaFromRow(row);
                    tableSchemas.Add(schema);
                }
            }
            return tableSchemas;
        }
        protected ColumnSchemaExtend GetColumnSchemaFromRow(DataRow row)
        {
            ColumnSchemaExtend schema = new ColumnSchemaExtend
            {
                Explain = row[ColumnOfComment] as String,
                Name = row[ColumnOfName] as String,
                DbTypeString = row[ColumnOfDbType] as String
            };

            //IsNullable
            String nullableStr = row[ColumnOfNullable].ToString();
            if (nullableStr == NullableOfYes)
            {
                schema.IsNullable = true;
            }

            //IsPrimaryKey
            String priStr = row[ColumnOfKey].ToString();
            if (priStr == KeyTypeOfPrimary)
            {
                schema.IsPrimaryKey = true;
            }

            //Length
            String lengthStr = row[ColumnOfLength].ToString();
            if (Int32.TryParse(lengthStr, out Int32 length))
            {
                schema.Length = length;
            }

            return schema;
        }

        protected TableSchemaExtend GetTableSchemaFromRow(DataRow row)
        {
            TableSchemaExtend schema = new TableSchemaExtend
            {
                Explain = row[TableOfComment] as String,
                Name = row[TableOfName] as String,
            };
            return schema;
        }


        Task<(TableSchemaExtend table, IList<ColumnSchemaExtend> column)> ISchemaProvider.GetTableSchemaTupleAsync(String tableName)
        {
            throw new NotImplementedException();
        }

        Task<IList<TableSchemaExtend>> ISchemaProvider.LoadTableSchemaListAsync()
        {
            throw new NotImplementedException();
        }

        Task<IList<ColumnSchemaExtend>> ISchemaProvider.LoadColumnSchemaListAsync(String tableName)
        {
            throw new NotImplementedException();
        }
    }
}
