using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handiness.Orm
{
    public static class StringExtension
    {
        public static Boolean Like(this String str, String like)
        {
            return str.Contains(like);
        }
    }
}
