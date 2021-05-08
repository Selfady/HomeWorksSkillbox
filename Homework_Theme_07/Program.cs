using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;

namespace Homework_Theme_07
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("This is a batch of solutions for \"Homework_Theme_07 7.8 Homework\"");
            //var page1 = new Note(1, "blablabla");
            //page1.Summary = "About bla.";


            //var page2 = new Note(2, "bla?") { Edited = true };
            //var page3 = new Note(3, "mwahaha!");

            //var diary = new Diary("first.txt");
            //diary.Add(page1);
            //diary.Add(page2);
            //diary.Add(page3);
            ////diary.Remove(page2);


            //diary.PrintDiary();
            //diary.Save("first.txt");

            var diary = new Diary("first.txt");
            diary.Load();
            //TODO: make remove method work for loaded diary
            //diary.Remove(page2);
            diary.PrintDiary();

            Console.ReadKey();
        }
    }
}
