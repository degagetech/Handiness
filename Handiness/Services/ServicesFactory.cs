using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
namespace Handiness.Services
{
    /*-------------------------------------------------------------------------
 * 版权所有：王浪静
 * 作者：王浪静
 * 联系方式：932444208@qq.com
 * 创建时间： 2017/7/17 19:15:48
 * 版本号：v1.0
 * .NET 版本：4.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/
    /// <summary>
    /// Service实例获取工厂
    /// </summary>
    /// <typeparam name="T">服务实例的类型</typeparam>
    public class ServicesFactory<T> where T : IService
    {
        public static T ExportServiceInstance(String adaptiveGuid, String directory = null)
        {
            if (String.IsNullOrWhiteSpace(adaptiveGuid))
            {
                throw new ArgumentException(TextResources.ALNameGuidWithEmpty);
            }
            T instance = default(T);
            directory = directory ?? AppDomain.CurrentDomain.BaseDirectory;
            DirectoryCatalog searchCatalog = new DirectoryCatalog(directory, TextResources.ALNamePattern);
            ObjectExportService.GetExport<T>(searchCatalog, adaptiveGuid);
            return instance;
        }
    }
}
