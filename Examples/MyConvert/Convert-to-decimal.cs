using MyLibraries.MySystemLib.Classes;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal number;

            number = default; MyConvert.ConvertToDecimal(ref number, "12.5");                           // number = 12.5
            number = default; MyConvert.ConvertToDecimal(ref number, "12,5");                           // number = 12.5
            number = default; MyConvert.ConvertToDecimal(ref number, "12/5");                           // number = default
            number = default; MyConvert.ConvertToDecimal(ref number, "12/5", new List<char>() { '/' }); // number = 12.5

            return;
        }
    }
}
