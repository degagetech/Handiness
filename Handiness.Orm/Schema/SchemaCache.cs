using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Handiness.Orm
{
    /// <summary>
    /// 存储类相关Schema信息的缓存
    /// </summary>
    public class SchemaCache
    {
        public PropertyAccessor PropertyAccessor { get; set; }
  
        public String TableName
        {
            get => this.TableSchema.Name;
        }

        public String this[String propertyName]
        {
            get
            {
                return this.GetColumnName(propertyName);
            }
        }

        public Type Type { get; set; }

        public TableSchema TableSchema { get; set; }

        /// <summary>
        /// Key为属性名
        /// </summary>
        public Dictionary<String, ColumnSchema> ColumnSchemas { get; set; } = new Dictionary<String, ColumnSchema>();
        /// <summary>
        /// 列名集合
        /// </summary>
        public List<String> ColumnNames { get; set; } = new List<String>();


        public PropertyInfo[] PropertyInfos { get; set; }

        public IEnumerable<ColumnSchema> GetColumnSchemas()
        {
            return this.ColumnSchemas.Values;
        }
        /// <summary>
        /// 通过属性名称获取映射的列名称，若无返回空引用
        /// </summary>
        public String GetColumnName(String propertyName)
        {
            if (this.ColumnSchemas.ContainsKey(propertyName))
            {
                return this.ColumnSchemas[propertyName].Name;
            }
            return null;
        }

        /// <summary>
        /// 通过属性名称获取映射的<see cref="ColumnSchema"/>信息，若无返回空引用
        /// </summary>
        public ColumnSchema GetColumnSchema(String propertyName)
        {
            if (this.ColumnSchemas.ContainsKey(propertyName))
            {
                return this.ColumnSchemas[propertyName];
            }
            return null;
        }


        public SchemaCache()
        {

        }
    }

}
