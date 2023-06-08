using System.Collections.Generic;

namespace MyLibraries.MySystemLib.Classes
{
    /// <summary>
    /// Символ
    /// </summary>
    static public class MyChar
    {
        #region Function
        #region Checks
        /// <summary>
        /// Перевірити символ
        /// </summary>
        /// <param name="currentSymbol">Поточний символ</param>
        /// <param name="checkByNumbers">Перевірити по числам</param>
        /// <param name="checkByEnglishLowercaseLetters">Перевірити по англійським літерам нижнього регістру</param>
        /// <param name="checkByEnglishUppercaseLetters">Перевірити по англійським літерам верхнього регістру</param>
        /// <returns>true - символ входить у задані симоли, false - символ не входить у задані симоли</returns>
        public static bool CheckSymbol(char currentSymbol, bool checkByNumbers = false, bool checkByEnglishLowercaseLetters = false, bool checkByEnglishUppercaseLetters = false)
        {
            if (!checkByNumbers && !checkByEnglishLowercaseLetters && !checkByEnglishUppercaseLetters) return false;
            else if (checkByNumbers && checkByEnglishLowercaseLetters && checkByEnglishUppercaseLetters) return CheckSymbol(currentSymbol, true, true);

            return
                 (checkByNumbers && CheckByNumbers(currentSymbol)) ||
                 (checkByEnglishLowercaseLetters && CheckByEnglishLowercaseLetters(currentSymbol)) ||
                 (checkByEnglishUppercaseLetters && CheckByEnglishUppercaseLetters(currentSymbol));
        }
        /// <summary>
        /// Перевірити символ
        /// </summary>
        /// <param name="currentSymbol">Поточний символ</param>
        /// <param name="checkByNumbers">Перевірити по числам</param>
        /// <param name="checkByEnglishLetters">Перевірити по англійським літерам</param>
        /// <returns>true - символ входить у задані симоли, false - символ не входить у задані симоли</returns>
        public static bool CheckSymbol(char currentSymbol, bool checkByNumbers = false, bool checkByEnglishLetters = false)
        {
            if (!checkByNumbers && !checkByEnglishLetters) return false;

            return
                (checkByNumbers && CheckByNumbers(currentSymbol)) ||
                (checkByEnglishLetters && CheckByEnglishLetters(currentSymbol));
        }
        /// <summary>
        /// Перевірити символ по числам
        /// </summary>
        /// <param name="currentSymbol">Поточний символ</param>
        /// <returns>true - поточний символ це число, false - поточний символ це не число</returns>
        static private bool CheckByNumbers(char currentSymbol)
        {
            List<string> numbers = default; MyList.GetNumbers(ref numbers);

            return MyList.CheckValueForEntryInList(currentSymbol.ToString(), numbers);
        }
        /// <summary>
        /// Перевірити символ по англійським літерам
        /// </summary>
        /// <param name="currentSymbol">Поточний символ</param>
        /// <returns>true - поточний символ це англійська літера, false - поточний символ це не англійська літера</returns>
        static private bool CheckByEnglishLetters(char currentSymbol)
        {
            List<string> englishLetters = default; MyList.GetEnglishLetters(ref englishLetters);

            return MyList.CheckValueForEntryInList(currentSymbol.ToString(), englishLetters);
        }
        /// <summary>
        /// Перевірити символ по малим англійським літерам
        /// </summary>
        /// <param name="currentSymbol">Поточний символ</param>
        /// <returns>true - поточний символ це мала англійська літера, false - поточний символ це не мала англійська літера</returns>
        static private bool CheckByEnglishLowercaseLetters(char currentSymbol)
        {
            List<string> englishLowercaseLetters = default; MyList.GetEnglishLowercaseLetters(ref englishLowercaseLetters);

            return MyList.CheckValueForEntryInList(currentSymbol.ToString(), englishLowercaseLetters);
        }
        /// <summary>
        /// Перевірити символ по великим англійським літерам
        /// </summary>
        /// <param name="currentSymbol">Поточний символ</param>
        /// <returns>true - поточний символ це велика англійська літера, false - поточний символ це не велика англійська літера</returns>
        static private bool CheckByEnglishUppercaseLetters(char currentSymbol)
        {
            List<string> englishUppercaseLetters = default; MyList.GetEnglishUppercaseLetters(ref englishUppercaseLetters);

            return MyList.CheckValueForEntryInList(currentSymbol.ToString(), englishUppercaseLetters);
        }
        #endregion Checks
        #endregion Function
    }
}
