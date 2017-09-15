using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Handiness.Metadata;
namespace Handiness
{
    /*-------------------------------------------------------------------------
 * 版权所有：王浪静
 * 作者：王浪静
 * 联系方式：932444208@qq.com
 * 创建时间： 2017/7/27 18:02:04
 * 版本号：v1.0
 * .NET 版本：4.0
 * 本类主要用途描述：用以传递特定的Schema信息
 *  -------------------------------------------------------------------------*/
    /// <summary>
    /// 用以传递特定的Schema信息
    /// </summary>
    public class SchemaCourier<T> where T : RowBase
    {
        public TableSchema Table { get; private set; }
        public IDictionary<String, ColumnSchema> ColumnDict { get; private set; }

        public SchemaCourier(TableSchema table, IDictionary<String, ColumnSchema> columnDict)
        {
            this.Table = table;
            this.ColumnDict = columnDict;
        }

        public String TableName { get => this.Table.Name; }
        public String ColumnName(String key)
        {
            String name = null;
            name = this.Column(key)?.Name;
            return name;
        }
        public ColumnSchema Column(String key)
        {
            ColumnSchema schema = null;
            if (!String.IsNullOrWhiteSpace(key) && this.ColumnDict.ContainsKey(key))
            {
                schema = this.ColumnDict[key];
            }
            return schema;
        }
    }
}
