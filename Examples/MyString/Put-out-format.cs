using MyLibraries.MySystemLib.Classes;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            string str;


            str = "123-45-67-890"; MyString.PutOutFormat(ref str, "XXX-XX-XX-XXX");                   // 1234567890
            str = "123.45.67.890"; MyString.PutOutFormat(ref str, "---.--.--.---", formatChar: '-');  // 1234567890

            return;
        }
    }
}
