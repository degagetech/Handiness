using System;
using System.Collections.Generic;
using System.Text;
using NPOI.HSSF;
using System.Linq;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using System.Diagnostics;
namespace Handiness2.Schema.Exporter
{
    public class OfficeExporter : BaseExporter
    {
        /// <summary>
        /// Excel 模板中目录表的名称
        /// </summary>
        const String CatalogSheetName = "catalog";
        /// <summary>
        /// Excel 模板中模板表的名称
        /// </summary>
        const String TableSchemaTemplate = "_table_schema_t";

        #region 目录信息工作表的参数预设
        /// <summary>
        /// 目录表起始信息行的X坐标
        /// </summary>
        const Int32 CatalogSheetStartOffSetX = 7;
        /// <summary>
        /// 目录表起始信息行的Y坐标
        /// </summary>
        const Int32 CatalogSheetStartOffsetY = 1;

        /// <summary>
        /// 目录表 链接列的Y坐标
        /// </summary>
        const Int32 CatalogSheetLinkColY = 0;
        /// <summary>
        ///目录表每行信息的占用的实际行数
        /// </summary>
        const Int32 CatalogSheetRowSpanSize = 2;

        /// <summary>
        /// 目录表 序号列的Y坐标
        /// </summary>
        const Int32 CatalogSheetNoColY = 1;
        /// <summary>
        ///  目录表 表名列的Y坐标
        /// </summary>
        const Int32 CatalogSheetTableNameColY = 3;

        /// <summary>
        /// 目录表 说明列的Y坐标
        /// </summary>
        const Int32 CatalogSheetExplainColY = 9;

        /// <summary>
        /// 目录表 说明备注列的Y坐标
        /// </summary>
        const Int32 CatalogSheetRemarkColY = 18;

        #endregion

        #region  表信息工作表的参数预设
        /// <summary>
        ///信息表每行信息的占用的实际行数
        /// </summary>
        const Int32 TableSheetRowSpanSize = 2;
        /// <summary>
        /// 信息表 表名行
        /// </summary>
        const Int32 TableSheetNameColX = 2;
        /// <summary>
        /// 信息表 表名列
        /// </summary>
        const Int32 TableSheetNameColY = 0;

        /// <summary>
        /// 信息表 起始信息行 X
        /// </summary>
        const Int32 TableSheetStartColumnOffsetX = 6;
        /// <summary>
        /// 信息表 起始信息行 Y
        /// </summary>
        const Int32 TableSheetStartColumnOffsetY = 0;

        /// <summary>
        /// 信息表 序号列的Y坐标
        /// </summary>
        const Int32 TableSheetNoY = 0;

        /// <summary>
        /// 信息表 名称列的Y坐标
        /// </summary>
        const Int32 TableSheetNameY = 2;

        /// <summary>
        /// 信息表 说明列的Y坐标
        /// </summary>
        const Int32 TableSheetExplainY = 6;

        /// <summary>
        /// 信息表 类型列的Y坐标
        /// </summary>
        const Int32 TableSheetTypeY = 14;

        /// <summary>
        /// 信息表 主键列的Y坐标
        /// </summary>
        const Int32 TableSheetPrimaryY = 18;

        /// <summary>
        /// 信息表 可空列的Y坐标
        /// </summary>
        const Int32 TableSheetNullableY = 20;


        #endregion
        public override void ExportSchema(ISchemaProvider provider, String args, Action<Int32, TableSchema> callback)
        {
            var command = CommandSerializer<OfficeExportCommand>.DeSerialize(args);
            this.ExportSchema(provider, command, callback);
        }

