using System.Collections.Generic;
using MyLibraries.MySystemLib.Classes;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listInt = new List<int>();

            #region Filling
            listInt.Add(0);
            listInt.Add(8);
            listInt.Add(3);
            listInt.Add(1);
            listInt.Add(2);
            listInt.Add(3);
            listInt.Add(4);
            listInt.Add(5);
            listInt.Add(6);
            listInt.Add(7);
            listInt.Add(8);
            listInt.Add(9);
            listInt.Add(5);
            #endregion Filling

            // Start listInt:   {0, 8, 3, 1, 2, 3, 4, 5, 6, 7, 8, 9, 5}

            MyList.RemoveDuplicates(ref listInt);

            // Finish listInt:   {0, 8, 3, 1, 2, 4, 5, 6, 7, 9}

            return;
        }
    }
}
