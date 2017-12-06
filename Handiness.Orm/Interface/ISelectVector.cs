using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq.Expressions;

namespace Handiness.Orm
{
    /// <summary> 
    /// 查询容器，提交查询并处理查询结果
    /// </summary>
    public interface ISelectVector<T> : IDisposable
    {

        /// <summary>
        /// 查询返回的<see cref="System.Data.Common.DbDataReader"/> 
        /// </summary>
        DbDataReader DbDataReader { get; set; }
        /// <summary>
        /// 查询结果中是否包含有一行或多行
        /// </summary>
        Boolean HasRows { get; }
        /// <summary>
        /// 将查询结果转换成一个<see cref="List{T}"/>类型链表 
        /// </summary>
        /// <returns></returns>
        List<T> ToList();
        /// <summary>
        /// 返回查询结果中的第一个，如果查询结果为空则返回<see cref="T"/>类型的默认值 
        /// </summary>
        /// <returns></returns>
        T FirstOrDefault();
        /// <summary>
        /// 将查询的结果转换成一个数组
        /// </summary>
        /// <returns></returns>
        T[] ToArray();

        /// <summary>
        /// 关闭对象并释放占用的资源
        /// </summary>
        void Close();
    }
}
