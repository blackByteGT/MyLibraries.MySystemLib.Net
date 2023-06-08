using System;
using System.Collections.Generic;
using System.Globalization;

namespace MyLibraries.MySystemLib.Classes
{
    /// <summary>
    /// Десяткове число з плаваючою комою
    /// </summary>
    static public class MyDecimal
    {
        #region Items
        /// <summary>
        /// Список розподілювачів за замовчуванням
        /// </summary>
        public static readonly List<string> DefaultListSeparators = new List<string>() { ".", "," };
        #endregion Items

        #region Functions
        #region Parse
        /// <summary>
        /// Перетворити текст на число
        /// </summary>
        /// <param name="number">Поточне число</param>
        /// <param name="numberToString">Текст</param>
        /// <returns>true - вдалося перетворити, false - не вдалося перетворити</returns>
        public static bool Parse(ref decimal number, string numberToString)
        {
            if (numberToString.Length == 0) return false;

            try
            {
                number = decimal.Parse(numberToString, new NumberFormatInfo() { NumberDecimalSeparator = "," });
            }
            catch
            {
                try
                {
                    number = decimal.Parse(numberToString, new NumberFormatInfo() { NumberDecimalSeparator = "." });
                }
                catch
                {
                    return false;
                }
            }

            return true;
        }
        #endregion Parse

        #region Check
        /// <summary>
        /// Перевірити чи можливе перетворення тексту на число
        /// </summary>
        /// <param name="decimalToString">Текст</param>
        /// <returns>true - вдалося перетворити, false - не вдалося перетворити</returns>
        public static bool CheckParse(string decimalToString)
        {
            decimal currentDecimal = default;

            return Parse(ref currentDecimal, decimalToString);
        }
        /// <summary>
        /// Перевірити точність числа
        /// </summary>
        /// <param name="checkNumber">Число для перевірки</param>
        /// <param name="referenceNumber">Еталонне число</param>
        /// <returns>true - число коректне, false - число не коректне</returns>
        static public bool CheckPrecision(decimal checkNumber, decimal referenceNumber)
        {
            #region Items
            const int defaultForPrecision = -1;
            List<string> listSeparators = new List<string>() { ".", "," };
            int
                precisionReferenceNumber = defaultForPrecision,
                precisionCheckNumber = 0;
            #endregion Items

            GetPrecision(ref precisionReferenceNumber, referenceNumber, listSeparators);
            if (precisionReferenceNumber == defaultForPrecision) return false;

            GetPrecision(ref precisionCheckNumber, checkNumber, listSeparators);
            return !(precisionCheckNumber > precisionReferenceNumber);
        }
        #endregion Check

        #region Sets
        /// <summary>
        /// Встановити точність
        /// </summary>
        /// <param name="number">Поточне число</param>
        /// <param name="referenceNumber">Еталонне число</param>
        static public void SetPrecision(ref decimal number, decimal referenceNumber)
        {
            if (number == default || referenceNumber == default) return;

            #region Items
            List<string> listSeparators = new List<string>() { ".", "," };
            int precision = -1;

            GetPrecision(ref precision, referenceNumber, listSeparators);
            #endregion Items

            if (precision != -1)
                SetPrecision(ref number, precision, listSeparators);
            else
                TakeFractionalPart(ref number, listSeparators);
        }
        /// <summary>
        /// Встановити точність
        /// </summary>
        /// <param name="number">Поточне число</param>
        /// <param name="precision">Точність після коми</param>
        /// <param name="listSeparators">Список розділювачів</param>
        static public void SetPrecision(ref decimal number, int precision, List<string> listSeparators)
        {
            if (number == default || !(precision > 0)) return;

            #region Items
            string
                numberToString = number.ToString(),
                newNumericToString = default,
                currentSymbol = default;
            int lengthNumericToString = numberToString.Length;
            #endregion Items

            for (int i = 0; i < lengthNumericToString; i++)
            {
                currentSymbol = numberToString[i].ToString();

                if (MyList.CheckValueForEntryInList(currentSymbol, listSeparators))
                {
                    int length = precision + 1;

                    if (length < lengthNumericToString - i)
                    {
                        newNumericToString += numberToString.Substring(i, length);
                        number = decimal.Parse(newNumericToString);
                    }

                    return;
                }

                newNumericToString += currentSymbol;
            }
        }
        /// <summary>
        /// Встановити точність
        /// </summary>
        /// <param name="number">Поточне число</param>
        /// <param name="precision">Точність після коми</param>
        static public void SetPrecision(ref decimal number, int precision) =>
            SetPrecision(ref number, precision, DefaultListSeparators);
        #endregion Sets

