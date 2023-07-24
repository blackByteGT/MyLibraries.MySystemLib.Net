using MyLibraries.MySystemLib.Classes;

namespace ConsoleAppForShowExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Items
            const string startStr = "hello";
            string str;
            #endregion Items

            str = startStr; MyString.SetLength(ref str, str.Length + 2);        // "hello  "
            str = startStr; MyString.SetLength(ref str, str.Length + 2, '_');   // "hello__"

            return;
        }
    }
}
