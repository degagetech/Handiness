using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace Handiness.Metadata
{
    /*-------------------------------------------------------------------------
 * 版权所有：王浪静
 * 作者：王浪静
 * 联系方式：932444208@qq.com
 * 创建时间： 2017/7/19 15:33:32
 * 版本号：v1.0
 * .NET 版本：4.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/
    internal class MetadataContainer
    {
        private const String ColumnOfDbName = "DbName";
        private const String ColumnOfTableKey = "TableKey";
        private const String ColumnOfColumnKey = "ColumnKey";
        private const String ColumnOfColSchema = "ColumnSchema";
        private const String ColumnOfTableSchema = "TableSchema";
        private const String TableNameOfCol = "ColumnSchema";
        private const String TableNameOfTab = "TableSchema";


        /***********************************/
        private DataSet _dataSet = null;
        public MetadataContainer()
        {
            this._dataSet = new DataSet();

            DataColumn dbNameCol = new DataColumn(MetadataContainer.ColumnOfDbName, typeof(String));
            DataColumn tableKeyCol = new DataColumn(MetadataContainer.ColumnOfTableKey, typeof(String));
            DataColumn dbNameCol2 = new DataColumn(MetadataContainer.ColumnOfDbName, typeof(String));
            DataColumn tableKeyCol2 = new DataColumn(MetadataContainer.ColumnOfTableKey, typeof(String));
            DataColumn columnKeyCol = new DataColumn(MetadataContainer.ColumnOfColumnKey, typeof(String));
            DataColumn columnSchemaCol = new DataColumn(
                MetadataContainer.ColumnOfColSchema,
                typeof(ColumnSchema));

            DataColumn tableSchemaCol = new DataColumn(
                MetadataContainer.ColumnOfTableSchema,
                typeof(TableSchema));


            DataTable columnSchemaTable = new DataTable(MetadataContainer.TableNameOfCol);
      
            columnSchemaTable.Columns.Add(dbNameCol);
            columnSchemaTable.Columns.Add(tableKeyCol);
            columnSchemaTable.Columns.Add(columnKeyCol);
            columnSchemaTable.Columns.Add(columnSchemaCol);
            columnSchemaTable.PrimaryKey = new DataColumn[] { dbNameCol, tableKeyCol, columnKeyCol };
            this._dataSet.Tables.Add(columnSchemaTable);

            DataTable tableSchemaTable = new DataTable(MetadataContainer.TableNameOfTab);
        
            tableSchemaTable.Columns.Add(dbNameCol2);
            tableSchemaTable.Columns.Add(tableKeyCol2);
            tableSchemaTable.Columns.Add(tableSchemaCol);
            tableSchemaTable.PrimaryKey = new DataColumn[] { dbNameCol2, tableKeyCol2 };
            this._dataSet.Tables.Add(tableSchemaTable);
        }
        /*****************************/
        public Boolean AddColumnSchema(String dbName, String tableKey, String columnKey, ColumnSchema schema)
        {
            DataTable table = this._dataSet.Tables[MetadataContainer.TableNameOfCol];
            DataRow row = table.NewRow();
            row[MetadataContainer.ColumnOfDbName] = dbName;
            row[MetadataContainer.ColumnOfTableKey] = tableKey;
            row[MetadataContainer.ColumnOfColumnKey] = columnKey;
            row[MetadataContainer.ColumnOfColSchema] = schema;
            try
            {
                table.Rows.Add(row);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Boolean AddTableSchema(String dbName, String tableKey, TableSchema schema)
        {
            DataTable table = this._dataSet.Tables[MetadataContainer.TableNameOfTab];
            DataRow row = table.NewRow();
            row[MetadataContainer.ColumnOfDbName] = dbName;
            row[MetadataContainer.ColumnOfTableKey] = tableKey;
            row[MetadataContainer.ColumnOfTableSchema] = schema;
            try
            {
                table.Rows.Add(row);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public ColumnSchema GetColumnSchema(String columnKey, String tableKey = null, String dbName = null)
        {
            ColumnSchema schema = null;
            if (!String.IsNullOrWhiteSpace(columnKey))
            {
                DataTable table = this._dataSet.Tables[MetadataContainer.TableNameOfCol];
                String where = $"{ColumnOfColumnKey}='{columnKey}'";
                if (tableKey != null) where += $" And {ColumnOfTableKey}='{tableKey}";
                if (dbName != null) where += $" And {ColumnOfDbName}='{dbName}'";
                DataRow[] rows = table.Select(where);
                if (rows.Length > 0) schema = rows[0][ColumnOfColSchema] as ColumnSchema;
            }
            return schema;
        }
        public TableSchema GetTableSchema(String tableKey, String dbName = null)
        {
            TableSchema schema = null;
            if (!String.IsNullOrWhiteSpace(tableKey))
            {
                DataTable table = this._dataSet.Tables[MetadataContainer.TableNameOfTab];
                String where = $"{ColumnOfTableKey}='{tableKey}'";
                if (dbName != null) where += $" And {ColumnOfDbName}='{dbName}'";
                DataRow[] rows = table.Select(where);
                if (rows.Length > 0) schema = rows[0][ColumnOfTableSchema] as TableSchema;
            }
            return schema;
        }
    }
}
