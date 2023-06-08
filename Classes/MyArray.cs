

namespace MyLibraries.MySystemLib.Classes
{
    /// <summary>
    /// Масив
    /// </summary>
    static public class MyArray
    {
        #region Add
        /// <summary>
        /// Добавити значення в масив у кінець
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">Поточний масив</param>
        /// <param name="newValue">Нове значення</param>
        static public void Add<T>(ref T[] array, T newValue) => Add(ref array, newValue, -1);
        /// <summary>
        /// Добавити значення в масив по заданому індексу
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">Поточний масив</param>
        /// <param name="newValue">Нове значення</param>
        /// <param name="index">Індекс нового значення. Якщо менше за 0 або більше за кількість значень в списку - добавляється в кінець</param>
        static public void Add<T>(ref T[] array, T newValue, int index)
        {
            int lengthArray = array.Length;
            T[] newArray = new T[lengthArray + 1];

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
        #endregion Add
    }
}
