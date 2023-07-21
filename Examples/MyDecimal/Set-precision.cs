using MyLibraries.MySystemLib.Classes;
using System;
using System.Collections.Generic;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Items
            const decimal startNumber = 12.543m;

            decimal number = default;
            #endregion Items

            // Info startNumber: 12.543

            number = startNumber; MyDecimal.SetPrecision(ref number, 0.001m);   // number = 12.543
            number = startNumber; MyDecimal.SetPrecision(ref number, 3);        // number = 12.543
            number = startNumber; MyDecimal.SetPrecision(ref number, 0.01m);    // number = 12.54
            number = startNumber; MyDecimal.SetPrecision(ref number, 2);        // number = 12.54
            number = startNumber; MyDecimal.SetPrecision(ref number, 0.1m);     // number = 12.5
            number = startNumber; MyDecimal.SetPrecision(ref number, 1);        // number = 12.5
            number = startNumber; MyDecimal.SetPrecision(ref number, 1m);       // number = 12
            number = startNumber; MyDecimal.SetPrecision(ref number, 0);        // number = 12

            return;
        }
    }
}
