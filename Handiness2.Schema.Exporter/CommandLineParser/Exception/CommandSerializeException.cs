using System;
using System.Collections.Generic;
using System.Text;

namespace Handiness2.Schema.Exporter
{
    /// <summary>
    /// 命令序列化时发生的异常
    /// </summary>
    public class CommandSerializeException : Exception
    {
        /// <summary>
        /// 序列化的说明
        /// </summary>
        public String SerializeExplain { get; set; }

        public CommandSerializeException(String explain) : base(explain)
        {
            this.SerializeExplain = explain;
        }
    }
}
