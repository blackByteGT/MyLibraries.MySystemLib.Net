using System.Collections.Generic;
using MyLibraries.MySystemLib.Classes;

namespace ConsoleAppForShowExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Items
            const string str = "abcde";

            bool result = default;
            #endregion Items

            result = MyString.IsEntry(str, 'e');  // true
            result = MyString.IsEntry(str, 'q');  // false
            result = MyString.IsEntry(str, "ab"); // true

            result = MyString.IsEntry(str, format: "XXcXX");                      // true
            result = MyString.IsEntry(str, format: "--c--", formatChar: '-');     // true
            result = MyString.IsEntry(str, format: "--c--f", formatChar: '-');    // false

            result = MyString.IsEntry(str, new List<string>() { "a", "ab", "tr" });                         // true
            result = MyString.IsEntry(str, new List<string>() { "a", "ab", "tr" }, austerityEntry: true);   // false

            return;
        }
    }
}
