using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Handiness.Adaptive;
using System.Reflection;
using System.ComponentModel.Composition;

namespace Handiness.SQLServer
{
    /// <summary>
    ///SQL Server 适配层描述器
    /// </summary>
    [Export(typeof(IAdaptiveExplain))]
    public class SQLServerAdaptiveExplain : IAdaptiveExplain
    {
        /// <summary>
        /// 此适配层标识符
        /// </summary>
        internal const String ALGuid = "41668F3A-DE95-4E1D-8213-1BCAAAA912C1";
        /// <summary>
        /// 此适配层名称
        /// </summary>
        internal const String ALName = "SQL Server";
        /// <summary>
        /// 此适配层版本
        /// </summary>
        internal const String ALVersion = "1.0.0.0";

        /*************************************************/
        public String Name => ALName;

        public String Guid => ALGuid;

        public String Version => ALVersion;
    }
}
