using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
namespace Handiness.Orm
{
    public static class DbDataReaderExtension
    {
        public static List<T> ToList<T>(DbDataReader reader) where T : class
        {
            List<T> result = new List<T>();
       
            return result;
        }
    }
}
