using MyLibraries.MySystemLib.Classes;

namespace ConsoleAppForShowExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Items
            const string str = "hello.everybody";

            string substr = default;
            #endregion Items

            // Info str: "hello.everybody"

            MyString.GetSubstring(ref substr, str);                         // "hello.everybody"
            MyString.GetSubstring(ref substr, str, index: 6);               // "everybody"
            MyString.GetSubstring(ref substr, str, lenght: 5);              // "hello"
            MyString.GetSubstring(ref substr, str, index: 5, lenght: 1);    // "."

            MyString.GetSubstring(ref substr, str, "lo", "bo");                                                     // ".every"
            MyString.GetSubstring(ref substr, str, "lo", "bo", austerityPrimaryStr: true);                          // "lo.every"
            MyString.GetSubstring(ref substr, str, "lo", "bo", austerityPrimaryStr: true, austerityFinalStr: true); // "lo.everybo"

            return;
        }
    }
}
