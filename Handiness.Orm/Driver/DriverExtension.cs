#define MYSQL_NO
#if MYSQL
using System;
using System.Linq.Expressions;

namespace Handiness.Orm
{
    public static class DriverExtension
    {
        internal static readonly String LimitKeywordFormat = " LIMIT {0},{1} ";
        internal static readonly String TopKeywordFormat = " LIMIT {0} ";
        internal static readonly String DescKeyword = " DESC ";
        internal static readonly String AscKeyword = " ASC ";
        internal static readonly String OrderByKeywordFormat = " ORDER BY {0} {1} ";
        public static IDriver<T> Limit<T>(this IDriver<T> driver, Int32 beginIndex, Int32 count = -1) where T : class
        {
            if (-1 >= beginIndex && count < -1)
            {
                throw new ArgumentException("Limit beginIndex or count is invalid!");
            }
            String limitSql = String.Format(LimitKeywordFormat, beginIndex, count);
            driver.AppendSql(limitSql);
            return driver;
        }
        public static IDriver<T> Top<T>(this IDriver<T> driver, Int32 count) where T : class
        {
            if (count < -1)
            {
                throw new ArgumentException("Top count is invalid!");
            }
            String topSql = String.Format(TopKeywordFormat, count);
            driver.AppendSql(topSql);
            return driver;
        }
        public static IDriver<T> OrderBy<T>(this IDriver<T> driver, String dependent, Boolean desc = true) where T : class
        {
            if (String.IsNullOrEmpty(dependent))
            {
                throw new ArgumentException("Order by dependent is invalid!");
            }
            String orderBySql = String.Format(OrderByKeywordFormat, dependent, desc ? DescKeyword : AscKeyword);
            driver.AppendSql(orderBySql);
            return driver;
        }
        public static IDriver<T> OrderBy<T>(this IDriver<T> driver, Expression<Func<T, String>> dependent, Boolean desc = true) where T : class
        {
            if (null == dependent)
            {
                throw new ArgumentException("Order by dependent is invalid!");
            }
            String dependentStr = Expression.Lambda(dependent.Body).Compile().DynamicInvoke() as String; 
            return OrderBy<T>(driver, dependentStr, desc);
        }
    }
}
#endif