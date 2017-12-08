using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace Handiness.Orm
{
    public static class ParaCounter<T> where T : class
    {
        private static Int64 _Count = 0;
        /// <summary>
        /// 获取计数并使得计数加1
        /// </summary>
        public static Int64 Count
        {
            get
            {
                return Interlocked.Increment(ref _Count);
            }
        }
        /// <summary>
        /// 获取计数字符串并使得计数加1
        /// </summary>
        public static String CountStr
        {
            get
            {
                return Interlocked.Increment(ref _Count).ToString();
            }
        }
    }
}
