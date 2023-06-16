using System;
using MyLibraries.MySystemLib.Enums;

namespace MyLibraries.MySystemLib.Classes
{
    /// <summary>
    /// Математичні функції
    /// </summary>
    static public class MyMath
    {
        #region Items
        /// <summary>
        /// Метод який буде виконуватися при виключенні парсингу типу
        /// </summary>
        private delegate void MethodForCatchParse();
        #endregion Items

        #region Functions
        #region Gets
        /// <summary>
        /// Отримати typeof шаблону
        /// </summary>
        /// <typeparam name="T">Шаблон</typeparam>
        /// <param name="currentTypeof">Поточний typeof</param>
        static private void GetTypeofTemplate<T>(ref MyTypeof currentTypeof)
        {
            Type typeT = typeof(T);

            if (typeT == typeof(object))
            {
                currentTypeof = MyTypeof.@object;
                return;
            }
            if (typeT == typeof(char))
            {
                currentTypeof = MyTypeof.@char;
                return;
            }
            if (typeT == typeof(string))
            {
                currentTypeof = MyTypeof.@string;
                return;
            }
            if (typeT == typeof(int))
            {
                currentTypeof = MyTypeof.@int;
                return;
            }
            if (typeT == typeof(double))
            {
                currentTypeof = MyTypeof.@double;
                return;
            }
            if (typeT == typeof(float))
            {
                currentTypeof = MyTypeof.@float;
                return;
            }
            if (typeT == typeof(decimal))
            {
                currentTypeof = MyTypeof.@decimal;
                return;
            }
        }
        #endregion Gets

        #region Checks
        /// <summary>
        /// Перевірити на рівність шаблонні значення
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value1">Значення 1</param>
        /// <param name="value2">Значення 2</param>
        /// <param name="symbolEquality">Символ рівності</param>
        /// <returns></returns>
        static public bool CheckForEquality<T>(T value1, T value2, string symbolEquality = "==")
        {
            MyTypeof typeofT = MyTypeof.other; GetTypeofTemplate<T>(ref typeofT);

            switch (typeofT)
            {
                case MyTypeof.@char:
                    {
                        #region Items
                        char
                            newValue1 = new char(),
                            newValue2 = new char();
                        #endregion Items

                        newValue1 = char.Parse(value1.ToString()); newValue2 = char.Parse(value2.ToString());

                        switch (symbolEquality)
                        {
                            case "==": { return newValue1 == newValue2; }
                            case "!=": { return newValue1 != newValue2; }
                            case ">": { return newValue1 > newValue2; }
                            case "<": { return newValue1 < newValue2; }
                            case ">=": { return newValue1 >= newValue2; }
                            case "<=": { return newValue1 <= newValue2; }
                            default: { return false; }
                        }
                    }
                case MyTypeof.@string:
                    {
                        #region Items
                        string
                            newValue1 = default,
                            newValue2 = default;
                        #endregion Items

                        try { newValue1 = value1.ToString(); newValue2 = value2.ToString(); }
                        catch { return false; }

                        switch (symbolEquality)
                        {
                            case "==": { return newValue1 == newValue2; }
                            case "!=": { return newValue1 != newValue2; }
                            case ">":
                                {
                                    try {  return int.Parse(newValue1) > int.Parse(newValue2); }
                                    catch
                                    {
                                        try { return double.Parse(newValue1) > double.Parse(newValue2); }
                                        catch { return false; }
                                    }
                                }
                            case "<":
                                {
                                    try { return int.Parse(newValue1) < int.Parse(newValue2); }
                                    catch
                                    {
                                        try { return double.Parse(newValue1) < double.Parse(newValue2); }
                                        catch { return false; }
                                    }
                                }
                            case ">=":
                                {
                                    try { return int.Parse(newValue1) >= int.Parse(newValue2); }
                                    catch
                                    {
                                        try { return double.Parse(newValue1) >= double.Parse(newValue2); }
                                        catch { return false; }
                                    }
                                }
                            case "<=":
                                {
                                    try { return int.Parse(newValue1) <= int.Parse(newValue2); }
                                    catch
                                    {
                                        try { return double.Parse(newValue1) <= double.Parse(newValue2); }
                                        catch { return false; }
                                    }
                                }
                            default: { return false; }
                        }
                    }
                case MyTypeof.@int:
                    {
                        #region Items
                        int
                            newValue1 = default,
                            newValue2 = default;
                        #endregion Items

                        try { newValue1 = int.Parse(value1.ToString()); newValue2 = int.Parse(value2.ToString()); }
                        catch { return false; }

                        switch (symbolEquality)
                        {
                            case "==": { return newValue1 == newValue2; }
                            case "!=": { return newValue1 != newValue2; }
                            case ">": { return newValue1 > newValue2; }
                            case "<": { return newValue1 < newValue2; }
                            case ">=": { return newValue1 == newValue2; }
                            case "<=": { return newValue1 == newValue2; }
                            default: { return false; }
                        }
                    }
                case MyTypeof.@double:
                    {
                        #region Items
                        double
                            newValue1 = default,
                            newValue2 = default;
                        #endregion Items

                        try { newValue1 = double.Parse(value1.ToString()); newValue2 = double.Parse(value2.ToString()); }
                        catch { return false; }

                        switch (symbolEquality)
                        {
                            case "==": { return newValue1 == newValue2; }
                            case "!=": { return newValue1 != newValue2; }
                            case ">": { return newValue1 > newValue2; }
                            case "<": { return newValue1 < newValue2; }
                            case ">=": { return newValue1 == newValue2; }
                            case "<=": { return newValue1 == newValue2; }
                            default: { return false; }
                        }
                    }
                case MyTypeof.@decimal:
                    {
                        #region Items
                        decimal
                            newValue1 = default,
                            newValue2 = default;
                        #endregion Items

                        try { newValue1 = decimal.Parse(value1.ToString()); newValue2 = decimal.Parse(value2.ToString()); }
                        catch { return false; }

                        switch (symbolEquality)
                        {
                            case "==": { return newValue1 == newValue2; }
                            case "!=": { return newValue1 != newValue2; }
                            case ">": { return newValue1 > newValue2; }
                            case "<": { return newValue1 < newValue2; }
                            case ">=": { return newValue1 == newValue2; }
                            case "<=": { return newValue1 == newValue2; }
                            default: { return false; }
                        }
                    }
                default: { return false; }
            }
        }
        #endregion Checks
        #endregion Functions
    }
}
