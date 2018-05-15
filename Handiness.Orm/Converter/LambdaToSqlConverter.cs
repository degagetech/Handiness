using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq.Expressions;
using System.Text;
using System.Reflection;
namespace Handiness.Orm
{
    public class KnownExtendMethodNames
    {
        public const String Contains = "Contains";
        public const String Like = "Like";
        public const String StartLike = "StartLike";
        public const String EndLike = "EndLike";

        /// <summary>
        /// 方法名称与SQL关键词的映射
        /// </summary>
        internal static Dictionary<String, String> _ExtendMethodFormatDict = new Dictionary<String, String>
        {
            { KnownExtendMethodNames.Contains,"{0} LIKE '%'+{1}+'%' "},
            { KnownExtendMethodNames.Like,"{0} LIKE '%'+{1}+'%' "},
            { KnownExtendMethodNames.StartLike,"{0} LIKE {1}+'%' "},
            { KnownExtendMethodNames.EndLike,"{0} LIKE '%'+{1}"}
        };
        public static Boolean IsMethodSupport(String methodName)
        {
            return _ExtendMethodFormatDict.ContainsKey(methodName);
        }

        public static String GetFormat(String methodName)
        {
            return _ExtendMethodFormatDict[methodName];
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="format"> {0} {1}  0 会被填充列名， 1 会被填充参数名</param>
        /// <returns></returns>
        public static void SetFormt(String methodName, String format)
        {
            _ExtendMethodFormatDict[methodName] = format;
        }
    }
    public class LambdaToSqlConverter
    {
      
        /// <summary>
        /// 表达式类型符号与SQL符号的映射
        /// </summary>
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




        /// <summary>
        /// 提取表达式包含的Value
        /// </summary>
        internal static Object ExtractExpressionContainValue(Expression expression)
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

        /// <summary>
        /// 通过表达式的节点类型获取对应的SQL符号
        /// </summary>
        internal static String GetSymbol(ExpressionType type)
        {
            return ExpressionTypeMapTable[type];
        }
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


    }
    /// <summary>
    ///用于将Lambda表达式转换成SQL语句
    /// </summary>
    public class LambdaToSqlConverter<T> : LambdaToSqlConverter where T : class
    {
        ///<summary>
        /// 方法表达式解析委托映射表 ，Key方法名称
        /// </summary>
        internal static Dictionary<String, Action<DbProvider,
            MethodCallExpression, SQLComponent, Dictionary<String, SchemaCache>>>

            ExpressionAnalyzingMapTable =
            new Dictionary<String, Action<DbProvider, MethodCallExpression, SQLComponent, Dictionary<String, SchemaCache>>>
            {
                {KnownExtendMethodNames.Contains,AnalyzingLikeMethodExpression },
                {KnownExtendMethodNames.Like, AnalyzingLikeMethodExpression},
                {KnownExtendMethodNames.StartLike, AnalyzingLikeMethodExpression},
                {KnownExtendMethodNames.EndLike, AnalyzingLikeMethodExpression}
            };
        /// <summary>
        /// 获取方法名称对应的表达式解析委托
        /// </summary>
        internal static Action<DbProvider, MethodCallExpression, SQLComponent, Dictionary<String, SchemaCache>>
            GetAnalyzingAction(String methodName)
        {
            return ExpressionAnalyzingMapTable[methodName];
        }

        public static String SelectConvert(String conflictFreeFormat, Expression<Func<T, dynamic>> selector)
        {

            String convertedString = BasicSqlFormat.SELECT_FORMAT;

            NewExpression newExpression = selector.Body as NewExpression;
            if (newExpression.Arguments == null || newExpression.Arguments.Count <= 0)
            {
                throw new ArgumentException(nameof(selector));
            }

            MemberExpression memberExpression = null;
            var args = newExpression.Arguments;
            Int32 count = 1;
            StringBuilder columnNames = new StringBuilder();
            foreach (Expression expression in args)
            {
                memberExpression = expression as MemberExpression;
                String columnName = Table<T>.
                    Schema[memberExpression.Member.Name];
                if (null != columnName)
                {
                    columnNames.Append(String.Format(conflictFreeFormat, columnName));
                    if (count++ != args.Count)
                        columnNames.Append(SqlKeyWord.COMMA);
                }

            }
            convertedString = String.Format(convertedString, columnNames.ToString(), Table<T>.Schema.TableName);


            return convertedString;
        }

