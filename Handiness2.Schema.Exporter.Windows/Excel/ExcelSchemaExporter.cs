using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.Util;
namespace Handiness2.Schema.Exporter.Windows
{
    public class ExcelSchemaExporter : ISchemaExporter
    {
        public event Action<Object, SchemaExportEventArgs> ExportProgressChanged;
        public event Action<Object, SchemaExportCompletedEventArgs> ExportCompleted;
        public void Export(String exportDirectory, IList<SchemaInfoTuple> schemas, ExportConfig config)
        {

            List<SchemaInfoTuple> schemaInfos = new List<SchemaInfoTuple>(schemas);
            ExcelExportConfig exportConfig = config as ExcelExportConfig;

            //若有分组，首先写入分组中的结构信息
            //在目标表合并一行用于写入分组名称
            //后续写入属于此组的 TableSchema 信息
            //若需要建立合并分组信息，则以组名创建 Sheet ，属于此组的所有 Schem 信息，写入到此 Sheet 中
            //完成一个组的写入，并移除已写入的 Schema 信息

            //完成所有分组的写入后，将剩下零散的 Schema 信息单独创建 Sheet 写入信息


            //Start
            var workbook = OfficeAssistor.OpenExcel(exportConfig.ExcelTemplatePath);
            //新建目录 Sheet 
            EPoint catalogLocation = new EPoint(2,3);
            var catalogTemplateSheet= workbook.CreateSheet(ExcelTemplateFormat.CatalogSheetTemplateName);
            var catalogSheet = workbook.CreateSheet(ExcelTemplateFormat.CatalogSheetName);

            //复制目录头
            OfficeAssistor.CopyRow(catalogTemplateSheet, ExcelTemplateFormat.CSTHeadRowNum, catalogSheet, catalogLocation.X, catalogLocation.Y);
            //复制目录列
            OfficeAssistor.CopyRow(catalogTemplateSheet, ExcelTemplateFormat.CSTColumnHeaderRowNum, catalogSheet, catalogLocation.X, catalogLocation.Y);
            //复制目录行

            foreach (var pair in exportConfig.GroupInfos)
            {
                 
            }

            workbook.SaveExcel(DateTime.Now.ToString("yyyyMMddHHmmssfff") + ExcelTemplateFormat.ExcelFileExt);
        }
        public void WriteSchemaInfo(ISheet sheet,EPoint start,SchemaInfoTuple schemaInfo)
        {

        }
    }
}