        private void WriteColumnSchemaInfo(ColumnSchemaExtend schema, ISheet sheet, Int32 row)
        {
            Int32 x = TableSheetStartColumnOffsetX + row * TableSheetRowSpanSize;

            //写入序号
            var noCell = OfficeAssistor.GetCell(sheet, x, TableSheetNoY, false);
            noCell.SetCellValue(row + 1);

            //写入字段名
            var nameCell = OfficeAssistor.GetCell(sheet, x, TableSheetNameY, false);
            nameCell.SetCellValue(schema.Name);

            //写入字段说明
            var explainCell = OfficeAssistor.GetCell(sheet, x, TableSheetExplainY, false);
            explainCell.SetCellValue(schema.Explain);

            //写入字段类型
            var typeCell = OfficeAssistor.GetCell(sheet, x, TableSheetTypeY, false);
            String dbString = schema.DbTypeString;
            if (schema.Length > 0)
            {
                dbString += $"({schema.Length.ToString()})";
            }
            typeCell.SetCellValue(dbString);

            //写入主键信息
            var priCell = OfficeAssistor.GetCell(sheet, x, TableSheetPrimaryY, false);
            priCell.SetCellValue(schema.IsPrimaryKey ? "主键" : " ");

            //写入可空信息
            var nullableCell = OfficeAssistor.GetCell(sheet, x, TableSheetNullableY, false);
            nullableCell.SetCellValue(schema.IsNullable ? "是" : " ");

            Trace.WriteLine(schema.Name);

        }
        private void WriteTableSchameInfo((TableSchemaExtend table, ColumnSchemaExtend[] columns) schema, ISheet sheet)
        {
            //写入表名 表说明
            String tableInfo = schema.table.Name;
            if (!String.IsNullOrEmpty(schema.table.Explain))
            {
                tableInfo += $"({schema.table.Explain})";
            }
            var cell = OfficeAssistor.GetCell(sheet, TableSheetNameColX, TableSheetNameColY, false);
            cell.SetCellValue(tableInfo);

            for (Int32 row = 0; row < schema.columns.Length; ++row)
            {
                this.WriteColumnSchemaInfo(schema.columns[row], sheet, row);
            }

        }
        /// <summary>
        /// 将指定的  <see cref="TableSchemaExtend"/>  信息写入目录信息的工作表
        /// </summary>
        private void WriteCatalogInfo(TableSchemaExtend schema, ISheet sheet, Int32 row, ISheet linkSheet = null)
        {
            Int32 x = CatalogSheetStartOffSetX + row * CatalogSheetRowSpanSize;

            //如果链接表参数不为空，设置链接
            if (linkSheet != null)
            {
                var cell = OfficeAssistor.GetCell(sheet, x, CatalogSheetLinkColY, false);
                cell.SetCellValue("→");
                IHyperlink link = OfficeAssistor.CreateHyperlink(linkSheet);
                cell.Hyperlink = link;
                
            }

            //写入序号
            var noCell = OfficeAssistor.GetCell(sheet, x, CatalogSheetNoColY, false);
            noCell.SetCellValue(row + 1);

            //写入表名
            var nameCell = OfficeAssistor.GetCell(sheet, x, CatalogSheetTableNameColY, false);
            nameCell.SetCellValue(schema.Name);

            //写入说明
            var explainCell = OfficeAssistor.GetCell(sheet, x, CatalogSheetExplainColY, false);
            explainCell.SetCellValue(schema.Explain);

            Trace.WriteLine(schema.Name);
        }
        /// <summary>
        /// 获取  '回到目录的单元格' 
        /// </summary>
        /// <returns></returns>
        public ICell GetBackCatalogCell(ISheet sheet)
        {
            return sheet.GetRow(3).GetCell(11);
        }
        public void ExportSchema(ISchemaProvider provider, OfficeExportCommand command, Action<Int32, TableSchema> callback)
        {
            //使用指定的模板打开 Excel
            switch (command.Type)
            {
                default:
                case OfficeExportCommand.ExportTypeExcel:
                    {

                        IWorkbook workbook = OfficeAssistor.OpenExcel(command.Template);

                        ISheet catalogSheet = OfficeAssistor.GetSheet(workbook, CatalogSheetName);

                        ISheet templateSheet = OfficeAssistor.GetSheet(workbook, TableSchemaTemplate);

                        var tableSchemas = provider.LoadTableSchemaList().ToArray();
                        Int32 total = tableSchemas.Length;
                        for (Int32 row = 0; row < tableSchemas.Length; ++row)
                        {
                            var tableSchema = tableSchemas[row];
                            ISheet sheet = templateSheet.CopySheet(tableSchema.Name, true);

                            //写入目录信息
                            this.WriteCatalogInfo(tableSchema, catalogSheet, row, sheet);

                            var colSchemas = provider.LoadColumnSchemaList(tableSchema.Name).ToArray();
                            //写入表信息
                            this.WriteTableSchameInfo((tableSchema, colSchemas), sheet);

                            //设置回到目录的超链接
                            Int32 x = CatalogSheetStartOffSetX + (row + 1) * CatalogSheetRowSpanSize;
                            Int32 y = 5;
                            var link = OfficeAssistor.CreateHyperlink(catalogSheet, $"!R{x}C{y}");
                            var cell = this.GetBackCatalogCell(sheet);
                            String str = cell.StringCellValue;
                            cell.Hyperlink = link;

                            callback.Invoke((Int32)((row * 1.0 / total) * 100), tableSchema);
                        }
                        workbook.RemoveSheetAt(1);
                        workbook.SetActiveSheet(0);
                        File.Delete(command.Output);
                        using (FileStream stream = new FileStream(command.Output, FileMode.Create, FileAccess.ReadWrite))
                        {
                            workbook.Write(stream);
                        }
                    }
                    break;
            }

        }
    }
}
