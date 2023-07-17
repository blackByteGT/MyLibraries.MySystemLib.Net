using System.Collections.Generic;
using MyLibraries.MySystemLib.Classes;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Items
            List<char>
                listChars = new List<char>(),
                listCharsResult = default;
            List<Test>
                listTest = new List<Test>(),
                listTestResult = default;
            #endregion Items

            #region Filling
            MyList.GetEnglishLowercaseLetters(ref listChars);

            listTest.Add(new Test(1, 'a'));
            listTest.Add(new Test(2, 'b'));
            listTest.Add(new Test(3, 'c'));
            listTest.Add(new Test(4, 'd'));
            listTest.Add(new Test(5, 'e'));
            listTest.Add(new Test(6, 'f'));
            listTest.Add(new Test(7, 'g'));
            #endregion Filling

            // Start listChars: {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h',
            //                   'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q',
            //                   'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'}
            // Start listTest:  {{1, 'a'}, {2, 'b'}, {3, 'c'}, {4, 'd'}, {5, 'e'}, {6, 'f'}, {7, g}}

            MyList.GetSublist(ref listCharsResult, listChars, x => x >= 'a' && x <= 'h');   // {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h'}
            MyList.GetSublist(ref listCharsResult, listChars, x => x >= 'i' && x <= 'q');   // {'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q'}
            MyList.GetSublist(ref listCharsResult, listChars, x => x >= 'r' && x <= 'z');   // {'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'}
            MyList.GetSublist(ref listTestResult, listTest, x => x.Index % 2 == 0);         // {{2, 'b'}, {4, 'd'}, {6, 'f'}}
            MyList.GetSublist(ref listTestResult, listTest, x => x.Value % 2 != 0);         // {{1, 'a'}, {3, 'c'}, {5, 'e'}, {7, g}}

            return;
        }

        class Test
        {
            public int Index { get; private set; }
            public char Value { get; private set; }

            public Test(int index, char value)
            {
                Index = index;
                Value = value;
            }
        }
    }
}
