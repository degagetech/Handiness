using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Handiness.CodeBuild
{
    /*-------------------------------------------------------------------------
 * 版权所有：王浪静
 * 作者：王浪静
 * 联系方式：932444208@qq.com
 * 创建时间： 2017/7/21 15:11:18
 * 版本号：v1.0
 * .NET 版本：4.0
 * 本类主要用途描述：管理数据库类型到实体属性类型的映射
 *  -------------------------------------------------------------------------*/
    /// <summary>
    /// 管理数据库类型到实体属性类型的映射
    /// </summary>
    public class TypeMapper
    {
      
        /// <summary>
        /// 当数据库类型长度为此值时，<see cref="TypeMapper"/>忽略长度匹配条件
        /// </summary>
        internal const Int32 IgnorableTypeLength = -1;

        protected Dictionary<String, String> _typeMappingDic = new Dictionary<String, String>();

        public TypeMapper(TypeMappingXml typeMapping)
        {
            foreach (TypeMappingNodeXml node in typeMapping.MappingNodes)
            {
                this.Add(node);
            }
        }
        public TypeMapper(String fileNames) : this(TypeMappingXml.Load(fileNames).First())
        {
        }
        /************************************/
        protected void Add(String type, String mappingType)
        {
            if (!String.IsNullOrWhiteSpace(type)
                && !this._typeMappingDic.ContainsKey(type))
            {
                this._typeMappingDic.Add(type, mappingType);
            }
        }
        protected void Add(TypeMappingNodeXml node)
        {
            String type = this.GenerateKey(node.DbType, node.Length);
            String mappingType = node.MappingType;
            this.Add(type, mappingType);

        }
        protected String GenerateKey(String dbType, Int32 length = -1)
        {
            String key = dbType;
            if (length > TypeMapper.IgnorableTypeLength)
            {
                key += length;
            }
            return key;
        }
        protected String GetMappingType(String key)
        {
            String mappingType = null;
            if (this._typeMappingDic.ContainsKey(key))
            {
                mappingType = this._typeMappingDic[key];
            }
            return mappingType;
        }
        /************************************/
        /// <summary>
        /// 返回此数据库类型映射后的类型,若无返回 null
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        /// <param name="length">数据库类型长度</param>
        public String Mapping(String dbType, Int32 length = -1)
        {
            String mappingType = String.Empty;
            String key = this.GenerateKey(dbType, length);
            mappingType = this.GetMappingType(key);
            return mappingType;
        }
        /************************************/
     
    }
}
