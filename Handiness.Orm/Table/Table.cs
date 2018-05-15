using System;
using System.Collections.Generic;
using System.Reflection;

namespace Handiness.Orm
{
    public class Table
    {
        /// <summary>
        /// 获取或设置此表对象关联的<see cref="DbProvider"/>对象
        /// </summary>
        public DbProvider DbProvider { get; set; }

        public Table(DbProvider dbProvider)
        {
            this.DbProvider = dbProvider;
        }
    }
    public class Table<T> : Table where T : class
    {
        /// <summary>
        /// 表结构信息缓存
        /// </summary>
        public static SchemaCache Schema { get; } = GetSchemaCache();
        public static InstanceCreator<T> Creator = new InstanceCreator<T>();

  
        public static SchemaCache GetSchemaCache()
        {
            return SchemaCacheBuilder.CreateByAttribute(typeof(T));
        }

        public Table(DbProvider dbProvider) : base(dbProvider)
        {

        }
    }


    /******************************************/

}
