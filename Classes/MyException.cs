using System;
using System.Runtime.CompilerServices;

namespace MyLibraries.MySystemLib.Classes
{
    /// <summary>
    /// Виключення
    /// </summary>
    /// <remarks>
    ///     <para>Файл класу: <seealso href="https://github.com/blackByteGT/MyLibraries.MySystemLib.Net/blob/main/Classes/MyException.cs"/></para>
    ///     <para>Приклади застосування: <seealso href="https://github.com/blackByteGT/MyLibraries.MySystemLib.Net/tree/main/Examples/MyException"/></para>
    /// </remarks>
    /// 
    /// <translation xml:lang="en">
    ///     <summary>
    ///     Exception
    ///     </summary>
    ///     <remarks>
    ///         <para>File code: <seealso href="https://github.com/blackByteGT/MyLibraries.MySystemLib.Net/blob/main/Classes/MyException.cs"/></para>
    ///         <para>Application examples: <seealso href="https://github.com/blackByteGT/MyLibraries.MySystemLib.Net/tree/main/Examples/MyException"/></para>
    ///     </remarks>
    /// </translation>
    public class MyException
    {
        #region Items
        /// <summary>
        /// Назва класу, де відбулося виключення
        /// </summary>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     The name of the class where the exception occurred
        ///     </summary>
        /// </translation>
        public string MemberName { get; private set; }
        /// <summary>
        /// Номер рядка коду, де відбулося виключення
        /// </summary>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     The line number of the code where the exception occurred
        ///     </summary>
        /// </translation>
        public string NumberLine { get; private set; }
        /// <summary>
        /// Шлях до файлу, у якому відбулося виключення
        /// </summary>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     The path to the file where the exception occurred
        ///     </summary>
        /// </translation>
        public string FilePath { get; private set; }
        /// <summary>
        /// Додаткова інформація виключення
        /// </summary>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Additional exclusion information
        ///     </summary>
        /// </translation>
        public Exception ExceptionInfo { get; private set; }
        #endregion Items

        #region Constructions
        /// <summary>
        /// Внести додаткову інформацію про виключення 
        /// </summary>
        /// <remarks>Приклад: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyException/Main-example.cs"/></remarks>
        /// <param name="getFullFilePath">true - отримати повний шлях filePath, false - отримати скорочений шлях filePat</param>
        /// <param name="exceptionInfo">Додаткова інформація виключення</param>
        /// <param name="sourceMemberName">default</param>
        /// <param name="sourceFilePath">default</param>
        /// <param name="sourceLineNumber">default</param>
        /// 
        /// <translation xml:lang="en">
        ///     <summary>
        ///     Enter additional information about the exception
        ///     </summary>
        ///     <remarks>Example: <seealso href="https://raw.githubusercontent.com/blackByteGT/MyLibraries.MySystemLib.Net/main/Examples/MyException/Main-example.cs"/></remarks>
        ///     <param name="getFullFilePath">true - get the full filePath path, false - get the shortened filePat path</param>
        ///     <param name="exceptionInfo">Additional exclusion information</param>
        ///     <param name="sourceMemberName">default</param>
        ///     <param name="sourceFilePath">default</param>
        ///     <param name="sourceLineNumber">default</param>
        /// </translation>
        public MyException(
            bool getFullFilePath = false, Exception exceptionInfo = default, [CallerMemberName] string sourceMemberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0
        )
        {
            #region Filling items
            ExceptionInfo = exceptionInfo;
            MemberName = sourceMemberName;
            NumberLine = sourceLineNumber.ToString();
            FilePath = sourceFilePath;
            #endregion Filling items

            #region Getting full file path exception
            if (!getFullFilePath)
            {
                int lengthSourceFilePath = sourceFilePath.Length;
                string newSourceFilePath = "", currentChar = "";

                MyString.Flip(ref sourceFilePath);

                for (int i = 0; i < lengthSourceFilePath; i++)
                {
                    currentChar = sourceFilePath[i].ToString();
                    if (currentChar == @"\") break;

                    newSourceFilePath += currentChar;
                }

                sourceFilePath = newSourceFilePath;

                MyString.Flip(ref sourceFilePath);

                FilePath = sourceFilePath;
                #endregion Getting full file path exception
            }
        }
        #endregion Constructions
    }
}
