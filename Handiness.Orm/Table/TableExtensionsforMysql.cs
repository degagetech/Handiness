using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Handiness.Orm
{
   public static class TableExtensionsforMysql
    {
        public static IServomotor<T> BulkReplace<T>(this Table<T> tableObj, IEnumerable<T> objs) where T : class
        {
            List<DbParameter> dbParameterList = new List<DbParameter>();
            String insertSql = ObjectToSqlConverter<T>.BulkReplaceConvert(tableObj.BindingDbProvider, objs, dbParameterList);
            IServomotor<T> servomotor = tableObj.BindingDbProvider.ServomotorFactroy<T>();
            servomotor.AppendSql(insertSql);
            servomotor.DbParameterCollection.AddRange(dbParameterList);
            return servomotor;
        }
        public static IServomotor<T> Replace<T>(this Table<T> tableObj, T obj) where T : class
        {
            List<DbParameter> dbParameterList = new List<DbParameter>();
            String replaceSql = ObjectToSqlConverter<T>.ReplaceConvert(tableObj.BindingDbProvider, obj, dbParameterList);
            IServomotor<T> servomotor = tableObj.BindingDbProvider.ServomotorFactroy<T>();
            servomotor.AppendSql(replaceSql);
            servomotor.DbParameterCollection.AddRange(dbParameterList);
            return servomotor;
        }

    }
}
