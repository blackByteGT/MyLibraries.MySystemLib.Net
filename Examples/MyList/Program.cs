using System.Collections.Generic;
using MyLibraries.MySystemLib.Classes;

namespace ConsoleAppForShowExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Test> listTest = new List<Test>();

            #region Filling
            listTest.Add(new Test(-1, 'a'));
            listTest.Add(new Test(1, 'A'));
            listTest.Add(new Test(2, 'b'));
            listTest.Add(new Test(3, 'B'));
            listTest.Add(new Test(4, 'c'));
            listTest.Add(new Test(5, 'C'));
            listTest.Add(new Test(6, 'd'));
            listTest.Add(new Test(7, 'D'));
            listTest.Add(new Test(8, 'e'));
            listTest.Add(new Test(9, 'E'));
            #endregion Filling

            // Start listTest:  {{-1, 'a'}, {1, 'A'}, {2, 'b'}, {3, 'B'}, {4, 'c'},
            //                   {5, 'C'}, {6, 'd'}, {7, 'D'}, {8, 'e'}, {9, 'E'}}

            MyList.Remove(ref listTest, x => x.Index % 2 == 0);                 // {{-1, 'a'}, {1, 'A'}, {3, 'B'}, {5, 'C'}, {7, 'D'}, {9, 'E'}}
            MyList.Remove(ref listTest, x => x.Value < 97 || x.Value > 122);    // {{-1, 'a'}}

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
