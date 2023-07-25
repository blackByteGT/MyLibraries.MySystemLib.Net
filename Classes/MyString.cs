using System;
using System.Collections.Generic;

namespace MyLibraries.MySystemLib.Classes
{
    /// <summary>
    /// Рядок
    /// </summary>
    /// <remarks>
    ///     <para>Файл класу: <seealso href="https://github.com/blackByteGT/MyLibraries.MySystemLib.Net/blob/main/Classes/MyString.cs"/></para>
    ///     <para>Приклади застосування: <seealso href="https://github.com/blackByteGT/MyLibraries.MySystemLib.Net/tree/main/Examples/MyString"/></para>
    /// </remarks>
    /// 
    /// <translation xml:lang="en">
    ///     <summary>
    ///     String
    ///     </summary>
    ///     <remarks>
    ///         <para>File code: <seealso href="https://github.com/blackByteGT/MyLibraries.MySystemLib.Net/blob/main/Classes/MyString.cs"/></para>
    ///         <para>Application examples: <seealso href="https://github.com/blackByteGT/MyLibraries.MySystemLib.Net/tree/main/Examples/MyString"/></para>
    ///     </remarks>
    /// </translation>
    static public class MyString
    {
        #region Items
        /// <summary>
        /// Символи для роботи з форматом рядка
        /// </summary>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Symbols for working with string format
        ///     </summary>
        /// </translation>
        public const char SymbolForFormat = 'X';

        #region Formats
        /// <summary>
        /// Формат номера телефону
        /// </summary>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Format for phone number
        ///     </summary>
        /// </translation>
        public const string FormatByTelephoneNumber = "+38-(XXX)-XXX-XX-XX";
        /// <summary>
        /// Формат номера банківської карти
        /// </summary>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Bank card number format
        ///     </summary>
        /// </translation>
        public const string FormatByNumberCard = "XXXX-XXXX-XXXX-XXXX";
        #endregion Formats

        #endregion Items

        #region Functions
        #region Sets
        /// <summary>
        /// Встановити довжину рядка
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyString/Set-length.cs"/></remarks>
        /// <param name="str">Поточний рядок</param>
        /// <param name="length">Вказана довжина</param>
        /// <param name="charSet">Символ добавлення довжини</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Set the line length
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyString/Set-length.cs"/></remarks>
        ///     <param name="str">The current line</param>
        ///     <param name="length">The specified length</param>
        ///     <param name="charSet">Add length symbol</param>
        /// </translation>
        static public void SetLength(ref string str, int length, char charSet = ' ')
        {
            #region Items
            string newStr = "";
            int
                lengthStr = str.Length,
                difference = default;

            if (charSet == default) charSet = ' ';
            #endregion Items

            for (int i = 0; i < length && i < lengthStr; i++) newStr += str[i];

            if ((difference = length - lengthStr) > 0)
                for (int i = 0; i < difference; i++) newStr += charSet;

            str = newStr;
        }
        #endregion Sets

