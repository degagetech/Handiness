using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Collections.Concurrent;
using System.Data.SqlClient;
using System.Configuration;
namespace Handiness.Orm
{
    public class DbProviderCollection
    {
        private IDictionary<String, DbProvider> _dbProviderDictionary = new ConcurrentDictionary<String, DbProvider>();
        public DbProvider this[String name]
        {
            get
            {
                DbProvider dbProvider = null;
                if (this._dbProviderDictionary.ContainsKey(name))
                {
                    dbProvider = this._dbProviderDictionary[name];
                }
                return dbProvider;
            }
        }
        /// <summary>
        /// 确定集合中是否包含指定名称的DbProvider对象
        /// </summary>
        /// <param name="name">名称</param>
        public Boolean ContainsKey(String name)
        {
            return this._dbProviderDictionary.ContainsKey(name);
        }
        /// <summary>
        /// 添加一个DbProvider对象到集合中
        /// </summary>
        /// <param name="name">Key</param>
        /// <param name="dbProvider">Value</param>
        /// <param name="replaced">如果存在是否替换，默认为false 不替换</param>
        public void Add(String name, DbProvider dbProvider, Boolean replaced = false)
        {
            if (!this._dbProviderDictionary.ContainsKey(name))
            {
                this._dbProviderDictionary.Add(name, dbProvider);
            }
            else
            {
                if (replaced)
                {
                    this._dbProviderDictionary[name] = dbProvider;
                }
                else
                {
                    throw new System.Exception("DbProvider with the same name already exists!");
                }
            }
        }
        /// <summary>
        ///将指定名称的DbProvider对象从集合中移除，如果指定的Key不存在，则不会有任何操作
        /// </summary>
        /// <param name="name">名称</param>
        public void Remove(String name)
        {
            if (this._dbProviderDictionary.ContainsKey(name))
            {
                this._dbProviderDictionary.Remove(name);
            }
        }
        /// <summary>
        /// 清除集合中所有的DbProvider对象
        /// </summary>
        public void Clear()
        {
            this._dbProviderDictionary.Clear();
        }

    }
    public class DbProvider
    {

        private static DbProviderCollection _DbProviderCollection = new DbProviderCollection();
        /// <summary>
        /// 存放数据库提供者对象的集合
        /// </summary>
        public static DbProviderCollection DbProviderCollection
        {
            get
            {
                
                return _DbProviderCollection;
            }
        }
        /********************/

        /// <summary>
        /// 创建 DbProvider 类的实例，并为其指定名称、关联的数据库连接字符串
        /// </summary>
        /// <param name="name">DbProvider对象的名称</param>
        /// <param name="connectionString">DbProvider关联的连接字符串</param>
        /// <param name="replaced">如果已存在指定名称的DbProvider是否要将其替换 默认为fasle</param>
        public DbProvider(String name, String connectionString, Boolean replaced = false, Boolean saved = false)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("The name specified for the DbProvider object can not be null!");
            }
            this.Name = name;
            this.ConnectionString = connectionString;
            if (saved)
            {
                _DbProviderCollection.Add(name, this, replaced);
            }
        }
        /// <summary>
        /// 创建 DbProvider 类的实例，并为其指定名称，并在配置文件中寻找此名称的数据库连接字符串
        /// </summary>
        /// <param name="name">DbProvider对象的名称</param>
        /// <param name="isReplace">如果已存在指定名称的DbProvider是否要将其替换 默认为fasle</param>
        public DbProvider(String name, Boolean isReplace = false)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("The name specified for the DbProvider object can not be null!");
            }
            this.Name = name;
            String connectionString = ConfigurationManager.ConnectionStrings[this.Name].ConnectionString;
            if (String.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException("The connection string for the DbProvider object can not be null!");
            }
            this.ConnectionString = connectionString;
            _DbProviderCollection.Add(name, this, isReplace);
        }
        /// <summary>
        ///获取此数据库提供者的名字
        /// </summary>
        public String Name { get; } = String.Empty;

        /// <summary>
        /// 获取或设置此数据库提供者关联的数据库连接字符串
        /// </summary>
        public String ConnectionString { get; set; } = String.Empty;

        /// <summary>
        /// 提供一个用于访问数据库的连接
        /// </summary>
        /// <param name="connectionString">连接的字符串</param>
        /// <param name="isRelevance">是否将此新的连接字符串与此DbProvider对象，注意空的连接字符串不会关联</param>
        /// <returns></returns>
        public virtual DbConnection DbConnectionFactroy(String connectionString = null, Boolean isRelevance = false)
        {
            SqlConnection sqlConnection = connectionString == null ? new SqlConnection(this.ConnectionString) : new SqlConnection(connectionString);
            if (isRelevance && !String.IsNullOrEmpty(connectionString))
            {
                this.ConnectionString = connectionString;
            }
        
            return sqlConnection;
        }
        public virtual DbCommand DbCommandFactroy(String commandText = null, DbParameter[] dbParameterArray = null)
        {
   
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = commandText;
            if (dbParameterArray != null && dbParameterArray.Length > 0)
            {
                sqlCommand.Parameters.AddRange(dbParameterArray);
            }
            return sqlCommand;
        }
        public virtual DbParameter DbParameterFactroy(String name = null, DbType dbType = DbType.Object, Object value = null)
        {
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = name;
            sqlParameter.DbType = dbType;
            sqlParameter.Value = value;
            return sqlParameter;
        }
        public virtual String PrefixParameterName { get; } = "@";
        /// <summary>
        /// 继动器工厂
        /// </summary>
        public virtual IServomotor<T> ServomotorFactroy<T>() where T : class => new Servomotor<T>(this);
    }

}
