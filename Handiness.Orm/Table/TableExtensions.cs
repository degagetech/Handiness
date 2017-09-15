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
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tableObj"></param>
        /// <param name="selectSql">只写需要查询的字段 例如 Name,Sex,Age</param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static IServomotor<T> Select<T>(this Table<T> tableObj, String selectSql, IEnumerable<DbParameter> parameters = null) where T : class
        {
            if (String.IsNullOrEmpty(selectSql.Trim()))
            {
                return Select<T>(tableObj);
            }
            selectSql = String.Format(BasicSqlFormat.SelectFormat.Describe(), selectSql, Table<T>.TableReflectionCache.TableName);
            IServomotor<T> servomotor = tableObj.BindingDbProvider.ServomotorFactroy<T>();
            servomotor.AppendSql(selectSql);
            servomotor.AppendDbParameters(parameters);
            return servomotor;
        }
        /// <summary>
        /// 查询表中记录的数量
        /// </summary>
        public static IServomotor<T> Count<T>(this Table<T> tableObj) where T : class
        {
            return Select<T>(tableObj, "count(*)");
        }
        public static IServomotor<T> Select<T>(this Table<T> tableObj) where T : class
        {
            String sql = String.Format
                (
                BasicSqlFormat.SelectFormat.Describe(),
                SqlKeyWord.AllColumn.Describe(),
                Table<T>.TableReflectionCache.TableName
                );
            IServomotor<T> servomotor = tableObj.BindingDbProvider.ServomotorFactroy<T>();
            servomotor.AppendSql(sql);
            return servomotor;
        }
        public static IServomotor<T> Select<T>(this Table<T> tableObj, Expression<Func<T, dynamic>> selector) where T : class
        {
            String selectSql = LambdaToSqlConverter<T>.SelectConvert(selector);
            if (String.IsNullOrEmpty(selectSql))
            {
                return Select<T>(tableObj);
            }
            IServomotor<T> servomotor = tableObj.BindingDbProvider.ServomotorFactroy<T>();
            servomotor.AppendSql(selectSql);
            servomotor.Selector = selector;
            return servomotor;
        }

        public static IServomotor<T> Select<T>(this Table<T> tableObj, Expression<Func<T, String>> propertyNameExp) where T : class
        {
            String propertyName = Expression.Lambda(propertyNameExp.Body).Compile().DynamicInvoke() as String;
            String columnName = Table<T>.TableReflectionCache.ColumnAttributeCollection[propertyName].Name;
            return Select<T>(tableObj, columnName);
        }
        /*.................更新.................*/
        public static IServomotor<T> Update<T>(this Table<T> tableObj, Expression<Func<T>> regenerator) where T : class
        {

            List<DbParameter> parameterList = new List<DbParameter>();
            String updateSql = LambdaToSqlConverter<T>.UpdateConvert(tableObj.BindingDbProvider, regenerator, parameterList, "UP");

            IServomotor<T> servomotor = tableObj.BindingDbProvider.ServomotorFactroy<T>();
            servomotor.AppendSql(updateSql);
            servomotor.DbParameterCollection.AddRange(parameterList);
            return servomotor;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="updateSql">只写更新字段的语句  例如 Name="小王"</param>
        /// <param name="parameterArray"></param>
        /// <returns></returns>
        public static IServomotor<T> Update<T>(this Table<T> tableObj, String updateSql, IEnumerable<DbParameter> parameters = null) where T : class
        {
            if (String.IsNullOrEmpty(updateSql))
            {
                throw new ArgumentException("无效的更新语句!");
            }
            updateSql = String.Format(BasicSqlFormat.UpdateFormat.Describe(),
                Table<T>.TableReflectionCache.TableName,
                updateSql);
            IServomotor<T> servomotor = tableObj.BindingDbProvider.ServomotorFactroy<T>();
            servomotor.AppendSql(updateSql);
            servomotor.AppendDbParameters(parameters);
            return servomotor;
        }
        /*.................插入.................*/
        public static IServomotor<T> Insert<T>(this Table<T> tableObj, T obj) where T : class
        {

            List<DbParameter> dbParameterList = new List<DbParameter>();
            String insertSql = ObjectToSqlConverter<T>.InsertConvert(tableObj.BindingDbProvider, obj, dbParameterList);
            IServomotor<T> servomotor = tableObj.BindingDbProvider.ServomotorFactroy<T>();
            servomotor.AppendSql(insertSql);
            servomotor.DbParameterCollection.AddRange(dbParameterList);
            return servomotor;
        }
        /*.................批量插入.................*/
        /// <summary>
        ///批量插入
        /// </summary>
        public static IServomotor<T> BulkInsert<T>(this Table<T> tableObj, IEnumerable<T> objs) where T : class
        {
            List<DbParameter> dbParameterList = new List<DbParameter>();
            String insertSql = ObjectToSqlConverter<T>.BulkInsertConvert(tableObj.BindingDbProvider, objs, dbParameterList);
            IServomotor<T> servomotor = tableObj.BindingDbProvider.ServomotorFactroy<T>();
            servomotor.AppendSql(insertSql);
            servomotor.DbParameterCollection.AddRange(dbParameterList);
            return servomotor;
        }
        public static IServomotor<T> Insert<T>(this Table<T> tableObj, String columnSql, String valueSql, IEnumerable<DbParameter> parameters) where T : class
        {
            String insertSql = String.Format(BasicSqlFormat.InsertFormat.Describe(),
                Table<T>.TableReflectionCache.TableName,
                columnSql,
                valueSql
                );
            IServomotor<T> servomotor = tableObj.BindingDbProvider.ServomotorFactroy<T>();
            servomotor.AppendSql(insertSql);
            servomotor.AppendDbParameters(parameters);
            return servomotor;
        }
        public static ITransactionExecutor<T> MakeInsertTransaction<T>(this Table<T> tableObj, Int32 maximum = 100, String connectionString = null) where T : class
        {
            return new WriteTransactionExecutor<T>(tableObj, maximum, connectionString);
        }
        public static ITransactionExecutor<T> MakeReplaceTransaction<T>(this Table<T> tableObj, Int32 maximum = 100, String connectionString = null) where T : class
        {
            return new ReplaceTransactionExecutor<T>(tableObj, maximum, connectionString);
        }
        /************Delete*************/
        public static IServomotor<T> Delete<T>(this Table<T> tableObj) where T : class
        {
            String deleteSql = String.Format(BasicSqlFormat.DeleteFormat.Describe(), Table<T>.TableReflectionCache.TableName);
            IServomotor<T> servomotor = tableObj.BindingDbProvider.ServomotorFactroy<T>();
            servomotor.AppendSql(deleteSql);
            return servomotor;
        }
        //IServomotor<T> Delete(String deleteSql, DbParameter[] parameterArray = null);

        /******** Truncate*************/
        public static IServomotor<T> Truncate<T>(this Table<T> tableObj) where T : class
        {
            String truncateSql = String.Format(BasicSqlFormat.TruncateFormat.Describe(), Table<T>.TableReflectionCache.TableName);
            IServomotor<T> servomotor = tableObj.BindingDbProvider.ServomotorFactroy<T>();
            servomotor.AppendSql(truncateSql);
            return servomotor;
        }

        /**********Transaction***********/
        public static  DbTransaction BeginTransaction<T>(this Table<T> tableObj, String connectionString = null) where T : class
        {
            String connectionStr = connectionString == null ? tableObj.BindingDbProvider.ConnectionString : connectionString;
            DbConnection connection = tableObj.BindingDbProvider.DbConnectionFactroy(connectionStr);
            connection.Open();
            DbTransaction tansaction = connection.BeginTransaction();
            return  tansaction;
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

