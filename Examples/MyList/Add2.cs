using System.Collections.Generic;
using MyLibraries.MySystemLib.Classes;

namespace ConsoleAppForShowExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Items
            List<string>
                listString = new List<string>(),
                addListString = new List<string>();
            List<Test>
                listTest = new List<Test>(),
                addListTest = new List<Test>();
            #endregion Items

            #region Filling
            listString.Add("m");
            listString.Add("f");
            listString.Add("t");
            listString.Add("z");
            listString.Add("j");

            addListString.Add("a");
            addListString.Add("n");
            addListString.Add("q");
            addListString.Add("p");
            addListString.Add("k");

            listTest.Add(new Test(4, "a"));
            listTest.Add(new Test(8, "p"));
            listTest.Add(new Test(9, "h"));
            listTest.Add(new Test(2, "c"));
            listTest.Add(new Test(0, "e"));

            addListTest.Add(new Test(7, "q"));
            addListTest.Add(new Test(3, "y"));
            addListTest.Add(new Test(1, "u"));
            addListTest.Add(new Test(6, "d"));
            addListTest.Add(new Test(5, "x"));
            #endregion Filling

            // Start listString:    {"m", "f", "t", "z", "j"}
            // Info addListString   {"a", "n", "q", "p", "k"}
            // Start listTest:      {{4, "a"}, {8, "p"}, {9, "h"}, {2, "c"}, {0, "e"}}
            // Info AddListTest     {{7, "q"}, {3, "y"}, {1, "u"}, {6, "d"}, {5, "x"}}

            MyList.Add(ref listString, addListString, index: listString.Count);
            MyList.Add(ref listTest, addListTest, index: 1);

            // Finish listString:   {"m", "f", "t", "z", "j", "a", "n", "q", "p", "k"}
            // Finish listTest:     {{4, "a"}, {7, "q"}, {3, "y"}, {1, "u"}, {6, "d"},
            //                       {5, "x"}, {8, "p"}, {9, "h"}, {2, "c"}, {0, "e"}}

            return;
        }

        class Test
        {
            public int Index { get; private set; }
            public string Value { get; private set; }

            public Test(int index, string value)
            {
                Index = index;
                Value = value;
            }
        }
    }
}
