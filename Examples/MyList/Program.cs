using System.Collections.Generic;
using MyLibraries.MySystemLib.Classes;

namespace ConsoleAppForShowExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Items
            List<char>
                mainList = new List<char>(),
                listResult = new List<char>();

            MyList.GetEnglishLowercaseLetters(ref mainList);
            #endregion Items

            // Start mainList:   {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h',
            //                    'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q',
            //                    'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'}

            MyList.GetSublist(ref listResult, mainList, x => x >= 'a' && x <= 'h'); // {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h'}
            MyList.GetSublist(ref listResult, mainList, x => x >= 'i' && x <= 'q'); // {'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q'}
            MyList.GetSublist(ref listResult, mainList, x => x >= 'r' && x <= 'z'); // {'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'}

            return;
        }
    }
}
