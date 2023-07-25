using MyLibraries.MySystemLib.Classes;

namespace ConsoleAppForShowExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Items
            const int defaultIndex = -1;
            const string str = "abcde";

            int
                startIndex,
                endIndex;
            #endregion Items

            // Info str: "abcde"
            // Info defaultIndex: -1

            startIndex = endIndex = defaultIndex;
            MyString.GetSubstringIndices(ref startIndex, ref endIndex, str, "q"); // startIndex = endIndex = -1

            startIndex = endIndex = defaultIndex; 
            MyString.GetSubstringIndices(ref startIndex, ref endIndex, str, "c"); // startIndex = endIndex = 2

            startIndex = endIndex = defaultIndex;
            MyString.GetSubstringIndices(ref startIndex, ref endIndex, str, "bcd"); // startIndex = 1, endIndex = 3

            return;
        }
    }
}
