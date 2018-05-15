using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Linq.Expressions;


namespace Handiness.Orm
{
    /// <summary>
    /// 用于对属性的快速访问，其性能高于反射低于直接操作
    /// </summary>
    public sealed class PropertyAccessor
    {
        private Action<Object, Object>[] _setterCache = null;
        private Func<Object, Object>[] _getterCache = null;
        /// <summary>
        /// Setter方法缓存计数器
        /// </summary>
        private Int32 _setterCacheCount = 0;
        /// <summary>
        /// Getter方法缓存计数器
        /// </summary>
        private Int32 _getterCacheCount = 0;
        /****************/
        public PropertyAccessor() { }

        public void Initlialize(Int32 size)
        {
            this._setterCache = new Action<Object, Object>[size];
            this._getterCache = new Func<Object, Object>[size];
            this._setterCacheCount = 0;
            this._getterCacheCount = 0;
        }
        /// <summary>
        /// 使用指定索引处的缓存委托设置实例的属性的值
        /// </summary>
        public void SetValue(Int32 index, Object instance, Object value)
        {
            if (value != null)
            {
                Action<Object, Object> cache = this._setterCache[index];
                cache.Invoke(instance, value);
            }
        }
        /// <summary>
        /// 使用指定索引处的缓存委托获取实例的属性的值
        /// </summary>
        public Object GetValue(Int32 index, Object instance)
        {
            Func<Object, Object> cache = this._getterCache[index];
            return cache.Invoke(instance);
        }
        /// <summary>
        /// 获取指定索引处setter的缓存
        /// </summary>
        public Action<Object, Object> SetterCache(Int32 index)
        {
            return this._setterCache[index];
        }
        /// <summary>
        /// 获取指定索引处getter的缓存
        /// </summary>
        public Func<Object, Object> GetterCache(Int32 index)
        {
            return this._getterCache[index];
        }
        /// <summary>
        /// 根据属性信息生成对应的缓存委托，并返回委托的位置
        /// </summary>
        public Int32 BuildingSetPropertyCache(PropertyInfo info)
        {

            //(Object instance,Object value)=>((ReflectedType)instance).Set_XXX((PropertyType)value);
            MethodInfo method = info.GetSetMethod();
            Type objectType = typeof(Object);
            ParameterExpression instanceExp = Expression.Parameter(objectType, "instance");
            ParameterExpression parameterExp = Expression.Parameter(objectType, "value");
            UnaryExpression valueCastExp = Expression.Convert(parameterExp, info.PropertyType);
            UnaryExpression instanceCastExp = Expression.Convert(instanceExp, info.ReflectedType);
            MethodCallExpression invokeExp = Expression.Call(instanceCastExp, method, valueCastExp);
            Action<Object, Object> handler = Expression.Lambda<Action<Object, Object>>(invokeExp, instanceExp, parameterExp).Compile();
            this._setterCache[this._setterCacheCount] = handler;
            return this._setterCacheCount++;
        }
        /// <summary>
        /// 根据属性信息生成对应的缓存委托，并返回委托的位置
        /// </summary>
        public Int32 BuildingGetPropertyCache(PropertyInfo info)
        {

            //(Object instance)=>(Object)((ReflectedType)instance).Get_XXX();

            MethodInfo methodInfo = info.GetGetMethod();
            Type objectType = typeof(Object);
            ParameterExpression instanceExp = Expression.Parameter(objectType, "instance");
            UnaryExpression instanceCastExp = Expression.Convert(instanceExp, info.ReflectedType);
            MethodCallExpression invokeExp = Expression.Call(instanceCastExp, methodInfo);
            UnaryExpression resultCastExp = Expression.Convert(invokeExp, objectType);
            Func<Object, Object> handler = Expression.Lambda<Func<Object, Object>>(resultCastExp, instanceExp).Compile();
            this._getterCache[this._getterCacheCount] = handler;
            return this._getterCacheCount++;
        }
    }
}
