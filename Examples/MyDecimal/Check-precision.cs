using MyLibraries.MySystemLib.Classes;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Items
            const decimal number = 12.5m;

            bool result = default;
            #endregion Items

            // Info number: 12.5

            result = CheckPrecision(number, 1m);                 // result = false
            result = MyDecimal.CheckPrecision(number, 0.1m);     // result = true
            result = MyDecimal.CheckPrecision(number, 0.01m);    // result = false

            return;
        }
    }
}
