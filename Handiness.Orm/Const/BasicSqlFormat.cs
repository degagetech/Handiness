using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
namespace Handiness.Orm
{
    /// <summary>
    /// 提供一系列基础SQL语句的格式字符串
    /// </summary>
    public class BasicSqlFormat
    {
        public const String SELECT_FORMAT = "SELECT {0} FROM {1} ";
        public const String UPDATE_FORMAT = "UPDATE {0} SET {1} ";
        public const String INSERT_FORMAT = "INSERT INTO {0}({1}) VALUES({2}) ";
        public const String DELETE_FORMAT = "DELETE FROM {0} ";
        public const String TRUNCATE_FORMAT = "TRUNCATE TABLE {0} ";
        public const String REPLACE_FORMAT = "REPLACE INTO {0}({1}) VALUES({2}) ";
    }
}
