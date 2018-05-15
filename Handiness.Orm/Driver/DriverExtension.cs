
using System;
using System.Linq.Expressions;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections;
namespace Handiness.Orm
{
    public static class DriverExtension
    {
        public static IDriver<T> JoinIn<T, T1>(this IDriver<T> driver, Expression<Func<T1, Object>> filter, Object[] values)
          where T : class where T1 : class
        {
            driver.SQLComponent.AppendWhere();
            AnalyingIn<T1>(driver.DbProvider, filter, driver.SQLComponent, values);
            return driver;
        }
        public static IDriver<T> In<T>(this IDriver<T> driver, Expression<Func<T, Object>> filter, Object[] values)
            where T : class
        {
            driver.SQLComponent.AppendWhere();
            AnalyingIn<T>(driver.DbProvider, filter, driver.SQLComponent, values);
            return driver;
        }
        public static IDriver<T> OrIn<T>(this IDriver<T> driver, Expression<Func<T, Object>> filter, Object[] values)
         where T : class
        {
            driver.SQLComponent.AppendWhere(false);
            AnalyingIn<T>(driver.DbProvider, filter, driver.SQLComponent, values);
            return driver;
        }
        internal static void AnalyingIn<T>(DbProvider dbProvider, Expression<Func<T, Object>> filter, SQLComponent component, Object[] values)
            where T : class
        {
            if (filter.Body.NodeType != ExpressionType.MemberAccess)
                throw new ArgumentException(nameof(filter));

            MemberExpression expression = filter.Body as MemberExpression;


            SchemaCache schema = Table<T>.Schema;
            var colSchema = schema.GetColumnSchema(expression.Member.Name);
            String columnName = colSchema.Name;
            columnName = String.Format(dbProvider.ConflictFreeFormat, columnName);
            columnName = String.Format(CommonFormat.COLUMN_FORMAT, schema.TableName, columnName);

            StringBuilder inParaNames = new StringBuilder();
            Int32 count = values.Length;
            String paraSymbol = "inPara";
            for (Int32 i = 0; i < count; ++i)
            {
                String paraName = dbProvider.Prefix + paraSymbol + ParaCounter<T>.CountStr;
                inParaNames.Append(paraName);
                if (i != (count - 1))
                {
                    inParaNames.Append(SqlKeyWord.COMMA);
                }
                DbParameter parameter = dbProvider.DbParameter(
                    paraName, values[i], colSchema.DbType
                    );
                component.AddParameter(parameter);
            }
            component.AppendSQL(columnName);
            component.AppendSQL(SqlKeyWord.IN);
            component.AppendSQLFormat(CommonFormat.BRACKET_FORMAT, inParaNames.ToString());

        }
    }
}
