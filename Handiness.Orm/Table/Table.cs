using System;
using System.Collections.Generic;
using System.Reflection;

namespace Handiness.Orm
{
    /// <summary>
    /// 表反射的缓存
    /// </summary>
    public class TableReflectionCache<T> where T : class
    {
        public PropertyAccessor<T> PropertyAccessor { get; set; } = new PropertyAccessor<T>();
        public String TableName
        {
            get
            {
                return this.TableAttribute.Name;
            }
        }
        public Type Type { get; private set; }
        /// <summary>
        /// 表属性
        /// </summary>
        public TableAttribute TableAttribute { get; private set; }
        /// <summary>
        /// 附加在属性的列特性的集合 Key 为属性的名称 
        /// </summary>
        public IDictionary<String, ColumnAttribute> ColumnAttributeCollection { get; private set; } = new Dictionary<String, ColumnAttribute>();

        public IList<PropertyInfo> ColumnPropertyCollection { get; private set; } = new List<PropertyInfo>();
        public TableReflectionCache()
        {
            this.Type = typeof(T);
            Object[] customAttributes = null;

            //获取表特性
            customAttributes = this.Type.GetCustomAttributes(typeof(TableAttribute), true);
            this.TableAttribute = customAttributes.Length == 0 ? new TableAttribute(nameof(T)) : customAttributes[0] as TableAttribute;
            this.TableAttribute.Name = this.TableAttribute.Name ?? this.Type.Name;
            //获取列特性
            customAttributes = null;
            Type columnAttributeType = typeof(ColumnAttribute);
            PropertyInfo[] propertyInfoArray = this.Type.GetProperties();
            ColumnAttribute columnAttributeTemp = null;

            foreach (PropertyInfo propertyInfo in propertyInfoArray)
            {
                customAttributes = propertyInfo.GetCustomAttributes(columnAttributeType, true);
                if (0 != customAttributes.Length)
                {
                    columnAttributeTemp = customAttributes[0] as ColumnAttribute;
                    if (columnAttributeTemp != null)
                    {
                        //如果列特性中Name属性为空 则默认以属性名称为列名
                        columnAttributeTemp.Name = columnAttributeTemp.Name ?? propertyInfo.Name;
                        this.ColumnAttributeCollection.Add(propertyInfo.Name, columnAttributeTemp);
                        this.ColumnPropertyCollection.Add(propertyInfo);
                    }
                }
            }
        }
    }

    /******************************************/
    public class Table<T> where T : class
    {
        /// <summary>
        /// 此表类的反射缓存
        /// </summary>
        public static TableReflectionCache<T> TableReflectionCache { get; } = new TableReflectionCache<T>();
        /// <summary>
        /// 获取或设置此表对象绑定的数据库提供者对象
        /// </summary>
        public DbProvider BindingDbProvider { get; set; }

        public Table(DbProvider dbProvider = null)
        {
            if (null == dbProvider)
            {
                if (!DbProvider.DbProviderCollection.ContainsKey(TableReflectionCache.TableAttribute.BindingDbProviderName))
                {
                    throw new ArgumentNullException("You can not bind an empty DbProvider for a table object!");
                }
                this.BindingDbProvider = DbProvider.DbProviderCollection[TableReflectionCache.TableAttribute.BindingDbProviderName];
            }
            else
            {
                this.BindingDbProvider = dbProvider;
            }
        }
    }
}
