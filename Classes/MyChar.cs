using System.Collections.Generic;

namespace MyLibraries.MySystemLib.Classes
{
    /// <summary>
    /// Символ
    /// </summary>
    /// <remarks>
    ///     <para>Файл класу: <seealso href="https://github.com/blackByteGT/MyLibraries.MySystemLib.Net/blob/main/Classes/MyChar.cs"/></para>
    ///     <para>Приклади застосування: <seealso href="https://github.com/blackByteGT/MyLibraries.MySystemLib.Net/tree/main/Examples/MyChar"/></para>
    /// </remarks>
    /// 
    /// <translation xml:lang="en">
    ///     <summary>
    ///     Symbol
    ///     </summary>
    ///     <remarks>
    ///         <para>File code: <seealso href="https://github.com/blackByteGT/MyLibraries.MySystemLib.Net/blob/main/Classes/MyChar.cs"/></para>
    ///         <para>Application examples: <seealso href="https://github.com/blackByteGT/MyLibraries.MySystemLib.Net/tree/main/Examples/MyChar"/></para>
    ///     </remarks>
    /// </translation>
    static public class MyChar
    {
        #region Checks
        /// <summary>
        /// Перевірити символ
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyChar/Check-symbol.cs"/></remarks>
        /// <param name="symbol">Поточний символ</param>
        /// <param name="checkByNumbers">Перевірити по числам</param>
        /// <param name="checkByEnglishLowerLetters">Перевірити по англійським літерам нижнього регістру</param>
        /// <param name="checkByEnglishUpperLetters">Перевірити по англійським літерам верхнього регістру</param>
        /// <returns>true - символ входить у задані символи, false - символ не входить у задані символи</returns>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Check symbol
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyChar/Check-symbol.cs"/></remarks>
        ///     <param name="symbol">Current symbol</param>
        ///     <param name="checkByNumbers">Check by numbers</param>
        ///     <param name="checkByEnglishLowerLetters">Check for lowercase English letters</param>
        ///     <param name="checkByEnglishUpperLetters">Check for uppercase English letters</param>
        ///     <returns>true - the symbol is included in the specified symbols, false - the symbol is not included in the specified symbols</returns>
        /// </translation>
        public static bool CheckSymbol(char symbol, bool checkByNumbers = false, bool checkByEnglishLowerLetters = false, bool checkByEnglishUpperLetters = false)
        {
            if (!checkByNumbers && !checkByEnglishLowerLetters && !checkByEnglishUpperLetters) return false;
            else if (checkByNumbers && checkByEnglishLowerLetters && checkByEnglishUpperLetters) return CheckSymbol(symbol, true, true);

            return
                 (checkByNumbers && CheckByNumbers(symbol)) ||
                 (checkByEnglishLowerLetters && CheckByEnglishLowercaseLetters(symbol)) ||
                 (checkByEnglishUpperLetters && CheckByEnglishUppercaseLetters(symbol));
        }
        /// <summary>
        /// Перевірити символ
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyChar/Check-symbol.cs"/></remarks>
        /// <param name="symbol">Поточний символ</param>
        /// <param name="checkByNumbers">Перевірити по числам</param>
        /// <param name="checkByEnglishLetters">Перевірити по англійським літерам</param>
        /// <returns>true - символ входить у задані символи, false - символ не входить у задані символи</returns>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Check symbol
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyChar/Check-symbol.cs"/></remarks>
        ///     <param name="symbol">Current symbol</param>
        ///     <param name="checkByNumbers">Check by numbers</param>
        ///     <param name="checkByEnglishLetters">Check by English letters</param>
        ///     <returns>true - the symbol is included in the specified symbols, false - the symbol is not included in the specified symbols</returns>
        /// </translation>
        public static bool CheckSymbol(char symbol, bool checkByNumbers = false, bool checkByEnglishLetters = false)
        {
            if (!checkByNumbers && !checkByEnglishLetters) return false;

            return
                (checkByNumbers && CheckByNumbers(symbol)) ||
                (checkByEnglishLetters && CheckByEnglishLetters(symbol));
        }
        /// <summary>
        /// Перевірити символ по числам
        /// </summary>
        /// <param name="symbol">Поточний символ</param>
        /// <returns>true - поточний символ це число, false - поточний символ це не число</returns>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Check the symbol by numbers
        ///     </summary>
        ///     <param name="symbol">Current symbol</param>
        ///     <returns>true - the current symbol is a number, false - the current symbol is not a number</returns>
        /// </translation>
        static private bool CheckByNumbers(char symbol)
        {
            List<char> numbers = default; MyList.GetNumbers(ref numbers);

            return MyList.IsEntry(numbers, symbol);
        }
        /// <summary>
        /// Перевірити символ по англійським літерам
        /// </summary>
        /// <param name="symbol">Поточний символ</param>
        /// <returns>true - поточний символ це англійська літера, false - поточний символ це не англійська літера</returns>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Check the symbol by English letters
        ///     </summary>
        ///     <param name="symbol">Current symbol</param>
        ///     <returns>true - the current symbol is an English letter, false - the current symbol is not an English letter</returns>
        /// </translation>
        static private bool CheckByEnglishLetters(char symbol)
        {
            List<char> englishLetters = default; MyList.GetEnglishLetters(ref englishLetters);

            return MyList.IsEntry(englishLetters, symbol);
        }
        /// <summary>
        /// Перевірити символ по малим англійським літерам
        /// </summary>
        /// <param name="symbol">Поточний символ</param>
        /// <returns>true - поточний символ це мала англійська літера, false - поточний символ це не мала англійська літера</returns>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Check the symbol by lowercase English letters
        ///     </summary>
        ///     <param name="symbol">Current symbol</param>
        ///     <returns>true - the current symbol is a lowercase English letter, false - the current symbol is not a lowercase English letter</returns>
        /// </translation>
        static private bool CheckByEnglishLowercaseLetters(char symbol)
        {
            List<char> englishLowercaseLetters = default; MyList.GetEnglishLowercaseLetters(ref englishLowercaseLetters);

            return MyList.IsEntry(englishLowercaseLetters, symbol);
        }
        /// <summary>
        /// Перевірити символ по великим англійським літерам
        /// </summary>
        /// <param name="symbol">Поточний символ</param>
        /// <returns>true - поточний символ це велика англійська літера, false - поточний символ це не велика англійська літера</returns>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Check the symbol against uppercase English letters
        ///     </summary>
        ///     <param name="symbol">Current symbol</param>
        ///     <returns>true - the current symbol is an uppercase English letter, false - the current symbol is not an uppercase English letter</returns>
        /// </translation>
        static private bool CheckByEnglishUppercaseLetters(char symbol)
        {
            List<char> englishUppercaseLetters = default; MyList.GetEnglishUppercaseLetters(ref englishUppercaseLetters);

            return MyList.IsEntry(englishUppercaseLetters, symbol);
        }
        #endregion Checks
    }
}
