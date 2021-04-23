using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_03
{
    static class Program
    {
        /*
    I want it Dry
    I want it dRy
    I want it drY
    And I wanna cry!
    */
        static void Main()
        {
            //I have to use unicode for input/output values
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            #region Number of players
            //General message
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Вы запустили игру \"Homework_Theme_03 3.10 Домашняя работа\"");
            Console.ForegroundColor = ConsoleColor.Gray;
            string gameMenu = "Введите количество игроков:" +
                              "\n 1 - против компьютера" +
                              "\n 2 - игра на 2 игрока" +
                              "\n 3 - игра на 3 игрока" +
                              "\n 4 - игра на 4 игрока" +
                              "\n 5 - игра на 5 игроков";
            Console.WriteLine(gameMenu);

            //numberOfPlayers initialization to store the number of players
            byte numberOfPlayers = default;

            //a flag that to show error message for the user
            bool dataEntered = false;

            //Validating user input till he enters from 1 to 5 players
            while (!IntWithinRange(numberOfPlayers,1,5))
            {
                if (dataEntered)
                    Console.WriteLine($"В 'Homework_Theme_03' может играть от 1 до 5 человек. Введите цифру.");
                byte.TryParse(Console.ReadLine(), out numberOfPlayers);
                dataEntered = true;
            }

            Console.WriteLine($"Вы выбрали режим на {numberOfPlayers} игрока/ов");
            #endregion

            #region Diffulty Single Player
            //numberOfPlayers initialization to store the number of players
            byte difficultySinglePlayer = default;

            //a flag that to show error message for the user
            dataEntered = false;

            //Set Computer difficulty if single player
            if (numberOfPlayers == 1)
            {
                Console.WriteLine("Введите уровень сложности" +
                                  "\n 1 - простой" +
                                  "\n 2 - сложный");

                //Validating user input till he enters from 1 to 5 players
                while (!IntWithinRange(difficultySinglePlayer, 1, 2))
                {
                    if (dataEntered)
                        Console.WriteLine($"ВВедите 1 или 2.");
                    byte.TryParse(Console.ReadLine(), out difficultySinglePlayer);
                    dataEntered = true;
                }

                Console.WriteLine(difficultySinglePlayer == 1
                    ? "Вам будет просто победить."
                    : "Вам будет сложно победить.");
            }

            #endregion

            #region Players

            //Initialized the list of players to allocate memory for the object
            List<string> Players = new List<string>();

            do
            {
                Console.WriteLine($"ВВедите имя игрока № {Players.Count +1}");
                Players.Add(Console.ReadLine());
            } while (Players.Count != numberOfPlayers);
            
            //Adding a computer player if Single Player
            if (Players.Count == 1)
            {
                switch (difficultySinglePlayer)
                {
                    case 1:
                        Players.Add("Незнайка (Компьютер)");
                        break;
                    case 2:
                        Players.Add("Знайка (Компьютер)");
                        break;
                }
            }

            //List the players into the console
            Console.WriteLine("Сегодня в игру \"Homework_Theme_03 3.10 Домашняя работа\" играют:");
            foreach (var p in Players)
            {
                Console.WriteLine("Игрок " + p);
            }

            #endregion

            #region rulesMod
            //numberOfPlayers initialization to store the number of players
            byte rulesMod = default;

            //a flag that to show error message for the user
            dataEntered = false;

            //Set Computer difficulty if single player

            string rules = "Правила игры:" +
                           "\nЗагадывается число от 12 до 120, причём случайным образом. Назовём его gameNumber" +
                           "\nИгроки по очереди выбирают число от одного до четырёх. Пусть это число обозначается как userTry." +
                           "\nUserTry после каждого хода вычитается из gameNumber, а само gameNumber выводится на экран." +
                           "\nЕсли после хода игрока gameNumber равняется нулю, то походивший игрок оказывается победителем.";
            Console.WriteLine(rules);

            Console.WriteLine("Хотите изменить стандартные правила?" +
                              "\n 1 - да" +
                              "\n 2 - нет");

            //Validating user input till he enters from 1 to 5 players
            while (!IntWithinRange(rulesMod, 1, 2))
            {
                if (dataEntered)
                    Console.WriteLine($"ВВедите 1 или 2.");
                byte.TryParse(Console.ReadLine(), out rulesMod);
                dataEntered = true;
            }

            int minGameNumber = default;
            int maxGameNumber = default;
            long gameNumber = default;
            int minUserTry = default;
            int maxUserTry = default;


            //Generating rules
            if (rulesMod != 1)
            {
                Console.WriteLine("Играем по обычным правилам.");
                minGameNumber = 12;
                maxGameNumber = 120;

                //Generating gameNumber
                gameNumber = GenerateNumberInRange(minGameNumber, maxGameNumber);

                minUserTry = 1;
                maxUserTry = 4;
                Console.WriteLine($"GameNumber = {gameNumber}" +
                                  $"\nUserTry от {minUserTry} до {maxUserTry}");
            }
            else
            {
                Console.WriteLine("Будем играть по своим правилам!");

                #region Custom gameNumber

                Console.WriteLine("ВВедите минимально возможное значение для gameNumber");

                //a flag that to show error message for the user
                dataEntered = false;

                while (!IntWithinRange(minGameNumber, 1, int.MaxValue-1))
                {
                    if (dataEntered)
                        Console.WriteLine($"ВВедите чисто от 1 до {int.MaxValue-1}");
                    int.TryParse(Console.ReadLine(), out minGameNumber);
                    dataEntered = true;
                }

                Console.WriteLine("Минимально возможное значение для gameNumber установлено в: {0}", minGameNumber);

                Console.WriteLine("ВВедите максимально возможное значение для gameNumber");

                //a flag that to show error message for the user
                dataEntered = false;

                while (!IntWithinRange(maxGameNumber, minGameNumber+1, int.MaxValue))
                {
                    if (dataEntered)
                        Console.WriteLine($"ВВедите чисто от {minGameNumber+1} до {int.MaxValue}");
                    int.TryParse(Console.ReadLine(), out maxGameNumber);
                    dataEntered = true;
                }

                Console.WriteLine("Максимально возможное значение для gameNumber установлено в: {0}", maxGameNumber);
                
                #endregion Custom gameNumber

                #region Custom minUserTry and maxUserTry

                Console.WriteLine("ВВедите максимально возможное значение для userTry");

                //a flag that to show error message for the user
                dataEntered = false;

                while (!IntWithinRange(maxUserTry, 2, maxGameNumber))
                {
                    if (dataEntered)
                        Console.WriteLine($"ВВедите чисто от 2 до {maxGameNumber}");
                    int.TryParse(Console.ReadLine(), out maxUserTry);
                    dataEntered = true;
                }

                Console.WriteLine("Максимально возможное значение для userTry установлено в: {0}", maxUserTry);

                Console.WriteLine("ВВедите минимально возможное значение для userTry");

                //a flag that to show error message for the user
                dataEntered = false;

                while (!IntWithinRange(minUserTry, 1, maxUserTry-1))
                {
                    if (dataEntered)
                        Console.WriteLine($"ВВедите чисто от 1 до {maxUserTry-1}");
                    int.TryParse(Console.ReadLine(), out minUserTry);
                    dataEntered = true;
                }

                Console.WriteLine("Минимально возможное значение для userTry установлено в: {0}", minUserTry);

                Console.WriteLine("Играем по своим правилам.");

                //Generating gameNumber
                gameNumber = GenerateNumberInRange(minGameNumber, maxGameNumber);
                
                Console.WriteLine($"GameNumber = {gameNumber}" +
                                  $"\nUserTry от {minUserTry} до {maxUserTry}");



                #endregion Custom minUserTry and maxUserTry
            }

            #endregion

            #region The Game

            

            #endregion




            Console.ReadLine();

        }

        /// <summary>
        /// Method to make sure an input value is within the given range
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="min">minimum value</param>
        /// <param name="max">maximum value</param>
        /// <returns></returns>
        private static bool IntWithinRange(int value, int min, int max)
        {
            var withinRange = value >= min && value <= max;
            return withinRange;
        }

        private static int GenerateNumberInRange(int min, int max)
        {
            Random rnd = new Random();
            return rnd.Next(min, max+1);
        }









    }
}
