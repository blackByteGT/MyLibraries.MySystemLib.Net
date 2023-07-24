using MyLibraries.MySystemLib.Classes;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            int digit = default;

            digit = default; MyDecimal.GetDigit(ref digit, 1);      // digit = 1
            digit = default; MyDecimal.GetDigit(ref digit, "1");    // digit = 1
            digit = default; MyDecimal.GetDigit(ref digit, 1000);   // digit = 4
            digit = default; MyDecimal.GetDigit(ref digit, "1000"); // digit = 4

            digit = default; MyDecimal.GetDigit(ref digit, "12,75");                                // digit = 2
            digit = default; MyDecimal.GetDigit(ref digit, "100.25");                               // digit = 3
            digit = default; MyDecimal.GetDigit(ref digit, "1000/05", new List<char>() { '/' });    // digit = 4

            return;
        }
    }
}
