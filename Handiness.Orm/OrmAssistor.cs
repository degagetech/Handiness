
using System;

using System.Threading;
namespace Handiness.Orm
{
    /// <summary>
    ///为ORM框架提供常用辅助功能
    /// </summary>
    public static class OrmAssistor
    {

        internal static String BuildColumnName(ColumnSchema schema, String freeFormat, String tableName = null)
        {
            String result = schema.Name;
            result = String.Format(freeFormat, schema.Name);
            if (!schema.DisableColumnSpecifically && tableName != null)
            {
                result = String.Format(CommonFormat.COLUMN_FORMAT, tableName, result);
            }
            return result;
        }

#if SQLITE_ENABLE_
        using System.Data.SQLite;
        private readonly static String _SQLiteConnectionstringFormat = "Data Source={0};UTF8Encoding=True;";
        public static String FetchSQLiteConnectionString(String path) => String.Format(_SQLiteConnectionstringFormat, path);
        /// <summary>
        /// 清空SQLite连接池
        /// </summary>
        public static void ClearSQLiteDbConnectionPool()
        {
            SQLiteConnection.ClearAllPools();
            GC.Collect();
        }
#endif
        /********************************/

        /// <summary>
        /// 查询指定的字符串中是否含有指定的SQL关键词
        /// 
        /// 
        /// 
        /// </summary>
        internal static Boolean HasSqlKeyword(String sql, String keyword) => (-1 != sql?.ToLower().IndexOf(keyword.ToLower()));



    }
}
