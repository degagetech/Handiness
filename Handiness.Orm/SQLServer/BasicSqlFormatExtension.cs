using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biobank.Orm
{
    public partial class BasicSqlFormat
    {
        /// <summary>
        /// 分页查询格式    0 查询语句    1 排序字段名称  2 起始位置  3 结束位置  4 排序规则
        /// </summary>
        public const String PAGE_QUERY_FORMAT =
            "SELECT * FROM  (  SELECT TOP {3}  *, ROW_NUMBER () OVER (ORDER BY SOURCE.[{1}] {4}) AS [ROW_NUM]  FROM  ({0}) as SOURCE" +
            ") AS T   WHERE  T.[ROW_NUM]> {2}";
        /// <summary>
        /// CTE 递归查询格式       0  查询列(不能为 *)    
        /// </summary>
        public const String CET_QUERY_FORMAT = @"WITH {3}({0}) AS ({1} UNION ALL {2}) SELECT * FROM  {3}";


        /// <summary>
        /// 查询 0 前X条记录 1 查询的列名  2 表名
        /// </summary>
        public const String SELECT_TOP_FORMAT = "SELECT  TOP {0} {1} FROM {2} ";
    }
}
