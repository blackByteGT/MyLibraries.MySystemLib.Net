using MyLibraries.MySystemLib.Classes;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal number;

            number = default; MyDecimal.Parse(ref number, "12.5"); // number = 12.5
            number = default; MyDecimal.Parse(ref number, "12,5"); // number = 12.5
            number = default; MyDecimal.Parse(ref number, "12/5"); // number = default

            return;
        }
    }
}
