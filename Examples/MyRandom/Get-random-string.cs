using System.Collections.Generic;
using MyLibraries.MySystemLib.Classes;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Items
            const int lengthStr = 5;

            string str;
            #endregion Items

            // Info lengthStr: 5

            str = default; MyRandom.Next(ref str, lengthStr, listAllowedChars: new List<char>() { 'h', 'e', 'l', 'l', 'o' });       // hoehl
            str = default; MyRandom.Next(ref str, lengthStr, enterNumber: true);                                                    // str = 45426
            str = default; MyRandom.Next(ref str, lengthStr, enterLowLatter: true);                                                 // joxtc
            str = default; MyRandom.Next(ref str, lengthStr, enterCapLatter: true);                                                 // INJEO
            str = default; MyRandom.Next(ref str, lengthStr, enterLowLatter: true, enterCapLatter: true);                           // fgEJL
            str = default; MyRandom.Next(ref str, lengthStr * 2, enterNumber: true, enterLowLatter: true, enterCapLatter: true);    // HAzNarv85T
            str = default; MyRandom.Next(ref str, lengthStr * 2, enterNumber: true, listAddChars: new List<char>() { '.', ',' });   // 517.42,627

            return;
        }
    }
}
