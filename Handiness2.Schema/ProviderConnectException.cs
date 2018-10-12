using System;
using System.Collections.Generic;
using System.Text;

namespace Handiness2.Schema
{
    /// <summary>
    /// <see cref="ISchemaProvider"/> 对象在执行连接操作时的异常信息
    /// </summary>
    public class ProviderConnectException : System.Exception
    {
        /// <summary>
        /// 连接错误的说明
        /// </summary>
        public String ErrorExplain { get; set; }
        /// <summary>
        /// 连接适用的连接字符串信息
        /// </summary>
        public String ConnectionString { get; set; }


        public ProviderConnectException(Exception exc) : base(null, exc)
        {
        }

        public ProviderConnectException(String message, Exception exc) : base(message, exc)
        {
        }
    }
}
