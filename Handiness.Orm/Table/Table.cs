﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace Handiness.Orm
{
    public class Table<T> where T : class
    {
        /// <summary>
        /// 表结构信息缓存
        /// </summary>
        public static SchemaCache<T> Schema { get; } = GetSchemaCache();

        public static SchemaCache<T> GetSchemaCache()
        {
            return SchemaCacheBuilder.CreateByAttribute<T>();
        }

        /// <summary>
        /// 获取或设置此表对象关联的<see cref="DbProvider"/>对象
        /// </summary>
        public DbProvider DbProvider { get; set; }




        public Table(DbProvider dbProvider)
        {
            this.DbProvider = dbProvider;
        }
    }

  
    /******************************************/
  
}