        #region Gets
        /// <summary>
        /// Отримати підрядок з рядка
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyString/Get-substring.cs"/></remarks>
        /// <param name="substr">Поточний підрядок</param>
        /// <param name="str">Поточний рядок</param>
        /// <param name="index">Початковий індекс</param>
        /// <param name="lenght">Довжина підстроки. Якщо length = 0, тоді зчитування символів з str буде відбуватися до кінця</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Get a substring from a string
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyString/Get-substring.cs"/></remarks>
        ///     <param name="substr">Current substring</param>
        ///     <param name="str">The current line</param>
        ///     <param name="index">Initial index</param>
        ///     <param name="lenght">Substring length. If length = 0, then characters from str will be read to the end</param>
        /// </translation>
        static public void GetSubstring(ref string substr, string str, int index = 0, int lenght = 0)
        {
            #region Items
            int lengthStr = str.Length;

            if (index < 0 || index > lengthStr - 1) return;

            if (lenght == 0)
            {
                if (index == 0) { substr = str; return; }

                lenght = lengthStr;
            }

            string newSubstr = default;
            int lengthFromIndex = index + lenght;
            #endregion Items

            for (int i = index; i < lengthFromIndex && i < lengthStr; i++) newSubstr += str[i];

            substr = newSubstr;
        }
        /// <summary>
        /// Отримати підрядок з рядка
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyString/Get-substring.cs"/></remarks>
        /// <param name="substr">Поточний підрядок</param>
        /// <param name="str">Поточний рядок</param>
        /// <param name="primaryStr">Початковий підрядок</param>
        /// <param name="finalStr">Кінцевий підрядок</param>
        /// <param name="austerityPrimaryStr">Добавити початковий підрядок</param>
        /// <param name="austerityFinalStr">Добавити кінцевий підрядок</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Get a substring from a string
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyString/Get-substring.cs"/></remarks>
        ///     <param name="substr">Current substring</param>
        ///     <param name="str">The current line</param>
        ///     <param name="primaryStr">Initial substring</param>
        ///     <param name="finalStr">Final substring</param>
        ///     <param name="austerityPrimaryStr">Add an initial substring</param>
        ///     <param name="austerityFinalStr">Add a trailing line</param>
        /// </translation>
        static public void GetSubstring(
            ref string substr, string str, string primaryStr, string finalStr, bool austerityPrimaryStr = false, bool austerityFinalStr = false
        )
        {
            if (IsEmpty(str) || IsEmpty(primaryStr) || IsEmpty(finalStr)) return;

            #region Items
            int
                 lengthStr = str.Length,
                 lengthPrimaryStr = primaryStr.Length,
                 lengthFinalStr = finalStr.Length;
            string
                newSubstr = "",
                currentStr = "";
            #endregion Items

            for (int i = 0; i < lengthStr; i++)
            {
                GetSubstring(ref currentStr, str, i, lengthPrimaryStr);

                if (currentStr == primaryStr)
                {
                    for (i += austerityPrimaryStr ? 0 : lengthPrimaryStr; i < lengthStr; i++)
                    {
                        GetSubstring(ref currentStr, str, i, lengthFinalStr);

                        if (currentStr == finalStr)
                        {
                            newSubstr += austerityFinalStr ? currentStr : "";
                            break;
                        }

                        newSubstr += str[i];
                    }
                    break;
                }
            }

            substr = newSubstr;
        }
        /// <summary>
        /// Отримати підрядки з рядка
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyString/Get-substrings.cs"/></remarks>
        /// <param name="substrs">Поточний список підрядків</param>
        /// <param name="str">Поточний рядок</param>
        /// <param name="separator">Розподілювач</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Get substrings from a string
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyString/Get-substrings.cs"/></remarks>
        ///     <param name="substrs">Current list of substrings</param>
        ///     <param name="str">The current line</param>
        ///     <param name="separator">Distributor</param>
        /// </translation>
        static public void GetSubstrings(ref List<string> substrs, string str, string separator)
        {
            if (IsEmpty(str) || IsEmpty(separator)) return;

            #region Items
            int
                lengthStr = str.Length,
                lengthSeparator = separator.Length,
                currentIndex = 0;
            string currentStr = default;
            List<string> newSubstrs = new List<string>();
            #endregion Items

            for (int i = 0; i < lengthStr; i++)
            {
                GetSubstring(ref currentStr, str, i, lengthSeparator);

                if (currentStr == separator)
                {
                    GetSubstring(ref currentStr, str, currentIndex, i - currentIndex); newSubstrs.Add(currentStr);

                    currentIndex = i + lengthSeparator;
                }
            }

            if (currentIndex != lengthStr) { GetSubstring(ref currentStr, str, currentIndex); newSubstrs.Add(currentStr); }

            substrs = newSubstrs;
        }
        /// <summary>
        /// Отримати розташування підрядка в рядку
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyString/Get-substring-indices.cs"/></remarks>
        /// <param name="startIndex">Індекс початку</param>
        /// <param name="endIndex">Індекс кінця</param>
        /// <param name="str">Рядок</param>
        /// <param name="substr">Підрядок</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Get the position of a substring in a string
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyString/Get-substring-indices.cs"/></remarks>
        ///     <param name="startIndex">Start index</param>
        ///     <param name="endIndex">End index</param>
        ///     <param name="str">String</param>
        ///     <param name="substr">Substring</param>
        /// </translation>
        static public void GetSubstringIndices(ref int startIndex, ref int endIndex, string str, string substr)
        {
            if (IsEmpty(str) || IsEmpty(substr)) return;

            #region Items
            int
                lengthStr = str.Length,
                lengthSubstr = substr.Length;

            if (lengthSubstr > lengthStr) return;

            string currentStr = "";
            #endregion Items

            for (int i = 0; i < lengthStr; i++)
            {
                GetSubstring(ref currentStr, str, i, lengthSubstr);

                if (currentStr == substr)
                {
                    startIndex = i;
                    endIndex = i + lengthSubstr - 1;

                    return;
                }
            }
        }
        #endregion Gets

