using System.Collections.Generic;
using MyLibraries.MySystemLib.Classes;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Items
            int count = default;
            List<string>
                listString = new List<string>(),
                listMiddle = new List<string>(),
                listBegin = new List<string>(),
                listEnd = new List<string>();
            #endregion Items

            #region Filling
            listString.Add("hello");
            listString.Add("start");
            listString.Add("finish");
            listString.Add("return");
            listString.Add("main");
            listString.Add("class");
            listString.Add("public");
            listString.Add("bye");

            count = listString.Count / 2;
            #endregion Filling

            // Start listString:   {"hello", "start", "finish", "return", "main", "class", "public", "bye"}

            MyList.GetSublist(ref listMiddle, listString, ((listString.Count - count) / 2), count);
            MyList.GetSublist(ref listBegin, listString, count: count);
            MyList.GetSublist(ref listEnd, listString, index: listString.Count - count);

            // Info listMiddle: {"finish", "return", "main", "class"}
            // Info listBegin:  {"hello", "start", "finish", "return"}
            // Info listEnd:    {"main", "class", "public", "bye"}

            return;
        }
    }
}
