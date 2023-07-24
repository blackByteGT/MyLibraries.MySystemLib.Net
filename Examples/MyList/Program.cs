using System.Collections.Generic;
using MyLibraries.MySystemLib.Classes;

namespace ConsoleAppForShowExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = 
                new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            MyList.Shuffle(ref list); // { 2, 7, 3, 4, 9, 8, 5, 0, 6, 1 }

            return;
        }
    }
}
