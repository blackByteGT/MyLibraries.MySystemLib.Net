using MyLibraries.MySystemLib.Classes;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            int digit = default;

            MyDecimal.GetDigit(ref digit, 1);       // digit = 1
            MyDecimal.GetDigit(ref digit, 10);      // digit = 2
            MyDecimal.GetDigit(ref digit, 100);     // digit = 3
            MyDecimal.GetDigit(ref digit, 1000);    // digit = 4

            return;
        }
    }
}
