using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;

namespace Homework_Theme_07
{
    class Program
    {
        //static void MainMenu()
        //{
        //    Console
        //}

        static void Main(string[] args)
        {
            Console.WriteLine("This is a batch of solutions for \"Homework_Theme_07 7.8 Homework\"");

            //загрузка записей из файла по диапазону дат,
            //упорядочивание записей по выбранному полю.
            //Записи сортируются по выбранному полю.

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
            //TODO: make remove method work for loaded diary
            //diary.Remove(page2);
            diary.PrintDiary();


            //WIll have to Parse DateTime
            //diary.RemoveAll(DateTime.Parse("09/05/2021 01:28:31"));

            //will have to escape "\" symbol in entered strings
            diary.RemoveAllByAuthor("SELFADY-PC\\Selfady");

            Console.WriteLine("\nSome elements were removed.");
            diary.PrintDiary();

            Console.ReadKey();
        }
    }
}
