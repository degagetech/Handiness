
using System;
using System.Linq.Expressions;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections;
namespace Biobank.Orm
{
    public static class SQLServerTableExtension
    {
        /// <summary>
        /// 获取前指定数量的记录，此查询使用记录的默认顺序，不进行排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tableObj"></param>
        /// <param name="topNumber"></param>
        /// <returns></returns>
        public static IDriver<T> SelectTop<T>(this Table<T> tableObj, Int32 topNumber) where T : class
        {
            String sql = String.Format
                (
                BasicSqlFormat.SELECT_TOP_FORMAT, topNumber,
               TableExtensions.GetColumnNames<T>(tableObj),
                Table<T>.Schema.TableName
                );

            IDriver<T> driver = tableObj.DbProvider.Driver<T>();
            driver.SQLComponent.AppendSQL(sql);
            return driver;
        }
        public static IDriver<T> CETSelect<T>(this Table<T> tableObj, IDriver start, IDriver body) where T : class
        {
            return CETSelect<T>(tableObj, start.SQLComponent, body.SQLComponent);
        }
        public static IDriver<T> CETSelect<T>(this Table<T> tableObj, SQLComponent start, SQLComponent body) where T : class
        {
            IDriver<T> driver = tableObj.DbProvider.Driver<T>();
            String columnNames = tableObj.GetColumnNames();
            String sql = String.Format(BasicSqlFormat.CET_QUERY_FORMAT, columnNames, start.SQL, body.SQL);
            driver.SQLComponent.AppendSQL(sql);
            driver.SQLComponent.AddParameters(start.Parameters);
            driver.SQLComponent.AddParameters(body.Parameters);
            return driver;
        }
    }
}
