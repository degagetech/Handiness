using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Handiness.Orm
{
    public class InstanceCreator<T> where T : class
    {
        private Func<T> _factory = null;

        public InstanceCreator()
        {
            Type type = typeof(T);
            Expression exp = Expression.New(type);
            this._factory = (Func<T>)Expression.Lambda(exp).Compile();
        }
        /// <summary>
        /// 创建一个全新的对象
        /// </summary>
        /// <returns></returns>
        public T New()
        {
         
                return this._factory.Invoke();
           
        
        }
    }
}
