using System.Collections.Generic;
using MyLibraries.MySystemLib.Classes;

namespace ConsoleAppForShowExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Items
            bool result = default;
            List<string> list = new List<string>();
            #endregion Items

            #region Filling
            list.Add("hello");
            list.Add("start");
            list.Add("main");
            list.Add("return");
            list.Add("finish");
            #endregion Filling

            // Start list: {"hello", "start", "main", "return", "finish"}

            result = MyList.IsEntry(list, "bye");   // result = false
            result = MyList.IsEntry(list, "hello"); // result = true

            return;
        }
    }
}
