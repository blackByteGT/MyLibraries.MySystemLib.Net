using System.Collections.Generic;
using MyLibraries.MySystemLib.Classes;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            int precision = default;

            MyDecimal.GetPrecision(ref precision, 12.5m);                               // 1
            MyDecimal.GetPrecision(ref precision, 12m);                                 // 0
            MyDecimal.GetPrecision(ref precision, "23,7", new List<char>() { ',' });    // 1

            return;
        }
    }
}
