using System.Collections.Generic;
using MyLibraries.MySystemLib.Classes;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Items
            List<string> listValues = new List<string>();
            IEnumerable<string> enumerableRemove = default;
            #endregion Items

            #region Filling
            listValues.Add("m");
            listValues.Add("f");
            listValues.Add("y");
            listValues.Add("k");
            listValues.Add("o");
            listValues.Add("a");
            listValues.Add("q");
            listValues.Add("z");
            listValues.Add("p");
            listValues.Add("w");

            enumerableRemove = new List<string>() { "a", "o", "e", "y", "u" };
            #endregion Filling

            // Start listValues:        {"m", "f", "y", "k", "o", "a", "q", "z", "p", "w"}
            // Info enumerableRemove:   {"a", "o", "e", "y", "u"}

            MyList.Remove(ref listValues, enumerableRemove);

            // Finish listValues: {"m", "f", "k", "q", "z", "p", "w"}

            return;
        }
    }
}
