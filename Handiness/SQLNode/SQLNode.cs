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
    * 本接口规范描述：用于SQL生成的功能点
    *  -------------------------------------------------------------------------*/

    public abstract class SQLNode<T> where T : RowBase
    {
        public SchemaCourier<T> SchemaCourier { get; set; } = null;
        public SQLCourier SQLCourier { get; set; } = null;
        public abstract SQLNodeType NodeType { get; protected set; }
        public abstract Int32 NodeLevel { get; protected set; }

        /// <summary>
        /// 主线节点
        /// </summary>
        public SQLNode<T> Left { get; set; }
        /// <summary>
        /// 支线节点
        /// </summary>
        public SQLNode<T> Right { get; set; }
    }
}
