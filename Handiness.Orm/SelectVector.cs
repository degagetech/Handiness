using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Handiness.Orm
{

    /// <summary>
    /// 查询容器基础实现类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SelectVector<T> : ISelectVector<T> where T : class
    {

        public DbDataReader DbDataReader { get; set; }





        public SelectVector(DbDataReader dbDataReader)
        {
            this.DbDataReader = dbDataReader;
            
        }


        public Boolean HasRows
        {
            get
            {
                if (this.DbDataReader != null)
                    return this.DbDataReader.HasRows;
                return false;
            }
        }



        public T[] ToArray()
        {
            List<T> result = this.ToList();
            return result.ToArray();
        }



        public List<T> ToList()
        {
            List<T> result = new List<T>();
            if (this.HasRows)
            {
                try
                {
                    result=DataExtractor<T>.ToList(this.DbDataReader);
                }
                finally
                {
                    this.Close();
                }
            }
            return result;
        }

        public void Dispose()
        {
            this.Close();
        }
        public void Close()
        {
            if (this.DbDataReader != null && !this.DbDataReader.IsClosed)
            {
                this.DbDataReader.Close();
            }
        }
        public T Single()
        {
            return this.ToList().Single();
        }
        public T FirstOrDefault()
        {
            return this.ToList().FirstOrDefault();
        }
    }
}
