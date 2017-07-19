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
 * 创建时间： 2017/7/15 13:50:09
 * 版本号：v1.0
 * .NET 版本：4.0
 * 本类主要用途描述：用于操作数据库的主要对象
 *  -------------------------------------------------------------------------*/
    public class DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="adaptiveGuid">适配层guid</param>
        /// <param name="buffer">结构信息缓存器</param>
        public DbContext(String connectionString, String adaptiveGuid, SchemaBuffer buffer)
        {

        }
        /// <summary>
        /// 数据库的连接字符串
        /// </summary>
        public String ConnectionString { get; private set; }
        public SchemaBuffer SchemaBuffer { get; private set; }
        public String AdaptiveGuid { get; private set; }
    }
}
