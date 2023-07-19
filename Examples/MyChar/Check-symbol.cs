using MyLibraries.MySystemLib.Classes;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Items
            bool result = default;
            char
                number = '0',
                upperLetter = 'A',
                lowerLetter = 'a';
            #endregion Items

            // Info number:          0
            // Info upperLetter:    'A'
            // Info lowerLetter:    'a'

            result = MyChar.CheckSymbol(number, checkByNumbers: true, checkByEnglishLetters: true);             // result = true
            result = MyChar.CheckSymbol(number, checkByEnglishLetters: true);                                   // result = false
            result = MyChar.CheckSymbol(upperLetter, checkByNumbers: true, checkByEnglishLetters: true);        // result = true
            result = MyChar.CheckSymbol(upperLetter, checkByNumbers: true, checkByEnglishLowerLetters: true);   // result = false
            result = MyChar.CheckSymbol(lowerLetter, checkByEnglishLetters: true);                              // result = true
            result = MyChar.CheckSymbol(lowerLetter, checkByEnglishUpperLetters: true);                         // result = false

            return;
        }
    }
}
