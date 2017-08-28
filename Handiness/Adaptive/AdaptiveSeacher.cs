using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using Handiness.Services;
using System.ComponentModel.Composition.Primitives;

namespace Handiness.Adaptive
{
    /*-------------------------------------------------------------------------
 * 版权所有：王浪静
 * 作者：王浪静
 * 联系方式：932444208@qq.com
 * 创建时间： 2017/7/17 19:40:35
 * 版本号：v1.0
 * .NET 版本：4.0
 * 本类主要用途描述：用于搜索指定目录下的适配层
 *  -------------------------------------------------------------------------*/
    /// <summary>
    /// 适配层搜索器
    /// </summary>
    public class AdaptiveSeacher
    {
        /// <summary>
        /// 用以导出指定目录下所有的适配层描述对象
        /// </summary>
        /// <param name="directory">指定目录</param>
        public static IEnumerable<IAdaptiveExplain> ExportAdaptiveExplain(String directory = null)
        {
            directory = directory ?? AppDomain.CurrentDomain.BaseDirectory;
            DirectoryCatalog searchCatalog = new DirectoryCatalog(directory, TextResources.PatternOfALDllName);
            return ExportAdaptiveExplain(searchCatalog);
        }
        /// <summary>
        /// 用以导出指定目录下所有的适配层描述对象
        /// </summary>
        /// <param name="directory">指定目录</param>
        public static IEnumerable<IAdaptiveExplain> ExportAdaptiveExplain(ComposablePartCatalog catalog)
        {
            return InstanceExportService.GetExports<IAdaptiveExplain>(catalog);
        }

    }
}
