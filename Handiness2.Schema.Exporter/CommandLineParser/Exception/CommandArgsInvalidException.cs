using System;
using System.Collections.Generic;
using System.Text;

namespace Handiness2.Schema.Exporter
{
    /// <summary>
    /// 命令行参数值无效时发生的异常
    /// </summary>
    public class CommandArgsInvalidException : Exception
    {
        /// <summary>
        /// 无效参数的说明
        /// </summary>
        public String InvalidArgExplain { get; set; }

        /// <summary>
        /// 命令参数
        /// </summary>
        public CommandArgsAttribute CommandArgs { get; set; }


        public CommandArgsInvalidException(String explain) : base(explain)
        {
            this.InvalidArgExplain = explain;
        }
    }
}
