using System;
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

            //A loop to enter data for every user
            int i = 1;
            while (i <= amountOfWorkers)
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

                #endregion


                
                i++;
            }
        


    Console.ReadLine();


            #region Задание 1

            /* Задание 1: Что нужно сделать
            Некоторая компания заинтересована в том, чтобы вы создали для неё приложение ― записную книжку. Сейчас в компании работает три сотрудника, именно они и будут пользователями приложения.

            Создайте переменные для этих пользователей. При этом раскрывать свои персональные данные они не захотели и предпочитают вводить их самостоятельно.

            Итого для каждого пользователя должны быть доступны переменные под следующие данные:
                имя,
                возраст,
                рост,
                баллы по русскому языку,
                баллы по истории,
                баллы по математике.
                При решении подумайте, какой тип данных под какую переменную подходит больше всего.
        
            Советы и рекомендации
                Клиент хочет, чтобы сотрудники вводили данные последовательно: сначала первый сотрудник введёт все свои данные, затем второй и, наконец, третий.
                Когда пользователь будет вводить данные, он может сделать ошибку и ввести, например, отрицательный рост или огромный балл по математике. Вам стоит предусмотреть этот момент.
                При возникновении ошибки пользователю наверняка захочется увидеть сообщение о ней, но никак не пустой экран.
                Не используйте в названиях переменных транслит.
        
            Что оценивается
                Должны быть объявлены переменные под данные для трёх сотрудников.
                Переменные должны быть подходящего типа: для баллов по предметам ― целочисленный тип, а для имени пользователя ― строка.
                Должен быть организован ввод данных с клавиатуры.
            */



            #endregion





            // Заказчик просит написать программу «Записная книжка». Оплата фиксированная - $ 120.

            // В данной программе, должна быть возможность изменения значений нескольких переменных для того,
            // чтобы персонифецировать вывод данных, под конкретного пользователя.

            // Для этого нужно: 
            // 1. Создать несколько переменных разных типов, в которых могут храниться данные
            //    - имя;
            //    - возраст;
            //    - рост;
            //    - баллы по трем предметам: история, математика, русский язык;

            // 2. Реализовать в системе автоматический подсчёт среднего балла по трем предметам, 
            //    указанным в пункте 1.

            // 3. Реализовать возможность печатки информации на консоли при помощи 
            //    - обычного вывода;
            //    - форматированного вывода;
            //    - использования интерполяции строк;

            // 4. Весь код должен быть откомментирован с использованием обычных и хml-комментариев

            // **
            // 5. В качестве бонусной части, за дополнительную оплату $50, заказчик просит реализовать 
            //    возможность вывода данных в центре консоли.

            /*
            2.7 Домашняя работа

            Задача
            Цель домашнего задания
            Научиться:

            использовать в своих программах различные типы данных,
            применять форматированный вывод для строк;
            пользоваться интерполяцией.


            Что входит в домашнее задание
            Создать несколько переменных разных типов, в которых могут храниться данные.
            Реализовать в системе автоматический подсчёт среднего балла по трём предметам из пункта 1.
            Реализовать возможность вывода информации на консоли.
            Прокомментировать весь код с использованием обычных или XML-комментариев.
            Реализовать возможность вывода данных в центре консоли.


            Задание 1. Создание нескольких переменных разных типов, в которых могут храниться данные


            Что нужно сделать
            Некоторая компания заинтересована в том, чтобы вы создали для неё приложение ― записную книжку. Сейчас в компании работает три сотрудника, именно они и будут пользователями приложения.

            Создайте переменные для этих пользователей. При этом раскрывать свои персональные данные они не захотели и предпочитают вводить их самостоятельно.

            Итого для каждого пользователя должны быть доступны переменные под следующие данные:

            имя,
            возраст,
            рост,
            баллы по русскому языку,
            баллы по истории,
            баллы по математике.
            При решении подумайте, какой тип данных под какую переменную подходит больше всего.



            Советы и рекомендации
            Клиент хочет, чтобы сотрудники вводили данные последовательно: сначала первый сотрудник введёт все свои данные, затем второй и, наконец, третий.
            Когда пользователь будет вводить данные, он может сделать ошибку и ввести, например, отрицательный рост или огромный балл по математике. Вам стоит предусмотреть этот момент.
            При возникновении ошибки пользователю наверняка захочется увидеть сообщение о ней, но никак не пустой экран.
            Не используйте в названиях переменных транслит.


            Что оценивается
            Должны быть объявлены переменные под данные для трёх сотрудников.
            Переменные должны быть подходящего типа: для баллов по предметам ― целочисленный тип, а для имени пользователя ― строка.
            Должен быть организован ввод данных с клавиатуры.


            Как отправить задание на проверку
            Работу необходимо сдавать в одном из следующих форматов:

            Проект в архиве со всеми файлами формата ZIP или RAR.
            Ссылка на архив на Google Диске или аналогах.
            Ссылка на репозиторий GitHub с исходным кодом домашнего задания.


            Задание 2. Реализация в системе автоматического подсчёта среднего балла по трём предметам, указанным в пункте 1


            Что нужно сделать
            Сотрудникам необходимо получить свой средний балл по трём предметам, однако самостоятельно рассчитывать его они не хотят. Ваша задача ― автоматизировать этот процесс. Для этого:

            создайте переменную под средний балл для каждого сотрудника,
            рассчитайте среднее арифметическое баллов для каждого сотрудника,
            выведите средний балл на экран.

            Советы и рекомендации
            При выводе среднего балла стоит округлить его до двух знаков после запятой.
            Не стоит выводить средний балл как отдельно стоящее число. Вам следует добавить подсказку пользователю, что именно это число является средним баллом и никакое другое. 
            Если для баллов вы использовали целочисленный тип, возможно, вам понадобится преобразование типов, так как результат целочисленного деления ― целочисленный, а средний балл может быть со знаком.


            Что оценивается
            Для каждого пользователя должен быть рассчитан средний балл.
            Каждый средний балл должен быть выведен на экран.


            Как отправить задание на проверку
            Задание является частью предыдущего. Отправьте их вместе.



            Задание 3. Реализация возможности вывода информации на консоли


            Что нужно сделать
            Каждый сотрудник компании высказал свои личные пожелания к тому, как должен быть осуществлён вывод информации о нём.



            Первый сотрудник предпочитает самый простой метод вывода ― обычный вывод.

            Второй сотрудник хотел бы, чтобы вы использовали форматированный вывод.

            Третий сотрудник, указал, что обязательным пунктом является использование интерполяции строк.



            Реализуйте возможность вывода информации из консоли, учитывая пожелания сотрудников:

            при помощи обычного вывода,
            при помощи форматированного вывода,
            используя интерполяцию строк.


            Что оценивается
            В задании должен быть реализован обычный вывод.
            В задании должен быть реализован форматированный вывод.
            В задании должен быть реализован вывод с использованием интерполяции строк.

            Как отправить задание на проверку
            Задание является частью предыдущего. Отправьте их вместе.



            Задание 4. Комментирование кода с использованием обычных или XML-комментариев


            Что нужно сделать
            Для того чтобы обеспечить читабельность кода, используйте следующие типы комментариев:

            обычные комментарии,
            многострочные комментарии,
            XML-комментарии.

            Советы и рекомендации
            Комментарии — это полезный инструмент, однако ваши переменные должны быть названы так, чтобы их назначение было понятно и без подсказок.


            Что оценивается
            В коде задания должны быть использованы комментарии.



            Как отправить задание на проверку
            Задание является частью предыдущего. Отправьте их вместе.



            Задание 5. Реализация возможности вывода данных в центре консоли


            Что нужно сделать
            Реализуйте вывод данных в центре консоли. Заказчик уточнил, что вы получите дополнительный перевод в 150$, если вам это удастся.



            Советы и рекомендации
            Убедитесь, что ваш вывод расположен по центру, а не начинается с него. Для этого вам необходимо использовать длину выводимой строки.
            Длину любой строки можно узнать с помощью свойства Length.


            Что оценивается
            Одна или несколько строк должны быть выведены по центру.



            Как отправить задание на проверку
            Задание является частью предыдущего. Отправьте их вместе.*/
        }
    }
}