using System;

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
        public delegate void MethodForCatchParse();

        /// <summary>
        /// Перерахування типів 
        /// </summary>
        public enum @typeof
        {
            @other = 0,
            @object = 1,
            @char = 2,
            @string = 3,
            @int = 4,
            @double = 5,
            @float = 6,
            @decimal = 7
        }
        #endregion Items

        #region Functions
        /// <summary>
        /// Отримати максимальне значення
        /// </summary>
        /// <param name="currentValue">Поточне значення</param>
        /// <param name="value1">Значення 1</param>
        /// <param name="value2">Значення 2</param>
        static public void Max(ref int currentValue, int value1, int value2) => currentValue = value1 > value2 ? value1 : value2;

        #region Gets
        /// <summary>
        /// Отримати typeof шаблону
        /// </summary>
        /// <typeparam name="T">Шаблон</typeparam>
        /// <param name="currentTypeof">Поточний typeof</param>
        static public void GetTypeofTemplate<T>(ref @typeof currentTypeof)
        {
            Type typeT = typeof(T);

            if (typeT == typeof(object))
            {
                currentTypeof = @typeof.@object;
                return;
            }
            if (typeT == typeof(char))
            {
                currentTypeof = @typeof.@char;
                return;
            }
            if (typeT == typeof(string))
            {
                currentTypeof = @typeof.@string;
                return;
            }
            if (typeT == typeof(int))
            {
                currentTypeof = @typeof.@int;
                return;
            }
            if (typeT == typeof(double))
            {
                currentTypeof = @typeof.@double;
                return;
            }
            if (typeT == typeof(float))
            {
                currentTypeof = @typeof.@float;
                return;
            }
            if (typeT == typeof(decimal))
            {
                currentTypeof = @typeof.@decimal;
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
            @typeof typeofT = @typeof.other; GetTypeofTemplate<T>(ref typeofT);

            switch (typeofT)
            {
                case @typeof.@char:
                    {
                        char
                            newValue1 = new char(),
                            newValue2 = new char();

                        newValue1 = char.Parse(value1.ToString()); newValue2 = char.Parse(value2.ToString());

                        switch (symbolEquality)
                        {
                            case "==":
                                {
                                    return newValue1 == newValue2;
                                }
                            case "!=":
                                {
                                    return newValue1 != newValue2;
                                }
                            case ">":
                                {
                                    return newValue1 > newValue2;
                                }
                            case "<":
                                {
                                    return newValue1 < newValue2;
                                }
                            case ">=":
                                {
                                    return newValue1 >= newValue2;
                                }
                            case "<=":
                                {
                                    return newValue1 <= newValue2;
                                }
                            default:
                                {
                                    return false;
                                }
                        }
                    }
                case @typeof.@string:
                    {
                        string
                            newValue1 = default,
                            newValue2 = default;

                        try { newValue1 = value1.ToString(); newValue2 = value2.ToString(); }
                        catch { return false; }

                        switch (symbolEquality)
                        {
                            case "==":
                                {
                                    return newValue1 == newValue2;
                                }
                            case "!=":
                                {
                                    return newValue1 != newValue2;
                                }
                            case ">":
                                {
                                    try
                                    {
                                        int
                                            newInt1 = int.Parse(newValue1),
                                            newInt2 = int.Parse(newValue2);

                                        return newInt1 > newInt2;
                                    }
                                    catch
                                    {
                                        try
                                        {
                                            double
                                                newDouble1 = double.Parse(newValue1),
                                                newDouble2 = double.Parse(newValue2);

                                            return newDouble1 > newDouble2;
                                        }
                                        catch
                                        {

                                        }
                                    }

                                    return false;
                                }
                            case "<":
                                {
                                    try
                                    {
                                        int
                                            newInt1 = int.Parse(newValue1),
                                            newInt2 = int.Parse(newValue2);

                                        return newInt1 < newInt2;
                                    }
                                    catch
                                    {
                                        try
                                        {
                                            double
                                                newDouble1 = double.Parse(newValue1),
                                                newDouble2 = double.Parse(newValue2);

                                            return newDouble1 < newDouble2;
                                        }
                                        catch
                                        {

                                        }
                                    }

                                    return false;
                                }
                            case ">=":
                                {
                                    try
                                    {
                                        int
                                            newInt1 = int.Parse(newValue1),
                                            newInt2 = int.Parse(newValue2);

                                        return newInt1 >= newInt2;
                                    }
                                    catch
                                    {
                                        try
                                        {
                                            double
                                                newDouble1 = double.Parse(newValue1),
                                                newDouble2 = double.Parse(newValue2);

                                            return newDouble1 >= newDouble2;
                                        }
                                        catch
                                        {

                                        }
                                    }

                                    return false;
                                }
                            case "<=":
                                {
                                    try
                                    {
                                        int
                                            newInt1 = int.Parse(newValue1),
                                            newInt2 = int.Parse(newValue2);

                                        return newInt1 <= newInt2;
                                    }
                                    catch
                                    {
                                        try
                                        {
                                            double
                                                newDouble1 = double.Parse(newValue1),
                                                newDouble2 = double.Parse(newValue2);

                                            return newDouble1 <= newDouble2;
                                        }
                                        catch
                                        {

                                        }
                                    }

                                    return false;
                                }
                            default:
                                {
                                    return false;
                                }
                        }
                    }
                case @typeof.@int:
                    {
                        int
                            newValue1 = default,
                            newValue2 = default;

                        try { newValue1 = int.Parse(value1.ToString()); newValue2 = int.Parse(value2.ToString()); }
                        catch { return false; }

                        switch (symbolEquality)
                        {
                            case "==":
                                {
                                    return newValue1 == newValue2;
                                }
                            case "!=":
                                {
                                    return newValue1 != newValue2;
                                }
                            case ">":
                                {
                                    return newValue1 > newValue2;
                                }
                            case "<":
                                {
                                    return newValue1 < newValue2;
                                }
                            case ">=":
                                {
                                    return newValue1 == newValue2;
                                }
                            case "<=":
                                {
                                    return newValue1 == newValue2;
                                }
                            default:
                                {
                                    return false;
                                }
                        }
                    }
                case @typeof.@double:
                    {
                        double
                            newValue1 = default,
                            newValue2 = default;

                        try { newValue1 = double.Parse(value1.ToString()); newValue2 = double.Parse(value2.ToString()); }
                        catch { return false; }

                        switch (symbolEquality)
                        {
                            case "==":
                                {
                                    return newValue1 == newValue2;
                                }
                            case "!=":
                                {
                                    return newValue1 != newValue2;
                                }
                            case ">":
                                {
                                    return newValue1 > newValue2;
                                }
                            case "<":
                                {
                                    return newValue1 < newValue2;
                                }
                            case ">=":
                                {
                                    return newValue1 == newValue2;
                                }
                            case "<=":
                                {
                                    return newValue1 == newValue2;
                                }
                            default:
                                {
                                    return false;
                                }
                        }
                    }
                case @typeof.@decimal:
                    {
                        decimal
                            newValue1 = default,
                            newValue2 = default;

                        try { newValue1 = decimal.Parse(value1.ToString()); newValue2 = decimal.Parse(value2.ToString()); }
                        catch { return false; }

                        switch (symbolEquality)
                        {
                            case "==":
                                {
                                    return newValue1 == newValue2;
                                }
                            case "!=":
                                {
                                    return newValue1 != newValue2;
                                }
                            case ">":
                                {
                                    return newValue1 > newValue2;
                                }
                            case "<":
                                {
                                    return newValue1 < newValue2;
                                }
                            case ">=":
                                {
                                    return newValue1 == newValue2;
                                }
                            case "<=":
                                {
                                    return newValue1 == newValue2;
                                }
                            default:
                                {
                                    return false;
                                }
                        }
                    }
                default:
                    {
                        return false;
                    }
            }
        }
        #endregion Checks
        #endregion Functions
    }
}
