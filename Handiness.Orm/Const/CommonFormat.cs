using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handiness.Orm
{
    public class CommonFormat
    {
        /// <summary>
        /// 列名 0 表名 1 列名
        /// </summary>
        public const String COLUMN_FORMAT = " {0}.{1} ";
        /// <summary>
        /// 排序 0 列名称 1 排序规则
        /// </summary>
        public const String ORDER_BY_FORMAT = " ORDER BY {0} {1} ";
        /// <summary>
        /// 内联接 0 表名 1联接条件
        /// </summary>
        public const String JOIN_ON_FORMAT = " JOIN {0} ON {1}";

        public const String BRACKET_FORMAT = " ({0}) ";
    }
}
