using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq.Expressions;

namespace Handiness.Orm
{
    /// <summary>
    /// 基础继动器接口
    /// </summary> IServomotor<T>
    /// <typeparam name="T">模型类</typeparam>
    public interface IServomotor<T> where T : class
    {
        /// <summary>
        /// 获取或设置继动器使用的连接
        /// </summary>
        DbConnection Connection { get; set; }
        /// <summary>
        /// 获取或设置继动器使用的Command
        /// </summary>
        DbCommand Command { get; set; }
        /// <summary>
        /// 获取继动器当前包含的Sql 字符串
        /// </summary>
        String CurrentContainedSql { get; }
        /// <summary>
        /// 获取或设置继动器的Selector
        /// </summary>
        Expression<Func<T, dynamic>> Selector { get; set; }

        DbProvider DbProvider { get; }
        /// <summary>
        /// 附加sql
        /// </summary>
        void AppendSql(String sql);
        /// <summary>
        /// 附加参数
        /// </summary>
        void AppendDbParameters(IEnumerable<DbParameter> parameters);
        /// <summary>
        ///获取继动器当前包含的参数的集合
        /// </summary>
        List<DbParameter> DbParameterCollection { get; }
        IServomotor<T> Where(String whereSql, IEnumerable<DbParameter> parameters = null);
        IServomotor<T> Where(Expression<Func<T, Boolean>> predicate);
        /// <summary>
        /// 传入连接字符串，缺省的话使用 Table对象绑定的 DbProvider 的 连接字符串
        /// </summary>
        ISelectResultVector<T> ExecuteReader(String connectionString = null);
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
