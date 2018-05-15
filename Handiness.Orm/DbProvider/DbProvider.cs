using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Collections.Concurrent;
using System.Data.SqlClient;
using System.Configuration;
namespace Handiness.Orm
{

    /// <summary>
    /// 提供一系列用于操作数据库的辅助对象，默认提供SQL Server数据库的访问
    /// </summary>
    public class DbProvider
    {

        /// <summary>
        /// 创建 DbProvider 类的实例，并为其指定名称、关联的数据库连接字符串
        /// </summary>
        /// <param name="name">DbProvider对象的名称</param>
        /// <param name="connectionString">DbProvider关联的连接字符串</param>
        public DbProvider(String name, String connectionString)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            this.Name = name;
            this.ConnectionString = connectionString;

        }
        /// <summary>
        ///数据库提供者的名称
        /// </summary>
        public String Name { get; } = String.Empty;

        /// <summary>
        /// 获取或设置此数据库提供者关联的数据库连接字符串
        /// </summary>
        public String ConnectionString { get; set; } = String.Empty;

        /// <summary>
        /// 提供一个用于访问数据库的连接对象
        /// </summary>
        /// <param name="connectionString">连接的字符串，若空则使用对象本身包含的连接字符串</param>
        /// <param name="isRelevance">是否将此新的连接字符串与此DbProvider对象，空的连接字符串不会关联</param>
        /// <returns></returns>
        public virtual DbConnection DbConnection(String connectionString = null, Boolean isRelevance = false)
        {
            SqlConnection sqlConnection = connectionString == null ? new SqlConnection(this.ConnectionString) : new SqlConnection(connectionString);
            if (isRelevance && !String.IsNullOrEmpty(connectionString))
            {
                this.ConnectionString = connectionString;
            }

            return sqlConnection;
        }
        public virtual DbCommand DbCommand(String commandText = null, DbParameter[] dbParameterArray = null)
        {
            SqlCommand sqlCommand = new SqlCommand
            {
                CommandText = commandText
            };
            if (dbParameterArray != null && dbParameterArray.Length > 0)
            {
                sqlCommand.Parameters.AddRange(dbParameterArray);
            }
            return sqlCommand;
        }

        public virtual DbParameter DbParameter(String name = null, Object value = null, DbType dbType = DbType.Object)
        {
            SqlParameter sqlParameter = new SqlParameter
            {
                ParameterName = name,
                Value = value
            };
            if (dbType != DbType.Object)
            {
                sqlParameter.DbType = dbType;
            }
            //   sqlParameter.DbType = dbType;
            return sqlParameter;
        }
        /// <summary>
        /// SQL参数对象名称前导符
        /// </summary>
        public virtual String Prefix { get; } = "@";
        /// <summary>
        /// 用于避免关键词与表字段冲突
        /// </summary>
        public virtual String ConflictFreeFormat { get; set; } = "[{0}]";
        /// <summary>
        /// 创建一个新的传动器
        /// </summary>
        public virtual IDriver<T> Driver<T>() where T : class => ObjectFactory._.Driver<T>(this);

        /// <summary>
        /// 创建一个新的事务执行器
        /// </summary>
        public virtual ITransactionExecutor TransactionExecutor() => ObjectFactory._.TransactionExecutor(this);
    }

}
