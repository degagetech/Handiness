using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq.Expressions;
namespace Handiness.Orm
{

    public static class TableExtensions
    {
        /*.................查询.................*/
        /// <summary>
        /// 执行指定的查询语句
        /// </summary>
        /// <param name="sql">参数占位需要自己处理</param>
        /// <param name="paras">参数</param>
        /// <returns>若无数据，则返回一个元素个数为零的链表</returns>
        public static List<T> ExecuteQuery<T>(this Table<T> tableObj, String sql, params DbParameter[] paras) where T : class
        {
            List<T> results = new List<T>();
            if (!String.IsNullOrEmpty(sql))
            {
                return results;
            }
            using (DbConnection connection = tableObj.DbProvider.DbConnection())
            {
                DbCommand command = tableObj.DbProvider.DbCommand();
                command.CommandText = sql;
                command.Parameters.AddRange(paras);
                connection.Open();
                DbDataReader dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {

                }
            }
            return results;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tableObj"></param>
        /// <param name="selectSql">只写需要查询的字段 例如 Name,Sex,Age</param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static IDriver<T> Select<T>(this Table<T> tableObj, String selectSql, IEnumerable<DbParameter> parameters = null) where T : class
        {
            if (String.IsNullOrEmpty(selectSql.Trim()))
            {
                return Select<T>(tableObj);
            }
            selectSql = String.Format(BasicSqlFormat.SELECT_FORMAT, selectSql, Table<T>.Schema.TableName);
            IDriver<T> driver = tableObj.DbProvider.Driver<T>();
            driver.SQLComponent.Append(selectSql, parameters);
            return driver;
        }
        /// <summary>
        /// 查询表中记录的数量
        /// </summary>
        public static IDriver<T> Count<T>(this Table<T> tableObj) where T : class
        {
            return Select<T>(tableObj, "COUNT(*)");
        }
        public static IDriver<T> Select<T>(this Table<T> tableObj) where T : class
        {
            String sql = String.Format
                (
                BasicSqlFormat.SELECT_FORMAT,
                SqlKeyWord.ASTERISK,
                Table<T>.Schema.TableName
                );

            IDriver<T> driver = tableObj.DbProvider.Driver<T>();
            driver.SQLComponent.AppendSQL(sql);
            return driver;
        }
        public static IDriver<T> Select<T>(this Table<T> tableObj, Expression<Func<T, dynamic>> selector) where T : class
        {
            String selectSql = LambdaToSqlConverter<T>.SelectConvert(selector);
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

            List<DbParameter> parameters = new List<DbParameter>();
            String updateSql = LambdaToSqlConverter<T>.UpdateConvert(tableObj.DbProvider, regenerator, parameters, "UP");

            IDriver<T> driver = tableObj.DbProvider.Driver<T>();
            driver.SQLComponent.Append(updateSql, parameters);

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

            List<DbParameter> parameters = new List<DbParameter>();
            String insertSql = ObjectToSqlConverter<T>.InsertConvert(tableObj.DbProvider, obj, parameters);

            IDriver<T> driver = tableObj.DbProvider.Driver<T>();
            driver.SQLComponent.Append(insertSql, parameters);

            return driver;
        }
        /*.................批量插入.................*/
        /// <summary>
        ///批量插入
        /// </summary>
        public static IDriver<T> BatchInsert<T>(this Table<T> tableObj, IEnumerable<T> objs) where T : class
        {
            List<DbParameter> parameters = new List<DbParameter>();
            String insertSql = ObjectToSqlConverter<T>.BatchInsertConvert(tableObj.DbProvider, objs, parameters);
            IDriver<T> driver = tableObj.DbProvider.Driver<T>();
            driver.SQLComponent.Append(insertSql, parameters);
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
        public static DbTransaction BeginTransaction<T>(this Table<T> tableObj, String connectionString = null) where T : class
        {
            String connectionStr = connectionString == null ? tableObj.DbProvider.ConnectionString : connectionString;
            DbConnection connection = tableObj.DbProvider.DbConnection(connectionStr);
            connection.Open();
            DbTransaction tansaction = connection.BeginTransaction();
            return tansaction;
        }
        public static void CommitTransaction<T>(this Table<T> tableObj, DbTransaction transaction) where T : class
        {
            try
            {
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
            finally
            {
                if (transaction.Connection.State == System.Data.ConnectionState.Open)
                {
                    transaction.Connection.Close();
                }
            }
        }
    }
}

