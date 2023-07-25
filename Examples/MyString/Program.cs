using System.Collections.Generic;
using MyLibraries.MySystemLib.Classes;

namespace ConsoleAppForShowExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Items
            const string startStr = "a.b,c.d,e";

            string str;
            List<string> listReplace = new List<string>() { ".", "," };
            #endregion Items

            // Info startStr: "a.b,c.d,e"
            // Info listReplace: { ".", "," }

            str = startStr; MyString.Replace(ref str, ",e", ""); // a.b,c.d

            str = startStr; MyString.Replace(ref str, listReplace, "_");                        // "a_b_c_d_e"
            str = startStr; MyString.Replace(ref str, listReplace, new List<string>() { "_" }); // "a_b_c_d_e"

            str = startStr; MyString.Replace(ref str, listReplace, new List<string>() { "_", "-" });            // "a_b-c_d-e"
            str = startStr; MyString.Replace(ref str, new List<(string, string)>() { (".", "_"), (",", "-") }); // "a_b-c_d-e"

            return;
        }
    }
}
