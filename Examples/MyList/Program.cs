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

            #region Sort by growth
            MyList.Sort(ref listString, x => x, byGrowth: true);        // {"f", "j", "m", "t", "z"}
            MyList.Sort(ref listTest, x => x.Index, byGrowth: true);    // {{0, "e"}, {2, "c"}, {4, "a"}, {8, "p"}, {9, "h"}}
            MyList.Sort(ref listTest, x => x.Value, byGrowth: true);    // {{4, "a"}, {2, "c"}, {0, "e"}, {9, "h"}, {8, "p"}}
            #endregion Sort by growth

            #region Sort in descending
            MyList.Sort(ref listString, x => x, byGrowth: false);        // {"z", "t", "m", "j", "f"}
            MyList.Sort(ref listTest, x => x.Index, byGrowth: false);    // {{9, "h"}, {8, "p"}, {4, "a"}, {2, "c"}, {0, "e"}}
            MyList.Sort(ref listTest, x => x.Value, byGrowth: false);    // {{8, "p"}, {9, "h"}, {0, "e"}, {2, "c"}, {4, "a"}}
            #endregion Sort in descending

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
