using System;
using MyLibraries.MySystemLib.Classes;

namespace ConsoleAppForShowExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            MyException exception = default; GetException(ref exception);

            return;
        }

        static void GetException(ref MyException exception)
        {
            try
            {
                throw new Exception();
            }
            catch (Exception e)
            {
                exception = new MyException(true, e);

                /*
                 exception:
                    NumberLine = 23
                    MemberName = GetException
                    FilePath = "...\Examples\Program.cs"
                    ExceptionInfo = e
                 */
            }
        }
    }
}