        #region Checks
        /// <summary>
        /// Перевірити на входження підрядка в рядку
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyString/Is-entry.cs"/></remarks>
        /// <param name="str">Рядок</param>
        /// <param name="substr">Підрядок</param>
        /// <returns>true - підрядок входить в рядок, false - підрядок не входить</returns>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Check for occurrence of a substring in the line
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyString/Is-entry.cs"/></remarks>
        ///     <param name="str">String</param>
        ///     <param name="substr">Substring</param>
        ///     <returns>true - the substring is included in the string, false - the substring is not included</returns>
        /// </translation>
        static public bool IsEntry(string str, string substr)
        {
            if (IsEmpty(str, false) || IsEmpty(substr, false)) return false;

            #region Items
            int
                lengthStr = str.Length,
                lengthSubstr = substr.Length;

            if (lengthSubstr > lengthStr) return false; lengthStr -= lengthSubstr - 1;

            string currentSubstr = "";
            #endregion Items

            for (int i = 0; i < lengthStr; i++)
            {
                GetSubstring(ref currentSubstr, str, i, lengthSubstr);

                if (currentSubstr == substr) return true;
            }

            return false;
        }
        /// <summary>
        /// Перевірити на входження символа в рядку
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyString/Is-entry.cs"/></remarks>
        /// <param name="str">Рядок</param>
        /// <param name="symbol">Символ</param>
        /// <returns>true - символ входить в рядок, false - символ не входить</returns>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Check for occurrence of a character in a string
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyString/Is-entry.cs"/></remarks>
        ///     <param name="str">String</param>
        ///     <param name="symbol">Symbol</param>
        ///     <returns>true - the character is included in the line, false - the character is not included</returns>
        /// </translation>
        static public bool IsEntry(string str, char symbol)
        {
            return IsEntry(str, symbol.ToString());
        }
        /// <summary>
        /// Перевірити на входження індексу у рядок
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyString/Is-entry.cs"/></remarks>
        /// <param name="str">Рядок</param>
        /// <param name="index">Індекс</param>
        /// <returns>true - індекс входить у рядок, false - індекс не входить у рядок</returns>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Check for occurrence of the index in the string
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyString/Is-entry.cs"/></remarks>
        ///     <param name="str">String</param>
        ///     <param name="index">Index</param>
        ///     <returns>true - the index is included in the string, false - the index is not included in the string</returns>
        /// </translation>
        static public bool IsEntry(string str, int index)
        {
            return index > -1 && index < str.Length;
        }
        /// <summary>
        /// Перевірити на наявність формату в рядку
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyString/Is-entry.cs"/></remarks>
        /// <param name="str">Рядок</param>
        /// <param name="format">Формат</param>
        /// <param name="formatChar">Cимвол формату</param>
        /// <returns>true - формат знайдено в рядку, false - формат не знайдено в рядку</returns>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Check for format in a string
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyString/Is-entry.cs"/></remarks>
        ///     <param name="str">String</param>
        ///     <param name="format">String format</param>
        ///     <param name="formatChar">Symbol format</param>
        ///     <returns>true - the format is found in the string, false - the format is not found in the string</returns>
        /// </translation>
        static public bool IsEntry(string str, string format, char formatChar = SymbolForFormat)
        {
            #region Items
            string formatWitoutFormatChar = format; Remove(ref formatWitoutFormatChar, formatChar);

            if (IsEmpty(formatWitoutFormatChar)) return false;

            char currentChar = default;
            string currentStr = str;
            #endregion Items

            while (formatWitoutFormatChar.Length > 0)
            {
                currentChar = formatWitoutFormatChar[0];

                if (!IsEntry(currentStr, currentChar)) return false;

                Remove(ref currentStr, currentChar, false); Remove(ref formatWitoutFormatChar, 0);
            }

            return true;
        }
        /// <summary>
        /// Перевірити на входження підрядків в рядок
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyString/Is-entry.cs"/></remarks>
        /// <param name="str">Рядок</param>
        /// <param name="listSubstrs">Список підрядків</param>
        /// <param name="austerityEntry">Чи кожне значення зі списку має бути у реченні</param>
        /// <returns>true - підрядок входить в рядок, false - підрядок не входить</returns>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Check for occurrence of substrings in a string
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyString/Is-entry.cs"/></remarks>
        ///     <param name="str">String</param>
        ///     <param name="listSubstrs">List of substrings</param>
        ///     <param name="austerityEntry">Whether every value from the list must be in a sentence</param>
        ///     <returns>true - the substring is included in the string, false - the substring is not included</returns>
        /// </translation>
        static public bool IsEntry(string str, List<string> listSubstrs, bool austerityEntry = false)
        {
            if (MyList.IsEmpty(listSubstrs)) return false;

            int countListSubstrs = listSubstrs.Count;

            MyList.RemoveDuplicates(ref listSubstrs);

            for (int i = 0; i < countListSubstrs; i++)
            {
                if (IsEntry(str, listSubstrs[i]))   { if (!austerityEntry) return true; }
                else                                { if (austerityEntry) return false; }
            }

            return true;
        }
        /// <summary>
        /// Перевірка на порожній рядок
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyString/Is-empty.cs"/></remarks>
        /// <param name="str">Рядок</param>
        /// <param name="whiteSpace">Добавити перевіоку на рядок пробілів</param>
        /// <returns>true - рядок порожній, false - рядок не порожній</returns>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Check for an empty string
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyString/Is-empty.cs"/></remarks>
        ///     <param name="str">String</param>
        ///     <param name="whiteSpace">Add a check for a string of spaces</param>
        ///     <returns>true - the line is empty, false - the line is not empty</returns>
        /// </translation>
        static public bool IsEmpty(string str, bool whiteSpace = true)
        {
            return whiteSpace ? String.IsNullOrWhiteSpace(str) : String.IsNullOrEmpty(str);
        }
        #endregion Checks

