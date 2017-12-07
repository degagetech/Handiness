using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Handiness.Orm
{
    /// <summary>
    ///保证压入到执行器的一批SQL操作执行的事务性，这一批SQL操作要么都成功要么都失败
    /// </summary>
    public interface ITransactionExecutor
    {

        /// <summary>
        /// 表示当前事务执行器中包含的SQL组件的数量
        /// </summary>
        Int32 Count { get; }

        /// <summary>
        /// 将SQL组件添加到事务执行器，注意在事务执行器执行时此操作应该是无效的
        /// </summary>
        void Push(SQLComponent componect);
        ///// <summary>
        ///// 将插入对象转换成SQL组件后插入到事务执行器
        ///// </summary>
        ///// <param name="obj">需要插入的对象</param>
        //void InsertPush(T obj);
        /// <summary>
        /// 执行事务执行器包含的所有SQL组件
        /// </summary>
        /// <returns>表示事务执行成功与否</returns>
        Boolean Execute();
    }

}
