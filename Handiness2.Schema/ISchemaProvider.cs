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
        /// 使用指定的连接字符串，打开与数据服务实例的连接，若连接失败则抛出抛出异常信息
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        ///<exception cref="ProviderConnectException">连接失败时</exception>
        void Open(String connectionString);
        /// <summary>
        /// 表示是否已打开与指定数据服务实例的连接
        /// </summary>
        Boolean Opened { get; }
        /// <summary>
        /// 关闭与数据服务实例的连接，并释放相应资源
        /// </summary>
        void Close();

        /// <summary>
        /// 加载指定表的结构信息以及所有与其关联的列的结构信息
        /// </summary>
        /// <param name="tableName">表的名称</param>
        /// <returns>
        /// 返回一个三元组，
        /// 第一个组建表示获取成功与否
        /// 第二个组件包含表的结构信息
        /// 第三个组件包含一个 列结构信息的链表</returns>
        (Boolean success, TableSchemaExtend table, IList<ColumnSchemaExtend> columns) GetTableSchemaTuple(String tableName);



        /// <summary>
        /// 加载与当前连接关联的所有表的结构信息
        /// </summary>
        /// <returns></returns>
        IList<TableSchemaExtend> LoadTableSchemaList();



        /// <summary>
        /// 加载与指定表关联的所有的列的结构信息
        /// </summary>
        /// <param name="tableName">表的名称</param>
        /// <returns></returns>
        IList<ColumnSchemaExtend> LoadColumnSchemaList(String tableName);

        /// <summary>
        /// 加载与指定表关联的所有索引的结构信息
        /// </summary>
        /// <param name="tableName">表的名称</param>
        /// <returns></returns>
        IList<IndexSchema> LoadIndexSchemaList(String tableName);

        /// <summary>
        /// 加载所有与此连接关联的视图的结构信息
        /// </summary>
        /// <returns></returns>
        IList<TableSchemaExtend> LoadViewSchemaList();

        /// <summary>
        /// 通过指定视图名称加载与此视图关联的所有列结构的信息
        /// </summary>
        /// <param name="viewName">视图的名称</param>
        /// <returns></returns>
        IList<ColumnSchemaExtend> LoadViewColumnSchemaList(String viewName);

        /// <summary>
        /// 通过视图名称加载视图本身的结构信息以及与其关联的列结构的信息
        /// </summary>
        /// <param name="viewName">视图的名称</param>
        /// <returns>
        /// 返回一个三元组，
        /// 第一组件表示是否获取成功，
        /// 第二组件表示视图的结构信息，
        /// 第三组件表示关联的列的结构信息
        /// </returns>
        (Boolean success, TableSchemaExtend view, IList<ColumnSchemaExtend> columns) GetViewSchemaTuple(String viewName);

        /// <summary>
        /// 加载所有与此连接关联的函数的结构信息
        /// </summary>
        /// <returns></returns>
        IList<FunctionSchema> LoadFunctionSchemaList();

        /// <summary>
        /// 加载所有与此连接关联的存储过程的结构信息
        /// </summary>
        /// <returns></returns>
        IList<ProcedureSchema> LoadProcedureSchemaList();
    }
}
