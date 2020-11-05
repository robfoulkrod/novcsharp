using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module05.EntensionMethods
{
    public static class StringUtillity
    {
        public static bool IsEmail(this string testString)
        {
            if (string.IsNullOrEmpty(testString)) return false;
            if (testString.Length < "a@b.c".Length) return false;
            if (!testString.Contains("@")) return false;
            return true;

        }
    }

}
