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
    public abstract class AuxiliaryObjService : ServiceBase
    {
        public abstract DbConnection DbConnection();
        public abstract DbCommand DbCommand();
        public abstract DbParameter DbParameter();
        /// <summary>
        /// 参数区分符 例如：在SQL Server中参数前导区分符为@，（SELECT * FROM table WHERE col=@colValue）
        /// </summary>
        public abstract String Specificator { get; }
    }
}
