using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handiness.Adaptive
{
    /*-------------------------------------------------------------------------
    * 版权所有：王浪静
    * 作者：王浪静
    * 联系方式：932444208@qq.com
    * 创建时间： 2017/7/17 17:10:35
    * 版本号：v1.0
    * .NET 版本：4.0
    * 本接口规范描述：适配层描述接口，此接口要求所有Handines的适配层的开发者提供实现
    *  -------------------------------------------------------------------------*/
    /// <summary>
    /// 适配层信息描述接口
    /// </summary>
    public interface IAdaptiveExplain
    {
        /// <summary>
        /// 适配层的名称
        /// </summary>
        String Name { get; }
        /// <summary>
        /// 适配层的标识符
        /// </summary>
        String Guid { get; }
        /// <summary>
        /// 版本信息
        /// </summary>
        String Version { get; }
    }
}
