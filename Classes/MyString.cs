using System.Collections.Generic;

namespace MyLibraries.MySystemLib.Classes
{
    /// <summary>
    /// Рядок
    /// </summary>
    static public class MyString
    {
        #region Items
        /// <summary>
        /// Символи для роботи з форматом рядка
        /// </summary>
        public const string symbolForFormat = "X";

        #region Formats
        /// <summary>
        /// Формат для номера телефона
        /// </summary>
        public const string FormatByTelephoneNumber = "+38-(XXX)-XXX-XX-XX";
        /// <summary>
        /// Формат для номеру банківської карти
        /// </summary>
        public const string FormatByNumberCard = "XXXX-XXXX-XXXX-XXXX";
        #endregion Formats

        #endregion Items

        #region Functions
        #region For database
        /// <summary>
        /// Виправити рядок з БД
        /// </summary>
        /// <param name="str">Поточний рядок</param>
        static public void ToFixStringFromDB(ref string str)
        {
            List<string>
                listReplaceStr = new List<string>()
                {
                        @"\n2", // Двойний перехід на наступний рядок
                        @"\n",  // Перехід на наступний рядок
                        @"\t2"  // Двойний пробіл
                },
                listNewValue = new List<string>()
                {
                        "\n\n",
                        "\n",
                        "  "
                };

            Replace(ref str, listReplaceStr, listNewValue);
        }
        #endregion For database

        #region Sets
        /// <summary>
        /// Встановити довжину рядка
        /// </summary>
        /// <param name="str">Поточний рядок</param>
        /// <param name="length">Вказана довжина</param>
        static public void SetLength(ref string str, int length)
        {
            string newStr = "";

            int lengthStr = str.Length;
            for (int i = 0; i < length && i < lengthStr; i++) newStr += str[i];

            int difference = length - lengthStr;
            if (difference > 0) for (int i = 0; i < difference; i++) newStr += ' ';

            str = newStr;
        }
        #endregion Sets

