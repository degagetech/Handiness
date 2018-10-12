using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Handiness2.Schema.SQLServer
{
    public partial class SQLServerSchemaProvider : ISchemaProvider
    {
        //元数据信息-函数结构字段
        const String FunctionOfName = "name";
        const String FunctionOfDefinition = "definition";


        static String SQLForFunction = @"
                          SELECT
                                  name,
	                              definition
                          FROM
                                  sys.sql_modules m
                          INNER JOIN sys.objects o ON m.object_id = o.object_id
                          WHERE
                                  type = 'FN'";
        public IList<FunctionSchema> LoadFunctionSchemaList()
        {
            List<FunctionSchema> functionSchemas = new List<FunctionSchema>();
            DataTable info = this.ExecuteQuery(SQLForFunction);
            if (info.Rows.Count > 0)
            {
                foreach (DataRow row in info.Rows)
                {
                    FunctionSchema schema = this.GetFunctionSchemaFromRow(row);
                    functionSchemas.Add(schema);
                }
            }
            return functionSchemas;
        }

        protected FunctionSchema GetFunctionSchemaFromRow(DataRow row)
        {
            FunctionSchema schema = new FunctionSchema
            {
                Name = row[FunctionOfName].ToString(),
                Definition = row[FunctionOfDefinition].ToString()
            };
            return schema;
        }
    }
}
