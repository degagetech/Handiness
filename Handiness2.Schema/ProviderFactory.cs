using System;
using System.Collections.Generic;
using System.Text;
#if NETCOREAPP20
using System.Composition.Convention;

using System.Composition;
using System.Composition.Hosting;
using System.Composition.Hosting.Core;
#endif 
#if NET40
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
#endif
using System.Reflection;
using System.IO;


namespace Handiness2.Schema
{
    public class ProviderFactory
    {
        /// <summary>
        /// 最后一次缓存的 <see cref="ISchemaProvider"/> 对象的列表
        /// </summary>
        public IList<ISchemaProvider> SchemaProviders { get; private set; }

        /// <summary>
        ///搜索包含实现 <see cref="ISchemaProvider"/> 接口的类的程序集的名称格式 
        /// </summary>
        internal const String SearchPattern = "Handiness2.Schema.*.dll";
        /// <summary>
        /// 从当前目录下的所有程序集中加载所有实现 <see cref="ISchemaProvider"/> 接口的实例
        /// </summary>
        public IList<ISchemaProvider> LoadSchemProviders(Boolean isCached = true)
        {
            List<ISchemaProvider> providers = new List<ISchemaProvider>();
#if NET40
            String directory =Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            DirectoryCatalog catalog = new DirectoryCatalog(directory, SearchPattern);
            using (CatalogExportProvider exportProvider = new CatalogExportProvider(catalog))
            {
                exportProvider.SourceProvider = exportProvider;
                var exports= exportProvider.GetExportedValues<ISchemaProvider>();
                providers.AddRange(exports);
            }
#endif
#if NETCOREAPP20
            var convention = new ConventionBuilder();
            var part = convention.ForTypesDerivedFrom<ISchemaProvider>().Export();
            String directory = AppDomain.CurrentDomain.BaseDirectory;
            String[] files = Directory.GetFiles(directory, SearchPattern);
            if (files.Length > 0)
            {
                List<Assembly> assemblies = new List<Assembly>();
                foreach (String file in files)
                {
                    var assembly = Assembly.LoadFile(file);
                    assemblies.Add(assembly);
                }

                var configuration = new ContainerConfiguration();
                configuration.WithAssemblies(assemblies);

                var container = configuration.CreateContainer();

                var exports = container.GetExports<ISchemaProvider>();
                providers.AddRange(exports);
            }
#endif
            this.SchemaProviders = providers;
            return providers;
        }

    }
}
