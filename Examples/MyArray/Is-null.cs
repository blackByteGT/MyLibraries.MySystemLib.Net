using MyLibraries.MySystemLib.Classes;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Items
            bool result = default;
            int[]
                nullArray = null,
                notNullArray = new int[] { 0, 1, 2, 3, 4, 5 };
            #endregion Items

            // Start nullArray:     null
            // Start notNullArray:  { 0, 1, 2, 3, 4, 5 }

            result = MyArray.IsNull(nullArray);       // result = true
            result = MyArray.IsNull(notNullArray);    // result = false

            return;
        }
    }
}
