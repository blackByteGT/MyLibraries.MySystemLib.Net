using MyLibraries.MySystemLib.Classes;

namespace ConsoleAppForShowExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal number = default;

            number = 1.0200m; MyDecimal.TakeExtraZerosFractionalPart(ref number); // 1.02

            return;
        }
    }
}
