using System;
using System.Collections.Generic;
using System.Text;

namespace Handiness2.Schema.Exporter
{
    /// <summary>
    /// 命令参数设置异常时
    /// </summary>
    public class CommandSettingExpcetion : Exception
    {
        /// <summary>
        /// 设置异常的命令参数
        /// </summary>
        public CommandArgsAttribute CommandArgs { get; set; }
        /// <summary>
        /// 命令设置异常的说明
        /// </summary>
        public String Explain { get; set; }
    }
}
