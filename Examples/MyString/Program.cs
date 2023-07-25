using MyLibraries.MySystemLib.Classes;

namespace ConsoleAppForShowExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            string startStr, str;

            startStr = "abcde";

            str = startStr; MyString.Remove(ref str, startIndex: 0);                            // "bcde"
            str = startStr; MyString.Remove(ref str, startIndex: 2, endIndex: str.Length - 1);  // "ab"

            startStr = "ababab";

            str = startStr; MyString.Remove(ref str, 'a');                      // "bbb"
            str = startStr; MyString.Remove(ref str, 'a', austerity: false);    // "babab"

            startStr = "accaacca";

            str = startStr; MyString.Remove(ref str, "ca");                     // "ac"
            str = startStr; MyString.Remove(ref str, "ca", austerity: false);   // "acacca"

            return;
        }
    }
}