        #region Remove
        /// <summary>
        /// Видалити підрядок за вказаними індексами
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyString/Remove.cs"/></remarks>
        /// <param name="str">Поточний рядок</param>
        /// <param name="startIndex">Початковий індекс</param>
        /// <param name="endIndex">Кінцевий індекс</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Remove the substring at the specified indexes
        ///     </summary>
        ///     <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyString/Remove.cs"/></remarks>
        ///     <param name="str">The current string</param>
        ///     <param name="startIndex">Start index</param>
        ///     <param name="endIndex">End index</param>
        /// </translation>
        static public void Remove(ref string str, int startIndex, int endIndex = 0)
        {
            if (IsEmpty(str)) return;

            #region Items
            int lengthStr = str.Length;

            if (!(startIndex > -1)) return;

            if (endIndex == 0) endIndex = startIndex;
            else if (!(endIndex < lengthStr) || startIndex > endIndex) return;

            string newStr = "";
            #endregion Items

            for (int i = 0; i < lengthStr; i++)
            {
                if (i == startIndex)
                {
                    for (i = endIndex + 1; i < lengthStr; i++) newStr += str[i];

                    break;
                }

                newStr += str[i];
            }

            str = newStr;
        }
        /// <summary>
        /// Видалити вказаний підрядок
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyString/Remove.cs"/></remarks>
        /// <param name="str">Поточний рядок</param>
        /// <param name="substr">Підрядок для видалення</param>
        /// <param name="austerity">Видалити всі знайдені підрядки видалення</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Remove the specified substring
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyString/Remove.cs"/></remarks>
        ///     <param name="str">The current string</param>
        ///     <param name="substr">Substring to remove</param>
        ///     <param name="austerity">Delete all deletion substrings found</param>
        /// </translation>
        static public void Remove(ref string str, string substr, bool austerity = true)
        {
            if (IsEmpty(str) || IsEmpty(substr)) return;

            #region Items
            int
                lengthStr = str.Length,
                lengthSubstr = substr.Length;

            if (lengthSubstr > lengthStr) return;

            const int defaultIndex = -1;
            int
                startIndex = defaultIndex,
                endIndex = defaultIndex;
            #endregion Items

            while (true)
            {
                GetSubstringIndices(ref startIndex, ref endIndex, str, substr);

                if (startIndex == defaultIndex || endIndex == defaultIndex) break;

                Remove(ref str, startIndex, endIndex);

                if (!austerity) break;

                startIndex = defaultIndex; endIndex = defaultIndex;
            }
        }
        /// <summary>
        /// Видалити вказаний символ
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyString/Remove.cs"/></remarks>
        /// <param name="str">Поточний рядок</param>
        /// <param name="symbol">Символ для видалення</param>
        /// <param name="austerity">Видалити усі найдені символи видалення</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Remove the specified symbol
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyString/Remove.cs"/></remarks>
        ///     <param name="str">The current string</param>
        ///     <param name="symbol">Symbol to remove</param>
        ///     <param name="austerity">Remove all delete symbols found</param>
        /// </translation>
        static public void Remove(ref string str, char symbol, bool austerity = true) =>
            Remove(ref str, symbol.ToString(), austerity);
        #endregion Remove

