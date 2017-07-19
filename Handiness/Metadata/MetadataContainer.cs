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


        public MetadataContainer()
        {
            DataSet dataSet = new DataSet();
            
            DataColumn dbNameCol = new DataColumn("DbName", typeof(String));
            DataColumn tableKeyCol = new DataColumn("TableKey", typeof(String));
            DataColumn columnKeyCol = new DataColumn("ColumnKey", typeof(String));
            DataColumn columnSchmeCol = new DataColumn("ColumnSchema", typeof(ColumnSchema));

            DataTable columnSchemaTable = new DataTable("ColumnSchme");
            columnSchemaTable.Columns.Add(dbNameCol);
            columnSchemaTable.Columns.Add(tableKeyCol);
            columnSchemaTable.Columns.Add(columnKeyCol);
            columnSchemaTable.Columns.Add(columnSchmeCol);
            dataSet.Tables.Add(columnSchemaTable);

            DataTable tableSchemaTable = new DataTable("TableSchema");

            tableSchemaTable.Columns.Add(dbNameCol);
            tableSchemaTable.Columns.Add(tableKeyCol);
        }
        /*****************************/
        public void AddColumnSchema(String dbName, String tableKey, String columnKey, ColumnSchema schema)
        {

        }
    }
}
