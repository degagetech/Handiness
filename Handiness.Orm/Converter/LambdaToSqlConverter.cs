using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq.Expressions;
using static Handiness.Orm.OrmToolkit;
namespace Handiness.Orm
{
    /// <summary>
    /// lambda表达式转换器
    /// </summary>
    public class LambdaToSqlConverter<T> where T : class
    {

        public static String SelectConvert(Expression<Func<T, dynamic>> selector = null, List<DbParameter> parameterList = null)
        {
            String convertedString = BasicSqlFormat.SelectFormat.Describe();
            if (null == selector)
            {
                convertedString = String.Format(convertedString,
                    SqlKeyWord.AllColumn,
                    Table<T>.TableReflectionCache.TableName);
            }
            else
            {
                String columnNames = String.Empty;
                NewExpression newExpression = selector.Body as NewExpression;
                if (newExpression.Arguments == null || newExpression.Arguments.Count <= 0)
                {
                    throw new ArgumentException("Select column can not be empty!");
                }
                #region <<获取需要查询的列,并拼接Sql>>
                MemberExpression memberExpression = null;
                foreach (Expression expression in newExpression.Arguments)
                {
                    memberExpression = expression as MemberExpression;
                    if (Table<T>.
                        TableReflectionCache.
                        ColumnAttributeCollection.
                        ContainsKey(memberExpression.Member.Name))
                    {
                        ColumnAttribute columnAttribute = Table<T>.
                            TableReflectionCache.
                            ColumnAttributeCollection[memberExpression.Member.Name];
                        columnNames += columnAttribute.Name;
                        columnNames += SqlKeyWord.Comma.Describe();
                    }
                }
                TrimEndComma(ref columnNames);
                convertedString = String.Format(convertedString, columnNames, Table<T>.TableReflectionCache.TableName);
                #endregion
            }
            return convertedString;
        }

