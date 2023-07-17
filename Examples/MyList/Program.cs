using System.Collections.Generic;
using MyLibraries.MySystemLib.Classes;

namespace ConsoleAppForShowExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Items
            List<string>
                listValues = new List<string>(),
                listRemove = new List<string>();
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

            listRemove.Add("a");
            listRemove.Add("o");
            listRemove.Add("e");
            listRemove.Add("y");
            listRemove.Add("u");
            #endregion Filling

            // Start listValues:    {"m", "f", "y", "k", "o", "a", "q", "z", "p", "w"}
            // Info listRemove:     {"a", "o", "e", "y", "u"}

            MyList.Remove(ref listValues, listRemove);

            // Finish listValues: {"m", "f", "k", "q", "z", "p", "w"}

            return;
        }
    }
}
