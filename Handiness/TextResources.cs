using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
[assembly:SuppressIldasm]

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
        /// <summary>
        /// 数据库适配层程序集名称样式
        /// </summary>
        public const String ALNamePattern = "Handiness.*.dll";

        public const String ALNameGuidWithEmpty = "数据库适配层guid为空";
        public const String ColumnNameWithEmpty = "空的列名";
        public const String ConnectionStringWithEmpty = "空的连接字符串";
        public const String TableNameWithEmpty = "空的表名";

        public const String DeserializationSchemaFailedPattern = "在反序列化 {0} 中的Schema信息时失败";
      
    }
}
