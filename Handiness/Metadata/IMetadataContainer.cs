using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handiness.Metadata
{
    /*-------------------------------------------------------------------------
    * 版权所有：王浪静
    * 作者：王浪静
    * 联系方式：932444208@qq.com
    * 创建时间： 2017/7/20 18:01:16
    * 版本号：v1.0
    * .NET 版本：4.0
    * 本接口规范描述：Schema信息存取容器接口
    *  -------------------------------------------------------------------------*/
    /// <summary>
    /// Schema信息存取容器接口
    /// </summary>
    public interface IMetadataContainer
    {
        /// <summary>
        /// 向容器中添加一条<see cref="ColumnSchema"/>信息
        /// </summary>
        /// <param name="dbName">Schema所属数据库名称</param>
        /// <param name="tableKey">表Key</param>
        /// <param name="columnKey">列Key</param>
        /// <param name="schema">Schema</param>
        Boolean AddColumnSchema(String dbName, String tableKey, String columnKey, ColumnSchema schema);
        /// <summary>
        /// 先容器中添加一条<see cref="TableSchema"/>信息
        /// </summary>
        /// <param name="dbName">Schema所属数据库名称</param>
        /// <param name="tableKey">表Key</param>
        /// <param name="schema">Schema</param>
        Boolean AddTableSchema(String dbName, String tableKey, TableSchema schema);
        /// <summary>
        /// 从容器中取出一条<see cref="ColumnSchema"/>信息，当参数不全，有多条<see cref="ColumnSchema"/>信息时，返回第一条
        /// </summary>
        /// <param name="columnKey">必须值</param>
        /// <param name="tableKey">可选</param>
        /// <param name="dbName">可选</param>
        ColumnSchema GetColumnSchema(String columnKey, String tableKey = null, String dbName = null);
        /// <summary>
        /// 从容器中取出一条<see cref="TableSchema"/>信息，当参数不全，有多条<see cref="TableSchema"/>信息时，返回第一条
        /// </summary>
        /// <param name="tableKey">必须</param>
        /// <param name="dbName">可选</param>
        /// <returns></returns>
        TableSchema GetTableSchema(String tableKey, String dbName = null);
    }
}
