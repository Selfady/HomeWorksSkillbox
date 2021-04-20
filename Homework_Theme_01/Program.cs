using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace Homework_Theme_01
{
    /*
    I want it Dry
    I want it dRy
    I want it drY
    And I wanna cry!
    */

    // Поток сознания:
    // Процедурное программирование?
    // ООП?
    // Использование готовых решений для этих велосипедов?
    // Вносить изменения - боль.


    class Program
    {
        static void Main(string[] args)
        {
            
            //Установил codepage в Unicode чтобы избавиться от русской корявицы в своей консоли
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            //bufferWidth will store the initial console width
            int bufferWidth = Console.BufferWidth;

            //Initial dialog string
            string initialDialog = "Добро пожаловать в программу \"Задания 1-5 раздела Homework_Theme_01\"";
            //Calculating the position of cursor to make sure the whole initial dialog will be shown at the center of the console
            //TODO: Somehow recalculate the position of the flight to make sure the text is always in the middle of the console
            Console.SetCursorPosition(((bufferWidth - (initialDialog.Length)) / 2), 0);
            //Output for the initial dialog
            Console.WriteLine(initialDialog);

            //amountOfWorkers is a variable to set the amount of application users
            int amountOfWorkers = 3;

            //Assign memory for Company
            Company company = new Company(amountOfWorkers);

            //обычный вывод информации
            company.Print("Вот эти ребята:");

            //Display average score for the users
            foreach (var u in company.Users)
            {
                //Форматированный вывод информации
                Console.WriteLine("Средний бал пользователя {0} равен: {1}",u.Name, u.AverageScore());

            }
            
            Console.ReadLine();

        }
    }
}