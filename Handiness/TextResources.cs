using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
[assembly: SuppressIldasm]

namespace Handiness
{
    /*-------------------------------------------------------------------------
 * 版权所有：王浪静
 * 作者：王浪静
 * 联系方式：932444208@qq.com
 * 创建时间： 2017/7/17 17:29:22
 * 版本号：v1.0
 * .NET 版本：4.0
 * 本类主要用途描述：提供一系列的说明型文本资源
 *  -------------------------------------------------------------------------*/
    internal class TextResources
    {
        //名称格式
        internal const String PatternOfALDllName = "Handiness.*.dll";

        //错误信息
        internal const String ErrorOfALNameGuidWithEmpty = "数据库适配层guid为空";
        internal const String ErrorOfConnectionStringWithEmpty = "空的连接字符串";
        internal const String ErrorOfTableNameWithEmpty = "空的表名";
        internal const String ErrorOfColumnNameWithEmpty = "空的列名";

        //错误信息模板
        internal const String EFTOfDeserialization = "在反序列化 {0} 中的 {1} 信息时失败";

    }
}
