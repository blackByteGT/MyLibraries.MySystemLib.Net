using System.Runtime.CompilerServices;

namespace MyLibraries.MySystemLib.Classes
{
    /// <summary>
    /// Виключення
    /// </summary>
    public class MyException
    {
        #region Items
        /// <summary>
        /// Назва класу
        /// </summary>
        private string MemberName { get; set; }
        /// <summary>
        /// Номер рядка коду
        /// </summary>
        private string NumberLine { get; set; }
        /// <summary>
        /// Шлях до файлу
        /// </summary>
        private string FilePath { get; set; }
        #endregion Items

        /// <summary>
        /// 
        /// </summary>
        /// <param name="getFullFilePath">true - отримати повний шлях filePath, false - отримати скорочений шлях filePat</param>
        /// <param name="sourceMemberName"></param>
        /// <param name="sourceFilePath"></param>
        /// <param name="sourceLineNumber"></param>
        public MyException(bool getFullFilePath = false, [CallerMemberName] string sourceMemberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            MemberName = sourceMemberName;
            NumberLine = sourceLineNumber.ToString();
            FilePath = sourceFilePath;

            if (!getFullFilePath)
            {
                int lengthSourceFilePath = sourceFilePath.Length;
                string newSourceFilePath = "", currentChar = "";

                MyString.GetDeployed(ref sourceFilePath, sourceFilePath);

                for (int i = 0; i < lengthSourceFilePath; i++)
                {
                    currentChar = sourceFilePath[i].ToString();
                    if (currentChar == @"\") break;

                    newSourceFilePath += currentChar;
                }

                sourceFilePath = newSourceFilePath;

                MyString.GetDeployed(ref sourceFilePath, sourceFilePath);

                FilePath = sourceFilePath;
            }
        }
    }
}
