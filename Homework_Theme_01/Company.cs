using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Homework_Theme_01
{
    /// <summary>
    /// Класс, описывающий модель компании
    /// </summary>
    public class Company
    {
        /// <summary>
        /// Список пользователей, в котором хранятся 
        /// Имя, возраст, рост и баллы каждого пользователя
        /// </summary>
        public List<User> Users { get; set; }

        /// <summary>
        /// Конструктор, заполняющий компанию
        /// </summary>
        /// <param name="Count">Количество пользователей, которых нужно создать</param>
        public Company(int Count)
        {
            this.Users = new List<User>(); // Выделение памяти для списка пользователей

            //A loop to enter data for every user
            int i = 1;
            while (i <= Count)
            {
                #region Name
                //initialized a variable to store user input
                string userName = string.Empty;
                //initialized a pattern to validate user input
                //name pattern starts from russian capital letter
                string namePattern = "^[А-Я][а-яА-Я]*$";

                bool dataEntered = false;

                //Check if name corresponds to russian word that starts with a capital letter
                while (!Regex.IsMatch(userName, namePattern))
                {
                    //An expression to skip educational messages if user knows the limitations
                    if (dataEntered)
                    {
                        //Notified the user about name rules
                        Console.WriteLine("Имя - это русское слово с заглавной буквы.");
                    }
                    //Ask to enter Name for the user
                    Console.WriteLine("Введите Имя пользователя №" + i);
                    //Reading user input
                    userName = Console.ReadLine().Trim();
                    //Output to show the user thr data they entered
                    Console.WriteLine("Вы ввели: " + userName);
                    //set flag to true to notify the user about field restrictions
                    dataEntered = true;
                }

                #endregion

                #region Age
                //Initialized Age variable with default value
                ushort userAge = default;

                //Set dataEntered flag to false before we ask for the next user input
                dataEntered = false;

                //Make sure user puts his data
                //And the rule to check if Age is correct
                while (!((userAge > 0) && (userAge < 130)))
                {
                    //An expression to skip educational messages if user knows the limitations
                    if (dataEntered)
                    {
                        //Notified the user about name rules
                        Console.WriteLine("Под возрастом мы понимаем количество полных лет, \nварианты меньше 1 или больше 130 не подходят.");
                    }

                    //Ask to enter age for the user
                    Console.WriteLine("Введите Возраст пользователя №" + i);
                    //Reading user input and getting rid of extra whitespaces
                    string userInput = Console.ReadLine().Trim();
                    //Output to show the user the data they entered
                    Console.WriteLine("Вы ввели: " + userInput);
                    try
                    {
                        userAge = Convert.ToUInt16(
                            userInput);
                    }
                    //Много ввели - проигнорировать
                    catch (OverflowException)
                    {
                    }
                    //Не тот формат данных - проигнорировать
                    catch (FormatException)
                    {
                    }
                    //set flag to true to notify the user about field restrictions
                    dataEntered = true;
                }

                #endregion

                #region Height

                //Initialized Height variable with default value
                ushort userHeight = default;

                //Set dataEntered flag to false before we ask for the next user input
                dataEntered = false;

                //Make sure user puts his data
                //And the rule to check if Height is correct
                while (!((userHeight > 67) && (userHeight < 251)))
                {
                    //An expression to skip educational messages if user knows the limitations
                    if (dataEntered)
                    {
                        //Notified the user about Height rules
                        Console.WriteLine("Рост мы ожидаем в сантиметрах, \nварианты меньше 67 или больше 251 не подходят \nих не одобряют Хагендра Тапа Магар и Роберт Першинг Уодлоу");
                    }

                    //Ask to enter Height for the user
                    Console.WriteLine("Введите Рост пользователя №" + i);
                    //Reading user input and getting rid of extra whitespaces
                    string userInput = Console.ReadLine().Trim();
                    //Output to show the user the data they entered
                    Console.WriteLine("Вы ввели: " + userInput);
                    //Reading user input and getting rid of extra whitespaces
                    try
                    {
                        userHeight = Convert.ToUInt16(
                            userInput);
                    }
                    catch (OverflowException)
                    {
                    }
                    catch (FormatException)
                    {
                    }

                    //set flag to true to notify the user about field restrictions
                    dataEntered = true;
                }

                #endregion

                #region Russian Language Score

                //Initialized Russian Language Score variable with default value
                byte russianLanguageScore = default;

                //Set dataEntered flag to false before we ask for the next user input
                dataEntered = false;

                //Make sure user puts his data
                //And the rule to check if Russian Language Score is correct
                while (!((russianLanguageScore > 2) && (russianLanguageScore <= 100)))
                {
                    //An expression to skip educational messages if user knows the limitations
                    if (dataEntered)
                    {
                        //Notified the user about Score rules
                        Console.WriteLine("Мы ожидаем либо запись в аттестате от 3 до 5, либо оценку по ЕГЭ, не превышающую 100 баллов." +
                                          "\nКолы и двойки нам мало интересны в любом случае.");
                    }

                    //Ask to enter Score for the user
                    Console.WriteLine("Введите балл по русскому языку пользователя №" + i);
                    //Reading user input and getting rid of extra whitespaces
                    string userInput = Console.ReadLine().Trim();
                    //Output to show the user the data they entered
                    Console.WriteLine("Вы ввели: " + userInput);
                    //Reading user input and getting rid of extra whitespaces
                    try
                    {
                        russianLanguageScore = Convert.ToByte(
                            userInput);
                    }
                    catch (OverflowException)
                    {
                    }
                    catch (FormatException)
                    {
                    }

                    //set flag to true to notify the user about field restrictions
                    dataEntered = true;
                }

                #endregion

                #region History Score

                //Initialized History Score variable with default value
                byte historyScore = default;

                //Set dataEntered flag to false before we ask for the next user input
                dataEntered = false;

                //Make sure user puts his data
                //And the rule to check if History Score is correct
                while (!((historyScore > 2) && (historyScore <= 100)))
                {
                    //An expression to skip educational messages if user knows the limitations
                    if (dataEntered)
                    {
                        //Notified the user about Score rules
                        Console.WriteLine("Мы ожидаем либо запись в аттестате от 3 до 5, либо оценку по ЕГЭ, не превышающую 100 баллов." +
                                          "\nКолы и двойки нам мало интересны в любом случае.");
                    }

                    //Ask to enter Score for the user
                    Console.WriteLine("Введите балл по Истории пользователя №" + i);
                    //Reading user input and getting rid of extra whitespaces
                    string userInput = Console.ReadLine().Trim();
                    //Output to show the user the data they entered
                    Console.WriteLine("Вы ввели: " + userInput);
                    //Reading user input and getting rid of extra whitespaces
                    try
                    {
                        historyScore = Convert.ToByte(
                            userInput);
                    }
                    catch (OverflowException)
                    {
                    }
                    catch (FormatException)
                    {
                    }

                    //set flag to true to notify the user about field restrictions
                    dataEntered = true;
                }

                #endregion

                #region Mathematics Score
                byte mathematicsScore = default;

                //Set dataEntered flag to false before we ask for the next user input
                dataEntered = false;

                //Make sure user puts his data
                //And the rule to check if Mathematics Score is correct
                while (!((mathematicsScore > 2) && (mathematicsScore <= 100)))
                {
                    //An expression to skip educational messages if user knows the limitations
                    if (dataEntered)
                    {
                        //Notified the user about Score rules
                        Console.WriteLine("Мы ожидаем либо запись в аттестате от 3 до 5, либо оценку по ЕГЭ, не превышающую 100 баллов." +
                                          "\nКолы и двойки нам мало интересны в любом случае.");
                    }

                    //Ask to enter Score for the user
                    Console.WriteLine("Введите балл по Математики пользователя №" + i);
                    //Reading user input and getting rid of extra whitespaces
                    string userInput = Console.ReadLine().Trim();
                    //Output to show the user the data they entered
                    Console.WriteLine("Вы ввели: " + userInput);
                    //Reading user input and getting rid of extra whitespaces
                    try
                    {
                        mathematicsScore = Convert.ToByte(
                            userInput);
                    }
                    catch (OverflowException)
                    {
                    }
                    catch (FormatException)
                    {
                    }

                    //set flag to true to notify the user about field restrictions
                    dataEntered = true;
                }

                i++;

                #endregion

                this.Users.Add(
                    new User(
                        userName,
                        userAge,
                        userHeight,
                        new Attestat(russianLanguageScore, historyScore, mathematicsScore)
                    ));

            }

        }

        /// <summary>
        /// Метод вывода компании в консоль
        /// </summary>
        /// <param name="Text">Вспомогательный текст, который будет напечатан перед выводом базы</param>
        public void Print(string Text)
        {
            Console.WriteLine(Text);    // Печать в консоль вспомогательного текста

            // Изменяем цвет шрифта для печати в консоли на DarkBlue
            Console.ForegroundColor = ConsoleColor.Magenta;

            // Выводим Заголовки колонок списка пользователей
            Console.WriteLine($"{"Имя",20} {"Возраст",20} {"Рост",20} {"Русский", 5} {"История",5} {"Математика",5}");

            // Изменяем цвет шрифта для печати в консоли на Gray
            Console.ForegroundColor = ConsoleColor.Gray;

            
            foreach (var user in this.Users) 
            {                                    // Печатаем в консоль всех работников
                Console.WriteLine(user);       
            }                                    //

            Console.WriteLine($"Итого: {this.Users.Count}\n");    // Сводный отчёт. Сколько работников распечатано
        }

    }
}