        #region Gets
        /// <summary>
        /// Отримати рядок з відповідним форматом.
        /// X/x - поточний спеціальний символ формату
        /// Наприклад: str = "0985050836", format = "+38-(XXX)-XXX-XX-XX", length = 0 => +38-(098)-505-08-36
        /// </summary>
        /// <param name="str">Рядок без формату</param>
        /// <param name="format">Формат до якого потрібно привести str. Приклад наведено в описі</param>
        /// <param name="formatChar">Спеціальний символ формату</param>
        /// <param name="length">Довжина рядка. Якщо 0 - довжина не зміниться</param>
        static public void GetWithFormat(ref string str, int length = 0, string format = null, string formatChar = null)
        {
            int lengthStr = str.Length;
            string newStr = "";

            if (length > 0) SetLength(ref str, length);

            if (format != null)
            {
                string currentFormatChar = formatChar == null ? symbolForFormat : formatChar;

                if (CheckForFormatInString(str, format, currentFormatChar)) return;

                char currentChar = new char();
                int indexForStr = 0;
                int lengthFormat = format.Length;

                for (int i = 0; i < lengthFormat; i++)
                {
                    currentChar = format[i];

                    if (indexForStr < lengthStr && CheckSubstringInString(currentFormatChar, currentChar.ToString()))
                    {
                        newStr += str[indexForStr++];

                        continue;
                    }

                    newStr += currentChar;
                }

                str = newStr;
            }
        }
        /// <summary>
        /// Отримати рядок без формату.
        /// X/x - поточний спеціальний символ формату
        /// Наприклад: str = "+38-(098)-505-08-36", format = "+38-(XXX)-XXX-XX-XX", length = 0 => 0985050836
        /// </summary>
        /// <param name="str">Рядок без формату</param>
        /// <param name="format">Формат до якого потрібно привести str. Приклад наведено в описі</param>
        /// <param name="formatChar">Спеціальний символ формату</param>
        /// <param name="length">Довжина рядка. Якщо 0 - довжина не зміниться</param>
        static public void GetWithoutFormat(ref string str, int length = 0, string format = null, string formatChar = null)
        {
            string newStr = "";

            if (length > 0) SetLength(ref str, length);

            if (format != null)
            {
                string currentFormatChar = formatChar == null ? symbolForFormat : formatChar;

                if (!CheckForFormatInString(str, format, currentFormatChar)) return;

                int
                    lengthStr = str.Length,
                    lengthFormat = format.Length;
                string
                    currentCharStr = "",
                    currentCharFormat = "";

                for (int i = 0; i < lengthStr && i < lengthFormat; i++)
                {
                    currentCharStr = str[i].ToString();
                    currentCharFormat = format[i].ToString();

                    if (currentCharStr != currentCharFormat && CheckSubstringInString(currentFormatChar, currentCharFormat))
                        newStr += currentCharStr;
                }
            }

            str = newStr;
        }
        /// <summary>
        /// Отримати підрядок з рядка
        /// </summary>
        /// <param name="substr">Поточний підрядок</param>
        /// <param name="str">Поточний рядок</param>
        /// <param name="index">Початковий індекс</param>
        /// <param name="lenght">Довжина підстроки</param>
        static public void GetSubstring(ref string substr, string str, int index = 0, int lenght = 0)
        {
            int lengthStr = str.Length;

            if (index < 0 || index > lengthStr - 1) return;

            lenght = lenght == 0 ? lengthStr : lenght;

            string newSubstr = "";
            int lengthFromIndex = index + lenght;

            for (int i = index; i < lengthFromIndex && i < lengthStr; i++) newSubstr += str[i];

            substr = newSubstr;
        }
        /// <summary>
        /// Отримати підрядки з рядка
        /// </summary>
        /// <param name="substrs">Поточний список підрядків</param>
        /// <param name="str">Поточний рядок</param>
        /// <param name="strDividers">Рядок розділювачів</param>
        static public void GetSubstrings(ref List<string> substrs, string str, List<string> strDividers)
        {
            int
                lengthStr = str.Length,
                countStrDividers = strDividers.Count;

            if (lengthStr == 0 || countStrDividers == 0) return;

            string currentStr = "", currentDivider = "";
            int currentIndex = 0, currentLength = 0;
            List<string> newSubstrs = new List<string>();

            for (int i = 0; i < countStrDividers; i++)
                for (int j = 0; j < lengthStr; j++)
                {
                    currentDivider = strDividers[i];
                    currentLength = currentDivider.Length;
                    if (currentLength == 0) break;

                    GetSubstring(ref currentStr, str, j, currentLength);

                    if (currentStr == currentDivider)
                    {
                        GetSubstring(ref currentStr, str, currentIndex, j - currentIndex);
                        newSubstrs.Add(currentStr);

                        currentIndex = j + 1;
                    }
                }

            substrs = newSubstrs;
        }
        /// <summary>
        /// Отримати підрядок з рядка
        /// </summary>
        /// <param name="substr">Поточний підрядок</param>
        /// <param name="str">Поточний рядок</param>
        /// <param name="primaryStr">Початковий підрядок</param>
        /// <param name="finalStr">Кінцевий підрядок</param>
        /// <param name="austerityPrimaryStr"></param>
        /// <param name="austerityFinalStr"></param>
        static public void GetSubstring(
            ref string substr, string str, string primaryStr, string finalStr, bool austerityPrimaryStr = false, bool austerityFinalStr = false
        )
        {
            int
                 lengthStr = str.Length,
                 lengthPrimaryStr = primaryStr.Length,
                 lengthFinalStr = finalStr.Length;
            bool
                checkStr = lengthStr == 0,
                checkPrimaryStr = lengthPrimaryStr == 0,
                checkFinalStr = lengthFinalStr == 0;

            if (checkStr || checkPrimaryStr || checkFinalStr) return;

            string
                newSubstr = "",
                currentStr = "";

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
        /// Отримати розвернутий рядок
        /// </summary>
        /// <param name="newStr">Новий рядок</param>
        /// <param name="str">Поточний рядок</param>
        static public void GetDeployed(ref string newStr, string str)
        {
            int lengthStr = str.Length;
            if (lengthStr == 0) return;

            string newCurrentStr = "";

            for (int i = lengthStr - 1; !(i < 0); i--) newCurrentStr += str[i];

            newStr = newCurrentStr;
        }
        /// <summary>
        /// Отримати індекси підрядка в рядку
        /// </summary>
        /// <param name="str">Рядок</param>
        /// <param name="substr">Підрядок</param>
        /// <param name="firstIndex">Перший індекс</param>
        /// <param name="lastIndex">Останній індекс</param>
        static public void GetSubstringIndices(string str, string substr, ref int firstIndex, ref int lastIndex)
        {
            int
                lengthStr = str.Length,
                lengthSubstr = substr.Length;

            if (lengthStr == 0 || lengthSubstr == 0 || lengthSubstr > lengthStr) return;

            string currentStr = "";

            for (int i = 0; i < lengthStr; i++)
            {
                GetSubstring(ref currentStr, str, i, lengthSubstr);
                if (currentStr == substr)
                {
                    firstIndex = i;
                    lastIndex = i + lengthSubstr - 1;

                    return;
                }
            }
        }
        /// <summary>
        /// Отримати максимальну довжину значення з списка значень
        /// </summary>
        /// <param name="listValue">Список значень</param>
        /// <param name="maxLength">Поточна максимальна довжина</param>
        static public void GetMaximumLengthFromList(List<string> listValue, ref int maxLength)
        {
            int countListValue = listValue.Count;
            if (countListValue == 0) return;

            int newMaxLength = 0, currentLength = 0;

            for (int i = 0; i < countListValue; i++)
            {
                currentLength = listValue[i].Length;
                if (currentLength > newMaxLength) newMaxLength = currentLength;
            }

            maxLength = newMaxLength;
        }
        #endregion Gets

        #region Checks
        /// <summary>
        /// Перевірити на наявність підрядка в рядку
        /// </summary>
        /// <param name="str">Поточний рядок</param>
        /// <param name="substr">Поточний підрядок</param>
        /// <returns>true - підрядок входить в рядок,false - не входить</returns>
        static public bool CheckSubstringInString(string str, string substr)
        {
            int lengthStr = str.Length;
            int lengthSubstr = substr.Length;

            if (lengthSubstr > lengthStr) return false;

            string currentSubstr = "";

            lengthStr -= lengthSubstr - 1;
            for (int i = 0; i < lengthStr; i++)
            {
                GetSubstring(ref currentSubstr, str, i, lengthSubstr);

                if (currentSubstr == substr) return true;
            }

            return false;
        }
        /// <summary>
        /// Перевірити на наявність формату в рядку
        /// </summary>
        /// <param name="str">Рядок</param>
        /// <param name="format">Формат</param>
        /// <param name="formatChar">Спеціальний символ формату</param>
        /// <returns>true - якщо формат знайдено в рядку, false - якщо формат не знайдено в рядку</returns>
        static public bool CheckForFormatInString(string str, string format, string formatChar)
        {
            string formatWitoutFormatChar = format; Remove(ref formatWitoutFormatChar, formatChar);
            if (formatWitoutFormatChar.Length == 0) return false;

            string currentStr = str, currentChar = "";

            while (formatWitoutFormatChar.Length > 0)
            {
                currentChar = formatWitoutFormatChar[0].ToString();

                if (!CheckSubstringInString(currentStr, currentChar))
                    return false;

                Remove(ref currentStr, currentChar, false);
                Remove(ref formatWitoutFormatChar, 0);
            }

            return true;
        }
        /// <summary>
        /// Перевірити на недозволені підрядки в рядку
        /// </summary>
        /// <param name="str">Поточний рядок</param>
        /// <param name="allowedSubstrs">Список дозволених підрядків</param>
        /// <returns>true - недозволений рядок знайдено, false - недозволений рядок не знайдено</returns>
        static public bool CheckForIllegalSubstringInString(string str, List<string> allowedSubstrs)
        {
            #region Items
            int countAllowedSubstrs = allowedSubstrs.Count; if (countAllowedSubstrs == 0) return false;
            string currentStr = "";
            int
                lengthStr = str.Length,
                currentLengthSubstr = 0;
            #endregion Items

            for (int i = 0; i < countAllowedSubstrs; i++)
            {
                currentLengthSubstr = allowedSubstrs[i].Length;

                for (int j = 0; j < lengthStr; j += currentLengthSubstr)
                {
                    GetSubstring(ref currentStr, str, j, currentLengthSubstr);

                    if (!MyList.CheckValueForEntryInList(currentStr, allowedSubstrs)) return true;
                }
            }

            return false;
        }
        #endregion Checks

        #region Remove
        /// <summary>
        /// Видалити підрядок(-и) за вказаним індексом. Видалення з primaryIndex по finalIndex
        /// </summary>
        /// <param name="str">Поточний рядок</param>
        /// <param name="primaryIndex">Початковий індекс</param>
        /// <param name="finalIndex">Кінцевий індекс. Якщо 0 finalIndex = primaryIndex</param>
        static public void Remove(ref string str, int primaryIndex, int finalIndex = 0)
        {
            #region Items
            int lengthStr = str.Length;

            if (finalIndex == 0) finalIndex = primaryIndex;
            if (!(primaryIndex > -1) || !(finalIndex < lengthStr) || primaryIndex > finalIndex) return;

            string newStr = "";
            #endregion Items

            for (int i = 0; i < lengthStr; i++)
            {
                if (i == primaryIndex)
                {
                    for (i = finalIndex + 1; i < lengthStr; i++) newStr += str[i];

                    break;
                }

                newStr += str[i];
            }

            str = newStr;
        }
        /// <summary>
        /// Видалити вказаний підрядок
        /// </summary>
        /// <param name="str">Поточний рядок</param>
        /// <param name="substr">Підрядок для видалення</param>
        /// <param name="austerity">true - видаляти усі найдені підрядки, false - видаляти перший підрядок</param>
        static public void Remove(ref string str, string substr, bool austerity = true)
        {
            int
                lengthStr = str.Length,
                lengthSubstr = substr.Length;

            if (lengthSubstr > lengthStr || lengthStr == 0 || lengthSubstr == 0) return;

            int
                primaryIndex = -1,
                finalIndex = -1;

            while (true)
            {
                GetSubstringIndices(str, substr, ref primaryIndex, ref finalIndex);
                if (primaryIndex == -1 || finalIndex == -1) break;

                Remove(ref str, primaryIndex, finalIndex);

                if (!austerity) break;

                primaryIndex = -1; finalIndex = -1;
            }
        }
        #endregion Remove

        #region Replace
        /// <summary>
        /// Замінити список підрядків в рядку. Відповідність між списками значень для заміни та нових значьнь - паралельні
        /// </summary>
        /// <param name="currentStr">Поточний рядок</param>
        /// <param name="listReplaceStr">Список підрядків для заміни</param>
        /// <param name="listNewStr">Список нових підрядків</param>
        static public void Replace(ref string currentStr, List<string> listReplaceStr, List<string> listNewStr)
        {
            int
                lengthCurrentStr = currentStr.Length,
                countListReplacestr = listReplaceStr.Count,
                countListNewStr = listNewStr.Count;

            if (lengthCurrentStr == 0 || countListReplacestr == 0 || countListNewStr != countListReplacestr) return;

            string newStr = currentStr;

            for (int i = 0; i < countListReplacestr; i++) Replace(ref newStr, listReplaceStr[i], listNewStr[i]);

            currentStr = newStr;
        }
        /// <summary>
        /// Замінити список підрядків у рядку
        /// </summary>
        /// <param name="currentStr">Поточний рядок</param>
        /// <param name="listReplaceActions">Список дій для заміни. replaceStr - підрядок, який необхідно замінити, newValue - новий підрядок</param>
        static public void Replace(ref string currentStr, List<(string replaceStr, string newValue)> listReplaceActions)
        {
            #region Items
            int
                lengthCurrentStr = currentStr.Length,
                countListReplaceActions = listReplaceActions.Count;

            if (lengthCurrentStr == 0 || countListReplaceActions == 0) return;

            string newStr = currentStr;
            var replaceAction = listReplaceActions[0];
            #endregion Items

            for (int i = 0; i < countListReplaceActions; i++)
            {
                replaceAction = listReplaceActions[0];

                Replace(ref newStr, replaceAction.replaceStr, replaceAction.newValue);
            }
        }
        /// <summary>
        /// Замінити підрядок в рядку
        /// </summary>
        /// <param name="currentStr">Поточний рядок</param>
        /// <param name="replaceStr">Підрядок, який необхідно замінити</param>
        /// <param name="newValue">Новий підрядок</param>
        static public void Replace(ref string currentStr, string replaceStr, string newValue)
        {
            #region Items
            int
                lengthCurrentStr = currentStr.Length,
                lengthReplaceStr = replaceStr.Length;

            if (lengthCurrentStr == 0 || lengthReplaceStr == 0 || lengthReplaceStr > lengthCurrentStr) return;

            string
                newStr = "",
                current = "";
            #endregion Items

            for (int i = 0; i < lengthCurrentStr; i++)
            {
                GetSubstring(ref current, currentStr, i, lengthReplaceStr);

                if (current == replaceStr)
                {
                    newStr += newValue;
                    i += lengthReplaceStr - 1;
                }
                else newStr += currentStr[i];
            }

            currentStr = newStr;
        }
        /// <summary>
        /// Замінити список підрядків в рядку
        /// </summary>
        /// <param name="currentStr">Поточний рядок</param>
        /// <param name="listReplaceStr">Список підрядків для заміни</param>
        /// <param name="newValue">Новий підрядок</param>
        static public void Replace(ref string currentStr, List<string> listReplaceStr, string newValue)
        {
            #region Items
            int
                lengthCurrentStr = currentStr.Length,
                countListReplacestr = listReplaceStr.Count;

            if (lengthCurrentStr == 0 || countListReplacestr == 0) return;

            string newStr = currentStr;
            #endregion Items

            for (int i = 0; i < countListReplacestr; i++) Replace(ref newStr, listReplaceStr[i], newValue);

            currentStr = newStr;
        }
        #endregion Replace
        #endregion Functions
    }
}
