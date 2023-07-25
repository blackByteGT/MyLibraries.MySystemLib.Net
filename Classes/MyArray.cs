

namespace MyLibraries.MySystemLib.Classes
{
    /// <summary>
    /// Масив
    /// </summary>
    /// <remarks>
    ///     <para>Файл класу: <seealso href="https://github.com/blackByteGT/MyLibraries.MySystemLib.Net/blob/main/Classes/MyArray.cs"/></para>
    ///     <para>Приклади застосування: <seealso href="https://github.com/blackByteGT/MyLibraries.MySystemLib.Net/tree/main/Examples/MyArray"/></para>
    /// </remarks>
    /// 
    /// <translation xml:lang="en">
    ///     <summary>
    ///     Array
    ///     </summary>
    ///     <remarks>
    ///         <para>File code: <seealso href="https://github.com/blackByteGT/MyLibraries.MySystemLib.Net/blob/main/Classes/MyArray.cs"/></para>
    ///         <para>Application examples: <seealso href="https://github.com/blackByteGT/MyLibraries.MySystemLib.Net/tree/main/Examples/MyArray"/></para>
    ///     </remarks>
    /// </translation>
    static public class MyArray
    {
        #region Add
        /// <summary>
        /// Добавити значення в масив
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyArray/Add-of-value.cs"/></remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">Поточний масив</param>
        /// <param name="newValue">Нове значення</param>
        /// <param name="index">Індекс нового значення. Якщо менше за 0 або більше за кількість значень в списку - добавляється в кінець</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Add values to the array
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyArray/Add-of-value.cs"/></remarks>
        ///     <typeparam name="T"></typeparam>
        ///     <param name="array">Current array</param>
        ///     <param name="newValue">New value</param>
        ///     <param name="index">The index of the new value. If it is less than 0 or more than the number of values in the list, it is added to the end</param>
        /// </translation>
        static public void Add<T>(ref T[] array, T newValue, int index = -1)
        {
            #region Items
            if (IsNull(array)) array = new T[] { };

            int lengthArray = array.Length;
            T[] newArray = new T[lengthArray + 1];
            #endregion Items

            if (index < 0 || index > lengthArray - 1)
            {
                index = lengthArray;
                newArray[index] = newValue;

                for (int i = 0; i < lengthArray; i++) newArray[i] = array[i];
            }
            else
            {
                int indexNewArray = 0;

                for (int i = 0; i < lengthArray; i++)
                {
                    if (i == index) newArray[indexNewArray++] = newValue;

                    newArray[indexNewArray++] = array[i];
                }
            }

            array = newArray;
        }
        /// <summary>
        /// Добавити в масив значення з іншого масиву
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyArray/Add-array-of-values.cs"/></remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">Поточний масив</param>
        /// <param name="arrayAdd">Додатковий масив</param>
        /// <param name="index">Індекс нового значення. Якщо менше за 0 або більше за кількість значень в списку - добавляється в кінець</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Add values from another array to the array
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyArray/Add-array-of-values.cs"/></remarks>
        ///     <typeparam name="T"></typeparam>
        ///     <param name="array">Current array</param>
        ///     <param name="arrayAdd">Additional array</param>
        ///     <param name="index">The index of the new value. If it is less than 0 or more than the number of values in the list, it is added to the end</param>
        /// </translation>
        static public void Add<T>(ref T[] array, T[] arrayAdd, int index = -1)
        {
            #region Items
            if (IsEmpty(arrayAdd)) return;

            int
                lengthArrayAdd = arrayAdd.Length,
                indexAdd = index < 0 ? 0 : 1;
            T[] newArray = IsNull(array) ? new T[] { } : array;
            #endregion Items

            for (int i = 0; i < lengthArrayAdd; i++)
            {
                Add(ref newArray, arrayAdd[i], index);

                index += indexAdd;
            }

            array = newArray;
        }
        #endregion Add

        #region Check
        /// <summary>
        /// Перевірка на порожній масив
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyArray/Is-empty.cs"/></remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">Масив</param>
        /// <returns>true - масив порожній, false - масив не порожній</returns>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Checking for an empty array
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyArray/Is-empty.cs"/></remarks>
        ///     <typeparam name="T"></typeparam>
        ///     <param name="array">Array</param>
        ///     <returns>true - the array is empty, false - the array is not empty</returns>
        /// </translation>
        static public bool IsEmpty<T>(T[] array)
        {
            return IsNull(array) || array.Length == 0;
        }
        /// <summary>
        /// Перевірити масив на null
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyArray/Is-null.cs"/></remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">Масив</param>
        /// <returns>true - масив є null, false - масив не є null</returns>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Check the array for null
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyArray/Is-null.cs"/></remarks>
        ///     <typeparam name="T"></typeparam>
        ///     <param name="array">Array</param>
        ///     <returns>true - the array is null, false - the array is not null</returns>
        /// </translation>
        static public bool IsNull<T>(T[] array)
        {
            return array is null;
        }
        #endregion Check
    }
}
