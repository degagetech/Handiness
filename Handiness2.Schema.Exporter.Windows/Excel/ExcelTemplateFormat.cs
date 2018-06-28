using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handiness2.Schema.Exporter.Windows
{

    internal static class ExcelTemplateFormat
    {
        internal const Int32 RowSpan = 2;
        internal const String ExcelFileExt = ".xlsx";
        internal const String CatalogSheetName = "目录";
        /// <summary>
        /// Excel 模板中目录模板 Sheet 的名称
        /// </summary>
        internal const String CatalogSheetTemplateName = "_catalog";


        internal const Int32 CSTHeadRowNum = 0;
        internal const Int32 CSTColumnHeaderRowNum = 2;
        internal const Int32 CSTRowTemlateNum = 4;

        /// <summary>
        /// Excel 模板中表模板 Sheet 的名称
        /// </summary>
        internal const String TableSheetTemplateName = "_table";

      

        internal const Int32 CatalogNumColLength = 2;
        internal const Int32 CatalogTableNameColLength = 6;
        internal const Int32 CatalogExplainColLength = 8;
        internal const Int32 CatalogRemarkColLength = 7;






        internal const Int32 TSTHeadRowNum = 0;
        internal const Int32 TSTColumnHeaderRowNum = 2;
        internal const Int32 TSTRowTemlateNum = 4;

        internal const Int32 TableNumColLength = 2;
        internal const Int32 TableFieldNameColLength = 4;
        internal const Int32 TableExplainColLength = 8;
        internal const Int32 TableTypeColLength = 4;
        internal const Int32 TableLengthColLength = 2;
        internal const Int32 TableIsPrimaryColLength = 2;
        internal const Int32 TableIsNullableColLength = 2;
        internal const Int32 TableRemarkColLength = 2;

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



        // 表信息工作表的参数预设

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
    }
}
