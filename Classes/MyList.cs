using System;
using System.Linq;
using System.Collections.Generic;

namespace MyLibraries.MySystemLib.Classes
{
    /// <summary>
    /// Список
    /// </summary>
    /// <remarks>
    ///     <para>Файл класу: <seealso href="https://github.com/blackByteGT/MyLibraries.MySystemLib.Net/blob/main/Classes/MyList.cs"/></para>
    ///     <para>Приклади застосування: <seealso href="https://github.com/blackByteGT/MyLibraries.MySystemLib.Net/tree/main/Examples/MyList"/></para>
    /// </remarks>
    /// 
    /// <translation xml:lang="en">
    ///     <summary>
    ///     List
    ///     </summary>
    ///     <remarks>
    ///         <para>File code: <seealso href="https://github.com/blackByteGT/MyLibraries.MySystemLib.Net/blob/main/Classes/MyList.cs"/></para>
    ///         <para>Application examples: <seealso href="https://github.com/blackByteGT/MyLibraries.MySystemLib.Net/tree/main/Examples/MyList"/></para>
    ///     </remarks>
    /// </translation>
    static public class MyList
    {
        #region Add
        /// <summary>
        /// Добавити значення в список
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyList/Add-of-values.cs"/></remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">Поточний список</param>
        /// <param name="newValue">Нове значення</param>
        /// <param name="index">Індекс нового значення. Якщо менше за 0 або більше за кількість значень в списку - добавляється в кінець</param>
        /// 
        /// <translation xml:lang="en"> 
        ///     <summary>
        ///     Add value to list
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyList/Add-of-values.cs"/></remarks>
        ///     <typeparam name="T"></typeparam>
        ///     <param name="list">Current list</param>
        ///     <param name="newValue">New value</param>
        ///     <param name="index">The index of the new value. If it is less than 0 or more than the number of values in the list, it is added to the end</param>
        /// </translation>
        static public void Add<T>(ref List<T> list, T newValue, int index = 0)
        {
            #region Items
            if (IsNull(list)) list = new List<T>();

            List<T> newList = new List<T>();
            int countList = list.Count;
            #endregion Items

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
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyList/Add-list-of-values.cs"/></remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">Поточний список</param>
        /// <param name="addList">Додатковий список</param>
        /// <param name="index">Індекс додавання</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Add values from another list to the list
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyList/Add-list-of-values.cs"/></remarks>
        ///     <typeparam name="T"></typeparam>
        ///     <param name="list">Current list</param>
        ///     <param name="addList">Additional list</param>
        ///     <param name="index">Add index</param>
        /// </translation>
        static public void Add<T>(ref List<T> list, List<T> addList, int index = 0)
        {
            #region Items
            if (IsEmpty(addList)) return;

            int
                countAddList = addList.Count,
                addIndex = index < 0 ? 0 : 1;
            List<T> newList = IsNull(list) ? new List<T>() : list;
            #endregion Items

            for (int i = 0; i < countAddList; i++)
            {
                Add(ref newList, addList[i], index);

                index += addIndex;
            }

            list = newList;
        }
        /// <summary>
        /// Добавити список списків в список
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyList/Add-list-lists-of-values.cs"/></remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">Поточний список</param>
        /// <param name="addArrayList">Список списків</param>
        /// <param name="index">Індекс додавання</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Add a list of lists to a list
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyList/Add-list-lists-of-values.cs"/></remarks>
        ///     <typeparam name="T"></typeparam>
        ///     <param name="list">Current list</param>
        ///     <param name="addArrayList">List of lists</param>
        ///     <param name="index">Add index</param>
        /// </translation>
        static public void Add<T>(ref List<T> list, List<List<T>> addArrayList, int index = 0)
        {
            #region Items
            int countAddArrayList = addArrayList.Count; if (countAddArrayList == 0) return;
            List<T>
                newList = list,
                currentList = default;
            #endregion Items

            for (int i = 0; i < countAddArrayList; i++)
            {
                currentList = addArrayList[i];

                Add(ref newList, addArrayList[i], index);

                index += currentList.Count;
            }

            list = newList;
        }
        #endregion Add

        #region Replace
        /// <summary>
        /// Замінити значення в списку за індексом
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyList/Replace.cs"/></remarks>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">Поточний список</param>
        /// <param name="newValue">Нове значення</param>
        /// <param name="index">Індекс заміни. Якщо значення занадто велике - дія не виконується</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Replace the values in the list by index
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyList/Replace.cs"/></remarks>
        ///     </summary>
        ///     <typeparam name="T"></typeparam>
        ///     <param name="list">Current list</param>
        ///     <param name="newValue">New value</param>
        ///     <param name="index">Replacement index. If the value is too large, the action is not performed</param>
        /// </translation>
        static public void Replace<T>(ref List<T> list, T newValue, int index)
        {
            #region Items
            int countList = list.Count; if (index < 0 || index > countList - 1) return;
            List<T> newList = new List<T>();
            T currentValue;
            #endregion Items

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
        /// Видалити елементи з списку за вказаними індексами
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyList/Remove-by-indexes.cs"/></remarks>
        /// </summary>
        /// <param name="list">Поточний список</param>
        /// <param name="primaryIndex">Початковий індекс</param>
        /// <param name="finalIndex">Кінцевий індекс. Якщо this = 0 => finalIndex = primaryIndex</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Remove elements from list at the specified indexes
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyList/Remove-by-indexes.cs"/></remarks>
        ///     </summary>
        ///     <param name="list">Current list</param>
        ///     <param name="primaryIndex">Initial index</param>
        ///     <param name="finalIndex">Final index. If this = 0 => finalIndex = primaryIndex</param>
        /// </translation>
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
        /// Видалити елементи списку з списку
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyList/Remove-by-list.cs"/></remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="listValues">Поточний список значень</param>
        /// <param name="listRemove">Список для видалення</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Remove list items from the list
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyList/Remove-by-list.cs"/></remarks>
        ///     <typeparam name="T"></typeparam>
        ///     <param name="listValues">Current list of values</param>
        ///     <param name="listRemove">List to delete</param>
        /// </translation>
        static public void Remove<T>(ref List<T> listValues, List<T> listRemove)
        {
            if (IsEmpty(listValues) || IsEmpty(listRemove)) return;

            #region Items
            int
                countListValues = listValues.Count,
                countListRemove = listRemove.Count;
            List<T> newListValues = listValues;
            T currentValue = default;
            #endregion Items

            for (int i = 0; i < countListValues; i++)
            {
                currentValue = newListValues[i];

                for (int j = 0; j < countListRemove; j++)
                {
                    if (listRemove[j].Equals(currentValue))
                    {
                        Remove(ref newListValues, i);

                        countListValues = newListValues.Count;
                        i--;

                        break;
                    }
                }
            }

            listValues = newListValues;
        }
        /// <summary>
        /// Видалити елементи списку з перерахування
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyList/Remove-by-enumerable.cs"/></remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="listValues">Поточний список значень</param>
        /// <param name="enumerableRemove">Перерахування для видалення</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Remove list items from the enumeration
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyList/Remove-by-enumerable.cs"/></remarks>
        ///     <typeparam name="T"></typeparam>
        ///     <param name="listValues">Current list of values</param>
        ///     <param name="enumerableRemove">List to delete</param>
        /// </translation>
        static public void Remove<T>(ref List<T> listValues, IEnumerable<T> enumerableRemove) =>
            Remove(ref listValues, listRemove: new List<T>(enumerableRemove));
        /// <summary>
        /// Видалити елементи списку які відповідають умові
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyList/Remove-by-condition.cs"/>></remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">Поточний список</param>
        /// <param name="keySelector">Ключ для відбору елементів видалення</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Remove list items that match the condition
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyList/Remove-by-condition.cs"/>></remarks>
        ///     <typeparam name="T"></typeparam>
        ///     <param name="list">Current list</param>
        ///     <param name="keySelector">Key for select items to delete</param>
        /// </translation>
        static public void Remove<T>(ref List<T> list, Func<T, bool> keySelector)  
        {
            if (IsEmpty(list) || keySelector == default) return;

            Remove(ref list, list.Where(keySelector));
        }
        /// <summary>
        /// Видалити дублікати з списку
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyList/Remove-duplicates.cs"/></remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">Поточний список</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Remove duplicates from the list
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyList/Remove-duplicates.cs"/></remarks>
        ///     <typeparam name="T"></typeparam>
        ///     <param name="list">Current list</param>
        /// </translation>
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
                    if (newList[j].Equals(currentElement))
                    {
                        currentElementExist = true;
                        break;
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
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyList/Get-sublist.cs"/></remarks>
        /// <param name="sublist">Поточний підсписок</param>
        /// <param name="list">Поточний список</param>
        /// <param name="index">Початковий індекс</param>
        /// <param name="count">Кількість елементів підсписку. Якщо count = 0, тоді зчитування елементів з list буде відбуватися до кінця</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Get a sublist from a list
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyList/Get-sublist.cs"/></remarks>
        ///     <param name="sublist">Current sublist</param>
        ///     <param name="list">Current list</param>
        ///     <param name="index">Initial index</param>
        ///     <param name="count">Number of sublist elements. If count = 0, then the reading of elements from the list will take place until the end</param>
        /// </translation>
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
        /// Отримати підсписок з списку за умовою
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyList/Get-sublist-by-condition.cs"/></remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="sublist">Поточний підсписок</param>
        /// <param name="list">Поточний список</param>
        /// <param name="keySelector">Умова отримання</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Get a sublist from a list by condition
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyList/Get-sublist-by-condition.cs"/></remarks>
        ///     <typeparam name="T"></typeparam>
        ///     <param name="sublist">Current sublist</param>
        ///     <param name="list">Current list</param>
        ///     <param name="keySelector">Condition of receipt</param>
        /// </translation>
        static public void GetSublist<T>(ref List<T> sublist, List<T> list, Func<T, bool> keySelector)
        {
            if (IsEmpty(list) || keySelector == default) return;

            sublist = new List<T>(list.Where(keySelector));
        }
        /// <summary>
        /// Отримати індекс значення в списку
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyList/Get-index.cs"/></remarks>
        /// <param name="index">Індекс значення</param>
        /// <param name="list">Список</param>
        /// <param name="value">Значення</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Get the index of the value in the list
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyList/Get-index.cs"/></remarks>
        ///     <param name="index">Index value</param>
        ///     <param name="list">List</param>
        ///     <param name="value">Value</param>
        /// </translation>
        static public void GetIndex<T>(ref int index, List<T> list, T value)
        {
            if (IsEmpty(list)) return;

            int countList = list.Count;

            for (int i = 0; i < countList; i++)
                if (list[i].Equals(value))
                {
                    index = i;
                    return;
                }

            index = -1;
        }
        /// <summary>
        /// Отримати індекс значення в списку за умовою
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyList/Get-index-by-condition.cs"/></remarks>
        /// <param name="index">Індекс значення</param>
        /// <param name="list">Список</param>
        /// <param name="keySelector">Умова отримання</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Get the index of the value in the list by condition
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyList/Get-index-by-condition.cs"/></remarks>
        ///     <param name="index">Index value</param>
        ///     <param name="list">List</param>
        ///     <param name="value">Value</param>
        /// </translation>
        static public void GetIndex<T>(ref int index, List<T> list, Func<T, bool> keySelector)
        {
            #region Items
            if (IsEmpty(list) || keySelector == default) return;

            List<T> sample = default; GetSublist(ref sample, list, keySelector);

            if (IsEmpty(sample)) return;
            #endregion Items

            GetIndex(ref index, list, sample[0]);
        }
        /// <summary>
        /// Отримати список англійських літер нижнього регістру
        /// </summary>
        /// <param name="englishLowercaseLetters">Поточний список</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Get a list of lowercase English letters
        ///     </summary>
        ///     <param name="englishLowercaseLetters">Current list</param>
        /// </translation>
        static public void GetEnglishLowercaseLetters(ref List<char> englishLowercaseLetters) =>
            englishLowercaseLetters = new List<char>()
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
            };
        /// <summary>
        /// Отримати список англійських літер верхнього регістру регістру
        /// </summary>
        /// <param name="englishUppercaseLetters">Поточний список</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Get a list of upper case English letters
        ///     </summary>
        ///     <param name="englishUppercaseLetters">Current list</param>
        /// </translation>
        static public void GetEnglishUppercaseLetters(ref List<char> englishUppercaseLetters) =>
            englishUppercaseLetters = new List<char>()
            {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
            };
        /// <summary>
        /// Отримати список всіх англійських літер
        /// </summary>
        /// <param name="englishLetters">Поточний список</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Get a list of all English letters
        ///     </summary>
        /// <param name="englishLetters">Current list</param>
        /// </translation>
        static public void GetEnglishLetters(ref List<char> englishLetters)
        {
            #region Items
            List<char>
                newEnglishLetters = new List<char>(),
                currentList = default;
            #endregion Items

            GetEnglishLowercaseLetters(ref currentList); Add(ref newEnglishLetters, currentList);
            GetEnglishUppercaseLetters(ref currentList); Add(ref newEnglishLetters, currentList);

            englishLetters = newEnglishLetters;
        }
        /// <summary>
        /// Отримати список цифр 0-9
        /// </summary>
        /// <param name="numbers">Поточний список</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Get a list of numbers 0-9
        ///     </summary>
        /// <param name="numbers">Current list</param>
        /// </translation>
        static public void GetNumbers(ref List<char> numbers) =>
            numbers = new List<char>()
            {
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
            };
        #endregion Get

        #region Checks
        /// <summary>
        /// Перевірити на входження індексу у список
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyList/Is-entry-index.cs"/></remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">Поточний список</param>
        /// <param name="index">Індекс</param>
        /// <returns>true - індекс входить у список, false - індекс не входить у список</returns>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Check whether the index is in the list
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyList/Is-entry-index.cs"/></remarks>
        ///     <typeparam name="T"></typeparam>
        ///     <param name="list">Current list</param>
        ///     <param name="index">Index</param>
        ///     <returns>true - the index is included in the list, false - the index is not included in the list</returns>
        /// </translation>
        static public bool IsEntry<T>(List<T> list, int index)
        {
            return !(index < 0) && !IsEmpty(list) && index < list.Count;
        }
        /// <summary>
        /// Перевірити на входження значення в список 
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyList/Is-entry-value.cs"/></remarks>
        /// <param name="list">Список</param>
        /// <param name="value">Значення</param>
        /// <returns>true - значення знайдено в списку, false - значення не знайдено в списку</returns>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Check if the value is in the list
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyList/Is-entry-value.cs"/></remarks>
        ///     <param name="list">List</param>
        ///     <param name="value">Value</param>
        ///     <returns>true - the value is found in the list, false - the value is not found in the list</returns>
        /// </translation>
        static public bool IsEntry<T>(List<T> list, T value)
        {
            #region Items
            const int indexDefault = -1;
            int index = indexDefault;
            #endregion Items

            GetIndex(ref index, list, value);
            
            return index != indexDefault;
        }
        /// <summary>
        /// Перевірити на входження списку значень в список
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyList/Is-entry-from-list.cs"/></remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="listValues">Поточний список значень</param>
        /// <param name="listValuesForCheck">Список значень для перевірки</param>
        /// <returns>true - значення знайдено в списку, false - значення не знайдено в списку</returns>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Check whether the list of values is included in the list
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyList/Is-entry-from-list.cs"/></remarks>
        ///     <typeparam name="T"></typeparam>
        ///     <param name="listValues">Current list of values</param>
        ///     <param name="listValuesForCheck">List of values to check</param>
        ///     <returns>true - the value is found in the list, false - the value is not found in the list</returns>
        /// </translation>
        static public bool IsEntry<T>(List<T> listValues, List<T> listValuesForCheck)
        {
            if (IsEmpty(listValues) || IsEmpty(listValuesForCheck)) return false;

            int countListValuesForCheck = listValuesForCheck.Count;

            for (int i = 0; i < countListValuesForCheck; i++) 
                if (IsEntry(listValues, listValuesForCheck[i])) return true;

            return false;
        }
        /// <summary>
        /// Перевірити список на null
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyList/Is-null.cs"/></remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">Список</param>
        /// <returns>true - список є null, false - список не є null</returns>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Check the list for null
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyList/Is-null.cs"/></remarks>
        ///     <typeparam name="T"></typeparam>
        ///     <param name="list">List</param>
        ///     <returns>true - the list is null, false - the list is not null</returns>
        /// </translation>
        static public bool IsNull<T>(List<T> list)
        {
            return list is null;
        }
        /// <summary>
        /// Перевірка на порожній список
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyList/Is-empty.cs"/></remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">Список</param>
        /// <returns>true - список порожній, false - список не порожній</returns>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Checking for an empty list
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyList/Is-empty.cs"/></remarks>
        ///     <typeparam name="T"></typeparam>
        ///     <param name="list">List</param>
        ///     <returns>true - the list is empty, false - the list is not empty</returns>
        /// </translation>
        static public bool IsEmpty<T>(List<T> list)
        {
            return IsNull(list) || list.Count == 0;
        }
        #endregion Checks

        #region Sort
        /// <summary>
        /// Відсортувати
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyList/Sort.cs"/></remarks>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey">Ключ для сортування</typeparam>
        /// <param name="list">Список значень</param>
        /// <param name="keySelector">Ключ для сортування</param>
        /// <param name="byGrowth">true - сортувати по зростанню, false - сортувати по спаданню</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Sort
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyList/Sort.cs"/></remarks>
        ///     <typeparam name="T"></typeparam>
        ///     <typeparam name="TKey">Sort key</typeparam>
        ///     <param name="list">List of values</param>
        ///     <param name="keySelector">Sort key</param>
        ///     <param name="byGrowth">true - sort in ascending order, false - sort in descending order</param>
        /// </translation>
        static public void Sort<T, TKey>(ref List<T> list, Func<T, TKey> keySelector, bool byGrowth = true)
        {
            IOrderedEnumerable<T> resultSort = default;

            if (byGrowth) resultSort = list.OrderBy(keySelector);
            else resultSort = list.OrderByDescending(keySelector);

            list = resultSort.ToList();
        }
        #endregion Sort

        #region Other
        /// <summary>
        /// Перемістити елементи списку 
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyList/Move.cs"/></remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">Поточний список</param>
        /// <param name="indexItem1">Індекс першого елемента</param>
        /// <param name="indexItem2">Індекс другого елемента</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Move list items
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyList/Move.cs"/></remarks>
        ///     <typeparam name="T"></typeparam>
        ///     <param name="list">Current list</param>
        ///     <param name="indexItem1">The index of the first element</param>
        ///     <param name="indexItem2">The index of the second element</param>
        /// </translation>
        static public void Move<T>(ref List<T> list, int indexItem1, int indexItem2)
        {
            if (!IsEntry(list, indexItem1) || !IsEntry(list, indexItem2)) return;

            #region Items
            T temp = default;
            List<T> newList = list;
            #endregion Items

            temp = newList[indexItem1];
            newList[indexItem1] = newList[indexItem2];
            newList[indexItem2] = temp;

            list = newList;
        }
        /// <summary>
        /// Перемішати елементи списку
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyList/Shuffle.cs"/></remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">Поточний список</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Shuffle the list items
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyList/Shuffle.cs"/></remarks>
        ///     <typeparam name="T"></typeparam>
        ///     <param name="list">Current list</param>
        /// </translation>
        static public void Shuffle<T>(ref List<T> list)
        {
            #region Items
            if (IsEmpty(list)) return;

            int
                countList = list.Count,
                currentIndex = default;
            List<T> newList = list;

            if (!(countList > 2)) return;
            #endregion Items

            for (int i = 0; i < countList; i++)
            {
                currentIndex = i;

                while (currentIndex == i)
                    MyRandom.Next(ref currentIndex, maxNumber: countList - 1);

                Move(ref newList, i, currentIndex);
            }

            list = newList;
        }
        #endregion Other
    }
}
