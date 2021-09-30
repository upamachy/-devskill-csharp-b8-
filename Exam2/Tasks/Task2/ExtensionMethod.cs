using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public static class ExtensionMethod
    {
        public static bool IsOdd(this int a)
        {
            return (a % 2 != 0);
        }
    }
}
