using System;
using System.Threading;
using System.Collections.Generic;

namespace MyLibraries.MySystemLib.Classes
{
    /// <summary>
    /// Випадковий
    /// </summary>
    /// <remarks>
    ///     <para>Файл класу: <seealso href="https://github.com/blackByteGT/MyLibraries.MySystemLib.Net/blob/main/Classes/MyRandom.cs"/></para>
    ///     <para>Приклади застосування: <seealso href="https://github.com/blackByteGT/MyLibraries.MySystemLib.Net/tree/main/Examples/MyRandom"/></para>
    /// </remarks>
    /// 
    /// <translation xml:lang="en">
    ///     <summary>
    ///     Random
    ///     </summary>
    ///     <remarks>
    ///         <para>File code: <seealso href="https://github.com/blackByteGT/MyLibraries.MySystemLib.Net/blob/main/Classes/MyRandom.cs"/></para>
    ///         <para>Application examples: <seealso href="https://github.com/blackByteGT/MyLibraries.MySystemLib.Net/tree/main/Examples/MyRandom"/></para>
    ///     </remarks>
    /// </translation>
    static public class MyRandom
    {
        /// <summary>
        /// Отримати випадкове число
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyRandom/Get-random-int.cs"/></remarks>
        /// <param name="number">Поточне число</param>
        /// <param name="minNumber">Мінімальне число</param>
        /// <param name="maxNumber">Маскимальне число</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Get a random number
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyRandom/Get-random-int.cs"/></remarks>
        ///     <param name="number">The current number</param>
        ///     <param name="minNumber">Minimum number</param>
        ///     <param name="maxNumber">The maximum number</param>
        /// </translation>
        static public void Next(ref int number, int minNumber = 0, int maxNumber = int.MaxValue)
        {
            Thread.Sleep(10);

            number = new Random(DateTime.Now.Millisecond).Next(minNumber, maxNumber);
        }
        /// <summary>
        /// Отримати випадковий рядок
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyRandom/Get-random-string.cs"/></remarks>
        /// <param name="str">Поточний рядок</param>
        /// <param name="lengthStr">Довжина випадкового рядка</param>
        /// <param name="enterNumber">Вмістити числа</param>
        /// <param name="enterLowLatter">Вмістити маленькі літери</param>
        /// <param name="enterCapLatter">Вмістити великі літери</param>
        /// <param name="listAddChars">Список додаткових символів</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Get a random string
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyRandom/Get-random-string.cs"/></remarks>
        ///     <param name="str">The current line</param>
        ///     <param name="lengthStr">The length of the random string</param>
        ///     <param name="enterNumber">Enter numbers</param>
        ///     <param name="enterLowLatter">Enter lowercase letters</param>
        ///     <param name="enterCapLatter">Enter capital letters</param>
        ///     <param name="listAddChars">List of additional symbols</param>
        /// </translation>
        static public void Next(
            ref string str, int lengthStr, bool enterNumber = false, bool enterLowLatter = false, bool enterCapLatter = false, List<char> listAddChars = null
        )
        {
            #region Items
            bool listAddCharsIsEmpty = MyList.IsEmpty(listAddChars);

            if (!(lengthStr > 0) || (!enterNumber && !enterLowLatter && !enterCapLatter && listAddCharsIsEmpty)) return;

            List<char>
                listAllowedChars = new List<char>(),
                currentList = default;
            #endregion Items

            if (enterNumber) { MyList.GetNumbers(ref currentList); listAllowedChars.AddRange(currentList); }
            if (enterLowLatter) { MyList.GetEnglishLowercaseLetters(ref currentList); listAllowedChars.AddRange(currentList); }
            if (enterCapLatter) { MyList.GetEnglishUppercaseLetters(ref currentList); listAllowedChars.AddRange(currentList); }
            if (!listAddCharsIsEmpty) listAllowedChars.AddRange(listAddChars);

            MyList.Shuffle(ref listAllowedChars);
            Next(ref str, lengthStr, listAllowedChars);
        }
        /// <summary>
        /// Отримати випадковий рядок
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyRandom/Get-random-string.cs"/></remarks>
        /// <param name="str">Поточний рядок</param>
        /// <param name="lengthStr">Довжина випадкового рядка</param>
        /// <param name="listAllowedChars">Список дозволених символів</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Get a random string
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyRandom/Get-random-string.cs"/></remarks>
        ///     <param name="str">The current line</param>
        ///     <param name="lengthStr">The length of the random string</param>
        ///     <param name="listAllowedChars">List of allowed characters</param>
        /// </translation>
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
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyRandom/Get-random-value-of-list.cs"/></remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">Поточне значення</param>
        /// <param name="listValue">Список значень</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Get a random value from a list
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyRandom/Get-random-value-of-list.cs"/></remarks>
        ///     <typeparam name="T"></typeparam>
        ///     <param name="value">Current value</param>
        ///     <param name="listValue">List of values</param>
        /// </translation>
        static public void Next<T>(ref T value, List<T> listValue)
        {
            if (MyList.IsEmpty(listValue)) return;

            #region Items
            int 
                countListValue = listValue.Count,
                randomIndex = default;
            #endregion Items

            MyList.Shuffle(ref listValue);
            Next(ref randomIndex, 0, countListValue - 1);

            value = listValue[randomIndex];
        }
    }
}
