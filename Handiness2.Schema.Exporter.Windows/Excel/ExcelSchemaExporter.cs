using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.Util;
using System.Threading.Tasks;
using System.Threading;

namespace Handiness2.Schema.Exporter.Windows
{
    public class ExcelSchemaExporter : ISchemaExporter
    {
        public event Action<Object, SchemaExportEventArgs> ExportProgressChanged;
        //    public event Action<Object, SchemaExportCompletedEventArgs> ExportCompleted;
        public void Export(String exportDirectory, IList<SchemaInfoTuple> schemas, ExportConfig config)
        {

            List<SchemaInfoTuple> schemaInfos = new List<SchemaInfoTuple>(schemas);

            Dictionary<String, SchemaInfoTuple> schemaTable = new Dictionary<string, SchemaInfoTuple>();
            schemaInfos.ForEach(t =>
            {
                schemaTable.Add(t.TableSchema.Name, t);
            });
            Int32 total = schemaTable.Count;
            Int32 current = 0;
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

            EPoint catalogLocation = new EPoint(2, 2);

            var catalogTemplateSheet = workbook.GetSheet(ExcelTemplateFormat.CatalogSheetTemplateName);
            var tableTemplateSheet = workbook.GetSheet(ExcelTemplateFormat.TableSheetTemplateName);
            var catalogSheet = workbook.CreateSheet(ExcelTemplateFormat.CatalogSheetName);



            foreach (var pair in exportConfig.GroupInfos)
            {
                var schemaNames = pair.Value;
                var groupName = pair.Key;
                ISheet schemaSheet = null;
                EPoint sheetLocation = new EPoint(2, 2);
                if (exportConfig.IsMergeGroupToSheet)
                {
                    schemaSheet = workbook.CreateSheet(groupName);
                }



                //复制目录头
                catalogTemplateSheet.CopyRow(ExcelTemplateFormat.CSTHeadRowNum, catalogSheet, catalogLocation.X, catalogLocation.Y);
                //向目录表中写入 组名
                catalogSheet.SetCellValue(catalogLocation.X, 0, groupName);
                catalogLocation.X += ExcelTemplateFormat.RowSpan;

                //复制目录列
                catalogTemplateSheet.CopyRow(ExcelTemplateFormat.CSTColumnHeaderRowNum, catalogSheet, catalogLocation.X, catalogLocation.Y);
                catalogLocation.X += ExcelTemplateFormat.RowSpan;



                //写入目录行
                Int32 internalnum = 1;

                foreach (String schemaName in schemaNames)
                {
                    TableSchemaExtend tableSchema = schemaTable[schemaName].TableSchema;
                    catalogTemplateSheet.CopyRow(ExcelTemplateFormat.CSTRowTemlateNum, catalogSheet, catalogLocation.X, catalogLocation.Y);

                    var schemaInfo = schemaTable[schemaName];
                    this.RaiseExportProgressChanged(total, ++current, schemaInfo);
                    this.WriteCatalogRow(catalogSheet, tableSchema, internalnum++, catalogLocation.X, 0);
                    //写入对应表的列信息

                    if (!exportConfig.IsMergeGroupToSheet)
                    {
                        schemaSheet = workbook.CreateSheet(schemaInfo.TableSchema.Name);
                    }
                    this.WriteSchemaInfo(tableTemplateSheet, schemaSheet, sheetLocation, schemaInfo);
                    schemaTable.Remove(schemaName);
                    if (exportConfig.IsMergeGroupToSheet)
                    {
                        sheetLocation.X += ExcelTemplateFormat.RowSpan;
                    }

                    //目录表获取表名单元格，并添加链接
                    ICell cell = catalogSheet.GetCell(catalogLocation.X, 0 + ExcelTemplateFormat.CatalogNumColLength);

                    //TODO: 连接R1C1样式单元格 ，暂时只连接到 Sheet
                    IHyperlink link = OfficeAssistor.CreateHyperlink(schemaSheet/*, sheetLocation.X, sheetLocation.Y*/);

                    cell.Hyperlink = link;

                    catalogLocation.X += ExcelTemplateFormat.RowSpan;
                    Thread.Sleep(10);

                }
                catalogLocation.X += ExcelTemplateFormat.RowSpan;
            }

            if (schemaTable.Count > 0)
            {
                if (!exportConfig.EnableExclude)
                {
                    catalogTemplateSheet.CopyRow(ExcelTemplateFormat.CSTHeadRowNum, catalogSheet, catalogLocation.X, catalogLocation.Y);

                    catalogSheet.SetCellValue(catalogLocation.X, 0, ExcelTemplateFormat.CatalogSheetName);
                    catalogLocation.X += ExcelTemplateFormat.RowSpan;

                    //复制目录列
                    catalogTemplateSheet.CopyRow(ExcelTemplateFormat.CSTColumnHeaderRowNum, catalogSheet, catalogLocation.X, catalogLocation.Y);
                    catalogLocation.X += ExcelTemplateFormat.RowSpan;

                    Int32 num = 1;
                    foreach (var pair in schemaTable)
                    {
                        String schemaName = pair.Key;
                        var schemaInfo = schemaTable[schemaName];
                        ISheet schemaSheet = null;
                        EPoint sheetLocation = new EPoint(2, 2);
                        schemaSheet = workbook.CreateSheet(schemaName);

                        TableSchemaExtend tableSchema = schemaTable[schemaName].TableSchema;
                        catalogTemplateSheet.CopyRow(ExcelTemplateFormat.CSTRowTemlateNum, catalogSheet, catalogLocation.X, catalogLocation.Y);
                        this.RaiseExportProgressChanged(total, ++current, schemaInfo);
                        this.WriteCatalogRow(catalogSheet, tableSchema, num++, catalogLocation.X, 0);

                        this.WriteSchemaInfo(tableTemplateSheet, schemaSheet, sheetLocation, schemaInfo);

                        //目录表获取表名单元格，并添加链接
                        ICell cell = catalogSheet.GetCell(catalogLocation.X, 0 + ExcelTemplateFormat.CatalogNumColLength);

                        //TODO: 连接R1C1样式单元格 ，暂时只连接到 Sheet
                        IHyperlink link = OfficeAssistor.CreateHyperlink(schemaSheet);

                        cell.Hyperlink = link;

                        catalogLocation.X += ExcelTemplateFormat.RowSpan;
                        Thread.Sleep(10);
                    }
                }
                else
                {
                    this.RaiseExportProgressChanged(total - schemaTable.Count, current, null);
                }

            }

            //删除模板 Sheet 
            workbook.RemoveSheetByName(ExcelTemplateFormat.CatalogSheetTemplateName);
            workbook.RemoveSheetByName(ExcelTemplateFormat.TableSheetTemplateName);
            this.SaveExcel(workbook, exportDirectory);
        }
        private void RaiseExportProgressChanged(Int32 total, Int32 current, SchemaInfoTuple schema)
        {
            SchemaExportEventArgs args = new SchemaExportEventArgs();
            args.Total = total;
            args.Current = current;
            args.SchemaInfo = schema;
            ThreadPool.QueueUserWorkItem((s) =>
            {
                this.ExportProgressChanged?.Invoke(this, args);
            });
        }
        private void SaveExcel(IWorkbook workbook, String exportDirectory)
        {
            String name = DateTime.Now.ToString("yyyyMMddHHmmssfff") + ExcelTemplateFormat.ExcelFileExt;
            String path = Path.Combine(exportDirectory, name);
            workbook.SaveExcel(path);
        }
        private void WriteCatalogRow(ISheet sheet, TableSchemaExtend schema, Int32 num, Int32 row, Int32 startCol)
        {
            sheet.SetCellValue(row, startCol, num);
            startCol += ExcelTemplateFormat.CatalogNumColLength;
            sheet.SetCellValue(row, startCol, schema.Name);
            startCol += ExcelTemplateFormat.CatalogTableNameColLength;
            sheet.SetCellValue(row, startCol, schema.Explain);
        }
        public void WriteSchemaInfo(ISheet formatSheet, ISheet sheet, EPoint start, SchemaInfoTuple schemaInfo)
        {
            //复制表头
            formatSheet.CopyRow(ExcelTemplateFormat.TSTHeadRowNum, sheet, start.X, start.Y);
            //写入 表名（说明） 信息
            String name = schemaInfo.TableSchema.Name;
            if (!String.IsNullOrEmpty(schemaInfo.TableSchema.Explain))
            {
                name += $"({schemaInfo.TableSchema.Explain})";
            }
            sheet.SetCellValue(start.X, 0, name);

            start.X += ExcelTemplateFormat.RowSpan;
            //复制列头
            formatSheet.CopyRow(ExcelTemplateFormat.TSTColumnHeaderRowNum, sheet, start.X, start.Y);
            start.X += ExcelTemplateFormat.RowSpan;



            //开始写入列信息
            Int32 num = 1;
            if (schemaInfo.ColumnSchemas == null || schemaInfo.ColumnSchemas.Count == 0)
            {
                return;
            }
            foreach (var colSchema in schemaInfo.ColumnSchemas)
            {

                //复制行
                formatSheet.CopyRow(ExcelTemplateFormat.TSTRowTemlateNum, sheet, start.X, start.Y);

                Int32 col = 0;
                //写入序号
                sheet.SetCellValue(start.X, col, num++);
                col += ExcelTemplateFormat.TableNumColLength;

                //写入列名
                sheet.SetCellValue(start.X, col, colSchema.Name);
                col += ExcelTemplateFormat.TableFieldNameColLength;

                //写入注释
                sheet.SetCellValue(start.X, col, colSchema.Explain);
                col += ExcelTemplateFormat.TableExplainColLength;

                //写入类型
                sheet.SetCellValue(start.X, col, colSchema.DbTypeString);
                col += ExcelTemplateFormat.TableTypeColLength;

                //写入长度
                sheet.SetCellValue(start.X, col, colSchema.Length);
                col += ExcelTemplateFormat.TableLengthColLength;

                //写入主键信息
                if (colSchema.IsPrimaryKey) sheet.SetCellValue(start.X, col, colSchema.IsPrimaryKey);

                col += ExcelTemplateFormat.TableIsPrimaryColLength;

                //写入可空信息
                if (!colSchema.IsNullable) sheet.SetCellValue(start.X, col, colSchema.IsNullable);
                col += ExcelTemplateFormat.TableIsNullableColLength;


                start.X += ExcelTemplateFormat.RowSpan;
            }

        }
    }
}
