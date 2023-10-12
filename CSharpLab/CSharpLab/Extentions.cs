using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLab
{
    internal static class Extentions
    {
        public static string EnumerableToString<T>(this IEnumerable<T> items) =>
            $"{{ {string.Join(", ", items)} }}";
    }
}
