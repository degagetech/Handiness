using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq.Expressions;
using System.Text;

namespace Handiness.Orm
{

    public static class TableExtensions
    {
        /*.................查询.................*/
        /// <summary>
        /// 执行指定的查询语句，并返回包含查询结果的<see cref="DataTable"/>对象
        /// </summary>
        /// <returns>若参数异常，返回空引用</returns>
        public static DataTable Query(this Table tableObj, String sql, DbParameter[] paras = null, DbConnection connection = null)
        {
            DataTable table = null;
            if (String.IsNullOrEmpty(sql))
            {
                return table;
            }
            table = new DataTable();
            Boolean requiredDispose = connection == null;
            try
            {
                connection = connection??tableObj.DbProvider.DbConnection();
                DbCommand command = tableObj.DbProvider.DbCommand();
                ExceutePrepare(connection, command, sql, paras);
                connection.Open();
                DbDataReader dataReader = command.ExecuteReader();
                command.Parameters.Clear();
                table.Load(dataReader);
            }
            finally
            {
                if (requiredDispose)
                {
                    connection.Dispose();
                }
            }
            return table;
        }
        /// <summary>
        /// 执行指定的查询语句
        /// </summary>
        /// <param name="sql">参数占位需要自己处理</param>
        /// <param name="paras">参数</param>
        /// <returns>若无数据，或参数异常则返回一个元素个数为零的链表</returns>
        public static List<T> Query<T>(this Table tableObj, String sql, DbParameter[] paras = null, DbConnection connection = null) where T : class
        {
            List<T> results = new List<T>();
            if (String.IsNullOrEmpty(sql))
            {
                return results;
            }
            Boolean requiredDispose = connection == null;
            try
            {
                connection = connection ?? tableObj.DbProvider.DbConnection();
                DbCommand command = tableObj.DbProvider.DbCommand();
                ExceutePrepare(connection, command, sql, paras);
                connection.Open();
                DbDataReader dataReader = command.ExecuteReader();
                command.Parameters.Clear();
                results = DataExtractor<T>.ToList(dataReader);
            }
            finally
            {
                if (requiredDispose)
                {
                    connection.Dispose();
                }
            }

            return results;
        }
        public static IDriver<T> DistinctSelect<T>(this Table<T> tableObj, String columnNames = null) where T : class
        {
            String sql = String.Format
               (
               BasicSqlFormat.SELECT_DISTINCT_FORMAT,
               columnNames ?? GetColumnNames<T>(tableObj),
               Table<T>.Schema.TableName
               );

            IDriver<T> driver = tableObj.DbProvider.Driver<T>();
            driver.SQLComponent.AppendSQL(sql);
            return driver;
        }
        /// <summary>
        /// 执行非查询SQL语句
        /// </summary>
        public static Int32 Execute(this Table tableObj, String sql, params DbParameter[] paras)
        {
            Int32 effect = 0;
            using (DbConnection connection = tableObj.DbProvider.DbConnection())
            {
                DbCommand command = tableObj.DbProvider.DbCommand();
                ExceutePrepare(connection, command, sql, paras);
                connection.Open();
                effect = command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
            return effect;
        }

        private static void ExceutePrepare(
            DbConnection connection,
            DbCommand command,
            String sql,
            DbParameter[] parameters)
        {
            command.Connection = connection;
            command.CommandText = sql;
            if (parameters != null && parameters.Length > 0)
                command.Parameters.AddRange(parameters);

        }
        /// <summary>
        /// 查询指定列，列名使用字符串，例如 name,sex,age
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tableObj"></param>
        /// <param name="columnNames">列名，例如 name,sex,age </param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static IDriver<T> Select<T>(this Table<T> tableObj, String columnNames, IEnumerable<DbParameter> parameters = null) where T : class
        {
            if (String.IsNullOrEmpty(columnNames.Trim()))
            {
                return Select<T>(tableObj);
            }
            columnNames = String.Format(BasicSqlFormat.SELECT_FORMAT, columnNames, Table<T>.Schema.TableName);
            IDriver<T> driver = tableObj.DbProvider.Driver<T>();
            driver.SQLComponent.Append(columnNames, parameters);
            return driver;
        }
        /// <summary>
        /// 查询表中记录的数量
        /// </summary>
        public static IDriver<T> Count<T>(this Table<T> tableObj) where T : class
        {
            return Select<T>(tableObj, SqlKeyWord.COUNT_ALL);
        }
        public static IDriver<T> Select<T>(this Table tableObj, String columnNames = null) where T : class
        {
            String sql = String.Format
                (
                BasicSqlFormat.SELECT_FORMAT,
                columnNames ?? GetAllColumnNames<T>(tableObj),
                Table<T>.Schema.TableName
                );

            IDriver<T> driver = tableObj.DbProvider.Driver<T>();
            driver.SQLComponent.AppendSQL(sql);
            return driver;
        }
        /// <summary>
        /// 获取指定类型的表的包含所有列名信息的字符串，若别名传入 null，表示根据使用默认设置的表名，若传入 <see cref="String.Empty"/>，表示不使用表名前缀
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tableObj"></param>
        /// <param name="tableAlias"></param>
        /// <returns></returns>
        public static String GetColumnNames<T>(this Table<T> tableObj, String tableAlias = null) where T : class
        {
            return GetAllColumnNames<T>(tableObj, tableAlias);
        }
        public static String GetAllColumnNames<T>(this Table tableObj, String tableAlias = null) where T : class
        {
            StringBuilder builder = new StringBuilder();
            String tableName = tableAlias;
            if (tableAlias == String.Empty)
            {
                tableName = null;
            }
            else if (tableAlias == null)
            {
                tableName = Table<T>.Schema.TableName;
            }
            Int32 count = Table<T>.Schema.ColumnNames.Count;
            Int32 i = 1;
            foreach (var colSchema in Table<T>.Schema.GetColumnSchemas())
            {
                String colName = OrmAssistor.BuildColumnName(colSchema, tableObj.DbProvider.ConflictFreeFormat, tableName);
                builder.AppendFormat(colName);
                if (i++ != count)
                {
                    builder.Append(SqlKeyWord.COMMA);
                }
            }
            return builder.ToString(); ;
        }
        public static IDriver<T> Select<T>(this Table<T> tableObj) where T : class
        {
            String sql = String.Format
                (
                BasicSqlFormat.SELECT_FORMAT,
                GetColumnNames<T>(tableObj),
                Table<T>.Schema.TableName
                );

            IDriver<T> driver = tableObj.DbProvider.Driver<T>();
            driver.SQLComponent.AppendSQL(sql);
            return driver;
        }
        public static IDriver<T> Select<T>(this Table<T> tableObj, Expression<Func<T, dynamic>> selector) where T : class
        {

            String selectSql = LambdaToSqlConverter<T>.SelectConvert(tableObj.DbProvider.ConflictFreeFormat, selector);
            if (String.IsNullOrEmpty(selectSql))
            {
                return Select<T>(tableObj);
            }

            IDriver<T> driver = tableObj.DbProvider.Driver<T>();
            driver.SQLComponent.AppendSQL(selectSql);

            return driver;
        }

        public static IDriver<T> Select<T>(this Table<T> tableObj, Expression<Func<T, String>> propertyNameExp) where T : class
        {
            String propertyName = Expression.Lambda(propertyNameExp.Body).Compile().DynamicInvoke() as String;
            String columnName = Table<T>.Schema[propertyName];
            return Select<T>(tableObj, columnName);
        }


        /*.................更新.................*/
        public static IDriver<T> Update<T>(this Table<T> tableObj, Expression<Func<T>> regenerator) where T : class
        {

            IDriver<T> driver = tableObj.DbProvider.Driver<T>();
            LambdaToSqlConverter<T>.UpdateConvert(tableObj.DbProvider, regenerator, driver.SQLComponent);
            return driver;
        }
        /// <summary>
        /// 使用指定对象更新记录，注意此方法只会更新不为空的字段，以及非主键字段
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tableObj"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static IDriver<T> Update<T>(this Table<T> tableObj, T obj) where T : class
        {
            IDriver<T> driver = tableObj.DbProvider.Driver<T>();
            ObjectToSqlConverter<T>.UpdateConvert(tableObj.DbProvider, obj, driver.SQLComponent);
            return driver;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="updateSql">只写更新字段的语句  例如 Name="小王"</param>
        /// <param name="parameterArray"></param>
        /// <returns></returns>
        public static IDriver<T> Update<T>(this Table<T> tableObj, String updateSql, IEnumerable<DbParameter> parameters = null) where T : class
        {
            if (String.IsNullOrEmpty(updateSql))
            {
                throw new ArgumentException("update sql is empty");
            }
            updateSql = String.Format(BasicSqlFormat.UPDATE_FORMAT,
                Table<T>.Schema.TableName,
                updateSql);

            IDriver<T> driver = tableObj.DbProvider.Driver<T>();
            driver.SQLComponent.Append(updateSql, parameters);

            return driver;
        }
        /*.................插入.................*/
        public static IDriver<T> Insert<T>(this Table<T> tableObj, T obj) where T : class
        {
            IDriver<T> driver = tableObj.DbProvider.Driver<T>();
            ObjectToSqlConverter<T>.InsertConvert(tableObj.DbProvider, obj, driver.SQLComponent);
            return driver;
        }
        /*.................批量插入.................*/
        /// <summary>
        ///批量插入
        /// </summary>
        public static IDriver<T> BatchInsert<T>(this Table<T> tableObj, IEnumerable<T> objs) where T : class
        {
            IDriver<T> driver = tableObj.DbProvider.Driver<T>();
            ObjectToSqlConverter<T>.BatchInsertConvert(tableObj.DbProvider, objs, driver.SQLComponent);

            return driver;
        }
        public static IDriver<T> Insert<T>(this Table<T> tableObj, String columnSql, String valueSql, IEnumerable<DbParameter> parameters) where T : class
        {
            String insertSql = String.Format(BasicSqlFormat.INSERT_FORMAT,
                Table<T>.Schema.TableName,
                columnSql,
                valueSql
                );
            IDriver<T> driver = tableObj.DbProvider.Driver<T>();
            driver.SQLComponent.Append(insertSql, parameters);
            return driver;
        }

        /************Delete*************/
        public static IDriver<T> Delete<T>(this Table<T> tableObj) where T : class
        {
            String deleteSql = String.Format(BasicSqlFormat.DELETE_FORMAT, Table<T>.Schema.TableName);
            IDriver<T> driver = tableObj.DbProvider.Driver<T>();
            driver.SQLComponent.AppendSQL(deleteSql);
            return driver;
        }
        //IServomotor<T> Delete(String deleteSql, DbParameter[] parameterArray = null);

        /******** Truncate*************/
        public static IDriver<T> Truncate<T>(this Table<T> tableObj) where T : class
        {
            String truncateSql = String.Format(BasicSqlFormat.TRUNCATE_FORMAT, Table<T>.Schema.TableName);
            IDriver<T> driver = tableObj.DbProvider.Driver<T>();
            driver.SQLComponent.AppendSQL(truncateSql);
            return driver;
        }

        /**********Transaction***********/
        public static DbTransaction Begin(this Table tableObj, String connectionString = null)
        {
            String connectionStr = connectionString ?? tableObj.DbProvider.ConnectionString;
            DbConnection connection = tableObj.DbProvider.DbConnection(connectionStr);
            connection.Open();
            DbTransaction tansaction = connection.BeginTransaction();
            return tansaction;
        }


        /// <summary>
        ///  减小指定数值字段的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tableObj"></param>
        /// <param name="field"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static IDriver<T> Decrement<T>(this Table<T> tableObj, Expression<Func<T, Object>> field, Single number = 1) where T : class
        {
            IDriver<T> driver = tableObj.DbProvider.Driver<T>();


            var expression = (field.Body as UnaryExpression);
            var mexp = expression.Operand as MemberExpression;
            if (mexp == null) throw new ArgumentException(nameof(field));

            SchemaCache schema = Table<T>.Schema;
            var colSchema = schema.GetColumnSchema(mexp.Member.Name);
            String columnName = OrmAssistor.BuildColumnName(colSchema, tableObj.DbProvider.ConflictFreeFormat, schema.TableName);
            String setSql = columnName + SqlKeyWord.EQUAL + columnName + SqlKeyWord.MINUS + number.ToString();
            String sql = String.Format(BasicSqlFormat.UPDATE_FORMAT, schema.TableName, setSql);
            driver.SQLComponent.AppendSQL(sql);
            return driver;
        }
        /// <summary>
        /// 增大指定数值字段的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tableObj"></param>
        /// <param name="field"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static IDriver<T> Increment<T>(this Table<T> tableObj, Expression<Func<T, Object>> field, Single number = 1) where T : class
        {
            IDriver<T> driver = tableObj.DbProvider.Driver<T>();


            var expression = (field.Body as UnaryExpression);
            var mexp = expression.Operand as MemberExpression;
            if (mexp == null) throw new ArgumentException(nameof(field));
            SchemaCache schema = Table<T>.Schema;
            var colSchema = schema.GetColumnSchema(mexp.Member.Name);
            String columnName = OrmAssistor.BuildColumnName(colSchema, tableObj.DbProvider.ConflictFreeFormat, schema.TableName);
            String setSql = columnName + SqlKeyWord.EQUAL + columnName + SqlKeyWord.PLUS + number.ToString();
            String sql = String.Format(BasicSqlFormat.UPDATE_FORMAT, schema.TableName, setSql);
            driver.SQLComponent.AppendSQL(sql);
            return driver;
        }
    }
}

