using System.Collections.Generic;
using MyLibraries.MySystemLib.Classes;

namespace ConsoleAppForShowExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listString = new List<string>();
            List<Test> listTest = new List<Test>();

            #region Filling
            listString.Add("m");
            listString.Add("f");
            listString.Add("t");
            listString.Add("z");
            listString.Add("j");

            listTest.Add(new Test(4, "a"));
            listTest.Add(new Test(8, "p"));
            listTest.Add(new Test(9, "h"));
            listTest.Add(new Test(2, "c"));
            listTest.Add(new Test(0, "e"));
            #endregion Filling

            // Start listString:    {"m", "f", "t", "z", "j"}
            // Start listTest:      {{4, "a"}, {8, "p"}, {9, "h"}, {2, "c"}, {0, "e"}}

            #region Adding forward
            MyList.Add(ref listString, "forward");               // {"forward", "m", "f", "t", "z", "j"}
            MyList.Add(ref listTest, new Test(5, "forward"));    // {{5, "forward"}, {4, "a"}, {8, "p"}, {9, "h"}, {2, "c"}, {0, "e"}}
            #endregion Adding forward

            #region Adding by index
            MyList.Add(ref listString, "index", index: 1);                          // {"forward", "index", "m", "f", "t", "z", "j"}
            MyList.Add(ref listTest, new Test(7, "index"), index: listTest.Count);  // {{5, "forward"}, {4, "a"}, {8, "p"}, {9, "h"}, {2, "c"}, {0, "e"}, {7, "index"}}
            #endregion Adding by index
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
