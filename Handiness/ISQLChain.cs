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
    * 创建时间： 2017/7/6 19:16:44
    * 版本号：v1.0
    * .NET 版本：4.0
    * 本接口规范描述：一系列的  ISQLNode 的有序集合
    *  -------------------------------------------------------------------------*/
    /// <summary>
    /// 表示一系列<see cref="ISQLNode"/> 节点的有序集合
    /// </summary>
    public interface ISQLChain<T> where T : RowBase
    {
        /// <summary>
        /// 向Chain中添加节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="index">默认-1，-1 添加至尾部，0 添加至头部</param>
        void Add(ISQLNode<T> node, Int32 index = -1);
    }
}
