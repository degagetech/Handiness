using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
namespace Handiness.Orm
{
    /// <summary>
    /// 基础sql语句格式
    /// </summary>
    public enum BasicSqlFormat
    {
        /// <summary>
        /// select {0} from {1}
        /// </summary>
        [Description("SELECT {0} FROM {1} ")]
        SelectFormat = 0,
        /// <summary>
        /// update {0} set {1}
        /// </summary>
        [Description("UPDATE {0} SET {1} ")]
        UpdateFormat,
        /// <summary>
        /// insert into {0}({1}) values({2})
        /// </summary>
        [Description("INSERT INTO {0}({1}) VALUES({2}) ")]
        InsertFormat,
        /// <summary>
        /// delete from {0}
        /// </summary>
        [Description("DELETE FROM {0} ")]
        DeleteFormat,
        /// <summary>
        /// truncate table {0}
        /// </summary>
        [Description("TRUNCATE TABLE {0} ")]
        TruncateFormat,
        /// <summary>
        ///  replace into {0}({1}) values({2})
        /// </summary>
        [Description("REPLACE INTO {0}({1}) VALUES({2}) ")]
        ReplaceFormat,
    }
}
