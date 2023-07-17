using System.Collections.Generic;
using MyLibraries.MySystemLib.Classes;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Items
            List<string> listString = new List<string>();
            List<List<string>> listListsOfString = new List<List<string>>();
            List<Test> listTest = new List<Test>();
            List<List<Test>> listListsOfTest = new List<List<Test>>();
            #endregion Items

            #region Filling
            listString.Add("m");
            listString.Add("f");

            listListsOfString.Add(
                new List<string>() { "a", "u" }
            );
            listListsOfString.Add(
                new List<string>() { "x", "y" }
            );

            listTest.Add(new Test(4, "a"));
            listTest.Add(new Test(8, "p"));

            listListsOfTest.Add(
                new List<Test>() { new Test(1, "q"), new Test(5, "r") }
            );
            listListsOfTest.Add(
                new List<Test>() { new Test(7, "t"), new Test(0, "n") }
            );
            #endregion Filling

            // Start listString:        {"m", "f"}
            // Info listListsOfString   {{"a", "u"}, {"x", "y"}}
            // Start listTest:          {{4, "a"}, {8, "p"}}
            // Info listListsOfTest     {{{1, "q"}, {5, "r"}}, {{7, "t"}, {0, "n"}}}

            MyList.Add(ref listString, listListsOfString, index: listString.Count);
            MyList.Add(ref listTest, listListsOfTest, index: 1);

            // Finish listString:   {"m", "f", "a", "u", "x", "y"}
            // Finish listTest:     {{4, "a"}, {1, "q"}, {5, "r"}, {7, "t"}, {0, "n"}, {8, "p"}}

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
