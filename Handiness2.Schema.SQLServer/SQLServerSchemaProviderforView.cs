using System;
using System.Collections.Generic;
#if NETCOREAPP20
using System.Composition;
#endif
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Data.Common;


namespace Handiness2.Schema.SQLServer
{

    public partial class SQLServerSchemaProvider : ISchemaProvider
    {

        internal static String SQLForViewSchema = $"SELECT a.name as {TableOfName},max(b.[value]) as {TableOfComment} FROM sysobjects a LEFT JOIN sys.extended_properties b ON a.id=b.major_id AND b.minor_id = 0 where a.xtype='V'   GROUP BY a.name";
        internal static String SQLForViewSchemaWithWhere = $"SELECT a.name as {TableOfName},max(b.[value]) as {TableOfComment} FROM sysobjects a LEFT JOIN sys.extended_properties b ON a.id=b.major_id where a.xtype='V' AND b.minor_id=0  AND a.name=" + "'{0}' GROUP BY a.name";
        internal static String SQLForViewColumnSchemaWithWhere = $@"SELECT
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
                            INNER JOIN   sysobjects d ON a.id= d.id and d.xtype= 'V' AND d.name<>'dtproperties'
                            LEFT JOIN   syscomments e   ON a.cdefault= e.id
                            LEFT JOIN   sys.extended_properties g  ON a.id= g.major_id   AND a.colid= g.minor_id
                            LEFT JOIN   sys.extended_properties f  ON d.id= f.major_id  AND f.minor_id= 0 WHERE d.name=" + "'{0}'";





     
        public IList<TableSchemaExtend> LoadViewSchemaList()
        {
            List<TableSchemaExtend> viewSchemas = new List<TableSchemaExtend>();
            DataTable info = this.ExecuteQuery(SQLForViewSchema);
            if (info.Rows.Count > 0)
            {
                foreach (DataRow row in info.Rows)
                {
                    TableSchemaExtend schema = this.GetTableSchemaFromRow(row);
                    viewSchemas.Add(schema);
                }
            }
            return viewSchemas;
        }

        public IList<ColumnSchemaExtend> LoadViewColumnSchemaList(String viewName)
        {
            List<ColumnSchemaExtend> columnSchemas = new List<ColumnSchemaExtend>();
            String SQL = String.Format(SQLForViewColumnSchemaWithWhere, viewName);
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

        public (Boolean success, TableSchemaExtend view, IList<ColumnSchemaExtend> columns) GetViewSchemaTuple(String viewName)
        {
            Boolean success = false;
            TableSchemaExtend viewSchema = null;
            IList<ColumnSchemaExtend> columnSchemas = null;
            if (String.IsNullOrEmpty(viewName))
            {
                throw new ArgumentException(nameof(viewName));
            }
            String tableSchemaSQL = String.Format(SQLForViewColumnSchemaWithWhere, viewName);
            DataTable info = this.ExecuteQuery(tableSchemaSQL);
            if (info.Rows.Count > 0)
            {
                var row = info.Rows[0];
                viewSchema = this.GetTableSchemaFromRow(row);
                columnSchemas = this.LoadViewColumnSchemaList(viewName);
                success = true;
            }
            return (success, viewSchema, columnSchemas);
        }
    }
}
