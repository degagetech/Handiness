using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Handiness.Orm
{
    /// <summary>
    /// 事务执行器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ITransactionExecutor<T> where T : class
    {
        /// <summary>
        /// 事务执行器的最大大小，一但插入数量大小超过此大小，事务执行器将数据持久化到数据库中，并清空缓冲区
        /// </summary>
        Int32 BufferMaximum { get; }
        Int32 CurrentBufferCount { get; }
        /// <summary>
        /// 事务执行器 已写数据的总计数，不包括缓冲区的
        /// </summary>
        Int32 Sum { get; }
        /// <summary>
        /// 将记录压入事务执行器
        /// </summary>
        /// <param name="obj"></param>
        void Push(T obj);
        void BulkPush(IEnumerable<T> objs);
        /// <summary>
        /// 刷新事务执行器缓冲区中的数据，持久化到数据库中，并清空缓冲区
        /// </summary>
        void Flush();
    }

}