        #region Replace
        /// <summary>
        /// Замінити список підрядків в рядку <para>Відповідність між списками значень, для їх заміни - паралельна</para>
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyString/Replace.cs"/></remarks>
        /// <param name="str">Поточний рядок</param>
        /// <param name="listReplaceStr">Список підрядків для заміни</param>
        /// <param name="listNewStr">Список нових підрядків</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Replace the list of substrings in the line <para>Correspondence between lists of values, to replace them - parallel</para>
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyString/Replace.cs"/></remarks>
        ///     <param name="str">The current string</param>
        ///     <param name="listReplaceStr">List of substrings to replace</param>
        ///     <param name="listNewStr">List of new substrings</param>
        /// </translation>
        static public void Replace(ref string str, List<string> listReplaceStr, List<string> listNewStr)
        {
            if (IsEmpty(str, false) || MyList.IsEmpty(listReplaceStr) || MyList.IsEmpty(listNewStr)) return;

            #region Items
            int
                countListReplacestr = listReplaceStr.Count,
                countListNewStr = listNewStr.Count;

            if (countListNewStr != countListReplacestr)
            {
                if (countListNewStr > countListReplacestr || countListNewStr != 1) return;

                Replace(ref str, listReplaceStr, listNewStr[0]); return;
            }

            string newStr = str;
            #endregion Items

            for (int i = 0; i < countListReplacestr; i++) Replace(ref newStr, listReplaceStr[i], listNewStr[i]);

            str = newStr;
        }
        /// <summary>
        /// Замінити список підрядків у рядку
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyString/Replace.cs"/></remarks>
        /// <param name="str">Поточний рядок</param>
        /// <param name="listReplaceActions">Список дій для заміни <para>replaceStr - підрядок, який необхідно замінити. newStr - новий підрядок</para></param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Replace the list of substrings in a string
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyString/Replace.cs"/></remarks>
        ///     <param name="str">The current string</param>
        ///     <param name="listReplaceActions">List of actions to replace <para>replaceStr - the substring to be replaced. newStr - new substring</para></param>
        /// </translation>
        static public void Replace(ref string str, List<(string replaceStr, string newStr)> listReplaceActions)
        {
            if (IsEmpty(str, false) || MyList.IsEmpty(listReplaceActions)) return;

            #region Items
            int countListReplaceActions = listReplaceActions.Count;
            List<string>
                listReplaceStr = new List<string>(),
                listNewStr = new List<string>();
            #endregion Items

            for (int i = 0; i < countListReplaceActions; i++)
            {
                var replaceAction = listReplaceActions[i];

                listNewStr.Add(replaceAction.newStr);
                listReplaceStr.Add(replaceAction.replaceStr);
            }

            Replace(ref str, listReplaceStr, listNewStr);
        }
        /// <summary>
        /// Замінити підрядок в рядку
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyString/Replace.cs"/></remarks>
        /// <param name="str">Поточний рядок</param>
        /// <param name="replaceStr">Підрядок, який необхідно замінити</param>
        /// <param name="newStr">Новий підрядок</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Replace the substring in the string
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyString/Replace.cs"/></remarks>
        ///     <param name="str">The current string</param>
        ///     <param name="replaceStr">The substring to replace</param>
        ///     <param name="newStr">New substring</param>
        /// </translation>
        static public void Replace(ref string str, string replaceStr, string newStr)
        {
            if (IsEmpty(str, false) || IsEmpty(replaceStr) || IsEmpty(newStr)) return;

            #region Items
            int
                lengthStr = str.Length,
                lengthReplaceStr = replaceStr.Length;

            if (lengthReplaceStr > lengthStr) return;

            string
                _newStr = default,
                current = default;
            #endregion Items

            for (int i = 0; i < lengthStr; i++)
            {
                GetSubstring(ref current, str, i, lengthReplaceStr);

                if (current == replaceStr)
                {
                    _newStr += newStr;
                    i += lengthReplaceStr - 1;
                }
                else _newStr += str[i];
            }

            str = _newStr;
        }
        /// <summary>
        /// Замінити список підрядків в рядку
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyString/Replace.cs"/></remarks>
        /// <param name="str">Поточний рядок</param>
        /// <param name="listReplaceStr">Список підрядків для заміни</param>
        /// <param name="newStr">Новий підрядок</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Replace the list of substrings in a string
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyString/Replace.cs"/></remarks>
        ///     <param name="str">The current string</param>
        ///     <param name="listReplaceStr">List of substrings to replace</param>
        ///     <param name="newStr">New substring</param>
        /// </translation>
        static public void Replace(ref string str, List<string> listReplaceStr, string newStr)
        {
            if (IsEmpty(str, false) || MyList.IsEmpty(listReplaceStr) || IsEmpty(newStr)) return;

            #region Items
            int countListReplacestr = listReplaceStr.Count;
            string _newStr = str;
            #endregion Items

            for (int i = 0; i < countListReplacestr; i++) 
                Replace(ref _newStr, listReplaceStr[i], newStr);

            str = _newStr;
        }
        #endregion Replace

