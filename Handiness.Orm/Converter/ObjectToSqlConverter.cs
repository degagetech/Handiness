using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Reflection;
using System.Text;

namespace Handiness.Orm
{
    /// <summary>
    /// 用于将对象包含的信息转换成相应类型的SQL语句字符串
    /// </summary>
    public class ObjectToSqlConverter<T> where T : class
    {
        public static void BatchReplaceConvert(DbProvider dbProvider, IEnumerable<T> objs, SQLComponent component)
        {
            foreach (T obj in objs)
            {
                ReplaceConvert(dbProvider, obj, component);
                component.AppendSQL(SqlKeyWord.SEMICOLON);
            }
        }
        public static void ReplaceConvert(DbProvider dbProvider, T obj, SQLComponent component)
        {
            String columnName = null;
            String parameterName = null;
            Object value = null;
            DbParameter dbParameter = null;
            StringBuilder parameterNames = new StringBuilder();
            StringBuilder columnNames = new StringBuilder();
            Int32 length = Table<T>.Schema.PropertyInfos.Length;
            for (Int32 i = 0; i < length; ++i)
            {
                PropertyInfo info = Table<T>.Schema.PropertyInfos[i];
                columnName = Table<T>.Schema[info.Name];
                value = Table<T>.Schema.PropertyAccessor.GetValue(i, obj);
                //主键、默认值、可空判断
                parameterName = dbProvider.Prefix + columnName + ParaCounter<T>.CountStr;

                dbParameter = dbProvider.DbParameter(
                  parameterName,
                    value ?? DBNull.Value);
                columnNames.Append(String.Format(dbProvider.ConflictFreeFormat, columnName));
                parameterNames.Append(dbParameter.ParameterName);
                if (i != (length - 1))
                {
                    columnNames.Append(SqlKeyWord.COMMA);
                    parameterNames.Append(SqlKeyWord.COMMA);
                }

                component.AddParameter(dbParameter);
            }
            component.AppendSQLFormat(BasicSqlFormat.REPLACE_FORMAT,
                Table<T>.Schema.TableName,
                columnNames.ToString(),
                parameterNames.ToString());
        }
        public static void InsertConvert(DbProvider dbProvider, T obj, SQLComponent component)
        {

            String columnName = null;
            String parameterName = null;
            Object value = null;
            DbParameter dbParameter = null;
            StringBuilder parameterNames = new StringBuilder();
            StringBuilder columnNames = new StringBuilder();
            Int32 length = Table<T>.Schema.PropertyInfos.Length;
            for (Int32 i = 0; i < length; ++i)
            {
                PropertyInfo info = Table<T>.Schema.PropertyInfos[i];
                columnName = Table<T>.Schema[info.Name];
                value = Table<T>.Schema.PropertyAccessor.GetValue(i, obj);

                parameterName = dbProvider.Prefix + columnName + ParaCounter<T>.CountStr;
                dbParameter = dbProvider.DbParameter(parameterName, value ?? DBNull.Value);

                columnNames.Append(String.Format(dbProvider.ConflictFreeFormat, columnName));
                parameterNames.Append(dbParameter.ParameterName);
                if (i != (length - 1))
                {
                    columnNames.Append(SqlKeyWord.COMMA);
                    parameterNames.Append(SqlKeyWord.COMMA);
                }
                component.AddParameter(dbParameter);
            }
            component.AppendSQLFormat(BasicSqlFormat.INSERT_FORMAT,
                Table<T>.Schema.TableName,
                columnNames.ToString(),
                parameterNames.ToString());

        }
        public static void BatchInsertConvert(DbProvider dbProvider, IEnumerable<T> objs, SQLComponent component)
        {
            foreach (T obj in objs)
            {
                InsertConvert(dbProvider, obj, component);
                component.AppendSQL(SqlKeyWord.SEMICOLON);
            }
        }
    }
}
