using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Concurrent;
namespace Handiness.Orm
{
    #region  /****************枚举描述扩展****************/
    /// summary>
    ///枚举描述的扩展
    /// </summary>
    public static class EnumDescriptionExtensions
    {
        /// <summary>
        ///描述的缓存
        /// </summary>
        private static ConcurrentDictionary<Enum, String> _DescriptionCache = new ConcurrentDictionary<Enum, String>();
        /// <summary>
        /// 枚举类型缓存
        /// </summary>
        private static ConcurrentDictionary<Enum, Type> _EnumTypeCache = new ConcurrentDictionary<Enum, Type>();
        /// <summary>
        /// 同步对象
        /// </summary>
        private static Object _SyncObj = new Object();
        private static Type _DescriptionAttributeType = typeof(DescriptionAttribute);

        /****************方法****************/
        /// <summary>
        /// 获取枚举的描述
        /// </summary>
        public static String Describe(this Enum enumerator, Boolean withEndSpace = false,Boolean withStartSpace=false)
        {
            Type enumType = null;
            if (!_EnumTypeCache.ContainsKey(enumerator))
            {
                lock (_SyncObj)
                {
                    _EnumTypeCache.TryAdd(enumerator, enumerator.GetType());
                }
            }
            enumType = _EnumTypeCache[enumerator];
            if (!_DescriptionCache.ContainsKey(enumerator))
            {
                String description = String.Empty;
                String enumeratorName = enumerator.ToString();
                FieldInfo fieldInfo = enumType.GetField(enumeratorName);
                DescriptionAttribute[] descriptionArray = fieldInfo.GetCustomAttributes(_DescriptionAttributeType, false) as DescriptionAttribute[];
                description = descriptionArray.Length > 0 ? descriptionArray[0].Description : enumeratorName;
                lock (_SyncObj)
                {
                    _DescriptionCache.TryAdd(enumerator, description);
                }
            }
            String descriptionString = _DescriptionCache[enumerator];
            if (withEndSpace)
            {
                descriptionString = descriptionString + " ";
            }
            if (withStartSpace)
            {
                descriptionString = " " + descriptionString;
            }
            return descriptionString;
        }
    }
    #endregion
}
