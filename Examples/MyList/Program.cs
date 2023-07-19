using MyLibraries.MySystemLib.Classes;

namespace ConsoleAppForShowExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Items
            int[] 
                arrayString = new int[] { 1, 2, 3, 4, 5 },
                nullArray = null;
            #endregion Items

            // Start arrayString:   { 1, 2, 3, 4, 5 }
            // Start nullArray:     null

            MyArray.Add(ref nullArray, 0);                              // { 0 }
            MyArray.Add(ref arrayString, 6);                            // { 1, 2, 3, 4, 5, 6 }
            MyArray.Add(ref arrayString, 0, index: 0);                  // { 0, 1, 2, 3, 4, 5, 6 }
            MyArray.Add(ref arrayString, 9, arrayString.Length / 2);    // { 0, 1, 2, 9, 3, 4, 5, 6 }

            return;
        }
    }
}
