using System;
using MyLibraries.MySystemLib.Classes;

namespace ConsoleAppForShowExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            int number;

            number = default; MyRandom.Next(ref number);                                // 154107982
            number = default; MyRandom.Next(ref number, minNumber: 0, maxNumber: 10);   // 9
            number = default; MyRandom.Next(ref number, maxNumber: 10);                 // 4

            return;
        }
    }
}
