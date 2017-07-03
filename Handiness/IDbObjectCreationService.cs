using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Handiness
{
    /// <summary>
    /// 用于创建一系列数据源操作辅助对象的服务
    /// </summary>
    public interface IDbObjectCreationService
    {
        DbConnection GetDbConnection();
        DbCommand GetDbCommand();
        DbParameter GetDbParameter();
    }
}
