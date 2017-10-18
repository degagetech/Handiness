using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace Handiness.Orm
{
    public class PropertyAccessor<T>
    {
        private Dictionary<String, Delegate> _deleagateCache = new Dictionary<String, Delegate>();
        private Type _type = typeof(T);
        /// <summary>
        /// 属性获取访问器名称格式
        /// </summary>
        protected const String ProperityGetterNameFormat = "get_{0}";
        /// <summary>
        /// 属性设置访问其名称格式
        /// </summary>
        protected const String ProperitySetterNameFormat = "set_{0}";
        public void SetProperityValue(T obj, String propertyName, Object value)
        {
            Type type = this._type;
            Type inputType = typeof(Object);
            Action<T, Object> action = null;
            String key = $"ACT{ type.FullName}_{propertyName}_{inputType.FullName}";
            if (this._deleagateCache.ContainsKey(key))
            {
                action = this._deleagateCache[key] as Action<T, Object>;
            }
            else
            {
                //获取属性的getter
                var getter = type.GetMethod(String.Format(ProperitySetterNameFormat, propertyName));
                ParameterExpression instanceExp = Expression.Parameter(typeof(T), "obj");
                ParameterExpression valueExp = Expression.Parameter(typeof(Object), "value");
                //UnaryExpression unaryExp = Expression.Convert(valueExp, typeof(TINPUT));
                //Expression.call
                MethodCallExpression callExp = Expression.Call(instanceExp, getter, valueExp );
                var lambda = Expression.Lambda<Action<T, Object>>(callExp, instanceExp, valueExp);
                action = lambda.Compile();
                this._deleagateCache[key] = action;
            }
            action.Invoke(obj, value);
        }

        public TResult GetProperityValue<TResult>(T obj, String propertyName)
        {
            Type type = this._type;
            Type retType = typeof(TResult);
            Func<T, TResult> func = null;
            String key = $"RET{ type.FullName}_{propertyName}_{retType.FullName}";
            if (this._deleagateCache.ContainsKey(key))
            {
                func = this._deleagateCache[key] as Func<T, TResult>;
            }
            else
            {
                //获取属性的getter
                var getter = type.GetMethod(String.Format(ProperityGetterNameFormat, propertyName));
                ParameterExpression parameter = Expression.Parameter(typeof(T), "obj");
                MethodCallExpression callExp = Expression.Call(parameter, getter);
                UnaryExpression unaryExp=Expression.Convert(callExp, retType);
                var lambda = Expression.Lambda<Func<T, TResult>>(unaryExp, parameter);
               
                func = lambda.Compile();
                this._deleagateCache[key] = func;
            }
            return func.Invoke(obj);
        }

    }
}
