using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLibraries.MySystemLib.Classes
{
    /// <summary>
    /// Список
    /// </summary>
    static public class MyList
    {
        #region Add
        /// <summary>
        /// Добавити значення в List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">Поточний List</param>
        /// <param name="newValue">Нове значення</param>
        /// <param name="index">Індекс нового значення. Якщо менше за 0 або більше за кількість значень в списку - добавляється в кінець</param>
        static public void Add<T>(ref List<T> list, T newValue, int index = 0)
        {
            List<T> newList = new List<T>();
            int countList = list.Count;

            if (index < 0 || index > countList - 1)
            {
                newList = list;
                newList.Add(newValue);
            }
            else
            {
                for (int i = 0; i < countList; i++)
                {
                    if (i == index) newList.Add(newValue);
                    newList.Add(list[i]);
                }
            }

            list = newList;
        }
        /// <summary>
        /// Добавити в список значення з іншого списку
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="currentList">Поточний список</param>
        /// <param name="addList">Додатковий список</param>
        /// <param name="index">Індекс додавання</param>
        static public void Add<T>(ref List<T> currentList, List<T> addList, int index = 0)
        {
            int countAddList = addList.Count;
            if (countAddList == 0) return;

            List<T> newList = currentList;

            for (int i = 0; i < countAddList; i++) Add(ref newList, addList[i], index);

            currentList = newList;
        }
        /// <summary>
        /// Добавити список списків в список
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="currentList">Поточний список</param>
        /// <param name="addArrayList">Список списків</param>
        /// <param name="index">Індекс додавання</param>
        static public void Add<T>(ref List<T> currentList, List<List<T>> addArrayList, int index = 0)
        {
            int countAddArrayList = addArrayList.Count;
            if (countAddArrayList == 0) return;

            List<T> newList = currentList;

            for (int i = 0; i < countAddArrayList; i++) Add(ref newList, addArrayList[i], index);

            currentList = newList;
        }
        #endregion Add

        #region Replace
        /// <summary>
        /// Замінити значення в списку за індексом
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">Поточний список</param>
        /// <param name="newValue">Нове значення</param>
        /// <param name="index">Індекс значення. Якщо значення за велике - дія не виконується</param>
        static public void Replace<T>(ref List<T> list, T newValue, int index)
        {
            int countList = list.Count;
            if (index < 0 || index > countList - 1) return;

            List<T> newList = new List<T>();
            T currentValue;

            for (int i = 0; i < countList; i++)
            {
                currentValue = list[i];

                if (i == index) currentValue = newValue;

                newList.Add(currentValue);
            }

            list = newList;
        }
        #endregion Replace

        #region Remove
        /// <summary>
        /// Видалити елемент(-и) за вказаним індексом. Видалення з primaryIndex по finalIndex
        /// </summary>
        /// <param name="list">Поточний список</param>
        /// <param name="primaryIndex">Початковий індекс</param>
        /// <param name="finalIndex">Кінцевий індекс. Якщо 0 finalIndex = primaryIndex</param>
        static public void Remove<T>(ref List<T> list, int primaryIndex, int finalIndex = 0)
        {
            #region Items
            int countList = list.Count;

            if (finalIndex == 0) finalIndex = primaryIndex;
            if (!(primaryIndex > -1) || !(finalIndex < countList) || primaryIndex > finalIndex) return;

            List<T> newList = new List<T>();
            #endregion Items

            for (int i = 0; i < countList; i++)
            {
                if (i == primaryIndex)
                {
                    for (i = finalIndex + 1; i < countList; i++) newList.Add(list[i]);

                    break;
                }

                newList.Add(list[i]);
            }

            list = newList;
        }
        /// <summary>
        /// Видалити дублікати
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">Поточний список</param>
        static public void RemoveDuplicates<T>(ref List<T> list)
        {
            #region Items
            List<T> newList = new List<T>();
            T currentElement = default;
            bool currentElementExist = default;
            int countList = list.Count;
            #endregion Items

            for (int i = 0; i < countList; i++)
            {
                currentElementExist = false;
                currentElement = list[i];

                for (int j = 0; j < newList.Count; j++)
                {
                    if (MyMath.CheckForEquality(currentElement, newList[j]))
                    {
                        currentElementExist = true;
                        break;
                    }
                }

                if (!currentElementExist) newList.Add(currentElement);
            }

            list = newList;
        }
        #endregion Remove

        #region Get
        /// <summary>
        /// Отримати підсписок з списку
        /// </summary>
        /// <param name="sublist">Поточний підсписок</param>
        /// <param name="list">Поточний список</param>
        /// <param name="index">Початковий індекс</param>
        /// <param name="count">Кількість елементів підсписку. Якщо count = 0, тоді зчитування елементів з list буде відбуватися до кінця</param>
        static public void GetSublist<T>(ref List<T> sublist, List<T> list, int index = 0, int count = 0)
        {
            #region Items
            int countList = list.Count;

            if (index < 0 || index > countList - 1) return;

            if (count == 0)
            {
                if (index == 0) { sublist = list; return; }
                else count = countList;
            }

            List<T> newSublist = new List<T>();
            int lengthFromIndex = index + count;
            #endregion Items

            for (int i = index; i < lengthFromIndex && i < countList; i++) newSublist.Add(list[i]);

            sublist = newSublist;
        }
        /// <summary>
        /// Отримати індекс значення в списку. Якщо значення в списку не знайдено, значення параметра currentIndex не змнінюється
        /// </summary>
        /// <param name="currentIndex">Поточний індекс</param>
        /// <param name="list">Список</param>
        /// <param name="value">Значення</param>
        static public void GetIndexValue<T>(ref int currentIndex, List<T> list, T value)
        {
            int countList = list.Count;
            if (countList == 0) return;

            for (int i = 0; i < countList; i++)
                if (MyMath.CheckForEquality(list[i], value))
                {
                    currentIndex = i;
                    break;
                }
        }
        /// <summary>
        /// Отримати список англійських літер нижнього регістру
        /// </summary>
        /// <param name="englishLowercaseLetters">Поточний список</param>
        static public void GetEnglishLowercaseLetters(ref List<char> englishLowercaseLetters) =>
            englishLowercaseLetters = new List<char>()
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
            };
        /// <summary>
        /// Отримати список англійських літер верхнього регістру регістру
        /// </summary>
        /// <param name="englishUppercaseLetters">Поточний список</param>
        static public void GetEnglishUppercaseLetters(ref List<char> englishUppercaseLetters) =>
            englishUppercaseLetters = new List<char>()
            {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
            };
        /// <summary>
        /// Отримати список всіх англійських літер
        /// </summary>
        /// <param name="englishLetters">Поточний список</param>
        static public void GetEnglishLetters(ref List<char> englishLetters)
        {
            List<char>
                newEnglishLetters = new List<char>(),
                currentList = default;

            GetEnglishLowercaseLetters(ref currentList); newEnglishLetters.AddRange(englishLetters);
            GetEnglishUppercaseLetters(ref currentList); newEnglishLetters.AddRange(englishLetters);

            englishLetters = newEnglishLetters;
        }
        /// <summary>
        /// Отримати список цифр 0-9
        /// </summary>
        /// <param name="numbers">Поточний список</param>
        static public void GetNumbers(ref List<char> numbers) =>
            numbers = new List<char>()
            {
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
            };
        #endregion Get

        #region Checks
        /// <summary>
        /// Перевірити входження значення в список 
        /// </summary>
        /// <param name="value">Значення для пошуку</param>
        /// <param name="listValues">Список значень</param>
        /// <returns>true - значення знайдено в списку, false - значення не знайдено в списку</returns>
        static public bool CheckValueForEntryInList<T>(T value, List<T> listValues)
        {
            int countListValues = listValues.Count;
            if (value == null || countListValues == 0) return false;

            for (int i = 0; i < countListValues; i++)
                if (MyMath.CheckForEquality(value, listValues[i])) return true;

            return false;
        }
        /// <summary>
        /// Перевірити на недозволені рядки в списку
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listValue">Поточний список</param>
        /// <param name="allowedValue">Список дозволених значень</param>
        /// <returns>true - недозволене значення знайдено, false - недозволене значення не знайдено</returns>
        static public bool CheckForIllegalValueInList<T>(List<T> listValue, List<T> allowedValue)
        {
            int
                countListValue = listValue.Count,
                countAllowedValue = allowedValue.Count;
            if (countListValue == 0 || countAllowedValue == 0) return true;

            for (int i = 0; i < countListValue; i++)
                if (!CheckValueForEntryInList(listValue[i], allowedValue)) return true;

            return false;
        }
        /// <summary>
        /// Перевірити індекс на наявність у списку
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">Поточний список</param>
        /// <param name="index">Поточний індекс</param>
        /// <returns>true - індекс входить у список, false - індекс не входить у список</returns>
        static public bool CheckIndexForOccurrence<T>(List<T> list, int index)
        {
            return !(index < 0) && index < list.Count;
        }
        /// <summary>
        /// Перевірка на порожній список
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">Список</param>
        /// <returns>true - список порожній, false - список не порожній</returns>
        static public bool IsEmpty<T>(List<T> list)
        {
            return list == null || list.Count == 0;
        }
        #endregion Checks

        #region Sort
        /// <summary>
        /// Відсортувати. Використовується для списків з декількома типами
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey">Ключ для сортування</typeparam>
        /// <param name="list">Список значень</param>
        /// <param name="keySelector">Ключ для сортування</param>
        /// <param name="byGrowth">true - сортувати по зростанню, false - сортувати по спаданню</param>
        static public void Sort<T, TKey>(ref List<T> list, Func<T, TKey> keySelector, bool byGrowth = true)
        {
            IOrderedEnumerable<T> resultSort = default;

            if (byGrowth) resultSort = list.OrderBy(keySelector);
            else resultSort = list.OrderByDescending(keySelector);

            list = resultSort.ToList();
        }
        #endregion Sort
    }
}
