using System.Collections.Generic;
using MyLibraries.MySystemLib.Classes;

namespace ConsoleAppForShowExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Items
            List<string> listString = new List<string>();
            List<Test> listTest = new List<Test>();
            #endregion Items

            #region Filling
            listString.Add("m");
            listString.Add("f");
            listString.Add("y");
            listString.Add("k");
            listString.Add("o");

            listTest.Add(new Test(4, "a"));
            listTest.Add(new Test(8, "q"));
            listTest.Add(new Test(1, "z"));
            listTest.Add(new Test(9, "p"));
            listTest.Add(new Test(5, "w"));
            #endregion Filling

            // Start listString:    {"m", "f", "y", "k", "o"}
            // Start listTest:      {{4, "a"}, {8, "p"}, {1, "z"}, {9, "p"}, {5, "w"}}

            MyList.Replace(ref listString, "newValue", listString.Count - 1);
            MyList.Replace(ref listTest, new Test(0, "newValue"), 1);

            // Finish listString:   {"m", "f", "y", "k", "newValue"}
            // Finish listTest:     {{4, "a"}, {0, "newValue"}, {1, "z"}, {9, "p"}, {5, "w"}}

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
