using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handiness
{
    /*-------------------------------------------------------------------------
    * 版权所有：王浪静
    * 作者：王浪静
    * 联系方式：932444208@qq.com
    * 创建时间： 2017/7/6 19:16:01
    * 版本号：v1.0
    * .NET 版本：4.0
    * 本接口规范描述：用于SQL生成的最小结点
    *  -------------------------------------------------------------------------*/
    /// <summary>
    ///表示用于生成SQL字符串，解析Lamdba表达式，提取SQL参数等功能的最小功能点
    /// </summary>
    public interface ISQLNode<T> where T : RowBase
    {
        /// <summary>
        /// 获取节点类型
        /// </summary>
        SQLNodeType NodeType { get; }
        /// <summary>
        /// 获取此SQL结点包含的SQL 字符串
        /// </summary>
        /// <returns></returns>
        String GetSQLString();
        /// <summary>
        /// 获取此结点的Hash
        /// </summary>
        /// <returns></returns>
        Int64 HashCode();
        /// <summary>
        /// 获取或设置此结点所在的<see cref="ISQLChain"/>
        /// </summary>
        ISQLChain<T> Chain { get; set; }
    }
    public enum SQLNodeType
    {
        /// <summary>
        /// 主节点
        /// </summary>
        Primary,
        /// <summary>
        /// 条件节点
        /// </summary>
        Where,
        /// <summary>
        /// 辅节点
        /// </summary>
        Assist
    }
}
