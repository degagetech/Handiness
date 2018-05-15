using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq.Expressions;

namespace Handiness.Orm
{
    /// <summary> 
    /// 查询容器，用于获取查询结果，注意！结果获取函数调用一次后其他同类函数调用无效
    /// </summary>
    public interface ISelectVector<T> : IDisposable
    {

        DataSet ToDataSet();
        DataTable ToDataTable();

        /// <summary>
        /// 将查询结果转换成一个<see cref="List{T}"/>类型链表，无结果则返回一个包含零个对象的链表，
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

        T Single();
  
        /// <summary>
        /// 关闭对象并释放占用的资源
        /// </summary>
        void Close();
    }
}
