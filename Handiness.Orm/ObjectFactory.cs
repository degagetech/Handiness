using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Handiness.Orm
{
    /// <summary>
    /// 用于管理接口实现类对象的生成
    /// </summary>
    public class ObjectFactory
    {
        /// <summary>
        /// 获取此类的单例对象
        /// </summary>
        public static ObjectFactory _
        {
            get
            {
                return _Instance;
            }
        }
        private static ObjectFactory _Instance = new ObjectFactory();


        /// <summary>
        /// 返回一个实现查询容器的类的对象
        /// </summary>
        public ISelectVector<T> SelectVector<T>(IDriver<T> driver,String connectionString=null) where T : class
        {
            return new SelectVector<T>(driver, connectionString);
        }
        /// <summary>
        /// 返回一个实现查询容器的类的对象
        /// </summary>
        public ISelectVector<T> SelectVector<T>(IDriver<T> driver, DbConnection connection,DbTransaction transaction=null) where T : class
        {
            return new SelectVector<T>(driver, connection, transaction);
        }

        /// <summary>
        /// 返回一个实现传动器接口的类的对象
        /// </summary>
        public IDriver<T> Driver<T>(DbProvider dbProvider) where T : class
        {
            return new Driver<T>(dbProvider);
        }
        /// <summary>
        /// 返回一个实现事务执行器接口的类的对象
        /// </summary>
        public ITransactionExecutor TransactionExecutor(DbProvider dbProvider) 
        {
            return new TransactionExecutor(dbProvider);
        }
    }
}
