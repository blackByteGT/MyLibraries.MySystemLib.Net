﻿using MyLibraries.MySystemLib.Classes;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Items
            bool result = default;
            int[]
                emptyArray = new int[] { },
                notEmptyArray = new int[] { 0, 1, 2, 3, 4, 5 };
            #endregion Items

            // Start emptyArray:     {}
            // Start notEmptyArray:  { 0, 1, 2, 3, 4, 5 }

            result = MyArray.IsEmpty(emptyArray);       // result = true
            result = MyArray.IsEmpty(notEmptyArray);    // result = false

            return;
        }
    }
}
