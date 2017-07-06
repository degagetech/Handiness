using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using Handiness.Properties;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Data;

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

        #region 列信息获取操作
        /// <summary>
        /// 根据列的元数据信息判断此列是否为主键
        /// </summary>
        protected abstract Boolean IsPrimaryKey(DataRow row);
        /// <summary>
        /// 根据列的元数据信息获取此列的长度
        /// </summary>
        protected abstract Int32 GetLength(DataRow row);
        /// <summary>
        ///  根据列的元数据信息判断此列是否可为空
        /// </summary>
        protected abstract Boolean IsNullable(DataRow row);
        /// <summary>
        /// 将原始的元数据信息转换成<see cref="ColumnSchema"/> 实例
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        protected abstract ColumnSchema MetadataToColumnSechma(DataRow row);
        /// <summary>
        /// 根据列的元数据信息获取此列的注释
        /// </summary>
        protected abstract String GetExplain(DataRow row);
        #endregion


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
        public static IEnumerable<IMetadataProvider> GetMetadataProviders(String directory = null)
        {
            directory = directory ?? AppDomain.CurrentDomain.BaseDirectory;
            DirectoryCatalog searchCatalog = new DirectoryCatalog(directory, Resources.ALNamePattern);
            using (CompositionContainer compositionContainer = new CompositionContainer(searchCatalog))
            {
                var lazyInstances = compositionContainer.GetExports<IMetadataProvider>();
                foreach (var lazyInstance in lazyInstances)
                {
                    yield return lazyInstance.Value;
                }
            }
        }
    }
}
