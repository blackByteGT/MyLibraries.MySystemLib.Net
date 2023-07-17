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
            List<string>
                emptyList = new List<string>(),
                notEmptyList = new List<string>();
            #endregion Items

            #region Filling
            notEmptyList.Add("hello");
            notEmptyList.Add("start");
            notEmptyList.Add("middle");
            notEmptyList.Add("bye");
            notEmptyList.Add("finish");
            #endregion Filling

            // Start emptyList:     {}
            // Start notEmptyList:  {"hello", "start", "middle", "bye", "finish"}

            result = MyList.IsEmpty(emptyList);     // result = true
            result = MyList.IsEmpty(notEmptyList);  // result = false

            return;
        }
    }
}
