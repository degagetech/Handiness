using System;
using System.Data.SQLite;
using System.Threading;
namespace Handiness.Orm
{
    /// <summary>
    /// Handiness.Orm工具箱
    /// </summary>
    public static class OrmToolkit
    {
        private readonly static String _SQLiteConnectionstringFormat = "Data Source={0};UTF8Encoding=True;";

        /********************************/
        /// <summary>
        /// 去除字符串尾部的逗号
        /// </summary>
        /// <param name="source">源字符串的应用</param>
        internal static void TrimEndComma(ref String source) => source = source.Substring(0, source.Length - SqlKeyWord.Comma.Describe().Length);
        /// <summary>
        /// 查询指定的字符串中是否含有指定的sql关键词
        /// </summary>
        internal static Boolean HasSqlKeyword(String sql, SqlKeyWord keyword) => (-1 != sql?.ToLower().IndexOf(keyword.Describe(), StringComparison.Ordinal));

        public static String FetchSQLiteDbConnectionstringByPath(String path) => String.Format(_SQLiteConnectionstringFormat, path);
        /// <summary>
        /// 清空SQLite  连接池
        /// </summary>
        public static void ClearSQLiteDbConnectionPool()
        {
            SQLiteConnection.ClearAllPools();
            GC.Collect();
        }
    }
}
