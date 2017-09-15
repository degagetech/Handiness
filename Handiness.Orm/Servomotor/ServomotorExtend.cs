using System;
using System.Linq.Expressions;

namespace Handiness.Orm
{
    public static class ServomotorExtend
    {
        internal static readonly String LimitKeywordFormat = " limit {0},{1} ";
        internal static readonly String TopKeywordFormat = " limit {0} ";
        internal static readonly String DescKeyword = " desc ";
        internal static readonly String AscKeyword = " asc ";
        internal static readonly String OrderByKeywordFormat = " order by {0} {1} ";
        public static IServomotor<T> Limit<T>(this IServomotor<T> servomotor, Int32 beginIndex, Int32 count = -1) where T : class
        {
            if (-1 >= beginIndex && count < -1)
            {
                throw new ArgumentException("Limit beginIndex or count is invalid!");
            }
            String limitSql = String.Format(LimitKeywordFormat, beginIndex, count);
            servomotor.AppendSql(limitSql);
            return servomotor;
        }
        public static IServomotor<T> Top<T>(this IServomotor<T> servomotor, Int32 count) where T : class
        {
            if (count < -1)
            {
                throw new ArgumentException("Top count is invalid!");
            }
            String topSql = String.Format(TopKeywordFormat, count);
            servomotor.AppendSql(topSql);
            return servomotor;
        }
        public static IServomotor<T> OrderBy<T>(this IServomotor<T> servomotor, String dependent, Boolean desc = true) where T : class
        {
            if (String.IsNullOrEmpty(dependent))
            {
                throw new ArgumentException("Order by dependent is invalid!");
            }
            String orderBySql = String.Format(OrderByKeywordFormat, dependent, desc ? DescKeyword : AscKeyword);
            servomotor.AppendSql(orderBySql);
            return servomotor;
        }
        public static IServomotor<T> OrderBy<T>(this IServomotor<T> servomotor, Expression<Func<T, String>> dependent, Boolean desc = true) where T : class
        {
            if (null == dependent)
            {
                throw new ArgumentException("Order by dependent is invalid!");
            }
            String dependentStr = Expression.Lambda(dependent.Body).Compile().DynamicInvoke() as String; 
            return OrderBy<T>(servomotor, dependentStr, desc);
        }
    }
}
