using MyLibraries.MySystemLib.Classes;

namespace ConsoleAppForShowExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal number = default;

            number = 12;        MyDecimal.TakeFractionalPart(ref number); // number = 12
            number = 12.75m;    MyDecimal.TakeFractionalPart(ref number); // number = 12

            return;
        }
    }
}
