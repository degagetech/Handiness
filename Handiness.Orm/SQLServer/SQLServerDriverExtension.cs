
using System;
using System.Linq.Expressions;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections;
namespace Biobank.Orm
{
    public static class SQLServerDriverExtension
    {
        /// <summary>
        /// 【置于调用链末尾】  使用指定条件做递归查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="driver"></param>
        /// <returns></returns>
        public static IDriver<T> Recursion<T>(this IDriver<T> driver, Expression<Func<T, T, Boolean>> condition) where T : class
        {
            //String sql = BasicSqlFormat.RECURSIVE_QUERY_FORMAT ;
            //TODO:递归查询
            return driver;
        }
        /// <summary>
        ///【置于调用链末尾】 对当前的查询做分页操作。sorter  分页字段，此处返回 model 的指定属性。start 起始位置。 count 获取数量。asc 默认升序，置为 false 改为降序
        /// </summary>
        public static IDriver<T> Page<T>(this IDriver<T> driver, Expression<Func<T, Object>> sorter, Int32 start, Int32 count, Boolean asc = true)
        where T : class
        {
            String sortColName = null;
            SchemaCache schema = Table<T>.Schema;
            MemberExpression expression = null;
            if (sorter.Body.NodeType != ExpressionType.MemberAccess)
            {
                //由于函数签名为 Object 类型 所以值类型 属性会发生装箱
                if (sorter.Body.NodeType == ExpressionType.Convert)
                {
                    UnaryExpression unaryExp = sorter.Body as UnaryExpression;
                    expression = unaryExp.Operand as MemberExpression;
                }
                else
                {
                    throw new ArgumentException(nameof(sorter));

                }

            }
            else
            {
                expression = sorter.Body as MemberExpression;
            }
            sortColName = schema.GetColumnName(expression.Member.Name);
            return Page<T>(driver, sortColName, start, count, asc);
        }
        
        /// <summary>
        ///【置于调用链末尾】 对当前的查询做分页操作。sort  分页字段的列名。start 起始位置。 count 获取数量。asc 默认升序，置为false 改为降序
        /// </summary>
        public static IDriver<T> Page<T>(this IDriver<T> driver, String sort, Int32 start, Int32 count, Boolean asc = true)
        where T : class
        {
            String sql = BasicSqlFormat.PAGE_QUERY_FORMAT;
            String sortAsc = asc ? SqlKeyWord.ASC : SqlKeyWord.DESC;
            String sortColName = sort;
            String endIndex = (start + count).ToString();
            String startIndex = start.ToString();
            sql = String.Format(sql, driver.SQLComponent.SQL, sortColName, startIndex, endIndex, sortAsc);
            driver.SQLComponent.ClearSQL(sql);
            return driver;
        }
    }
}
