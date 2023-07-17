using System.Collections.Generic;
using MyLibraries.MySystemLib.Classes;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Items
            bool result = default;
            List<string>
                mainList = new List<string>(),
                listCheck = new List<string>(),
                listCheck2 = new List<string>(),
                listCheck3 = new List<string>();
            #endregion Items

            #region Filling
            mainList.Add("hello");
            mainList.Add("start");
            mainList.Add("main");
            mainList.Add("return");
            mainList.Add("finish");

            listCheck.Add("hello");
            listCheck.Add("remark");
            listCheck.Add("finish");

            listCheck2.Add("string");
            listCheck2.Add("index");
            listCheck2.Add("bye");

            listCheck3.Add("start");
            listCheck3.Add("main");
            listCheck3.Add("struct");
            #endregion Filling

            // Start mainList:      {"hello", "start", "main", "return", "finish"}
            // Start listCheck:     {"hello", "remark", "finish"}
            // Start listCheck2:    {"string", "index", "bye"}
            // Start listCheck3:    {"start", "main", "struct"}

            result = MyList.IsEntry(mainList, listCheck);   // result = true
            result = MyList.IsEntry(mainList, listCheck2);  // result = false
            result = MyList.IsEntry(mainList, listCheck3);  // result = true

            return;
        }
    }
}
