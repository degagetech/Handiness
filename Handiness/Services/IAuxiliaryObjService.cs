using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Handiness.Services
{
    /// <summary>
    /// 用于创建一系列数据源操作辅助对象的服务
    /// </summary>
    public interface IAuxiliaryObjService : IService
    {
        DbConnection GenerateDbConnection();
        DbCommand GenerateDbCommand();
        DbParameter GenerateDbParameter();
        /// <summary>
        /// 参数区分符 例如：在SQL Server中参数前导区分符为@，（SELECT * FROM table WHERE col=@colValue）
        /// </summary>
        String Specificator { get; }
    }
}
