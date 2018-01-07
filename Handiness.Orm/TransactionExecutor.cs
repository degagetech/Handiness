
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections.Concurrent;
using System.Data.Common;
namespace Handiness.Orm
{
    public class TransactionExecutor : ITransactionExecutor
    {

        public Int32 Count
        {
            get { return this._buffer.Count; }
        }

        /********************************/
        protected DbProvider _provider;
        protected ConcurrentQueue<SQLComponent> _buffer = new ConcurrentQueue<SQLComponent>();
        protected Int32 _allowFlag = 1;

        public TransactionExecutor(DbProvider provider)
        {
            this._provider = provider;
        }
        public virtual Boolean Execute()
        {
            Boolean successed = false;
            Interlocked.Exchange(ref this._allowFlag, 0);
            using (DbConnection connection = this._provider.DbConnection())
            {
                connection.Open();
                DbTransaction tansaction = connection.BeginTransaction();
                DbCommand command = this._provider.DbCommand();
                command.Connection = connection;
                command.Transaction = tansaction;
                try
                {
                    while (this._buffer.Count > 0)
                    {
                        if (this._buffer.TryDequeue(out SQLComponent component))
                        {
                            command.CommandText = component.SQL;
                            command.Parameters.AddRange(component.Parameters.ToArray());
                            command.ExecuteNonQuery();
                            command.Parameters.Clear();
                        }
                    }
                    tansaction.Commit();
                    successed = true;
                }
                catch
                {
                    tansaction.Rollback();
                    throw;
                }
                finally
                {
                    Interlocked.Exchange(ref this._allowFlag, 1);
                }
            }
            return successed;
        }

        public void Push(SQLComponent componect)
        {
            if (this._allowFlag!=0)
            {
                this._buffer.Enqueue(componect);
            }

        }
    }


}
