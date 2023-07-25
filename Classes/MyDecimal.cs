using System;
using System.Collections.Generic;

namespace MyLibraries.MySystemLib.Classes
{
    /// <summary>
    /// Десяткове число з плаваючою комою
    /// </summary>
    /// <remarks>
    ///     <para>Файл класу: <seealso href="https://github.com/blackByteGT/MyLibraries.MySystemLib.Net/blob/main/Classes/MyDecimal.cs"/></para>
    ///     <para>Приклади застосування: <seealso href="https://github.com/blackByteGT/MyLibraries.MySystemLib.Net/tree/main/Examples/MyDecimal"/></para>
    /// </remarks>
    /// 
    /// <translation xml:lang="en">
    ///     <summary>
    ///     A floating point decimal number
    ///     </summary>
    ///     <remarks>
    ///         <para>File code: <seealso href="https://github.com/blackByteGT/MyLibraries.MySystemLib.Net/blob/main/Classes/MyDecimal.cs"/></para>
    ///         <para>Application examples: <seealso href="https://github.com/blackByteGT/MyLibraries.MySystemLib.Net/tree/main/Examples/MyDecimal"/></para>
    ///     </remarks>
    /// </translation>
    static public class MyDecimal
    {
        #region Items
        /// <summary>
        /// Список розподілювачів за замовчуванням
        /// </summary>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     List of default distributors
        ///     </summary>
        /// </translation> 
        public static readonly List<char> DefaultListSeparators = new List<char>() { '.', ',' };
        #endregion Items

        #region Functions
        #region Check
        /// <summary>
        /// Перевірити точність числа
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyDecimal/Check-precision.cs"/></remarks>
        /// <param name="checkNumber">Число для перевірки</param>
        /// <param name="referenceNumber">Еталонне число</param>
        /// <returns>true - число коректне, false - число некоректне</returns>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Check the precision of the number
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyDecimal/Check-precision.cs"/></remarks>
        ///     <param name="checkNumber">Number to check</param>
        ///     <param name="referenceNumber">Reference number</param>
        ///     <returns>true - the number is correct, false - the number is incorrect</returns>
        /// </translation>
        static public bool CheckPrecision(decimal checkNumber, decimal referenceNumber)
        {
            #region Items
            const int defaultForPrecision = -1;
            int
                precisionReferenceNumber = defaultForPrecision,
                precisionCheckNumber = 0;
            #endregion Items

            GetPrecision(ref precisionReferenceNumber, referenceNumber);

            if (precisionReferenceNumber == defaultForPrecision) return false;

            GetPrecision(ref precisionCheckNumber, checkNumber);

            return precisionCheckNumber != precisionReferenceNumber;
        }
        #endregion Check

