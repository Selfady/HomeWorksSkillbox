using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_01
{
    class Program
    {
        static void Main(string[] args)
        {
            // Установил codepage в UTF8 чтобы избавиться от русскеой корявицы в своей консоли
            Console.OutputEncoding = Encoding.UTF8;

            // Instantiated random number generator using system-supplied value as seed.
            Random randomizer = new Random();
            
            #region Задание 1

            // Задание 1. Переделать программу так, чтобы до первой волны увольнени в отделе было не более 20 сотрудников

            // Создали репозиторий в котором не больше 20 сотрудников но есть хотя бы 1 а то увольнять совсем некого
            Repository repositoryTask1 = new Repository(randomizer.Next(1, 20));

            // Печать в консоль всех сотрудников
            repositoryTask1.Print("База данных Задания 1 до преобразования");

            // Увольнение всех работников с именем "Агата"
            repositoryTask1.DeleteWorkerByName("Агата");

            // Печать в консоль сотрудников, которые не попали под увольнение
            repositoryTask1.Print("База данных Задания 1 после первого преобразования");

            // Увольнение всех работников с именем "Аделина"
            repositoryTask1.DeleteWorkerByName("Аделина");

            // Печать в консоль сотрудников, которые не попали под увольнение
            repositoryTask1.Print("База данных Задания 1 после второго преобразования");

            Console.ReadKey();
            #endregion

            #region Задание 2

            // Задание 2. Создать отдел из 40 сотрудников и реализовать несколько увольнений, по результатам
            //              которых в отделе болжно остаться не более 30 работников

            Repository repositoryTask2 = new Repository(40);

            // Печать в консоль всех сотрудников
            repositoryTask2.Print("База данных Задания 2 до преобразования");

            // Некий указатель на следующее потенциально подходящее для увольнения имя
            int i = 0;

            //цикл для организации нескольких (больше одного но не факт что меньше четырёх) увольнений
            while (repositoryTask2.Workers.Count >= 30)
            {
                //Берем первое имя из списка
                string nameToSack = repositoryTask2.Workers.ElementAtOrDefault(i).FirstName;
                //Считаем сколько их там вообще таких красивых
                int amount = repositoryTask2.Workers.Where(w => w.FirstName == nameToSack).Count();

                //Console.WriteLine(nameToSack);
                //Console.WriteLine(amount);

                //Проверяем не десять ли их, а то все итеративное увольнение запорят
                if (amount >= 10)
                {
                    i++;
                    Console.WriteLine("Мы так всех за раз уволим " + nameToSack + " не подходит, их " + amount + " штук");
                }

                // Радостно увольняем если их приемлимое количество
                if (amount < 10)
                {
                    // Увольнение всех работников с первым попавшимся именем
                    Console.WriteLine("Увольняем " + nameToSack + " " + amount + " штук");
                    repositoryTask2.DeleteWorkerByName(nameToSack);

                    // Печать в консоль сотрудников, которые не попали под увольнение
                    repositoryTask2.Print("База данных Задания 2 после "+ i + " преобразования");

                }
                //Черт его знает, что еще могло попасть в список, пропустим от греха
                else
                {
                    i++;
                }
            }
            Console.ReadKey();
            #endregion
            
            #region Задание 3

            // Задание 3. Создать отдел из 50 сотрудников и реализовать увольнение работников 
            // чья зарплата превышает 30000руб

            //Говорят надо 50 челвоек в отделе
            Repository repositoryTask3 = new Repository(50);

            // Печать в консоль всех сотрудников
            repositoryTask3.Print("База данных Задания 3 до преобразования");

            // Увольняем тем, кто получает больше 30000
            repositoryTask3.DeleteWorkerBySalary(30000);

            // Печать в консоль сотрудников, которые не попали под увольнение
            repositoryTask3.Print("База данных Задания 3 после первой оптимизации расходов");


            Console.ReadKey();
            #endregion


            #region Домашнее задание

            // Уровень сложности: просто
            // Задание 1. Переделать программу так, чтобы до первой волны увольнени в отделе было не более 20 сотрудников

            // Уровень сложности: средняя сложность
            // * Задание 2. Создать отдел из 40 сотрудников и реализовать несколько увольнений, по результатам
            //              которых в отделе болжно остаться не более 30 работников

            // Уровень сложности: сложно
            // ** Задание 3. Создать отдел из 50 сотрудников и реализовать увольнение работников
            //               чья зарплата превышает 30000руб



            #endregion

        }
    }
}
