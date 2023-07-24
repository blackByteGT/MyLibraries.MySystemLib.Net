using MyLibraries.MySystemLib.Classes;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Items
            const string startStr = "1234567890";

            string str;
            #endregion Items

            str = startStr; MyString.PutFormat(ref str, "XXX-XX-XX-XXX");                   // 123-45-67-890
            str = startStr; MyString.PutFormat(ref str, "---.--.--.---", formatChar: '-');  // 123.45.67.890
            str = startStr; MyString.PutFormat(ref str, "XXX-XX-XX-XXX-X");                 // 123-45-67-890

            return;
        }
    }
}
