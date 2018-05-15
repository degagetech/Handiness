using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Handiness.Orm
{
    public class SchemaCacheBuilder
    {
        private static Type _IgnoreAttrType = typeof(IgnoreAttribute);
        private static Type _TableAttrType = typeof(TableAttribute);
        private static Type _ColumnAttrType = typeof(ColumnAttribute);
        /// <summary>
        /// 通过附加在指定类及其属性上的特性获取相关Schema缓存信息
        /// </summary>
        public static SchemaCache CreateByAttribute(Type type)
        {
            SchemaCache cache = new SchemaCache();
            cache.Type = type;
            cache.PropertyAccessor = new PropertyAccessor();


            //获取类符合要求的属性
            cache.PropertyInfos = cache.Type.GetProperties()?.Where(PropertyFilter)?.ToArray();
            cache.TableSchema = GetTableSchema(cache.Type);
            if (cache.PropertyInfos != null)
            {
                cache.PropertyAccessor.Initlialize(cache.PropertyInfos.Length);
                foreach (PropertyInfo propertyInfo in cache.PropertyInfos)
                {
                    ColumnSchema schema = GetColumnSchema(propertyInfo);
                    cache.PropertyAccessor.BuildingGetPropertyCache(propertyInfo);
                    cache.PropertyAccessor.BuildingSetPropertyCache(propertyInfo);
                    cache.ColumnSchemas.Add(propertyInfo.Name, schema);
                    cache.ColumnNames.Add(schema.Name);

                }
            }
            return cache;
        }

        private static TableSchema ConvertToTableSchema(TableAttribute attribute)
        {
            TableSchema schema = new TableSchema();
            schema.Name = attribute.Name;
            //...
            return schema;
        }
        private static ColumnSchema ConvertToColumnSchema(ColumnAttribute attribute)
        {
            ColumnSchema schema = new ColumnSchema();
            schema.Name = attribute.Name.Trim();
            schema.IsPrimaryKey = attribute.IsPrimaryKey;
            schema.DbType = attribute.DbType;
            schema.DisableColumnSpecifically = attribute.DisableColumnSpecifically;
            return schema;
        }
        /// <summary>
        /// 通过类的属性信息构造一个<see cref="ColumnSchema"/> 对象
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <returns></returns>
        private static ColumnSchema GetColumnSchema(PropertyInfo propertyInfo)
        {
            ColumnSchema schema = null;
            Object[] attrs = propertyInfo.GetCustomAttributes(_ColumnAttrType, true);
            if (attrs.Length > 0)
            {
                ColumnAttribute attr = attrs[0] as ColumnAttribute;
                schema = ConvertToColumnSchema(attr);
            }
            else
            {
                schema = DeduceColumnSchema(propertyInfo);
            }
            return schema;
        }
        /// <summary>
        /// 通过附加在类上的特性信息获取Schema
        /// </summary>
        private static TableSchema GetTableSchema(Type modelType)
        {
            TableSchema schema = null;
            Object[] attrs = modelType.GetCustomAttributes(_TableAttrType, true);
            TableAttribute tableAttribute = null;
            if (attrs.Length > 0)
            {
                tableAttribute = attrs[0] as TableAttribute;
                schema = ConvertToTableSchema(tableAttribute);
            }
            else
            {
                //若不存在表特性，则使用名称推断构造一个比较简单 Schema
                schema = DeduceTableSchema(modelType);
            }
            return schema;
        }
        /// <summary>
        ///筛出附加<see cref="IgnoreAttribute"/>特性的属性
        /// </summary>
        private static Boolean PropertyFilter(PropertyInfo info)
        {
            Boolean passed = true;
            Object[] attrs = info.GetCustomAttributes(_IgnoreAttrType, true);
            if (attrs.Length > 0)
            {
                passed = false;
            }
            return passed;
        }
        /// <summary>
        /// 使用类型信息简单推断出 <see cref="TableSchema"/> 信息
        /// </summary>
        private static TableSchema DeduceTableSchema(Type modelType)
        {
            TableSchema schema = new TableSchema();
            schema.Name = DeduceName(modelType.Name);
            return schema;
        }
        /// <summary>
        /// 使用属性信息简单推断出 <see cref="ColumnSchema"/> 信息
        /// </summary>
        private static ColumnSchema DeduceColumnSchema(PropertyInfo propertyInfo)
        {
            ColumnSchema schema = new ColumnSchema();
            schema.Name = DeduceName(propertyInfo.Name);
            return schema;
        }
        /// <summary>
        /// 根据原始名称推导其在数据库中的名称
        /// </summary>
        /// <param name="original">帕斯卡名称格式</param>
        /// <returns>例如 UserId 会推导为 user_id </returns>
        private static String DeduceName(String original)
        {
            StringBuilder builder = new StringBuilder();
            for (Int32 i = 0; i < original.Length; ++i)
            {
                Char c1 = original[i];
                if (Char.IsUpper(original[i]))
                {
                    if (i != 0) builder.Append('_');
                    c1 = Char.ToLower(original[i]);
                }
                builder.Append(c1);
            }
            return builder.ToString();
        }
    }
}

