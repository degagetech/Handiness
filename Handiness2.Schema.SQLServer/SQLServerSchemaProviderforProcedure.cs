using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Handiness2.Schema.SQLServer
{
    public partial class SQLServerSchemaProvider : ISchemaProvider
    {
        //元数据信息-存储过程结构字段
        const String ProcedureOfName = "name";
        const String ProcedureOfDefinition = "definition";


        static String SQLForProcedure = @"
                          SELECT
                                  name,
	                              definition
                          FROM
                                  sys.sql_modules m
                          INNER JOIN sys.objects o ON m.object_id = o.object_id
                          WHERE
                                  type = 'P'";
        public IList<ProcedureSchema> LoadProcedureSchemaList()
        {
            List<ProcedureSchema> procedureSchemas = new List<ProcedureSchema>();
            DataTable info = this.ExecuteQuery(SQLForProcedure);
            if (info.Rows.Count > 0)
            {
                foreach (DataRow row in info.Rows)
                {
                    ProcedureSchema schema = this.GetProcedureSchemaFromRow(row);
                    procedureSchemas.Add(schema);
                }
            }
            return procedureSchemas;
        }

        protected ProcedureSchema GetProcedureSchemaFromRow(DataRow row)
        {
            ProcedureSchema schema = new ProcedureSchema
            {
                Name = row[ProcedureOfName].ToString(),
                Definition = row[ProcedureOfDefinition].ToString()
            };
            return schema;
        }


    }
}
