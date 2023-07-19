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
                nullList = null,
                notNullList = new List<string>();
            #endregion Items

            #region Filling
            notNullList.Add("hello");
            notNullList.Add("start");
            notNullList.Add("middle");
            notNullList.Add("bye");
            notNullList.Add("finish");
            #endregion Filling

            // Start emptyList:     null
            // Start notEmptyList:  {"hello", "start", "middle", "bye", "finish"}

            result = MyList.IsNull(nullList);       // result = true
            result = MyList.IsNull(notNullList);    // result = false

            return;
        }
    }
}
