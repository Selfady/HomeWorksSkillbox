using System;
using System.IO;
using System.IO.Compression;
using System.Runtime.CompilerServices;

namespace Homework_Theme_06
{ 
    /// <summary>
    ///  /// Домашнее задание
    ///
    /// Группа начинающих программистов решила поучаствовать в хакатоне с целью демонстрации
    /// своих навыков. 
    /// 
    /// Немного подумав они вспомнили, что не так давно на занятиях по математике
    /// они проходили тему "свойства делимости целых чисел". На этом занятии преподаватель показывал
    /// пример с использованием фактов делимости. 
    /// Пример заключался в следующем: 
    /// Написав на доске все числа от 1 до N, N = 50, преподаватель разделил числа на несколько групп
    /// так, что если одно число делится на другое, то эти числа попадают в разные руппы. 
    /// В результате этого разбиения получилось M групп, для N = 50, M = 6
    /// 
    /// N = 50
    /// Группы получились такими: 
    /// 
    /// Группа 1: 1
    /// Группа 2: 2 3 5 7 11 13 17 19 23 29 31 37 41 43 47
    /// Группа 3: 4 6 9 10 14 15 21 22 25 26 33 34 35 38 39 46 49
    /// Группа 4: 8 12 18 20 27 28 30 42 44 45 50
    /// Группа 5: 16 24 36 40
    /// Группа 6: 32 48
    /// 
    /// M = 6
    /// 
    /// ===========
    /// 
    /// N = 10
    /// Группы получились такими: 
    /// 
    /// Группа 1: 1
    /// Группа 2: 2 7 9
    /// Группа 3: 3 4 10
    /// Группа 4: 5 6 8
    /// 
    /// M = 4
    /// 
    /// Участники хакатона решили эту задачу, добавив в неё следующие возможности:
    /// 1. Программа считыват из файла (путь к которому можно указать) некоторое N, 
    ///    для которого нужно подсчитать количество групп
    ///    Программа работает с числами N не превосходящими 1 000 000 000
    ///   
    /// 2. В ней есть два режима работы:
    ///   2.1. Первый - в консоли показывается только количество групп, т е значение M
    ///   2.2. Второй - программа получает заполненные группы и записывает их в файл используя один из
    ///                 вариантов работы с файлами
    ///            
    /// 3. После выполения пунктов 2.1 или 2.2 в консоли отображается время, за которое был выдан результат 
    ///    в секундах и миллисекундах
    /// 
    /// 4. После выполнения пунта 2.2 программа предлагает заархивировать данные и если пользователь соглашается -
    /// делает это.
    /// 
    /// Попробуйте составить конкуренцию начинающим программистам и решить предложенную задачу
    /// (добавление новых возможностей не возбраняется)
    ///
    /// * При выполнении текущего задания, необходимо документировать код 
    ///   Как пометками, так и xml документацией
    ///   В обязательном порядке создать несколько собственных методов
    
    
    class Program
    {
        /// <summary>
        /// The method breaks a sequence from 1 to a given number into groups so that elements of the groups
        /// are not multipliers of each other.
        /// </summary>
        /// <param name="number">Maximum number of the sequence.</param>
        /// <param name="sw">Output stream.</param>
        public static void PrintAlmostHalf(int number, StreamWriter sw)
        {
            if (number <= 0 || number > 2_000_000_000)
            {
                throw new Exception("PrintAlmostHalf algorithm is not supposed to work with numbers outside of the range from 0 to 2_000_000_000");
            }

            var group = 1;
            while (true)
            {
                sw.Write("Group {0}: ", group);
                for (int i = number; i > number / 2; i--)
                {
                    sw.Write($"{i} ");
                }

                sw.WriteLine();

                if (number / 2 != 1)
                {
                    group++;
                    number /= 2;
                    continue;
                }
                else
                {
                    group++;
                    sw.Write($"Group {group}: 1");
                }

                break;
            }
        }

        /// <summary>
        /// Method gives the number of groups our sequence breaks into.
        /// </summary>
        /// <param name="number">Maximum number of the sequence.</param>
        /// <returns>The number of groups the sequence falls onto.</returns>
        public static double CalculateNumberOfGroups(int number)
        {
            return Math.Ceiling(Math.Log2(number));
        }

        /// <summary>
        /// Method to read integer from a file by given path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static int ReadNumberFromFile(string path)
        {
            int n = 0;

            using (var sr = new StreamReader(path))
            {
                string line;
                // Read and display lines from the file until the end of the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine("We have read \"{0}\" from the file", line);
                    if (!Int32.TryParse(line, out n))
                    {
                        //We expect the file doesn't have extra symbols..
                        Console.WriteLine("Could not read the file n = {0}", n);
                    }
                    else
                    {
                        n = Int32.Parse(line);
                    }
                }
            }

            return n;
        }

        /// <summary>
        /// Entrance point for the program.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //TODO: Dialog "Do you wanna save the groups on the disk?"
            //TODO: Display only groups or save into a file.
            //TODO: Archive the file?

            Console.WriteLine("This is a batch of solutions for \"Homework_Theme_06 6.6 Homework\"");
            Console.WriteLine("\nEnter the path to your file with a number from 1 to 1_000_000_000.");
            
            var path = Console.ReadLine();
            
            //Make the user enter a path to his file with input parameters
            while(!File.Exists(path))
            {
                Console.WriteLine("\nSuch a file doesn't exist by the given path, please enter the right path to the file.");
                Console.WriteLine("\nIf it helps, your current directory has the following files:");

                DirectoryInfo directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory()); 
                foreach (var item in directoryInfo.GetFiles())
                {
                    Console.WriteLine($"{item.Name}");           
                }

                path = Console.ReadLine();
            }

            //The number to generate sequence.
            int n = 0;

            n = ReadNumberFromFile(path);

            var start = DateTime.Now;

            Console.WriteLine("\nWe will have {0} groups.", CalculateNumberOfGroups(n));
            TimeSpan timeSpan = DateTime.Now.Subtract(start);
            Console.WriteLine($"\nThe operation took {timeSpan.TotalMilliseconds} Milliseconds to complete.");

            Console.WriteLine("\nWould you like to save the groups in a file y/n?");
            var decision = Console.ReadLine();

            if (decision == "y")
            {
                start = DateTime.Now;

                //Initializing a stream to work with result.txt file.
                using (StreamWriter sw = new StreamWriter("result.txt"))
                {
                    PrintAlmostHalf(n, sw);
                    timeSpan = DateTime.Now.Subtract(start);
                    Console.WriteLine($"\nThe operation took {timeSpan.TotalMilliseconds} Milliseconds to complete.");
                }

                Console.WriteLine("\nWould you like to create archived version of the file y/n?");
                decision = Console.ReadLine();

                if (decision == "y")
                {
                    string source = "result.txt";
                    string compressed = "result.zip";
                    using (FileStream ss = new FileStream(source, FileMode.OpenOrCreate))
                    {
                        using (FileStream ts = File.Create(compressed))   // поток для записи сжатого файла
                        {
                            // поток архивации
                            using (GZipStream cs = new GZipStream(ts, CompressionMode.Compress))
                            {
                                ss.CopyTo(cs); // копируем байты из одного потока в другой
                                Console.WriteLine("File {0} successively compressed. " +
                                                  "\nIts size on the disk was {1} bytes and now: {2}.",

                                    source,
                                    ss.Length,
                                    ts.Length);
                            }
                        }
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
