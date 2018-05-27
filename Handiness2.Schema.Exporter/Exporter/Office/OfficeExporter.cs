using System;
using System.Collections.Generic;
using System.Text;
using NPOI.HSSF;
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
        const String TableSchemaTemplate = "table_schema_t";

        #region 目录表参数预设
        /// <summary>
        /// 目录表起始信息行的X坐标
        /// </summary>
        const Int32 CatalogStartOffSetX = 8;
        /// <summary>
        /// 目录表起始信息行的Y坐标
        /// </summary>
        const Int32 CatalogStartOffsetY = 1;

        /// <summary>
        ///目录表每行信息的占用的实际行数
        /// </summary>
        const Int32 CatalogRowSpanSize = 2;

        /// <summary>
        /// 目录表 序号列的Y坐标
        /// </summary>
        const Int32 CatalogNoColY = 3;
        /// <summary>
        ///  目录表 表名列的Y坐标
        /// </summary>
        const Int32 CatalogTableColY = 5;

        /// <summary>
        /// 目录表 说明列的Y坐标
        /// </summary>
        const Int32 CatalogExplainColY = 11;

        /// <summary>
        /// 目录表 说明备注列的Y坐标
        /// </summary>
        const Int32 CatalogRemarkColY = 19;

        #endregion
        public override void ExportSchema(ISchemaProvider provider, String args, Action<Int32, String> callback)
        {
            //暂时无视参数

            var tableSchemas = provider.LoadTableSchemaList();
        }
    }
}
