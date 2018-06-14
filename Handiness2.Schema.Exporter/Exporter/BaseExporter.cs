using System;
using System.Collections.Generic;
using System.Text;

namespace Handiness2.Schema.Exporter
{
    public abstract class BaseExporter
    {

        /// <summary>
        /// 导出结构信息
        /// </summary>
        /// <param name="provider">结构信息的提供者</param>
        /// <param name="args">导出参数</param>
        /// <param name="callback">进度改变的回调，第一个参数为进度的百分比，第二个参数为提示消息，例如当前正在导出的结构信息等</param>
        public abstract void ExportSchema(ISchemaProvider provider, String args, Action<Int32, TableSchema> callback);
    }
}
