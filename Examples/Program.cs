using MyLibraries.MySystemLib.Classes;

namespace ConsoleAppForShowExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal number = default;

            MyDecimal.Parse(ref number, "12.5"); // number = 12.5
            number = default; MyDecimal.Parse(ref number, "12,5"); // number = 12.5
            number = default; MyDecimal.Parse(ref number, "12/5"); // number = default

            return;
        }
    }
}
