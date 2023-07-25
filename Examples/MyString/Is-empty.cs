using MyLibraries.MySystemLib.Classes;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            bool result;

            result = MyString.IsEmpty("abcde");                     // false
            result = MyString.IsEmpty(null);                        // true
            result = MyString.IsEmpty(default);                     // true
            result = MyString.IsEmpty("abcde", whiteSpace: true);   // false
            result = MyString.IsEmpty("   ", whiteSpace: true);     // true

            return;
        }
    }
}
