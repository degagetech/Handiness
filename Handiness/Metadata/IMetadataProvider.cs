using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handiness.Metadata
{
    /// <summary>
    /// 元数据提供者接口
    /// </summary>
    public interface IMetadataProvider : IDisposable
    {
        /// <summary>
        /// 获取当前连接的数据库的名称，若无返回 null
        /// </summary>
        String DatabaseName { get; }
        /// <summary>
        /// 元数据提供者的版本信息
        /// </summary>
        String Version { get; }
        /// <summary>
        /// 元数据提供者的描述信息
        /// </summary>
        String Explain { get; }

        /// <summary>
        /// 关闭之前的连接若有，并打开新的数据库连接
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        void Open(String connectionString);
        /// <summary>
        /// 关闭连接
        /// </summary>
        void Close();

        /// <summary>
        /// 获取所连接的数据库的所有表结构信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<TableSchema> GetTableSchemas();
        /// <summary>
        /// 获取所连接的数据库的指定表的所有列信息
        /// </summary>
        /// <param name="tableName">指定的表名</param>
        /// <returns></returns>
        IEnumerable<ColumnSchema> GetColumnSchemas(String tableName);

    }
}
