using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;

namespace MyLibraries.MySystemLib.Classes
{
    /// <summary>
    /// Конвектор
    /// </summary> 
    /// <remarks>
    ///     <para>Файл класу: <seealso href="https://github.com/blackByteGT/MyLibraries.MySystemLib.Net/blob/main/Classes/MyConvert.cs"/></para>
    ///     <para>Приклади застосування: <seealso href="https://github.com/blackByteGT/MyLibraries.MySystemLib.Net/tree/main/Examples/MyConvert"/></para>
    /// </remarks>
    /// 
    /// <translation xml:lang="en">
    ///     <summary>
    ///     Convector
    ///     </summary>
    ///     <remarks>
    ///         <para>File code: <seealso href="https://github.com/blackByteGT/MyLibraries.MySystemLib.Net/blob/main/Classes/MyConvert.cs"/></para>
    ///         <para>Application examples: <seealso href="https://github.com/blackByteGT/MyLibraries.MySystemLib.Net/tree/main/Examples/MyConvert"/></para>
    ///     </remarks>
    /// </translation>
    static public class MyConvert
    {
        #region Convert to array byte
        /// <summary>
        /// Перетворити у масив байтів
        /// </summary>
        /// <param name="arrayByte">Поточний масив байтів</param>
        /// <param name="stream">Потік даних</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Convert to byte array
        ///     </summary>
        ///     <param name="arrayByte">The current byte array</param>
        ///     <param name="stream">Data stream</param>
        /// </translation>
        static public void ConvertToArrayByte(ref byte[] arrayByte, Stream stream)
        {
            if (stream is null) return;

            stream.Position = 0;

            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {

                int read;
                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }

                arrayByte = ms.ToArray();
            }
        }
        #endregion Convert to array byte

        #region Convert to stream
        /// <summary>
        /// Перетворити у потік даних
        /// </summary>
        /// <param name="stream">Поточний потік даних</param>
        /// <param name="arrayByte">Масив байтів</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Convert to data stream
        ///     </summary>
        ///     <param name="stream">Current data stream</param>
        ///     <param name="arrayByte">Byte array</param>
        /// </translation>
        static public void ConvertToStream(ref Stream stream, byte[] arrayByte) =>
            stream = new MemoryStream(arrayByte);
        #endregion Convert to stream

        #region Convert to object
        /// <summary>
        /// Перетворити список struct на список object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listObjects">Список object</param>
        /// <param name="listStructs">Список struct</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Convert a struct list into an object list
        ///     </summary>
        ///     <typeparam name="T"></typeparam>
        ///     <param name="listObjects">Object list</param>
        ///     <param name="listStructs">struct list</param>
        /// </translation>
        static public void ConvertToObject<T>(ref List<object> listObjects, List<T> listStructs) where T : struct
        {
            #region Items
            if (MyList.IsEmpty(listStructs)) return;

            int countListStructs = listStructs.Count;
            List<object> newListObjects = new List<object>();
            #endregion Items

            for (int i = 0; i < countListStructs; i++) newListObjects.Add(listStructs[i]);

            listObjects = newListObjects;
        }
        #endregion Convert to object

        #region Convert to struct
        /// <summary>
        /// Перетворити у struct
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">Поточне значення типу struct</param>
        /// <param name="obj">Об'єкт класу object</param>
        /// <returns>true - вдалося перетворити, false - не вдалося перетворити</returns>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Convert to struct
        ///     </summary>
        ///     <typeparam name="T"></typeparam>
        ///     <param name="value">Current value of type struct</param>
        ///     <param name="obj">An object of the object class</param>
        ///     <returns>true - conversion succeeded, false - conversion failed</returns>
        /// </translation>
        static public bool ConvertToStruct<T>(ref T value, object obj) where T : struct
        {
            try { value = (T)obj; }
            catch { return false; }

            return true;
        }
        /// <summary>
        /// Перетворити список object на список struct
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listValues">Поточний список значень типу struct</param>
        /// <param name="listObjects">Список об'єктів object</param>
        /// <returns>true - вдалося перетворити, false - не вдалося перетворити</returns>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Convert the object list to the struct list
        ///     </summary>
        ///     <typeparam name="T"></typeparam>
        ///     <param name="listValues">The current list of values of type struct</param>
        ///     <param name="listObjects">List of objects object</param>
        ///     <returns>true - conversion succeeded, false - conversion failed</returns>
        /// </translation>
        static public bool ConvertToStruct<T>(ref List<T> listValues, List<object> listObjects) where T : struct
        {
            #region Items
            if (MyList.IsEmpty(listObjects)) return false;

            int countListObject = listObjects.Count;
            T currentValue = default;
            List<T> newListValues = new List<T>();
            #endregion Items

            for (int i = 0; i < countListObject; i++)
            {
                if (!ConvertToStruct(ref currentValue, listObjects[i])) return false;

                newListValues.Add(currentValue);
            }

            listValues = newListValues; return true;
        }
        #endregion Convert to struct

        #region Convert to decimal
        /// <summary>
        /// Перетворити рядок у число decimal
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyConvert/Convert-to-decimal.cs"/></remarks>
        /// <param name="number">Поточне число</param>
        /// <param name="str">Рядок</param>
        /// <param name="listSeparator">Список розподілювачів</param>
        /// <returns>true - вдалося перетворити, false - вдалося перетворити</returns>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Convert a string to a decimal number
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyConvert/Convert-to-decimal.cs"/></remarks>
        ///     <param name="number">The current number</param>
        ///     <param name="str">String</param>
        ///     <param name="listSeparator">List of distributors</param>
        ///     <returns>true - successful conversion, false - successful conversion</returns>
        /// </translation>
        static public bool ConvertToDecimal(ref decimal number, string str, List<char> listSeparator)
        {
            if (MyList.IsEmpty(listSeparator) || String.IsNullOrWhiteSpace(str)) return false;

            int countListSeparator = listSeparator.Count;

            for (int i = 0; i < countListSeparator; i++)
                try
                {
                    number = decimal.Parse(str, new NumberFormatInfo() { NumberDecimalSeparator = listSeparator[i].ToString() });

                    return true;
                }
                catch { }

            return false;
        }
        /// <summary>
        /// Перетворити рядок у число decimal
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyConvert/Convert-to-decimal.cs"/></remarks>
        /// <param name="number">Поточне число</param>
        /// <param name="str">Рядок</param>
        /// <returns>true - вдалося перетворити, false - вдалося перетворити</returns>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Convert a string to a decimal number
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyConvert/Convert-to-decimal.cs"/></remarks>
        ///     <param name="number">The current number</param>
        ///     <param name="str">String</param>
        ///     <returns>true - successful conversion, false - successful conversion</returns>
        static public bool ConvertToDecimal(ref decimal number, string str)
        {
            return ConvertToDecimal(ref number, str, MyDecimal.DefaultListSeparators);
        }
        #endregion Convert to decimal
    }
}
