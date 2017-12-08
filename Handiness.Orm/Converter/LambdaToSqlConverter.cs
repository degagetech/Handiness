using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq.Expressions;
using System.Text;

namespace Handiness.Orm
{
    /// <summary>
    ///用于将Lambda表达式转换成SQL语句
    /// </summary>
    public class LambdaToSqlConverter<T> where T : class
    {

        public static String SelectConvert(String conflictFreeFormat, Expression<Func<T, dynamic>> selector)
        {

            String convertedString = BasicSqlFormat.SELECT_FORMAT;

            NewExpression newExpression = selector.Body as NewExpression;
            if (newExpression.Arguments == null || newExpression.Arguments.Count <= 0)
            {
                throw new ArgumentException("Select column can not be empty!");
            }
            #region <<获取需要查询的列,并拼接Sql>>
            MemberExpression memberExpression = null;
            var args = newExpression.Arguments;
            Int32 count = 1;
            StringBuilder columnNames = new StringBuilder();
            foreach (Expression expression in args)
            {
                memberExpression = expression as MemberExpression;
                String columnName = Table<T>.
                    Schema[memberExpression.Member.Name];
                if (null == columnName)
                {
                    columnNames.Append(String.Format(conflictFreeFormat, columnName));
                    if (count++ != args.Count)
                        columnNames.Append(SqlKeyWord.COMMA);
                }

            }
            convertedString = String.Format(convertedString, columnNames.ToString(), Table<T>.Schema.TableName);
            #endregion

            return convertedString;
        }

        public static void UpdateConvert(DbProvider dbProvider, Expression<Func<T>> regenerator, SQLComponent component)
        {
            MemberInitExpression memberInitExpression = regenerator.Body as MemberInitExpression;
            if (memberInitExpression.Bindings == null || memberInitExpression.Bindings.Count <= 0)
            {
                throw new ArgumentException("Invalid update expression!");
            }

            StringBuilder updateColumnNames = new StringBuilder();
            //获取需要更新的列 以及其值
            var bindings = memberInitExpression.Bindings;
            Int32 count = 1;
            foreach (MemberAssignment memberAssignment in bindings)
            {
                String columnName =
                            Table<T>.
                            Schema[memberAssignment.Member.Name];
                String parameterName = dbProvider.Prefix + columnName + ParaCounter<T>.CountStr;
                DbParameter dbParameter = dbProvider.DbParameter
                    (
                            parameterName,
                            ExtractExpressionContainValue(memberAssignment.Expression) ?? DBNull.Value
                    );
                /*.................拼接更新的SQL.................*/
                updateColumnNames.Append(String.Format(dbProvider.ConflictFreeFormat, columnName));
                updateColumnNames.Append(SqlKeyWord.EQUAL);
                updateColumnNames.Append(parameterName);
                if (count++ != bindings.Count)
                    updateColumnNames.Append(SqlKeyWord.COMMA);

                component.AddParameter(dbParameter);
            }
            component.AppendSQLFormat(BasicSqlFormat.UPDATE_FORMAT, Table<T>.Schema.TableName, updateColumnNames.ToString());
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
                        dynamic handler = Expression.Lambda(expression).Compile();
                        value = handler.Invoke();
                    }
                    break;
            }
            return value;
        }
        internal static Dictionary<ExpressionType, String> ExpressionTypeMapTable = new Dictionary<ExpressionType, String>()
        {
            {ExpressionType.AndAlso,SqlKeyWord.AND},
            {ExpressionType.OrElse,SqlKeyWord.OR},
            {ExpressionType.GreaterThan,SqlKeyWord.GREATERTHAN},
            {ExpressionType.GreaterThanOrEqual,SqlKeyWord.GREATERTHAN_OR_EQUAL},
            {ExpressionType.LessThan,SqlKeyWord.LESSTHAN},
            {ExpressionType.LessThanOrEqual,SqlKeyWord.LESSTHAN_OR_EQUAL},
            {ExpressionType.Equal,SqlKeyWord.EQUAL},
            {ExpressionType.NotEqual,SqlKeyWord.NOT_EQUAL}
        };
        internal static Dictionary<String, String> MethodNameMapTable = new Dictionary<String, String>
        {
            { "Contains",SqlKeyWord.LIKE}
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
        internal static void ExpressionTreeAnalyzing(DbProvider dbProvider, Expression expression, SQLComponent component)
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
                    symbol = MethodNameMapTable[callExpression.Method.Name];
                    propertyName = memberExpression.Member.Name;
                    value = ExtractExpressionContainValue(callExpression.Arguments[0]);

                    String columnName = Table<T>.Schema[propertyName];
                    String parameterName = dbProvider.Prefix + columnName + ParaCounter<T>.CountStr;
                    DbParameter parameter = dbProvider.DbParameter(
                         parameterName,
                         value ?? DBNull.Value
                        );
                    columnName = String.Format(dbProvider.ConflictFreeFormat, columnName);
                    columnName = String.Format(CommonFormat.COLUMN_FORMAT, Table<T>.Schema.TableName, columnName);

                    component.AppendSQL(columnName);
                    component.AppendSQL(symbol);
                    component.AppendSQL(parameter.ParameterName);
                    component.AddParameter(parameter);
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
                        symbol = ExpressionTypeMapTable[binaryExpression.NodeType];
                        value = ExtractExpressionContainValue(binaryExpression.Right);

                        String columnName = Table<T>.Schema[propertyName];
                        String parameterName = dbProvider.Prefix + columnName + ParaCounter<T>.CountStr;
                        columnName =String.Format(dbProvider.ConflictFreeFormat, columnName);
                        columnName = String.Format(CommonFormat.COLUMN_FORMAT, Table<T>.Schema.TableName, columnName);
                        DbParameter parameter = dbProvider.DbParameter(
                             parameterName,
                             value ?? DBNull.Value
                            );
                        component.AppendSQL(columnName);
                        component.AppendSQL(symbol);
                        component.AppendSQL(parameter.ParameterName);
                        component.AddParameter(parameter);
                    }
                    else
                    {
                        ExpressionTreeAnalyzing(dbProvider, binaryExpression.Left, component);
                        component.AppendSQL(ExpressionTypeMapTable[binaryExpression.NodeType]);
                        ExpressionTreeAnalyzing(dbProvider, binaryExpression.Right, component);
                    }
                }
            }

        }
        /// <summary>
        /// 将指定的条件表达式转换为响应的条件SQL语句，此函数不会判断条件关键词的存在
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="predicate"></param>
        /// <param name="component"></param>
        public static void WhereConvert(DbProvider provider, Expression<Func<T, Boolean>> predicate, SQLComponent component)
        {
            Expression body = predicate.Body;
            ExpressionTreeAnalyzing(provider, body, component);
        }
        public static void JoinOn<T1>(DbProvider provider, Expression<Func<T, T1, Boolean>> predicate, SQLComponent component) where T1 : class
        {
            StringBuilder builder = new StringBuilder();
            throw new Exception();
        }
        public static void JoinWhere<T1>(DbProvider provider, Expression<Func<T, T1, Boolean>> predicate, SQLComponent component) where T1 : class
        {
            throw new Exception();
        }
    }

}
