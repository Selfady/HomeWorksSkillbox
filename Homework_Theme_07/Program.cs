﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Enumeration;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;

namespace Homework_Theme_07
{
    class Program
    {
        /// <summary>
        /// Method that returns the next ID for notes.
        /// </summary>
        /// <returns></returns>
        static Note NewNote(Diary diary)
        {
            Console.WriteLine("\nPlease enter a summary for the note.");
            string summary = Console.ReadLine();
            Console.WriteLine("\nPlease enter text for the note.");
            string text = Console.ReadLine();
            return new Note(diary.LastNote, summary, text);
        }

        static void AddNote(Diary diary)
        {
            Console.WriteLine("\nAdd notes:" +
                              "\n1 - Add a note manually." +
                              "\n2 - Generate 10 notes automatically." +
                              "\n3 - Return to the Main menu.");
            Console.WriteLine("\nEnter a number from 1 to 3");
            string key = Console.ReadLine();
            var page = new Note();
            switch (key)
            {
                case "1":
                {
                    //Adding a new note from user input data.
                    diary.Add(NewNote(diary));
                    MainMenu(diary);
                    break;
                }
                case "2":
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        page = new Note(diary.LastNote, $"An autogenerated note #{i}.");
                        diary.Add(page);
                    }
                    MainMenu(diary);
                    break;
                }
                default:
                {
                    MainMenu(diary);
                    break;
                }
            }
        }

        static void MainMenu(Diary diary)
        {
            Console.WriteLine("\nNotes of the diary:");
            diary.PrintDiary();
            Console.WriteLine("\nMain menu:" +
                              "\n1 - Add a note." +
                              "\n2 - Edit a note." +
                              "\n3 - Remove a note." +
                              "\n4 - Sort notes." +
                              "\n5 - Save changes to the file." +
                              "\n6 - Exit the program.");
            Console.WriteLine("Enter a number from 1 to 6");
            string key = Console.ReadLine();
            switch (key)
            {
                case "1":
                {
                    AddNote(diary);
                    break;
                }
                default:
                {
                    break;
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("This is a batch of solutions for \"Homework_Theme_07 7.8 Homework\"");

            //TODO:загрузка записей из файла по диапазону дат,
            //TODO:упорядочивание записей по выбранному полю.
            //TODO:Записи сортируются по выбранному полю.

            const string fileName = "diary.txt";

            //Create a file to store a diary if it doesn't exist
            if (!File.Exists(fileName))
            {
                try
                {
                    // Create the file, or overwrite if the file exists.
                    using (FileStream fs = File.Create(fileName))
                    {
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            //Creating a diary
            var diary = new Diary(fileName);

            //Main loop of the program 
            do
            {
                //main menu call
                MainMenu(diary);

                Console.WriteLine("\nExit y/n?");
                var choice = Console.ReadLine();
                if (choice == "y" || choice == "Y")
                {
                    break;
                }

            } while (true);
            

            //var page2 = new Note(2, "bla?") { Edited = true };
            //var page3 = new Note(3, "mwahaha!");

            //var diary = new Diary("first.txt");
            //diary.Add(page1);
            //diary.Add(page2);
            //diary.Add(page3);
            ////diary.Remove(page2);


            //diary.PrintDiary();
            //diary.Save("first.txt");
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
