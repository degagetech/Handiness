using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handiness.Orm
{
    public static class StringExtension
    {
        /// <summary>
        /// %String%
        /// </summary>
        /// <param name="str"></param>
        /// <param name="like"></param>
        /// <returns></returns>
        public static Boolean Like(this String str, String like)
        {
            return str.Contains(like);
        }
        /// <summary>
        /// String%
        /// </summary>
        /// <param name="str"></param>
        /// <param name="like"></param>
        /// <returns></returns>
        public static Boolean StartLike(this String str, String like)
        {
            return str.Contains(like);
        }
        /// <summary>
        /// %String
        /// </summary>
        /// <param name="str"></param>
        /// <param name="like"></param>
        /// <returns></returns>
        public static Boolean EndLike(this String str, String like)
        {
            return str.Contains(like);
        }
    }
}
