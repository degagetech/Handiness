using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using Handiness.Properties;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace Handiness.Metadata
{
    public abstract class MetadataProvider : IMetadataProvider
    {
        public abstract String Version { get; }
        public abstract String Explain { get; }

        /********************/

        private DbConnection _connection = null;
        protected DbConnection Connection { get => this._connection; set => this._connection = value; }

        /********************/

        protected MetadataProvider() { }

        /********************/
        public void Close()
        {
            if (this._connection.State == System.Data.ConnectionState.Open)
            {
                this._connection.Close();
            }
        }
        public void Dispose()
        {
            this.Close();
            this._connection.Dispose();
        }
        public void Open(String connectionString)
        {
            if (String.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentException(Resources.EmptyConnectionString);
            }
            this.Close();
            this._connection.ConnectionString = connectionString;
            this._connection.Open();
        }

        /********************/
        public abstract IList<ColumnSchema> GetColumnSchemas(String tableName);
        public abstract IList<TableSchema> GetTableSchemas();

        /// <summary>
        /// 用以获取指定guid数据库适配层<see cref="IMetadataProvider"/>接口的实现对象
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="directory">指定的目录，默认为本程序集所在目录</param>
        /// <returns>返回实现此接口类的实例</returns>
        public static IMetadataProvider GetMetadataProvider(String guid, String directory = null)
        {
            IMetadataProvider instance = null;
            if (String.IsNullOrWhiteSpace(guid))
            {
                throw new ArgumentException(Resources.EmptyALNameGuid);
            }
            directory = directory ?? AppDomain.CurrentDomain.BaseDirectory;
            DirectoryCatalog searchCatalog = new DirectoryCatalog(directory, Resources.ALNamePattern);
            using (CompositionContainer compositionContainer = new CompositionContainer(searchCatalog))
            {
                instance = compositionContainer.GetExport<IMetadataProvider>(guid)?.Value;
            }
            return instance;
        }
        /// <summary>
        /// 用以获取指定目录下所有<see cref="IMetadataProvider"/>接口的实现对象
        /// </summary>
        /// <param name="directory">指定的目录，默认为本程序集所在目录</param>
        /// <returns>若不存在此类接口的实现类，则返回一个元素个数为0的<see cref="IList"/>实例对象</returns>
        public static IList<IMetadataProvider> GetMetadataProviders(String directory = null)
        {
            List<IMetadataProvider> instanceSet = new List<IMetadataProvider>();
            directory = directory ?? AppDomain.CurrentDomain.BaseDirectory;
            DirectoryCatalog searchCatalog = new DirectoryCatalog(directory, Resources.ALNamePattern);
            using (CompositionContainer compositionContainer = new CompositionContainer(searchCatalog))
            {
                var lazyInstances = compositionContainer.GetExports<IMetadataProvider>();
                foreach (var lazyInstance in lazyInstances)
                {
                    instanceSet.Add(lazyInstance.Value);
                }
            }
            return instanceSet;
        }
    }
}
