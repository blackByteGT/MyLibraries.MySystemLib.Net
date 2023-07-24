using System.Collections.Generic;
using MyLibraries.MySystemLib.Classes;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Items
            int currentValue = default;
            List<int> list = 
                new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            #endregion Items

            // Info list: { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }

            MyRandom.Next(ref currentValue, list); // 5
            MyRandom.Next(ref currentValue, list); // 0
            MyRandom.Next(ref currentValue, list); // 9

            return;
        }
    }
}
