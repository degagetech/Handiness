using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Handiness.Adaptive;
using System.Reflection;
using System.ComponentModel.Composition;

namespace Handiness.MySql
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
    public class MysqlAdaptiveExplain : IAdaptiveExplain
    {
        public String Name => TextResources.AdaptiveName;

        public String Guid => TextResources.Guid;

        public String Version => TextResources.Version;
    }
}
