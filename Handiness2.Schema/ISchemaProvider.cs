using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace Handiness2.Schema
{
    /// <summary>
    /// 与数据服务实例交互，生成 Schema 信息
    /// </summary>
    public interface ISchemaProvider : IDisposable
    {
        /// <summary>
        /// 对象名称，例如：SQL Server Schema Provider、MySQL Schema Provider 等
        /// </summary>
        String Name { get; }
        /// <summary>
        /// 对象的描述信息，例如：此 Schema Provider 适用于 SQL Server 2008+ ... 
        /// </summary>
        String Explain { get; }
        /// <summary>
        /// 当前所使用的连接字符串
        /// </summary>
        String ConnectionString { get; }
        /// <summary>
        /// 使用指定的连接字符串，打开与数据服务实例的连接，若连接失败则抛出 <see cref="ProviderConnectException"/> 异常信息
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        void Open(String connectionString);
        /// <summary>
        /// 关闭与数据服务实例的连接，并释放相应资源
        /// </summary>
        void Close();

        /// <summary>
        /// 加载于指定表关联的 <see cref="TableSchemaExtend"/> 信息以及所有 <see cref="ColumnSchemaExtend"/> 信息
        /// </summary>
        /// <param name="tableName">表的名称</param>
        /// <returns>返回一个二元组，第一个组件包含表的结构信息，第二个组件包含一个 列结构信息的链表</returns>
        (TableSchemaExtend table, IList<ColumnSchemaExtend> column) GetTableSchemaTuple(String tableName);

        /// <summary>
        ///  <see cref="GetTableSchemaTuple"/>  的异步版本
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
       Task< (TableSchemaExtend table, IList<ColumnSchemaExtend> column)> GetTableSchemaTupleAsync(String tableName);

        /// <summary>
        /// 加载与当前连接关联的所有 <see cref="TableSchemaExtend"/> 信息
        /// </summary>
        /// <returns></returns>
        IList<TableSchemaExtend> LoadTableSchemaList();

        /// <summary>
        ///  <see cref="LoadTableSchemaList"/> 的异步版本
        /// </summary>
        /// <returns></returns>
        Task<IList<TableSchemaExtend>> LoadTableSchemaListAsync();

        /// <summary>
        /// 加载与指定表关联的所有 <see cref="ColumnSchemaExtend"/> 信息
        /// </summary>
        /// <param name="tableName">表的名称</param>
        /// <returns></returns>
        IList<ColumnSchemaExtend> LoadColumnSchemaList(String tableName);

        /// <summary>
        ///  <see cref="LoadColumnSchemaList"/> 的异步版本
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        Task<IList<ColumnSchemaExtend>> LoadColumnSchemaListAsync(String tableName);
    }
}
