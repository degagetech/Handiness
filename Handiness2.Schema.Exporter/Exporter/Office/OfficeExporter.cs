using System;
using System.Collections.Generic;
using System.Text;
using NPOI.HSSF;
using System.Linq;
using NPOI.SS.UserModel;

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
            var command = CommandSerializer<OfficeExportCommand>.DeSerialize(args);
            this.ExportSchema(provider, command, callback);
        }
        public void ExportSchema(ISchemaProvider provider, OfficeExportCommand command, Action<Int32, String> callback)
        {
            //使用指定的模板打开 Excel
            switch (command.Type)
            {
                //TODO: 导出结构信息到 Excel
                default:
                case OfficeExportCommand.ExportTypeExcel:
                    {
                        IWorkbook workbook = OfficeAssistor.OpenExcel(command.Template);
                        var tableSchemas = provider.LoadTableSchemaList().ToArray();
                        for (Int32 i = 0; i < tableSchemas.Length; ++i)
                        {
                            var tableSchema = tableSchemas[i];
                            var colSchemas = provider.LoadColumnSchemaList(tableSchema.Name);

                            foreach (var colSchema in colSchemas)
                            {

                            }
                        }
                    }
                    break;
            }

        }
    }
}