        public static void UpdateConvert(DbProvider dbProvider, Expression<Func<T>> regenerator, SQLComponent component)
        {
            MemberInitExpression memberInitExpression = regenerator.Body as MemberInitExpression;
            if (memberInitExpression?.Bindings == null || memberInitExpression.Bindings.Count <= 0)
            {
                throw new ArgumentException(nameof(regenerator));
            }

            StringBuilder updateColumnNames = new StringBuilder();
            //获取需要更新的列 以及其值
            var bindings = memberInitExpression.Bindings;
            foreach (MemberAssignment memberAssignment in bindings)
            {
                ColumnSchema colSchema = Table<T>.Schema.GetColumnSchema(memberAssignment.Member.Name);
                if (colSchema.IsPrimaryKey) continue;
                String columnName = colSchema.Name;
                String parameterName = dbProvider.Prefix + columnName + ParaCounter<T>.CountStr;
                DbParameter dbParameter = dbProvider.DbParameter
                    (
                            parameterName,
                            ExtractExpressionContainValue(memberAssignment.Expression) ?? DBNull.Value,
                            colSchema.DbType
                    );
                /*.................拼接更新的SQL.................*/
                updateColumnNames.Append(OrmAssistor.BuildColumnName(colSchema, dbProvider.ConflictFreeFormat, Table<T>.Schema.TableName));
                updateColumnNames.Append(SqlKeyWord.EQUAL);
                updateColumnNames.Append(parameterName);
                updateColumnNames.Append(SqlKeyWord.COMMA);
                component.AddParameter(dbParameter);
            }
            updateColumnNames.Remove(updateColumnNames.Length - SqlKeyWord.COMMA.Length, SqlKeyWord.COMMA.Length);

            component.AppendSQLFormat(BasicSqlFormat.UPDATE_FORMAT, Table<T>.Schema.TableName, updateColumnNames.ToString());
        }

        /// <summary>
        /// 解析Contains、Like方法表达式，类似于 t.Id.Like("XXX") t.Id.Contains("XXX")
        /// </summary>
        /// <param name="dbProvider"></param>
        /// <param name="callExpression"></param>
        /// <param name="component"></param>
        /// <param name="schemaDict"></param>
        internal static void AnalyzingLikeMethodExpression(DbProvider dbProvider, MethodCallExpression callExpression, SQLComponent component,
            Dictionary<String, SchemaCache> schemaDict)
        {
            String methodName = callExpression.Method.Name;
            if (!KnownExtendMethodNames.IsMethodSupport(methodName))
            {
                throw new ArgumentException(nameof(callExpression));
            }
            String className = String.Empty;
            String propertyName = String.Empty;
            String format = String.Empty;
            Object value = null;
            //调用类型本身提供的方法，方法表达式的调用对象就可提供成员信息
            MemberExpression memberExpression = callExpression.Object as MemberExpression;

            if (memberExpression == null)
            {
                //如果是类型的扩展方法
                //调用类型的扩展方法，本质上是调用一个静态方法，方法的第一个参数提供提供成员信息
                memberExpression = callExpression.Arguments[0] as MemberExpression;
                value = ExtractExpressionContainValue(callExpression.Arguments[1]);
            }
            else
            {
                value = ExtractExpressionContainValue(callExpression.Arguments[0]);
            }
            format = KnownExtendMethodNames.GetFormat(callExpression.Method.Name);
            propertyName = memberExpression.Member.Name;
            className = memberExpression.Member.DeclaringType.Name;
            SchemaCache schema = schemaDict[className];

            var colSchema = schema.GetColumnSchema(propertyName);
            String columnName = colSchema.Name;
            String parameterName = dbProvider.Prefix + columnName + ParaCounter<T>.CountStr;
            DbParameter parameter = dbProvider.DbParameter(
                 parameterName,
                 value ?? DBNull.Value,
                 colSchema.DbType
                );

            columnName = OrmAssistor.BuildColumnName(colSchema, dbProvider.ConflictFreeFormat, schema.TableName);
            String sql = String.Format(format, columnName, parameter.ParameterName);
            component.AppendSQL(sql);
            component.AddParameter(parameter);
        }
        /// <summary>
        /// 解析方法表达式
        /// </summary>
        internal static void AnalyzingMethodExpression(DbProvider dbProvider, MethodCallExpression callExpression, SQLComponent component,
            Dictionary<String, SchemaCache> schemaDict)
        {
            String methodName = callExpression.Method.Name;
            var analyingAction = GetAnalyzingAction(methodName);
            analyingAction.Invoke(dbProvider, callExpression, component, schemaDict);
        }

