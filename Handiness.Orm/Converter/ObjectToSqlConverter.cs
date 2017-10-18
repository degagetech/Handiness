using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Reflection;
using static Handiness.Orm.OrmToolkit;
namespace Handiness.Orm
{
    /// <summary>
    /// 对象转换器
    /// </summary>
    public class ObjectToSqlConverter<T> where T : class
    {
        public static String BulkReplaceConvert(DbProvider dbProvider, IEnumerable<T> objs, List<DbParameter> parameterList = null, String postfixParameterName = null)
        {
            String convertedString = String.Empty;
            Int32 replaceCount = 0;
            foreach (T obj in objs)
            {
                ++replaceCount;
                convertedString += ReplaceConvert(dbProvider, obj, parameterList, postfixParameterName + replaceCount.ToString()) + SqlKeyWord.Semicolon.Describe(true);
            }
            return convertedString;
        }
        public static String ReplaceConvert(DbProvider dbProvider, T obj, List<DbParameter> parameterList = null, String postfixParameterName = null) 
        {
            String convertedString = BasicSqlFormat.ReplaceFormat.Describe();
            ColumnAttribute columnAttribute = null;
            Object value = null;
            DbParameter dbParameter = null;
            String parameterNames = String.Empty;
            String columnNames = String.Empty;

            foreach (PropertyInfo propertyInfo in Table<T>.TableReflectionCache.ColumnPropertyCollection)
            {
                columnAttribute = Table<T>.TableReflectionCache.ColumnAttributeCollection[propertyInfo.Name];
                //    value = propertyInfo.GetValue(obj, null);
                value = Table<T>.TableReflectionCache.PropertyAccessor.GetProperityValue<Object>(obj, propertyInfo.Name);
                if (value == null)
                {
                    if (columnAttribute.IsPrimaryKey)
                    {
                        throw new ArgumentNullException(String.Format("Table: {0}，Filed:{1} Primary key can not be empty!", Table<T>.TableReflectionCache.TableName, columnAttribute.Name));
                    }
                    if (columnAttribute.IsNotNullable)
                    {
                        if (columnAttribute.DefalutValue == null)
                            throw new ArgumentNullException(String.Format("Table: {0}，Filed:{1} Can not be empty!", Table<T>.TableReflectionCache.TableName, columnAttribute.Name));
                        else
                            value = columnAttribute.DefalutValue;
                    }
                    else
                        continue;
                }
                columnNames += columnAttribute.Name + SqlKeyWord.Comma.Describe();
                dbParameter = dbProvider.DbParameterFactroy(
                     dbProvider.PrefixParameterName + columnAttribute.Name + postfixParameterName,
                    columnAttribute.Type,
                    value);
                parameterNames += dbParameter.ParameterName + SqlKeyWord.Comma.Describe();
                parameterList?.Add(dbParameter);
            }
            TrimEndComma(ref columnNames);
            TrimEndComma(ref parameterNames);
            convertedString = String.Format(convertedString,
                Table<T>.TableReflectionCache.TableName,
                columnNames,
                parameterNames);
            return convertedString;
        }
        public static String InsertConvert(DbProvider dbProvider, T obj, List<DbParameter> parameterList = null, String postfixParameterName = null)
        {
            String convertedString = BasicSqlFormat.InsertFormat.Describe();
            ColumnAttribute columnAttribute = null;
            Object value = null;
            DbParameter dbParameter = null;
            String parameterNames = String.Empty;
            String columnNames = String.Empty;

            foreach (PropertyInfo propertyInfo in Table<T>.TableReflectionCache.ColumnPropertyCollection)
            {
                columnAttribute = Table<T>.TableReflectionCache.ColumnAttributeCollection[propertyInfo.Name];
             //   value = propertyInfo.GetValue(obj, null);
                value = Table<T>.TableReflectionCache.PropertyAccessor.GetProperityValue<Object>(obj, propertyInfo.Name);
                if (value == null)
                {
                    if (columnAttribute.IsPrimaryKey)
                    {
                        throw new ArgumentNullException(String.Format("Table: {0}，Filed:{1} Primary key can not be empty!", Table<T>.TableReflectionCache.TableName, columnAttribute.Name));
                    }
                    if (columnAttribute.IsNotNullable)
                    {
                        if (columnAttribute.DefalutValue == null)
                            throw new ArgumentNullException(String.Format("Table: {0}，Filed:{1} Can not be empty!", Table<T>.TableReflectionCache.TableName, columnAttribute.Name));
                        else
                            value = columnAttribute.DefalutValue;
                    }
                    else continue;
                }
                columnNames += columnAttribute.Name + SqlKeyWord.Comma.Describe();
                dbParameter = dbProvider.DbParameterFactroy(
                     dbProvider.PrefixParameterName + columnAttribute.Name + postfixParameterName,
                    columnAttribute.Type,
                    value);
                parameterNames += dbParameter.ParameterName + SqlKeyWord.Comma.Describe();
                parameterList?.Add(dbParameter);
            }
            TrimEndComma(ref columnNames);
            TrimEndComma(ref parameterNames);
            convertedString = String.Format(convertedString,
                Table<T>.TableReflectionCache.TableName,
                columnNames,
                parameterNames);
            return convertedString;
        }
        public static String BulkInsertConvert(DbProvider dbProvider, IEnumerable<T> objs, List<DbParameter> parameterList = null, String postfixParameterName = null)
        {
            String convertedString = String.Empty;
            Int32 insertCount = 0;
            foreach (T obj in objs)
            {
                ++insertCount;
                convertedString += InsertConvert(dbProvider, obj, parameterList, postfixParameterName+insertCount.ToString()) + SqlKeyWord.Semicolon.Describe(true);
            }
            return convertedString;
        }
    }
}
