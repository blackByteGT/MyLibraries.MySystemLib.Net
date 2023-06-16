using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibraries.MySystemLib.Classes
{
    /// <summary>
    /// Випадковий
    /// </summary>
    static public class MyRandom
    {
        /// <summary>
        /// Отримати випадкове число від minNumber до maxNumber
        /// </summary>
        /// <param name="number">Поточне число</param>
        /// <param name="minNumber">Мінімальне значення</param>
        /// <param name="maxNumber">Маскимальне число</param>
        static public void Next(ref int number, int minNumber = 0, int maxNumber = int.MaxValue) =>
            number = new Random().Next(minNumber, maxNumber);
        /// <summary>
        /// Отримати випадковий рядок
        /// </summary>
        /// <param name="str">Поточний рядок</param>
        /// <param name="lengthStr">Довжина випадкового рядка</param>
        /// <param name="enterNumber">Вмістити числа</param>
        /// <param name="enterLowLatter">Вмістити маленькі літери</param>
        /// <param name="enterCapLatter">Вмістити великі літери</param>
        /// <param name="listAddChars">Список додаткових символів</param>
        static public void Next(
            ref string str, int lengthStr, bool enterNumber = false, bool enterLowLatter = false, bool enterCapLatter = false, List<string> listAddChars = null
        )
        {
            if (!(lengthStr > 0) || (!enterNumber && !enterLowLatter && !enterCapLatter)) return;

            #region Items
            List<char>
                listAllowedChars = new List<char>(),
                currentList = default;
            #endregion Items

            if (enterNumber) { MyList.GetNumbers(ref currentList); listAllowedChars.AddRange(currentList); }
            if (enterLowLatter) { MyList.GetEnglishLowercaseLetters(ref currentList); listAllowedChars.AddRange(currentList); }
            if (enterCapLatter) { MyList.GetEnglishUppercaseLetters(ref currentList); listAllowedChars.AddRange(currentList); }
            if (listAddChars != null) listAllowedChars.AddRange(currentList);

            Next(ref str, lengthStr, listAllowedChars);
        }
        /// <summary>
        /// Отримати випадковий рядок
        /// </summary>
        /// <param name="str">Поточний рядок</param>
        /// <param name="lengthStr">Довжина випадкового рядка</param>
        /// <param name="listAllowedChars">Список дозволених символів</param>
        static public void Next(ref string str, int lengthStr, List<char> listAllowedChars)
        {
            #region Items
            int
                countListAllowedChars = listAllowedChars.Count,
                currentIndex = default;
            string newStr = "";
            #endregion Items

            for (int i = 0; i < lengthStr; i++)
            {
                Next(ref currentIndex, maxNumber: countListAllowedChars);

                newStr += listAllowedChars[currentIndex];
            }

            str = newStr;
        }
        /// <summary>
        /// Отримати випадкове значення з списку
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">Поточне значення</param>
        /// <param name="listValue">Список значень</param>
        static public void Next<T>(ref T value, List<T> listValue)
        {
            int countListValue = listValue.Count; if (!(countListValue > 0)) return;
            int randomIndex = default; Next(ref randomIndex, 0, countListValue - 1);

            value = listValue[randomIndex];
        }
    }
}
