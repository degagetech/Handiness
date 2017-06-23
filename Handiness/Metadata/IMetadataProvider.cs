using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handiness.Metadata
{
    public interface IMetadataProvider : IDisposable
    {
        /// <summary>
        /// 元数据提供者的版本信息，适配的数据库名称与数字的组合，例如 MariaDB1.0
        /// </summary>
        String Version { get; }
        /// <summary>
        /// 元数据提供者的描述信息
        /// </summary>
        String Explain { get; }

        /// <summary>
        /// 打开数据库连接
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        void Open(String connectionString);
        /// <summary>
        /// 关闭连接，并释放资源
        /// </summary>
        void Close();

        /// <summary>
        /// 获取所连接的数据库的所有表结构信息
        /// </summary>
        /// <returns></returns>
        IList<TableSchema> GetTableSchemas();
        /// <summary>
        /// 获取所连接的数据库的指定表的所有列信息
        /// </summary>
        /// <param name="tableName">指定的表名</param>
        /// <returns></returns>
        IList<ColumnSchema> GetColumnSchemas(String tableName);

    }
}