        public static String UpdateConvert(DbProvider dbProvider, Expression<Func<T>> regenerator, List<DbParameter> parameterList = null, String postfixParameterName = null)
        {
            MemberInitExpression memberInitExpression = regenerator.Body as MemberInitExpression;
            if (memberInitExpression.Bindings == null || memberInitExpression.Bindings.Count <= 0)
            {
                throw new ArgumentException("Invalid update expression!");
            }
            String convertedString = BasicSqlFormat.UpdateFormat.Describe();
            String updateColumnNames = String.Empty;
            //获取需要更新的列 以及其值
            foreach (MemberAssignment memberAssignment in memberInitExpression.Bindings)
            {
                ColumnAttribute columnAttribute =
                            Table<T>.
                            TableReflectionCache.
                            ColumnAttributeCollection[memberAssignment.Member.Name];
                String parameterName = dbProvider.PrefixParameterName + columnAttribute.Name + postfixParameterName;
                DbParameter dbParameter = dbProvider.DbParameterFactroy
                    (
                            parameterName,
                            columnAttribute.Type,
                            ExtractExpressionContainValue(memberAssignment.Expression)
                    );
                /*.................拼接更新的SQL.................*/
                updateColumnNames += columnAttribute.Name;
                updateColumnNames += SqlKeyWord.Equal.Describe();
                updateColumnNames += parameterName;
                updateColumnNames += SqlKeyWord.Comma.Describe();

                parameterList?.Add(dbParameter);
            }
            TrimEndComma(ref updateColumnNames);
            convertedString = String.Format(convertedString, Table<T>.TableReflectionCache.TableName, updateColumnNames);

            return convertedString;
        }
        /// <summary>
        /// 提取表达式包含的Value
        /// </summary>
        private static Object ExtractExpressionContainValue(Expression expression)
        {
            Object value = null;
            switch (expression.NodeType)
            {
                case ExpressionType.Constant:
                    {
                        value = (expression as ConstantExpression).Value;
                    }
                    break;
                default:
                    {
                        value = Expression.Lambda(expression).Compile().DynamicInvoke();
                    }
                    break;
            }
            return value;
        }
        internal static Dictionary<ExpressionType, SqlKeyWord> ExpressionTypeMapTable = new Dictionary<ExpressionType, SqlKeyWord>()
        {
            {ExpressionType.AndAlso,SqlKeyWord.And},
            {ExpressionType.OrElse,SqlKeyWord.Or},
            {ExpressionType.GreaterThan,SqlKeyWord.GreaterThan},
            {ExpressionType.GreaterThanOrEqual,SqlKeyWord.GreaterThanOrEqual},
            {ExpressionType.LessThan,SqlKeyWord.LessThan},
            {ExpressionType.LessThanOrEqual,SqlKeyWord.LessThanOrEqual},
            {ExpressionType.Equal,SqlKeyWord.Equal},
            {ExpressionType.NotEqual,SqlKeyWord.NotEqual}
        };
        internal static Dictionary<String, SqlKeyWord> MethodNameMapTable = new Dictionary<String, SqlKeyWord>
        {
            { "Contains",SqlKeyWord.Like}
        };
        /// <summary>
        /// 判断此表达式在整个表达式树中是否属于枝结点
        /// </summary>
        /// <param name="expression">被判断的表达式</param>
        /// <returns>返回判断的结果 TRUE（是）  FALSE（ 不是）</returns>
        internal static Boolean IsBranchNode(Expression expression)
        {
            Boolean isBranch = false;
            switch (expression.NodeType)
            {
                case ExpressionType.AndAlso:
                case ExpressionType.OrElse:
                case ExpressionType.GreaterThan:
                case ExpressionType.GreaterThanOrEqual:
                case ExpressionType.LessThan:
                case ExpressionType.LessThanOrEqual:
                case ExpressionType.Equal:
                case ExpressionType.NotEqual:
                case ExpressionType.Call:
                    {
                        isBranch = true;
                    }
                    break;
            }
            return isBranch;
        }
        internal static void ExpressionTreeAnalyzing(DbProvider dbProvider, Expression expression, ref String sql, List<DbParameter> parameterList = null)
        {
            if (IsBranchNode(expression))
            {
                if (ExpressionType.Call == expression.NodeType)
                {
                    String propertyName = String.Empty;
                    String symbol = String.Empty;
                    Object value = null;
                    MethodCallExpression callExpression = expression as MethodCallExpression;
                    MemberExpression memberExpression = callExpression.Object as MemberExpression;
                    symbol = MethodNameMapTable[callExpression.Method.Name].Describe(true,true);
                    propertyName = memberExpression.Member.Name;
                    value = ExtractExpressionContainValue(callExpression.Arguments[0]);

                    ColumnAttribute columnAttribute = Table<T>.TableReflectionCache.ColumnAttributeCollection[propertyName];
                    DbParameter parameter = dbProvider.DbParameterFactroy(
                         dbProvider.PrefixParameterName + columnAttribute.Name+ parameterList?.Count,
                         columnAttribute.Type,
                         value
                        );
                    sql += columnAttribute.Name;
                    sql += symbol;
                    sql += parameter.ParameterName;
                    parameterList?.Add(parameter);
                }
                else
                {
                    BinaryExpression binaryExpression = expression as BinaryExpression;
                    if (!IsBranchNode(binaryExpression.Left))
                    {
                        String propertyName = String.Empty;
                        String symbol = String.Empty;
                        Object value = null;

                        MemberExpression memberExpression = binaryExpression.Left as MemberExpression;
                        propertyName = memberExpression.Member.Name;
                        symbol = ExpressionTypeMapTable[binaryExpression.NodeType].Describe();
                        value = ExtractExpressionContainValue(binaryExpression.Right);
                        ColumnAttribute columnAttribute = Table<T>.TableReflectionCache.ColumnAttributeCollection[propertyName];
                        DbParameter parameter = dbProvider.DbParameterFactroy(
                             dbProvider.PrefixParameterName + columnAttribute.Name+ parameterList?.Count,
                             columnAttribute.Type,
                             value
                            );
                        sql += columnAttribute.Name;
                        sql += symbol;
                        sql += parameter.ParameterName;
                        parameterList?.Add(parameter);
                    }
                    else
                    {
                        ExpressionTreeAnalyzing(dbProvider, binaryExpression.Left, ref sql, parameterList);
                        sql += ExpressionTypeMapTable[binaryExpression.NodeType].Describe(true, true);
                        ExpressionTreeAnalyzing(dbProvider, binaryExpression.Right, ref sql, parameterList);
                    }
                }
            }

        }
        public static String WhereConvert(DbProvider dbProvider, Expression<Func<T, Boolean>> predicate, List<DbParameter> parameterList = null)
        {
            String convertedString = String.Empty;
            Expression body = predicate.Body;
            ExpressionTreeAnalyzing(dbProvider, body, ref convertedString, parameterList);
            return convertedString;
        }
    }

}
