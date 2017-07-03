using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Handiness.Metadata;
using System.Data.Common;
using MySql.Data.MySqlClient;
using System.ComponentModel.Composition;
using System.Data;

namespace Handiness.MySql
{
    [Export(TextResource.Guid, typeof(IMetadataProvider))]
    public class MySqlMetadataProvider : MetadataProvider
    {
        public override String Version => "MySql1.0";
        public override String Explain => "用于获取MySql或者其分支数据库的元数据信息提供类";
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

            return columnSchemas;
        }



        /********************/
        public override IList<TableSchema> GetTableSchemas()
        {
            throw new NotImplementedException();
        }

        /********************/

    }
}
