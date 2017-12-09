using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Reflection;

namespace Handiness.Orm
{
    /// <summary>
    /// 用于从指定数据源中提取包含信息的模型对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DataExtractor<T> where T : class
    {

        public static T FromDbDataReader(DbDataReader dr, HashSet<String> containCols)
        {
            T instance = Table<T>.Creator.New();
            String columnName = null;
            Int32 length = Table<T>.Schema.PropertyInfos.Length;
            for (Int32 i = 0; i < length; ++i)
            {
                PropertyInfo info = Table<T>.Schema.PropertyInfos[i];
                columnName = Table<T>.Schema[info.Name];
                if (containCols.Contains(columnName))
                {
                    Object value = dr[columnName];
                    value = value == DBNull.Value ? null : value;
                    Table<T>.Schema.PropertyAccessor.SetValue(i, instance, value);
                }
            }
            return instance;
        }
        /// <summary>
        /// 获取<see cref="DbDataReader"/>对象包含的所有数据列的名称
        /// </summary>
        private static HashSet<String> GetContainColumns(DbDataReader dr)
        {
            HashSet<String> columnNames = new HashSet<String>();
            Int32 count = dr.FieldCount;
            for (Int32 i = 0; i < count; ++i)
            {
                columnNames.Add(dr.GetName(i));
            }
            return columnNames;
        }
        /// <summary>
        /// 提取<see cref="DbDataReader"/>对象中包含的数据
        /// </summary>
        /// <param name="dr"></param>
        /// <returns>若无数据返回一个包含零个元素的链表对象</returns>
        public static List<T> ToList(DbDataReader dr)
        {
            List<T> result = new List<T>();
            HashSet<String> containCols = GetContainColumns(dr);
            while (dr.Read())
            {
                T instance = FromDbDataReader(dr, containCols);
                result.Add(instance);
            }
            return result;
        }

    }
}
