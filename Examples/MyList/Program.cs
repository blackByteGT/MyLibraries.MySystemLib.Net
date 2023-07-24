using System.Collections.Generic;
using MyLibraries.MySystemLib.Classes;

namespace ConsoleAppForShowExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Items
            List<int> list = new List<int>() { 0, 1, 2, 3, 4 };
            int countList = list.Count;
            #endregion Items

            // Start list: { 0, 1, 2, 3, 4 }

            for (int i = 0; i < 2; i++)
                MyList.Move(ref list, i, countList - i - 1);

            // i = 0: { 4, 1, 2, 3, 0 }
            // i = 1: { 4, 3, 2, 1, 0 }

            return;
        }
    }
}
