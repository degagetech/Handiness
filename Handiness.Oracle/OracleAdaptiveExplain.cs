using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Handiness.Adaptive;
using System.Reflection;
using System.ComponentModel.Composition;

namespace Handiness.Oracle
{

    /*-------------------------------------------------------------------------
 * 版权所有：王浪静
 * 作者：王浪静
 * 联系方式：932444208@qq.com
 * 创建时间： 2017/7/17 19:36:05
 * 版本号：v1.0
 * .NET 版本：4.0
 * 本类主要用途描述：Mysql适配层描述接口实现
 *  -------------------------------------------------------------------------*/
    /// <summary>
    /// Mysql适配层描述接口
    /// </summary>
    [Export(typeof(IAdaptiveExplain))]
    public class OracleAdaptiveExplain : IAdaptiveExplain
    {      /// <summary>
           /// 此适配层标识符
           /// </summary>
        internal const String ALGuid = "442157DA-5F41-40F9-9979-F75648B65024";
        /// <summary>
        /// 此适配层名称
        /// </summary>
        internal const String ALName = "Oracle";
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