        /// <summary>
        /// 解析表达式树，并将解析结果填充到指定的 <see cref="SQLComponent"/> 对象中
        /// </summary>
        internal static void AnalyzingExpressionTree(DbProvider dbProvider, Expression expression,
            SQLComponent component,
            Dictionary<String, SchemaCache> schemaDict)
        {
            if (IsBranchNode(expression))
            {
                if (ExpressionType.Call == expression.NodeType)
                {
                    AnalyzingMethodExpression(dbProvider, expression as MethodCallExpression, component, schemaDict);
                }
                else
                {
                    BinaryExpression binaryExpression = expression as BinaryExpression;
                    if (!IsBranchNode(binaryExpression.Left))
                    {
                        SchemaCache schema = null;
                        String propertyName = String.Empty;
                        String className = String.Empty;
                        String symbol = String.Empty;
                        Object value = null;
                        //两个表达式是否类型完全相等
                        Boolean isEqual = false;
                        MemberExpression memberExpression = binaryExpression.Left as MemberExpression;
                        MemberExpression rightMemberExpression = null;
                        String rightClassName = null;
                        if (memberExpression == null || memberExpression.Member.MemberType != MemberTypes.Property)
                        {
                            throw new ArgumentException(nameof(expression));
                        }
                        propertyName = memberExpression.Member.Name;
                        symbol = GetSymbol(binaryExpression.NodeType);

                        className = memberExpression.Member.DeclaringType.Name;
                        if (schemaDict != null)
                        {
                            schema = schemaDict[className];
                        }
                        if (binaryExpression.Right.NodeType == binaryExpression.Left.NodeType)
                        {
                            rightMemberExpression = binaryExpression.Right as MemberExpression;
                            isEqual = rightMemberExpression.Member.MemberType == memberExpression.Member.MemberType;
                            rightClassName = rightMemberExpression.Member.DeclaringType.Name;
                        }
                        if (schemaDict != null && isEqual && schemaDict.Count>1 && schemaDict.ContainsKey(rightClassName))
                        {
                            //关联查询时  例如 t.XX==t1.XX 这种表达式的解析

                            String rightPropertyName = rightMemberExpression.Member.Name;
                            SchemaCache rightSchema = schemaDict[rightClassName];
                            String innerSymbol = GetSymbol(binaryExpression.NodeType);

                            String leftColumnName = schema[propertyName];
                            String rightColumnName = rightSchema[rightPropertyName];

                            leftColumnName =OrmAssistor.BuildColumnName(schema.GetColumnSchema(propertyName), dbProvider.ConflictFreeFormat, schema.TableName);

                            rightColumnName = OrmAssistor.BuildColumnName(rightSchema.GetColumnSchema(rightPropertyName), dbProvider.ConflictFreeFormat, rightSchema.TableName);


                            component.AppendSQL(leftColumnName);
                            component.AppendSQL(innerSymbol);
                            component.AppendSQL(rightColumnName);


                        }
                        else
                        {
                            value = ExtractExpressionContainValue(binaryExpression.Right);
                            var colSchema = schema.GetColumnSchema(propertyName);
                            String columnName = colSchema.Name;
                            String parameterName = dbProvider.Prefix + columnName + ParaCounter<T>.CountStr;
                            columnName=OrmAssistor.BuildColumnName(colSchema, dbProvider.ConflictFreeFormat, schema.TableName);
                            DbParameter parameter = dbProvider.DbParameter(
                                 parameterName,
                                 value ?? DBNull.Value,
                                 colSchema.DbType
                                );
                            component.AppendSQL(columnName);
                            component.AppendSQL(symbol);
                            component.AppendSQL(parameter.ParameterName);
                            component.AddParameter(parameter);
                        }

                    }
                    else
                    {
                        AnalyzingExpressionTree(dbProvider, binaryExpression.Left, component, schemaDict);
                        component.AppendSQL(GetSymbol(binaryExpression.NodeType));
                        AnalyzingExpressionTree(dbProvider, binaryExpression.Right, component, schemaDict);
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

            AnalyzingExpressionTree(provider, body, component,
                new Dictionary<String, SchemaCache>
                {
                    { Table<T>.Schema.Type.Name, Table<T>.Schema }
                });
        }
        public static void JoinOn<T1>(DbProvider provider, Expression<Func<T, T1, Boolean>> predicate, SQLComponent component) where T1 : class
        {
            Expression body = predicate.Body;
            Dictionary<String, SchemaCache> schemaDic = new Dictionary<String, SchemaCache>
            {
                { Table<T>.Schema.Type.Name, Table<T>.Schema},
                { Table<T1>.Schema.Type.Name, Table<T1>.Schema}
            };
            AnalyzingExpressionTree(provider, body, component, schemaDic);
        }
        public static void JoinWhere<T1>(DbProvider provider, Expression<Func<T, T1, Boolean>> predicate, SQLComponent component) where T1 : class
        {
            Expression body = predicate.Body;
            Dictionary<String, SchemaCache> schemaDic = new Dictionary<String, SchemaCache>
            {
                { Table<T>.Schema.Type.Name, Table<T>.Schema},
                { Table<T1>.Schema.Type.Name, Table<T1>.Schema}
            };
            AnalyzingExpressionTree(provider, body, component, schemaDic);
        }
    }

}