        #region Sets
        /// <summary>
        /// Встановити точність
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyDecimal/Set-precision.cs"/></remarks>
        /// <param name="number">Поточне число</param>
        /// <param name="referenceNumber">Еталонне число</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Set precision
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyDecimal/Set-precision.cs"/></remarks>
        ///     <param name="number">The current number</param>
        ///     <param name="referenceNumber">Reference number</param>
        /// </translation>
        static public void SetPrecision(ref decimal number, decimal referenceNumber)
        {
            if (number == default || referenceNumber == default) return;

            #region Items
            int precision = default; GetPrecision(ref precision, referenceNumber);
            #endregion Items

            SetPrecision(ref number, precision);
        }
        /// <summary>
        /// Встановити точність
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyDecimal/Set-precision.cs"/></remarks>
        /// <param name="number">Поточне число</param>
        /// <param name="precision">Точність після коми</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Set precision
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyDecimal/Set-precision.cs"/></remarks>
        ///     <param name="number">The current number</param>
        ///     <param name="precision">Accuracy after the comma</param>
        /// </translation>
        static public void SetPrecision(ref decimal number, int precision)
        {
            if (number == default) return;

            #region Items
            if (!(precision > 0)) TakeFractionalPart(ref number);

            string
                numberToString = number.ToString(),
                newNumericToString = default;                
            char currentSymbol = default;
            int lengthNumericToString = numberToString.Length;
            #endregion Items

            for (int i = 0; i < lengthNumericToString; i++)
            {
                currentSymbol = numberToString[i];

                if (MyList.IsEntry(DefaultListSeparators, currentSymbol))
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
        #endregion Sets

        #region Gets
        #region Get precision
        /// <summary>
        /// Отримати точність числа
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyDecimal/Get-pecision.cs"/></remarks>
        /// <param name="precision">Поточна точність</param>
        /// <param name="numberToString">Число у вигляді рядка</param>
        /// <param name="listSeparators">Список розділювачів. Якщо список порожній береться за замовчуванням - <see cref="DefaultListSeparators"/></param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Get the precision of a number
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyDecimal/Get-pecision.cs"/></remarks>
        ///     <param name="precision">Current precision</param>
        ///     <param name="numberToString">Number as a string</param>
        ///     <param name="listSeparators">List of delimiters. If the list is empty, the default is taken - <see cref="DefaultListSeparators"/></param>
        /// </translation>
        static public void GetPrecision(ref int precision, string numberToString, List<char> listSeparators = default)
        {
            if (String.IsNullOrWhiteSpace(numberToString)) return;

            #region Items
            if (MyList.IsEmpty(listSeparators)) listSeparators = DefaultListSeparators;

            precision = 0;

            int lengthNumberic = numberToString.Length;
            #endregion Items

            for (int i = 0; i < lengthNumberic; i++)
                if (MyList.IsEntry(listSeparators, numberToString[i]))
                {
                    precision = numberToString.Length - 1 - i; return;
                }
        }
        /// <summary>
        /// Отримати точність числа
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyDecimal/Get-pecision.cs"/></remarks>
        /// <param name="precision">Поточна точність</param>
        /// <param name="number">Число</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Get the precision of a number
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyDecimal/Get-pecision.cs"/></remarks>
        /// <param name="precision">Current precision</param>
        /// <param name="number">Number</param>
        /// </translation>
        static public void GetPrecision(ref int precision, decimal number)
        {
            TakeExtraZerosFractionalPart(ref number);

            GetPrecision(ref precision, number.ToString(), DefaultListSeparators);
        }
        #endregion Get precision

        #region Get digit
        /// <summary>
        /// Отримати розрядність числа
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyDecimal/Get-digit.cs"/></remarks>
        /// <param name="digit">Поточна розрядність</param>
        /// <param name="numberToString">Число у вигляді рядка</param>
        /// <param name="listSeparators">Список розділювачів. Якщо список порожній береться за замовчуванням - <seealso cref="DefaultListSeparators"/></param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Get the digit of a number
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyDecimal/Get-digit.cs"/></remarks>
        ///     <param name="digit">Current digit</param>
        ///     <param name="numberToString">Number as a string</param>
        ///     <param name="listSeparators">List of delimiters. If the list is empty, the default is taken - <seealso cref="DefaultListSeparators"/></param>
        /// </translation>
        static public void GetDigit(ref int digit, string numberToString, List<char> listSeparators = default)
        {
            if (String.IsNullOrWhiteSpace(numberToString)) return;

            #region Items
            if (MyList.IsEmpty(listSeparators)) listSeparators = DefaultListSeparators;

            int lenghtNumberToString = numberToString.Length;
            #endregion Items

            try
            {
                for (int i = 0; i < lenghtNumberToString; i++)
                    if (MyList.IsEntry(listSeparators, numberToString[i]))
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
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyDecimal/Get-digit.cs"/></remarks>
        /// <param name="digit">Поточна розрядність</param>
        /// <param name="number">Число</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Get the digit of a number
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyDecimal/Get-digit.cs"/></remarks>
        ///     <param name="digit">Current digit</param>
        ///     <param name="number">Numeric</param>
        /// </translation>
        static public void GetDigit(ref int digit, decimal number) =>
            GetDigit(ref digit, number.ToString());
        #endregion Get digit
        #endregion Gets

        #region Takes
        /// <summary>
        /// Забрати дробову частину десяткового дробу
        /// </summary>
        /// <remarks>: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyDecimal/Take-fractional-part.cs"/></remarks>
        /// <param name="number">Поточне число</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Take the fractional part of the decimal fraction
        ///     </summary>
        ///     <param name="number">The current number</param>
        /// </translation>
        static public void TakeFractionalPart(ref decimal number)
        {
            if (number == default) return;

            #region Items
            string
                numberToString = number.ToString(),
                newNumberToString = default;                
            char currentSymbol = default;
            int lengthNumberToString = numberToString.Length;
            #endregion Items

            for (int i = 0; i < lengthNumberToString; i++)
            {
                currentSymbol = numberToString[i];

                if (MyList.IsEntry(DefaultListSeparators, currentSymbol))
                {
                    number = decimal.Parse(newNumberToString);
                    break;
                }

                newNumberToString += currentSymbol;
            }
        }
        /// <summary>
        /// Забрати зайві нулі з дробової частини числа
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyDecimal/Take-extra-zeros-fractional-part.cs"/></remarks>
        /// <param name="number">Поточне число</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Remove extra zeros from the fractional part of the number
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyDecimal/Take-extra-zeros-fractional-part.cs"/></remarks>
        ///     <param name="number">The current number</param>
        /// </translation>
        static public void TakeExtraZerosFractionalPart(ref decimal number) =>
            number = Convert.ToDecimal(Convert.ToDouble(number));
        #endregion Takes
        #endregion Functions
    }
}
