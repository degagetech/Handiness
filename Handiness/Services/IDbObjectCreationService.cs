using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Handiness.Services
{
    /// <summary>
    /// 用于创建一系列数据源操作对象的服务
    /// </summary>
    public interface IDbObjectCreationService : IService
    {
        DbConnection GetDbConnection();
        DbCommand GetDbCommand();
        DbParameter GetDbParameter();
    }
}