        #region Puts
        /// <summary>
        /// Поставити рядок у формат
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyString/Put-format.cs"/></remarks>
        /// <param name="str">Поточний рядок</param>
        /// <param name="format">Формат рядка</param>
        /// <param name="formatChar">Спеціальний символ формату</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Put the string in the format
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyString/Put-format.cs"/></remarks>
        ///     <param name="str">The current line</param>
        ///     <param name="format">String format</param>
        ///     <param name="formatChar">Special format symbol</param>
        /// </translation>
        static public void PutFormat(ref string str, string format, char formatChar = SymbolForFormat)
        {
            if (IsEmpty(str) || IsEmpty(format)) return;

            #region Items
            string newStr = "";

            if (IsEntry(str, format, formatChar)) return;

            int
                indexForStr = 0,
                lengthStr = str.Length,
                lengthFormat = format.Length;
            char currentChar = new char();
            #endregion Items

            for (int i = 0; i < lengthFormat && indexForStr < lengthStr; i++)
            {
                currentChar = format[i];

                if (currentChar == formatChar)
                {
                    newStr += str[indexForStr++];

                    continue;
                }

                newStr += currentChar;
            }

            str = newStr;
        }
        /// <summary>
        /// Забрати формат з рядка
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyString/Put-out-format.cs"/></remarks>
        /// <param name="str">Поточний рядок</param>
        /// <param name="format">Формат рядка</param>
        /// <param name="formatChar">Спеціальний символ формату</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Put out the format from the line
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyString/Put-out-format.cs"/></remarks>
        ///     <param name="str">The current line</param>
        ///     <param name="format">String format</param>
        ///     <param name="formatChar">Special format symbol</param>
        /// </translation>
        static public void PutOutFormat(ref string str, string format, char formatChar = SymbolForFormat)
        {
            if (IsEmpty(str) || IsEmpty(format)) return;

            #region Items
            string newStr = "";

            if (!IsEntry(str, format, formatChar)) return;

            int
                lengthStr = str.Length,
                lengthFormat = format.Length;
            char
                currentCharFormat = default,
                currentCharStr = default;
            #endregion Items

            for (int i = 0; i < lengthStr && i < lengthFormat; i++)
            {
                currentCharStr = str[i];
                currentCharFormat = format[i];

                if (currentCharStr != currentCharFormat && currentCharFormat == formatChar)
                    newStr += currentCharStr;
            }

            str = newStr;
        }
        #endregion Puts

        #region Other
        /// <summary>
        /// Перевернути рядок
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyString/Flip.cs"/></remarks>
        /// <param name="str">Поточний рядок</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Flip the string
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyString/Flip.cs"/></remarks>
        ///     <param name="str">Current the string</param>
        /// </translation>
        static public void Flip(ref string str)
        {
            if (IsEmpty(str)) return;

            #region Items
            int lengthStr = str.Length;
            string newCurrentStr = "";
            #endregion Items

            for (int i = lengthStr - 1; !(i < 0); i--)
                newCurrentStr += str[i];

            str = newCurrentStr;
        }
        #endregion Other
        #endregion Functions
    }
}
