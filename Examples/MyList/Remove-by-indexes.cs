using System.Collections.Generic;
using MyLibraries.MySystemLib.Classes;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listString = new List<string>();

            #region Filling
            listString.Add("m");
            listString.Add("f");
            listString.Add("y");
            listString.Add("k");
            listString.Add("o");
            listString.Add("a");
            listString.Add("q");
            listString.Add("z");
            listString.Add("p");
            listString.Add("w");
            #endregion Filling

            // Start listString:    {"m", "f", "y", "k", "o", "a", "q", "z", "p", "w"}

            MyList.Remove(ref listString, 1);                       // {"m", "y", "k", "o", "a", "q", "z", "p", "w"}
            MyList.Remove(ref listString, 3, listString.Count - 1); // {"m", "y", "k"}

            return;
        }
    }
}
