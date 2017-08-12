using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using Handiness;
using System.Data;
using System.Diagnostics;

namespace Handiness.Metadata
{
    /*-------------------------------------------------------------------------
 * 版权所有：王浪静
 * 作者：王浪静
 * 联系方式：932444208@qq.com
 * 创建时间： 2017/7/14 20:51:00
 * 版本号：v1.0
 * .NET 版本：4.0
 * 本类主要用途描述：负责管理Schema信息存取以及从本地磁盘文件上的加载与存储
 * 保存到本地文件中
 *  -------------------------------------------------------------------------*/
    /// <summary>
    /// Schema信息管理者
    /// </summary>
    public class SchemaManager
    {
    

        private MetadataContainer _metadataContainer = null;
        /*********************************/
        /// <summary>
        /// 构造一个SchemaBuffer实例
        /// </summary>
        /// <param name="container"><see cref="IMetadataContainer"/>的实例，可以传入null以使用默认实例</param>
        /// <param name="files">含有schema信息的文件列表</param>
        public SchemaManager(IMetadataContainer container, params String[] files)
        {
            if (container == null)
            {
                this._metadataContainer = new MetadataContainer();
            }
            IEnumerable<SchemaXml> schemaXmls = SchemaManager.Load(files);
            foreach (SchemaXml schemaXml in schemaXmls)
            {
                foreach (TableSchemaXml tabSchema in schemaXml.Tables)
                {
                    if (this._metadataContainer.AddTableSchema(schemaXml.DbName, tabSchema.Key, tabSchema.Schema))
                    {
                        foreach (ColumnSchemaXml colSchema in tabSchema.Columns)
                        {
                            this._metadataContainer.AddColumnSchema(schemaXml.DbName,
                                tabSchema.Key, colSchema.Key,
                               colSchema.Schema);
                        }
                    }
                }
            }
        }
        public virtual ColumnSchema this[String columnKey, String tableKey = null, String fileName = null]
        {
            get
            {
                return this.GetColumnSchema(columnKey, tableKey, fileName);
            }
        }
        public TableSchema GetTableSchema(String tableKey, String dbName = null)
        {
            return this._metadataContainer.GetTableSchema(tableKey, dbName);
        }
        /// <summary>
        /// 从已有的Schema信息中返回一个满足条件的<see cref="ColumnSchema"/>信息，当条件不全时，返回遇到的第一个满足条件值
        /// </summary>
        /// <param name="columnKey">必须的,通常使用实体类的属性名称</param>
        /// <param name="tableKey">可选的，通常使用实体类的名称</param>
        /// <param name="dbName">可选的，通常使用数据库名称</param>
        /// <returns>含有结构信息<see cref="ColumnSchema"/>实例</returns>
        public ColumnSchema GetColumnSchema(String columnKey, String tableKey = null, String dbName = null)
        {
            return this._metadataContainer.GetColumnSchema(columnKey, tableKey, dbName);
        }
        /// <summary>
        /// 从本地磁盘文件中加载Schema信息
        /// </summary>
        /// <param name="files">文件列表</param>
        public static IEnumerable<SchemaXml> Load(params String[] files)
        {
            return TKXmlSerializer.Load<SchemaXml>(files);
        }
        /// <summary>
        /// 将内存中的Schema信息保存到本地磁盘上
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="schemas">schema信息</param>
        public static void Save(String path, params SchemaXml[] schemas)
        {
            path = path.EndsWith("\\") ? path : path + "\\";
            foreach (var schema in schemas)
            {
                String fileName = String.Format(SchemaXml.SchemaFileNamePattern, schema.DbName);
                String filePath = path + fileName;
                File.Delete(filePath);
                TKXmlSerializer.Serialize<SchemaXml>(schema, filePath);
            }
        }
    }
}
