using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;

namespace Handiness.Services
{
    /*-------------------------------------------------------------------------
 * 版权所有：王浪静
 * 作者：王浪静
 * 联系方式：932444208@qq.com
 * 创建时间： 2017/7/19 15:24:14
 * 版本号：v1.0
 * .NET 版本：4.0
 * 本类主要用途描述：用于从指定搜索目录中导出类型匹配的类的实例
 *  -------------------------------------------------------------------------*/
    /// <summary>
    /// 用于从指定搜索目录中导出类型匹配的类的实例
    /// </summary>
    public class InstanceExportService : ServiceBase
    {
        /// <summary>
        /// 从指定搜索目录中导出匹配类型的单一实例
        /// </summary>
        /// <param name="name">契约名称</param>
        public static T GetExport<T>(DirectoryCatalog catalog, String name = null)
        {
            CatalogExportProvider exportProvider = new CatalogExportProvider(catalog);
            exportProvider.SourceProvider = exportProvider;
            return exportProvider.GetExportedValue<T>(name);

        }

        /// <summary>
        /// 从指定搜索目录中导出匹配类型的实例集合
        /// </summary>
        public static IEnumerable<T> GetExports<T>(String directory)
        {
            DirectoryCatalog catalog = new DirectoryCatalog(directory);
            return GetExports<T>(catalog);
        }
        /// <summary>
        /// 从指定程序集目录中导出匹配类型的实例集合
        /// </summary>
        public static IEnumerable<T> GetExports<T>(ComposablePartCatalog catalog)
        {
            CatalogExportProvider exportProvider = new CatalogExportProvider(catalog);
            exportProvider.SourceProvider = exportProvider;
            return exportProvider.GetExportedValues<T>();

        }
    }
}
