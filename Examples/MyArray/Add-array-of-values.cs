using MyLibraries.MySystemLib.Classes;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Items
            char[]
                arrayChar = default,
                addArrayChar = default;
            Test[]
                arrayTest = default,
                addArrayTest = default;
            #endregion Items

            #region Filling
            arrayChar = new char[] { 'm', 'f', 't', 'z', 'j' };

            addArrayChar = new char[] { 'a', 'n', 'q', 'p', 'k' };

            arrayTest = new Test[]
            {
                new Test(4, 'a'),
                new Test(8, 'p'),
                new Test(9, 'h'),
                new Test(2, 'c'),
                new Test(0, 'e')
            };

            addArrayTest = new Test[]
            {
                new Test(7, 'q'),
                new Test(3, 'y'),
                new Test(1, 'u'),
                new Test(6, 'd'),
                new Test(5, 'x'),
            };
            #endregion Filling

            // Start arrayChar:     {'m', 'f', 't', 'z', 'j'}
            // Info addArrayChar:   {'a', 'n', 'q', 'p', 'k'}
            // Start arrayTest:     {{4, 'a'}, {8, 'p'}, {9, 'h'}, {2, 'c'}, {0, 'e'}}
            // Info addArrayTest:   {{7, 'q'}, {3, 'y'}, {1, 'u'}, {6, 'd'}, {5, 'x'}}


            MyArray.Add(ref arrayChar, addArrayChar);
            MyArray.Add(ref arrayTest, addArrayTest, index: 1);

            // Finish listString:   {'m', 'f', 't', 'z', 'j', 'a', 'n', 'q', 'p', 'k'}
            // Finish listTest:     {{4, 'a'}, {7, 'q'}, {3, 'y'}, {1, 'u'}, {6, 'd'},
            //                       {5, 'x'}, {8, 'p'}, {9, 'h'}, {2, 'c'}, {0, 'e'}}

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
