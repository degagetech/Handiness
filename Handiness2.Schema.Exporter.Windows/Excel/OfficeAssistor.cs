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
    public struct EPoint
    {
        public EPoint(Int32 x, Int32 y)
        {
            this.X = x;
            this.Y = y;
        }
        public Int32 X;
        public Int32 Y;
    }
    /// <summary>
    /// 提供基于 NOPI 的各种与 Office 文档操作相关的功能函数
    /// </summary>
    public static class OfficeAssistor
    {
        #region EXCEL
        internal const String ExtOfExcel2003 = ".xls";
        internal const String ExtOfExcel2007Plus = ".xlsx";



        public static Double? GetCellDataDouble(this ISheet sheet, Int32 x, Int32 y)
        {

            Double? value = null;
            ICell cell = OfficeAssistor.GetCell(sheet, x, y);
            if (cell != null)
            {
                if (cell.CellType == CellType.String)
                {
                    String valueStr = cell.ToString();
                    if (Double.TryParse(valueStr, out Double doubleValue))
                    {
                        value = doubleValue;
                    }
                }
                else
                {
                    value = cell.NumericCellValue;
                }
            }

            return value;
        }
        /// <summary>
        /// 从工作表中获取单元格
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="isEvaluate">如果单元格的值为公式，是否需要计算</param>
        /// <returns></returns>
        public static ICell GetCell(this ISheet sheet, Int32 x, Int32 y, Boolean isEvaluate = true)
        {
            ICell cell = null;
            if (sheet.LastRowNum > x)
            {
                var row = sheet.GetRow(x);
                if (row.LastCellNum > y)
                {
                    cell = sheet.GetRow(x).Cells[y];
                    if (cell.CellType == CellType.Formula && isEvaluate)
                    {
                        IFormulaEvaluator evaluator = GetFormulaEvaluator(sheet.Workbook);
                        cell = evaluator.EvaluateInCell(cell);
                    }
                }
            }
            return cell;
        }
        /// <summary>
        /// 创建与指定 工作表关联的超链接
        /// </summary>
        /// <param name="sheet">工作表</param>
        /// <param name="address">链接地址</param>
        /// <returns></returns>
        public static IHyperlink CreateHyperlink(this ISheet sheet, String address = null)
        {
            IHyperlink link = null;
            if (sheet is XSSFSheet)
            {
                link = new XSSFHyperlink(HyperlinkType.Document);
            }
            else
            {
                link = new HSSFHyperlink(HyperlinkType.Document);
            }
            //'Murray工作表_2'!A1
            if (address == null)
            {
                address = "!A1";
            }
            link.Address = $"'{ sheet.SheetName}'" + address;
            return link;
        }
        public static String GetCellData(this ISheet sheet, Int32 x, Int32 y)
        {
            String value = null;
            var cell = OfficeAssistor.GetCell(sheet, x, y);
            if (cell != null)
                value = cell.ToString();
            return value;
        }

        public static void CopyRow(ISheet source, Int32 sourceRowNum, ISheet dest, Int32 destinationRowNum,Int32 offset=0)
        {
            // Get the source / new row
            IRow newRow = dest.GetRow(destinationRowNum);
            IRow sourceRow = source.GetRow(sourceRowNum);

            // If the row exist in destination, push down all rows by 1 else create a new row
            if (newRow != null)
            {
                source.ShiftRows(destinationRowNum, source.LastRowNum, 1);
            }
            else
            {
                newRow = dest.CreateRow(destinationRowNum);
            }

            // Loop through source columns to add to new row
            for (int i = 0; i < sourceRow.LastCellNum; i++)
            {
                // Grab a copy of the old/new cell
                ICell oldCell = sourceRow.GetCell(i);
                ICell newCell = newRow.CreateCell(offset+i);

                // If the old cell is null jump to next cell
                if (oldCell == null)
                {
                    newCell = null;
                    continue;
                }

                // Copy style from old cell and apply to new cell

                ICellStyle newCellStyle = source.Workbook.CreateCellStyle();
                newCellStyle.CloneStyleFrom(oldCell.CellStyle); ;
                newCell.CellStyle = newCellStyle;

                // If there is a cell comment, copy
                if (newCell.CellComment != null) newCell.CellComment = oldCell.CellComment;

                // If there is a cell hyperlink, copy
                if (oldCell.Hyperlink != null) newCell.Hyperlink = oldCell.Hyperlink;

                // Set the cell data type
                newCell.SetCellType(oldCell.CellType);

                // Set the cell data value
                switch (oldCell.CellType)
                {
                    case CellType.Blank:
                        newCell.SetCellValue(oldCell.StringCellValue);
                        break;
                    case CellType.Boolean:
                        newCell.SetCellValue(oldCell.BooleanCellValue);
                        break;
                    case CellType.Error:
                        newCell.SetCellErrorValue(oldCell.ErrorCellValue);
                        break;
                    case CellType.Formula:
                        newCell.SetCellFormula(oldCell.CellFormula);
                        break;
                    case CellType.Numeric:
                        newCell.SetCellValue(oldCell.NumericCellValue);
                        break;
                    case CellType.String:
                        newCell.SetCellValue(oldCell.RichStringCellValue);
                        break;
                    case CellType.Unknown:
                        newCell.SetCellValue(oldCell.StringCellValue);
                        break;

                }
            }

            for (int i = 0; i < source.NumMergedRegions; i++)
            {
                CellRangeAddress cellRangeAddress = source.GetMergedRegion(i);
                if (cellRangeAddress.FirstRow == sourceRow.RowNum)
                {
                    Int32 fisrtRow = newRow.RowNum;
                    Int32 lastRow = newRow.RowNum + (cellRangeAddress.LastRow - cellRangeAddress.FirstRow);
                    CellRangeAddress newCellRangeAddress = new CellRangeAddress(
                                                                           fisrtRow,
                                                                           lastRow,
                                                                           cellRangeAddress.FirstColumn+ offset,
                                                                           cellRangeAddress.LastColumn+ offset);
                    dest.AddMergedRegion(newCellRangeAddress);
                }
            }

        }
        public static void CopyRange(ISheet source, String range, ISheet dest, EPoint start)
        {
            CellRangeAddress rangeAddress = CellRangeAddress.ValueOf(range);
            for (Int32 i = rangeAddress.FirstRow; i < rangeAddress.LastRow; ++i)
            {
                //    source.GetMergedRegion
            }
        }
        /// <summary>
        /// 打开指定索引的工作表，
        /// 请使用此函数获取工作表对象
        /// </summary>
        /// <param name="workBook">工作簿对象</param>
        /// <param name="sheetIndex">工作表索引</param>
        public static ISheet OpenSheet(IWorkbook workBook, Int32 sheetIndex)
        {
            ISheet sheet = null;
            sheet = workBook.GetSheetAt(sheetIndex);

            return sheet;
        }
        public static ISheet GetSheet(IWorkbook book, String sheetName)
        {

            return book.GetSheet(sheetName);
        }

        /// <summary>
        /// 获取指定 <see cref="IWorkbook"/> 接口对象的公式计算接口
        /// </summary>
        /// <param name="workBook"></param>
        /// <returns></returns>
        public static IFormulaEvaluator GetFormulaEvaluator(IWorkbook workBook)
        {
            IFormulaEvaluator formulaEvaluator = null;
            if (workBook is HSSFWorkbook)
            {
                formulaEvaluator = new HSSFFormulaEvaluator(workBook);
            }
            else
            {
                formulaEvaluator = new XSSFFormulaEvaluator(workBook);
            }
            return formulaEvaluator;
        }
        public static IClientAnchor GenerationClientAnchor(String filePath,
           Int32 dx1, Int32 dy1, Int32 dx2, Int32 dy2, Int32 col1, Int32 row1, Int32 col2, Int32 row2)
        {
            IClientAnchor clientAnchor = null;
            String ext = Path.GetExtension(filePath);
            switch (ext)
            {
                case ExtOfExcel2003:
                    {
                        clientAnchor = new HSSFClientAnchor(dx1, dy1, dx2, dy2, col1, row1, col2, row2);
                    }
                    break;
                case ExtOfExcel2007Plus:
                default:
                    {
                        clientAnchor = new XSSFClientAnchor(dx1, dy1, dx2, dy2, col1, row1, col2, row2);
                    }
                    break;
            }
            return clientAnchor;
        }
        public static IWorkbook GenerationWorkBook(String filePath, Stream stream)
        {
            IWorkbook workBook = null;
            String ext = Path.GetExtension(filePath);
            switch (ext)
            {
                case ExtOfExcel2003:
                    {
                        workBook = new HSSFWorkbook(stream);
                    }
                    break;
                case ExtOfExcel2007Plus:
                default:
                    {
                        workBook = new XSSFWorkbook(stream);
                    }
                    break;
            }
            return workBook;
        }
        /// <summary>
        /// 打开指定路径的Excel
        /// </summary>
        /// <param name="filePath">指定的路径</param>
        /// <returns>返回 IWorkbook 接口以操作Excel</returns>
        public static IWorkbook OpenExcel(String filePath)
        {
            IWorkbook workBook = null;
            using (FileStream stream = new FileStream(filePath, FileMode.Open,
              FileAccess.ReadWrite))
            {
                workBook = GenerationWorkBook(filePath, stream);
            }
            return workBook;
        }
        /// <summary>
        /// 保存Excel至指定路径
        /// </summary>
        /// <param name="workBook">Excel对象</param>
        /// <param name="filePath">保存的路径</param>
        public static void SaveExcel(this IWorkbook workBook, String filePath)
        {
            File.Delete(filePath);
            using (FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite))
            {
                workBook.Write(stream);
            }
        }
        #endregion
    }
}
