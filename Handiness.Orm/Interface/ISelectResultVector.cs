using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq.Expressions;

namespace Handiness.Orm
{
    /// <summary> 
    /// 查询结果容器
    /// </summary>
    public interface ISelectResultVector<T> : IDisposable
    {

        /// <summary>
        /// 是否含有选择器
        /// </summary>
        Boolean HasSelector { get; }
        /// <summary>
        /// 选择器
        /// </summary>
        Expression<Func<T, dynamic>> Selector { get; set; }
        /// <summary>
        /// 查询返回的<see cref="System.Data.Common.DbDataReader"/> 
        /// </summary>
        DbDataReader DbDataReader { get; set; }
        /// <summary>
        /// 查询结果中是否包含有一行或多行
        /// </summary>
        Boolean HasRows { get; }
        /// <summary>
        /// 返回一个含有查询结果的<see cref="DataTable"/>，注意使用此属性会将 <see cref="DbDataReader"/> 中的数据填充到<see cref="DataTable"/>中去
        /// </summary>
        DataTable DataTable { get; }
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
        /// 当选择器为空时请不要使用此函数，否则会一直返回一个包含零个元素的List,
        /// 可以先使用HasSelector属性查看是否有选择器
        /// </summary>
        List<dynamic> ToDynamicList();
        /// <summary>
        /// 当选择器为空时请不要使用此函数，否则会一直返回一个包含零个元素的List,
        /// 可以先使用HasSelector属性查看是否有选择器
        /// </summary>
        dynamic[] ToDynamicArray();

        /// <summary>
        /// 关闭关联的DbDataReader对象
        /// </summary>
        void Close();
    }
}
