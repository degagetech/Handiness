using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq.Expressions;

namespace Handiness.Orm
{
    /// <summary>
    /// 基础SQL传动器接口
    /// <typeparam name="T">模型类</typeparam>
    public interface IDriver<T> where T : class
    {
        /// <summary>
        /// 获取传动器当前包含的SQL组件
        /// </summary>
        SQLComponent SQLComponent { get; }
        /// <summary>
        /// 获取或设置传动器使用的连接
        /// </summary>
        DbConnection Connection { get; set; }
        /// <summary>
        /// 获取或设置传动器使用的<see cref="DbCommand"/>对象
        /// </summary>
        DbCommand Command { get; set; }

        DbProvider DbProvider { get; }

        IDriver<T> Where(String whereSql, IEnumerable<DbParameter> parameters = null);
        IDriver<T> Where(Expression<Func<T, Boolean>> predicate);
        /// <summary>
        /// 传入连接字符串，缺省的话使用 Table对象绑定的 DbProvider 的 连接字符串
        /// </summary>
        ISelectVector<T> ExecuteReader(String connectionString = null);
        /// <summary>
        /// 执行非查询操作
        /// </summary>
        /// <returns></returns>
        Int32 ExecuteNonQuery(String connectionString = null);
        /// <summary>
        /// 执行查询，只返回第一行的第一列，忽略其他行和列
        /// </summary>
        /// <returns></returns>
        Object ExecuteScalar(String connectionString = null);
        /// <summary>
        /// 执行非查询操作
        /// </summary>
        /// <returns></returns>
        Int32 ExecuteNonQuery(DbConnection connection);
    }
}
