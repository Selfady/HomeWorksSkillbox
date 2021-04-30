using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_05
{
    class Program
    { 
        /// <summary>
        /// Writes a message to console, reads user input and checks its type.
        /// If the value is not in given range a message user in notified and has to enter something again.
        /// </summary>
        /// <param name="message">A message that tells the user what to enter</param>
        /// <returns></returns>
        public static byte RequestByte(string message)
       {
           byte parsed;
           Console.WriteLine(message);

           while (!byte.TryParse(Console.ReadLine(), out parsed))
           {
               Console.WriteLine($"Enter a number in range from {byte.MinValue} to {byte.MaxValue}");
           }

           return parsed;
       }

        /// <summary>
        /// Writes a message to console, reads user input and checks its type.
        /// If the value is not in given range a message user in notified and has to enter something again.
        /// </summary>
        /// <param name="message">A message that tells the user what to enter</param>
        /// <returns></returns>
        private static int RequestInt(string message)
        {
            int parsed;
            Console.WriteLine(message);

            while (!int.TryParse(Console.ReadLine(), out parsed))
            {
                Console.WriteLine($"Enter a number in range from {int.MinValue} to {int.MaxValue}");
            }

            return parsed;
        }

        /// <summary>
        /// Generates a matrix with given number of rows and columns
        /// and initializes it with random numbers from int.MinValue to int.MaxValue range. 
        /// </summary>
        /// <param name="rows">Number of rows in the matrix.</param>
        /// <param name="columns">Number of columns in the matrix.</param>
        /// <returns>Initialized array</returns>
        private static int[,] GenerateMatrix(byte rows, byte columns)
        {
            int[,] matrix = new int[rows,columns];
            Random rnd = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = rnd.Next(int.MinValue, int.MaxValue);
                }
            }

            return matrix;
        }

        /// <summary>
        /// Generates a matrix with given number of rows and columns
        /// and initializes it with random numbers from the given data range. 
        /// </summary>
        /// <param name="rows">Number of rows in the matrix.</param>
        /// <param name="columns">Number of columns in the matrix.</param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns>Initialized array</returns>
        private static int[,] GenerateMatrix(byte rows, byte columns, int min, int max)
        {
            int[,] matrix = new int[rows, columns];
            Random rnd = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = rnd.Next(min, max);
                }
            }

            return matrix;
        }

        /// <summary>
        /// Prints a header message and a matrix into the console.
        /// </summary>
        /// <param name="matrix">A matrix to print.</param>
        /// <param name="message">A header message to print.</param>
        private static void PrintMatrix(int[,] matrix, string message)
        {
            var rows = matrix.GetLength(0);
            var columns = matrix.GetLength(1);
            const byte digitsWithSpace = 12;

            Console.WriteLine(message);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{matrix[i,j],digitsWithSpace}");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Multiplies a matrix by scalar.
        /// </summary>
        /// <param name="matrix">A matrix.</param>
        /// <param name="scalar">A number.</param>
        /// <returns>The result of the multiplication.</returns>
        private static int[,] MultiplyMatrixByScalar(int[,] matrix, int scalar)
        {
            var rows = matrix.GetLength(0);
            var columns = matrix.GetLength(1);
            var result = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    result[i, j] = matrix[i, j] * scalar;
                }
            }

            return result;
        }

        /// <summary>
        /// Returns min or max value for the given matrix
        /// regarding of the input bool.
        /// </summary>
        /// <param name="matrix">Input matrix.</param>
        /// <param name="maximum">returns max value if true and min if false.</param>
        private static int MatrixExtremum(int[,] matrix, bool maximum)
        {
            var rows = matrix.GetLength(0);
            var columns = matrix.GetLength(1);
            var min = int.MaxValue; 
            var max = int.MinValue;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (matrix[i,j] <= min)
                        min = matrix[i, j];
                    if (matrix[i,j] >= max)
                        max = matrix[i, j];
                }
            }

            return maximum ? max : min;
        }

        private static bool ValidateMatrixOperation(int[,] matrix, int scalar)
        {
            //bool valid = default;
            //var rows = matrix.GetLength(0);
            //var columns = matrix.GetLength(1);

            //var maxByScalar = MatrixExtremum(matrix, true) * (long) scalar;
            //var minByScalar = MatrixExtremum(matrix, false) * (long) scalar;

            long[] extremes = { MatrixExtremum(matrix, true) * (long)scalar, 
                MatrixExtremum(matrix, false) * (long)scalar };
            Array.Sort(extremes);
            
            if (extremes[1] > int.MaxValue)
            {
                Console.WriteLine($"The result matrix cannot be properly created because {extremes[1]} is above {int.MaxValue}.");
                return false;
            }

            if (extremes[0] < int.MinValue)
            {
                Console.WriteLine($"The result matrix cannot be properly created because {extremes[0]} is below {int.MinValue}.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Subroutine to demonstrate Task1_1
        /// 1.1. Создать метод, принимающий число и матрицу, возвращающий матрицу умноженную на число
        /// </summary>
         internal static void Task1_1()
        {
            var rows = RequestByte("\nPlease enter a number of rows for a matrix.");
            var columns = RequestByte("\nPlease enter a number of columns for the matrix.");

            var firstMatrix = GenerateMatrix(rows, columns,-rows,columns);
            PrintMatrix(firstMatrix, "\nThe matrix:");

            var scalar = RequestInt("\nPlease enter a scalar to multiply the first matrix by.");

            if (ValidateMatrixOperation(firstMatrix, scalar))
            {
                PrintMatrix(MultiplyMatrixByScalar(firstMatrix, scalar), "\nResult matrix multiplied by the scalar:");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Would you like to change the input values (yes/no)?");
                while (Console.ReadLine() == "yes")
                {
                    Task1_1();
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                }
            }
        }

        static void Main(string[] args)
        {
            //I have to use unicode for input/output values
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            Console.WriteLine("Вы запустили пачку решений для \"Homework_Theme_05 5.5 Домашняя работа\".");

            //Task 1 part 1
            Task1_1();


            //Overloaded methods to validate input parameters
            //A method for scalar multoplication
            //A method for matrix addition
            //a methos to inverst sign
            //matrix multiplication




            // Задание 1.
            // Воспользовавшись решением задания 3 четвертого модуля
            // 1.1. Создать метод, принимающий число и матрицу, возвращающий матрицу умноженную на число
            // 1.2. Создать метод, принимающий две матрицу, возвращающий их сумму
            // 1.3. Создать метод, принимающий две матрицу, возвращающий их произведение








            // Задание 2.
            // 1. Создать метод, принимающий  текст и возвращающий слово, содержащее минимальное количество букв
            // 2.* Создать метод, принимающий  текст и возвращающий слово(слова) с максимальным количеством букв 
            // Примечание: слова в тексте могут быть разделены символами (пробелом, точкой, запятой) 
            // Пример: Текст: "A ББ ВВВ ГГГГ ДДДД  ДД ЕЕ ЖЖ ЗЗЗ"
            // 1. Ответ: А
            // 2. ГГГГ, ДДДД
            //
            // Задание 3. Создать метод, принимающий текст. 
            // Результатом работы метода должен быть новый текст, в котором
            // удалены все кратные рядом стоящие символы, оставив по одному 
            // Пример: ПППОООГГГООООДДДААА >>> ПОГОДА
            // Пример: Ххххоооорррооошшшиий деееннннь >>> хороший день
            // 
            // Задание 4. Написать метод принимающий некоторое количесво чисел, выяснить
            // является заданная последовательность элементами арифметической или геометрической прогрессии
            // 
            // Примечание
            //             http://ru.wikipedia.org/wiki/Арифметическая_прогрессия
            //             http://ru.wikipedia.org/wiki/Геометрическая_прогрессия
            //
            // *Задание 5
            // Вычислить, используя рекурсию, функцию Аккермана:
            // A(2, 5), A(1, 2)
            // A(n, m) = m + 1, если n = 0,
            //         = A(n - 1, 1), если n <> 0, m = 0,
            //         = A(n - 1, A(n, m - 1)), если n> 0, m > 0.
            // 
            // Весь код должен быть откоммментирован

        }
    }
}