        #region Gets
        #region Get precision
        /// <summary>
        /// Отримати точність числа
        /// </summary>
        /// <param name="precision">Поточна точність</param>
        /// <param name="numberToString">Число у вигляді рядка</param>
        /// <param name="listSeparators">Список розділювачів</param>
        static public void GetPrecision(ref int precision, string numberToString, List<string> listSeparators)
        {
            int lengthNumberic = numberToString.Length;

            for (int i = 0; i < lengthNumberic; i++)
                if (MyList.CheckValueForEntryInList(numberToString[i].ToString(), listSeparators))
                {
                    precision = numberToString.Length - 1 - i; return;
                }
        }
        /// <summary>
        /// Отримати точність числа
        /// </summary>
        /// <param name="precision">Поточна точність</param>
        /// <param name="number">Число у вигляді рядка</param>
        /// <param name="listSeparators">Список розділювачів</param>
        static public void GetPrecision(ref int precision, decimal number, List<string> listSeparators)
        {
            TakeExtraZerosFractionalPart(ref number);

            GetPrecision(ref precision, number.ToString(), listSeparators);
        }
        /// <summary>
        /// Отримати точність числа
        /// </summary>
        /// <param name="precision">Поточна точність</param>
        /// <param name="number">Число у вигляді рядка</param>
        static public void GetPrecision(ref int precision, decimal number) =>
            GetPrecision(ref precision, number, DefaultListSeparators);
        #endregion Get precision

        #region Get digit
        /// <summary>
        /// Отримати розрядність числа
        /// </summary>
        /// <param name="digit">Поточна розрядність</param>
        /// <param name="numberToString">Число у вигляді рядка</param>
        /// <param name="listSeparators">Список розділювачів</param>
        static public void GetDigit(ref int digit, string numberToString, List<string> listSeparators)
        {
            int lenghtNumberToString = numberToString.Length;

            try
            {
                if (!(lenghtNumberToString > 0)) throw new Exception();

                for (int i = 0; i < lenghtNumberToString; i++)
                    if (MyList.CheckValueForEntryInList(numberToString[i].ToString(), listSeparators))
                    {
                        digit = i; return;
                    }

                throw new Exception();
            }
            catch { digit = lenghtNumberToString; }
        }
        /// <summary>
        /// Отримати розрядність числа
        /// </summary>
        /// <param name="digit">Поточна розрядність</param>
        /// <param name="number">Число</param>
        /// <param name="listSeparators">Список розділювачів</param>
        static public void GetDigit(ref int digit, decimal number, List<string> listSeparators) =>
            GetDigit(ref digit, number.ToString(), listSeparators);
        /// <summary>
        /// Отримати розрядність числа
        /// </summary>
        /// <param name="digit">Поточна розрядність</param>
        /// <param name="number">Число</param>
        static public void GetDigit(ref int digit, decimal number) =>
            GetDigit(ref digit, number, DefaultListSeparators);
        #endregion Get digit
        #endregion Gets

        #region Takes
        /// <summary>
        /// Забрати дробову частину
        /// </summary>
        /// <param name="number">Поточне число</param>
        /// <param name="listSeparators">Список розділювачів</param>
        static public void TakeFractionalPart(ref decimal number, List<string> listSeparators)
        {
            if (number == default) return;

            string
                numberToString = number.ToString(),
                newNumberToString = default,
                currentSymbol = default;
            int lengthNumberToString = numberToString.Length;

            for (int i = 0; i < lengthNumberToString; i++)
            {
                currentSymbol = numberToString[i].ToString();

                if (MyList.CheckValueForEntryInList(currentSymbol, listSeparators))
                {
                    number = decimal.Parse(newNumberToString);
                    break;
                }

                newNumberToString += currentSymbol;
            }
        }
        /// <summary>
        /// Забрати дробову частину. Як список розподілювачів буде використано MyDecimal.DefaultListSeparators
        /// </summary>
        /// <param name="number">Поточне число</param>
        static public void TakeFractionalPart(ref decimal number) =>
            TakeFractionalPart(ref number, DefaultListSeparators);
        /// <summary>
        /// Забрати зайві нулі з дробової частини числа
        /// </summary>
        /// <param name="number">Поточне число</param>
        static public void TakeExtraZerosFractionalPart(ref decimal number) =>
            number = Convert.ToDecimal(Convert.ToDouble(number));
        #endregion Takes
        #endregion Functions
    }
}
