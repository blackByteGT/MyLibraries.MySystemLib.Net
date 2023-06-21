using System.IO;

namespace MyLibraries.MySystemLib.Net.Classes
{
    /// <summary>
    /// Конвектор
    /// </summary>
    static public class MyConvert
    {
        #region Convert to array byte
        /// <summary>
        /// Перетворити у масив байтів
        /// </summary>
        /// <param name="arrayByte">Поточний масив байтів</param>
        /// <param name="stream">Потік даних</param>
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
        /// <param name="arrayByte">Мисив байтів</param>
        static public void ConvertToStream(ref Stream stream, byte[] arrayByte) =>
            stream = new MemoryStream(arrayByte);
        #endregion Convert to stream
    }
}
