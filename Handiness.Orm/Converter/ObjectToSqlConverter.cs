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
                var colSchema = Table<T>.Schema.GetColumnSchema(info.Name);
                columnName = colSchema.Name;
                value = Table<T>.Schema.PropertyAccessor.GetValue(i, obj);
                //主键、默认值、可空判断
                parameterName = dbProvider.Prefix + columnName + ParaCounter<T>.CountStr;

                dbParameter = dbProvider.DbParameter(
                     parameterName,
                     value ?? DBNull.Value,
                     colSchema.DbType);
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
        public static void UpdateConvert(DbProvider dbProvider, T obj, SQLComponent component)
        {
            StringBuilder updateColumnNames = new StringBuilder();
            Int32 length = Table<T>.Schema.PropertyInfos.Length;
            for (Int32 i = 0; i < length; ++i)
            {
                PropertyInfo info = Table<T>.Schema.PropertyInfos[i];
                ColumnSchema colSchema = Table<T>.Schema.GetColumnSchema(info.Name);
                if (colSchema.IsPrimaryKey) continue;
                Object value = Table<T>.Schema.PropertyAccessor.GetValue(i, obj);
                if (value == null) continue;
                String columnName = colSchema.Name;
                String parameterName = dbProvider.Prefix + columnName + ParaCounter<T>.CountStr;
                DbParameter dbParameter = dbProvider.DbParameter
                    (
                            parameterName,
                            value ?? DBNull.Value,
                            colSchema.DbType
                    );
                updateColumnNames.Append(String.Format(dbProvider.ConflictFreeFormat, columnName));
                updateColumnNames.Append(SqlKeyWord.EQUAL);
                updateColumnNames.Append(parameterName);
                updateColumnNames.Append(SqlKeyWord.COMMA);
                component.AddParameter(dbParameter);
            }
            updateColumnNames.Remove(updateColumnNames.Length - SqlKeyWord.COMMA.Length, SqlKeyWord.COMMA.Length);
            component.AppendSQLFormat(BasicSqlFormat.UPDATE_FORMAT, Table<T>.Schema.TableName, updateColumnNames.ToString());
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
                var colSchema = Table<T>.Schema.GetColumnSchema(info.Name);
                columnName = colSchema.Name;
                value = Table<T>.Schema.PropertyAccessor.GetValue(i, obj);
                if (value == null) continue;
                parameterName = dbProvider.Prefix + columnName + ParaCounter<T>.CountStr;
                dbParameter = dbProvider.DbParameter(parameterName, value ?? DBNull.Value, colSchema.DbType);

                columnNames.Append(String.Format(dbProvider.ConflictFreeFormat, columnName));
                parameterNames.Append(dbParameter.ParameterName);
                columnNames.Append(SqlKeyWord.COMMA);
                parameterNames.Append(SqlKeyWord.COMMA);
                component.AddParameter(dbParameter);
            }
            Int32 commaLength = SqlKeyWord.COMMA.Length;
            columnNames.Remove(columnNames.Length - commaLength, commaLength);
            parameterNames.Remove(parameterNames.Length - commaLength, commaLength);

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
