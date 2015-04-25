using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fractals
{
    public static class ExtensionMethods
    {
        public static T Pop<T>(this List<T> list)
        {
            var value = list[0];
            list.RemoveAt(0);
            return value;
        }
    }
}
