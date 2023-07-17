using System.Collections.Generic;
using MyLibraries.MySystemLib.Classes;

namespace ConsoleAppForShowExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Items
            int index = default;
            List<string> listString = new List<string>();
            List<Test> listTest = new List<Test>();
            #endregion Items

            #region Fiiling
            listString.Add("hello");
            listString.Add("start");
            listString.Add("finish");
            listString.Add("return");
            listString.Add("bye");

            listTest.Add(new Test(1, 'x'));
            listTest.Add(new Test(2, 'y'));
            listTest.Add(new Test(3, 'z'));
            #endregion Fiiling

            index = -1; MyList.GetIndex(ref index, listString, x => x.Length > 10);                     // index = -1
            index = -1; MyList.GetIndex(ref index, listString, x => x[0] == 'b' && !(x.Length > 4));    // index = 4
            index = -1; MyList.GetIndex(ref index, listTest, x => x.Index > 4);                         // index = -1
            index = -1; MyList.GetIndex(ref index, listTest, x => x.Value > 121);                       // index = 2

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
