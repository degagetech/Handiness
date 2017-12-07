using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Reflection;
namespace Handiness.Orm
{
    /// <summary>
    /// 用于将对象包含的信息转换成相应类型的SQL语句字符串
    /// </summary>
    public class ObjectToSqlConverter<T> where T : class
    {
        public static String BatchReplaceConvert(DbProvider dbProvider, IEnumerable<T> objs, List<DbParameter> parameterList = null, String postfixParameterName = null)
        {
            String convertedString = String.Empty;
            Int32 replaceCount = 0;
            foreach (T obj in objs)
            {
                ++replaceCount;
                convertedString += ReplaceConvert(dbProvider, obj, parameterList, postfixParameterName + replaceCount.ToString()) + SqlKeyWord.SEMICOLON;
            }
            return convertedString;
        }
        public static String ReplaceConvert(DbProvider dbProvider, T obj, List<DbParameter> parameterList = null, String postfixParameterName = null)
        {
            String convertedString = BasicSqlFormat.REPLACE_FORMAT;
            String columnName = null;
            String parameterName = null;
            Object value = null;
            DbParameter dbParameter = null;
            String parameterNames = String.Empty;
            String columnNames = String.Empty;
            Int32 length = Table<T>.Schema.PropertyInfos.Length;
            for (Int32 i = 0; i < length; ++i)
            {
                PropertyInfo info = Table<T>.Schema.PropertyInfos[i];
                columnName = Table<T>.Schema[info.Name];
                value = Table<T>.Schema.PropertyAccessor.GetValue(i, obj);
                //主键、默认值、可空判断
                parameterName = dbProvider.Prefix + columnName + postfixParameterName;

                dbParameter = dbProvider.DbParameter(
                  parameterName,
                    value??DBNull.Value);
                columnNames += String.Format(dbProvider.ConflictFreeFormat, columnName);
                parameterNames += dbParameter.ParameterName;
                if (i != (length - 1))
                {
                    columnNames += SqlKeyWord.COMMA;
                    parameterNames +=SqlKeyWord.COMMA;
                }
     
                parameterList?.Add(dbParameter);
            }
            convertedString = String.Format(convertedString,
                Table<T>.Schema.TableName,
                columnNames,
                parameterNames);
            return convertedString;
        }
        public static String InsertConvert(DbProvider dbProvider, T obj, List<DbParameter> parameterList = null, String postfixParameterName = null)
        {
            String convertedString = BasicSqlFormat.INSERT_FORMAT;
            String columnName = null;
            String parameterName = null;
            Object value = null;
            DbParameter dbParameter = null;
            String parameterNames = String.Empty;
            String columnNames = String.Empty;
            Int32 length = Table<T>.Schema.PropertyInfos.Length;
            for (Int32 i = 0; i < length; ++i)
            {
                PropertyInfo info = Table<T>.Schema.PropertyInfos[i];
                columnName = Table<T>.Schema[info.Name];
                value = Table<T>.Schema.PropertyAccessor.GetValue(i, obj);

                parameterName = dbProvider.Prefix + columnName + postfixParameterName;
                dbParameter = dbProvider.DbParameter(parameterName,value ?? DBNull.Value);
                columnNames += String.Format(dbProvider.ConflictFreeFormat,columnName);
                parameterNames += dbParameter.ParameterName;
                if (i != (length - 1))
                {
                    columnNames += SqlKeyWord.COMMA;
                    parameterNames += SqlKeyWord.COMMA;
                }

                parameterList?.Add(dbParameter);
            }
            convertedString = String.Format(convertedString,
                Table<T>.Schema.TableName,
                columnNames,
                parameterNames);
            return convertedString;
        }
        public static String BatchInsertConvert(DbProvider dbProvider, IEnumerable<T> objs, List<DbParameter> parameterList = null, String postfixParameterName = null)
        {
            String convertedString = String.Empty;
            Int32 insertCount = 0;
            foreach (T obj in objs)
            {
                ++insertCount;
                convertedString += InsertConvert(dbProvider, obj, parameterList, postfixParameterName + insertCount.ToString()) + SqlKeyWord.SEMICOLON;
            }
            return convertedString;
        }
    }
}
