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
    * 本接口规范描述：用于生成SQL字符串
    *  -------------------------------------------------------------------------*/
    /// <summary>
    ///表示用于生成SQL字符串，解析Lamdba表达式，提取SQL参数等功能的最小功能点
    /// </summary>
    public interface ISQLNode
    {
        /// <summary>
        /// 获取此SQL结点包含的SQL
        /// </summary>
        /// <returns></returns>
        String GetSQLString();
        /// <summary>
        /// 获取此结点的Hash字符串
        /// </summary>
        /// <returns></returns>
        String HashCode();
        /// <summary>
        /// 获取或设置此结点所在的<see cref="ISQLChain"/>
        /// </summary>
        ISQLChain Chain { get; set; }
    }
}
