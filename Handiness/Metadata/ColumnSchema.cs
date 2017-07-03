using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
namespace Handiness.Metadata
{
    /// <summary>
    /// 列结构
    /// </summary>
    public class ColumnSchema
    {
        /// <summary>
        /// 列名
        /// </summary>
        public String Name { get; }
        /// <summary>
        /// 是否主键
        /// </summary>
        public Boolean IsPrimeKey { get; }
        /// <summary>
        /// 列的数据长度
        /// </summary>
        public Int32 Length { get; }
        /// <summary>
        /// 列类型
        /// </summary>
        public String Type { get; }
        /// <summary>
        /// 所属表的名称
        /// </summary>
        public String TableName { get; }
        /// <summary>
        /// 列的注释信息
        /// </summary>
        public String Explain { get; }
        public ColumnSchema(
            String name,
            Boolean isPrimekey,
            Int32 length,
            String type,
            String tableName,
            String explain
            )
        {
            this.Name = name;
            this.IsPrimeKey = isPrimekey;
            this.Length = length;
            this.Type = type;
            this.TableName = tableName;
            this.Explain = explain;
        }
    }
}
