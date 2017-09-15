
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections.Concurrent;
using System.Data.Common;

namespace Handiness.Orm
{
    public class WriteTransactionExecutor<T> : ITransactionExecutor<T> where T : class
    {
        public Int32 BufferMaximum
        {
            get; protected set;
        }

        public Int32 CurrentBufferCount
        {
            get { return this._buffer.Count; }
        }

        public Int32 Sum
        {
            get; protected set;
        }
        /********************************/
        protected Table<T> _table;
        protected List<T> _buffer = new List<T>();
        protected String _connectionString ;
        internal WriteTransactionExecutor(Table<T> tableObj, Int32 maximum,String connectionString=null)
        {
            if (null == (this._connectionString = connectionString))
            {
                this._connectionString = tableObj.BindingDbProvider.ConnectionString;
                if (String.IsNullOrEmpty(this._connectionString))
                {
                    throw new ArgumentException("Db connection string is  invalid!");
                }
            }
            this._table = tableObj;
            this.BufferMaximum = maximum;
        }
        public virtual void Flush()
        {
            Int32 affect = 0;
            using (DbConnection connection = this._table.BindingDbProvider.DbConnectionFactroy(this._connectionString))
            {
                connection.Open();
                DbTransaction tansaction = connection.BeginTransaction();
                try
                {
                    foreach (T obj in this._buffer)
                    {
                        affect+=this._table.Insert(obj).ExecuteNonQuery(connection);
                    }
                    tansaction.Commit();
                }
                catch
                {
                    tansaction.Rollback();
                    affect = 0;
                    throw;
                }
            } 
            this.Sum += affect;
            if (affect == this._buffer.Count)
            {
                this._buffer.Clear();
            }
        }

        public void BulkPush(IEnumerable<T> objs)
        {
            this._buffer.AddRange(objs);
            if (this.CurrentBufferCount > this.BufferMaximum)
            {
                this.Flush();
            }
        }

        public void Push(T obj)
        {
            this._buffer.Add(obj);
            if (this.CurrentBufferCount > this.BufferMaximum)
            {
                this.Flush();
            }
        }
    }

    public class ReplaceTransactionExecutor<T> : WriteTransactionExecutor<T> where T : class
    {
        internal ReplaceTransactionExecutor(Table<T> tableObj, Int32 maximum, String connectionString = null):base(tableObj,maximum,connectionString)
        {
        }
        public override void Flush()
        {
            Int32 affect = 0;
            using (DbConnection connection = this._table.BindingDbProvider.DbConnectionFactroy(this._connectionString))
            {
                connection.Open();
                DbTransaction tansaction = connection.BeginTransaction();
                try
                {
                    foreach (T obj in this._buffer)
                    {
                        affect += this._table.Replace(obj).ExecuteNonQuery(connection);
                    }
                    tansaction.Commit();
                }
                catch
                {
                    tansaction.Rollback();
                    affect = 0;
                    throw;
                }
            }
            this.Sum += affect;
            if (affect == this._buffer.Count)
            {
                this._buffer.Clear();
            }
        }
    }
}
