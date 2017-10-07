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
            if (!String.IsNullOrWhiteSpace(type) &&
                !String.IsNullOrWhiteSpace(mappingType)
                && !this._typeMappingDic.ContainsKey(type))
            {
                this._typeMappingDic.Add(type, mappingType);
            }
        }
        public void Add(TypeMappingNodeXml node)
        {
            String type = this.GenerateKey(node);
            String mappingType = node.MappingType.Trim();
            this.Add(type, mappingType);

        }
        protected String GenerateKey(TypeMappingNodeXml node)
        {
            //String key = this.ProcessDbTypeString(node.DbType);
            //if (node.Length != IgnorableTypeLength)
            //{
            //    key +="_"+node.Length.ToString();
            //}
            //return key;
            return this.GenerateKey(node.DbType, node.Length);
        }
        protected String GenerateKey(String dbType, String length)
        {
            String key = this.ProcessDbTypeString(dbType);
            if (!String.IsNullOrEmpty(length))
            {
                key += length;
            }
            return key;
        }
        protected String ProcessDbTypeString(String dbType)
        {
            return dbType.Trim().ToLower();
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
        /// <param name="length">数据库类型的长度信息</param>
        public String Mapping(String dbType, String length)
        {
            String mappingType = String.Empty;
            String key = this.GenerateKey(dbType, length);
            mappingType = this.GetMappingType(key);
            if (mappingType == null)
            {
                mappingType = this.GetMappingType(this.ProcessDbTypeString(dbType));
            }
            return mappingType;
        }
        /************************************/

    }
}
