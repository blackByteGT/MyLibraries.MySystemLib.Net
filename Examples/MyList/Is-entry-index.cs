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
            List<int> list = new List<int>();
            #endregion Items

            #region Filling
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            #endregion Filling

            // Start list: {1, 2, 3, 4, 5}

            result = MyList.IsEntry(list, 5); // result = false
            result = MyList.IsEntry(list, 4); // result = true

            return;
        }
    }
}
