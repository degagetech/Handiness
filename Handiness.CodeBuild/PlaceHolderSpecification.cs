using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handiness.CodeBuild
{
    /*-------------------------------------------------------------------------
 * 版权所有：王浪静
 * 作者：王浪静
 * 联系方式：932444208@qq.com
 * 创建时间： 2017/8/6 14:17:18
 * 版本号：v1.0
 * .NET 版本：4.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/
    /// <summary>
    /// 占位符规范信息，用于为代码模板中的数据填充提供一个规范
    /// </summary>
    public class PlaceHolderSpecification
    {
        /// <summary>
        /// 名称空间
        /// </summary>
        public const String NameSpace = "namespace";
        /// <summary>
        /// 表名
        /// </summary>
        public const String TableName = "tablename";
        /// <summary>
        /// 表描述
        /// </summary>
        public const String TableExplain  = "tableexplain";
        /// <summary>
        /// 类名
        /// </summary>
        public const String ClassName = "classname";
        /// <summary>
        /// 列名
        /// </summary>
        public const String ColumnName = "columnname";
        /// <summary>
        /// 属性名称
        /// </summary>
        public const String PropertyName = "propertyname";
        /// <summary>
        /// 字段名称
        /// </summary>
        public const String FieldName = "fieldname";
        /// <summary>
        /// 列描述
        /// </summary>
        public const String ColumnExplain = "columnexplain";
        /// <summary>
        /// 列类型
        /// </summary>
        public const String ColumnType = "columntype";
        /// <summary>
        /// 列映射类型
        /// </summary>
        public const String MappingType = "mappingtype";
        /// <summary>
        /// 列长度
        /// </summary>
        public const String ColumnLength = "columnlength";
    }
}
