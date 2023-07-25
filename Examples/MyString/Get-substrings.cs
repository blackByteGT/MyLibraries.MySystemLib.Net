using System.Collections.Generic;
using MyLibraries.MySystemLib.Classes;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listSubstrings;

            listSubstrings = default; MyString.GetSubstrings(ref listSubstrings, "1.2.3.4.5", ".");        // { "1", "2", "3", "4", "5" }
            listSubstrings = default; MyString.GetSubstrings(ref listSubstrings, "1.2.3.4.5.", ".");       // { "1", "2", "3", "4", "5" }
            listSubstrings = default; MyString.GetSubstrings(ref listSubstrings, "1..2..3..4..5.", "..");  // { "1", "2", "3", "4", "5." }

            return;
        }
    }
}
