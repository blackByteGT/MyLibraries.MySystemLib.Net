﻿using MyLibraries.MySystemLib.Classes;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            string str;

            str = "hello"; MyString.Flip(ref str);      // "olleh"
            str = "everybody"; MyString.Flip(ref str);  // "ydobyreve"

            return;
        }
    }
}
