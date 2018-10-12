using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handiness2.Schema.Exporter.Windows
{
    public static class SchemaAssistor
    {
        public static void SaveSchemaInfos(String path, List<SchemaInfoTuple> schemaInfos)
        {
            BinarySerializer.SerializeToFile(path, schemaInfos);
        }

        public static List<SchemaInfoTuple> LoadSchemaInfos(String path)
        {
            return BinarySerializer.DeserializeFromFile<List<SchemaInfoTuple>>(path);
        }
        /// <summary>
        /// 是否需要补全结构信息
        /// </summary>
        /// <param name="schemaInfo"></param>
        /// <returns></returns>
        public static Boolean IsRequiredCompleteSchema(SchemaInfoTuple schemaInfo)
        {
            return ((schemaInfo.SchemaType == SchemaType.Table || schemaInfo.SchemaType == SchemaType.View) && schemaInfo.ColumnSchemas == null);
        }
        /// <summary>
        /// 判断指定的结构集合是否需要补全细节信息,若需要则给出那些需要
        /// </summary>
        /// <param name="schemaInfos"></param>
        /// <returns>返回一个二元组，如果需要则第二组件中包含需要补全明细的结构集合</returns>
        public static (Boolean requried, List<SchemaInfoTuple> requiredSchemas) IsRequiredCompleteSchema(List<SchemaInfoTuple> schemaInfos)
        {
            Boolean required = false;
            var requiredSchemas = schemaInfos.Where(t => IsRequiredCompleteSchema(t)).ToList();
            if (requiredSchemas.Count > 0)
            {
                required = true;
            }
            return (required, requiredSchemas);
        }
        public static void CompleteSchema(ISchemaProvider provider, SchemaInfoTuple schemaInfo)
        {
            switch (schemaInfo.SchemaType)
            {
                case SchemaType.Table:
                    {
                        var columnSchemas = provider.LoadColumnSchemaList(schemaInfo.ObjectSchema.Name);
                        schemaInfo.ColumnSchemas = new List<ColumnSchemaExtend>(columnSchemas);
                        var indexSchemas = provider.LoadIndexSchemaList(schemaInfo.ObjectSchema.Name);
                        schemaInfo.IndexColumnSchemas = new List<IndexSchema>(indexSchemas);

                    }
                    break;
                case SchemaType.View:
                    {
                        var columnSchems = provider.LoadViewColumnSchemaList(schemaInfo.ObjectSchema.Name);
                        schemaInfo.ColumnSchemas = new List<ColumnSchemaExtend>(columnSchems);
                    }
                    break;
                case SchemaType.Procedure:
                    {
                    }
                    break;
                case SchemaType.Function:
                    {

                    }
                    break;
            }
        }
    }
}
