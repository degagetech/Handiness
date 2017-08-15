using System;
using System.Collections;
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
    /// 表示一组当前可在代码模板中识别并替换的占位符信息
    /// </summary>
    public class PlaceHolderRecognizableCollection
    {
        protected static Dictionary<String, String> PlaceHolderDic = new Dictionary<String, String>
        {
                  { nameof(NameSpace),"namespace"},
                  { nameof(TableName),"tablename"},
                  { nameof(TableExplain),"tableexplain"},
                  { nameof(ClassName),"classname"},
                  { nameof(ColumnName),"columnname"},
                  { nameof(PropertyName),"propertyname"},
                  { nameof(FieldName),"fieldname"},
                  { nameof(ColumnExplain),"columnexplain"},
                  { nameof(ColumnType),"columntype"},
                  { nameof(MappingType),"mappingtype"},
                  { nameof(ColumnLength),"columnlength"}
        };

        /// <summary>
        /// 名称空间
        /// </summary>
        public static String NameSpace
        {
            get => PlaceHolderDic[nameof(NameSpace)];
        }
        /// <summary>
        /// 表名
        /// </summary>
        public static String TableName
        {
            get => PlaceHolderDic[nameof(TableName)];
        }
        /// <summary>
        /// 表描述
        /// </summary>
        public static String TableExplain
        {
            get => PlaceHolderDic[nameof(TableExplain)];
        }
        /// <summary>
        /// 类名
        /// </summary>
        public static String ClassName
        {
            get => PlaceHolderDic[nameof(ClassName)];
        }
        /// <summary>
        /// 列名
        /// </summary>
        public static String ColumnName
        {
            get => PlaceHolderDic[nameof(ColumnName)];
        }
        /// <summary>
        /// 属性名称
        /// </summary>
        public static String PropertyName
        {
            get => PlaceHolderDic[nameof(PropertyName)];
        }
        /// <summary>
        /// 字段名称
        /// </summary>
        public static String FieldName
        {
            get => PlaceHolderDic[nameof(FieldName)];
        }
        /// <summary>
        /// 列描述
        /// </summary>
        public static String ColumnExplain
        {
            get => PlaceHolderDic[nameof(ColumnExplain)];
        }
        /// <summary>
        /// 列类型
        /// </summary>
        public static String ColumnType
        {
            get => PlaceHolderDic[nameof(ColumnType)];
        }
        /// <summary>
        /// 列映射类型
        /// </summary>
        public static String MappingType
        {
            get => PlaceHolderDic[nameof(MappingType)];
        }
        /// <summary>
        /// 列长度
        /// </summary>
        public static String ColumnLength
        {
            get => PlaceHolderDic[nameof(ColumnLength)];
        }

    }
}
