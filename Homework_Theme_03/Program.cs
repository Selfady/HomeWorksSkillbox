using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_03
{
    static class Program
    {
        static void Main()
        {
            //I have to use unicode for input/output values
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            //General message
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Вы запустили игру \"Homework_Theme_03\n3.10 Домашняя работа\"");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Введите количество игроков:" +
                              "\n 1 - против компьютера" +
                              "\n 2 - игра на 2 игрока" +
                              "\n 3 - игра на 3 игрока" +
                              "\n 4 - игра на 4 игрока" +
                              "\n 5 - игра на пятерых");
            string input = Console.ReadLine();
            ValidateConsoleInput(input);





            Console.ReadLine();
        }

        private static string ValidateConsoleInput(string input)
        {

            return input;
        }
    }
}
