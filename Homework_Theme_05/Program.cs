using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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
        /// Changes signs for every element of the matrix.
        /// </summary>
        /// <param name="matrix">Input matrix.</param>
        /// <returns>Output matrix with the opposite signs.</returns>
        private static int[,] MatrixChangeSign(int[,] matrix)
        {
            var rows = matrix.GetLength(0);
            var columns = matrix.GetLength(1);
            var result = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    result[i, j] = matrix[i, j] *-1;
                }
            }

            return result;
        }

        /// <summary>
        /// Sums of two arrays.
        /// </summary>
        /// <param name="matrix1">First addend.</param>
        /// <param name="matrix2">First addend.</param>
        /// <returns>Returns a matrix that sum of two input matrices.</returns>
        private static int[,] AddMatrices(int[,] matrix1, int[,] matrix2)
        {
            if (matrix1.GetLength(0) != matrix2.GetLength(0) || matrix1.GetLength(1) != matrix2.GetLength(1))
            {
                throw new Exception("They are supposed to be of the same size.");
            }

            var rows = matrix1.GetLength(0);
            var columns = matrix1.GetLength(1);
            var result = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }

            return result;
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

        /// <summary>
        /// Makes sure a matrix can be added to another one without exceeding max/min values for their data type.
        /// And some other restriction like their sizes.
        /// </summary>
        /// <param name="matrix">First addend to check.</param>
        /// <param name="matrix2">First addend to check.</param>
        /// <returns></returns>
        private static bool ValidateMatrixOperation(int[,] matrix, int[,] matrix2)
        {
            if (matrix.GetLength(0) != matrix2.GetLength(0) || matrix.GetLength(1) != matrix2.GetLength(1))
            {
                Console.WriteLine($"The result matrix cannot be properly created because they have different sizes.");
                return false;
            }

            var rows = matrix.GetLength(0);
            var columns = matrix.GetLength(1);
            var result = new long[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    result[i, j] = (long)matrix[i, j] + (long)matrix2[i, j];
                    if (result[i,j] > int.MaxValue || result[i,j] < int.MinValue)
                    {
                        Console.WriteLine($"The result matrix cannot be properly created because a result value {result[i, j]}" +
                                          $" is below {int.MinValue} or above {int.MaxValue}.");
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Makes sure a matrix can be multiplied by scalar without exceeding max/min values for its data type.
        /// </summary>
        /// <param name="matrix">Input matrix for multiplication by scalar.</param>
        /// <param name="scalar">Input scalar for the multiplication.</param>
        /// <returns>true if multiplication possible, else - false.</returns>
        private static bool ValidateMatrixOperation(int[,] matrix, int scalar)
        {
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
            Console.WriteLine("1.1. Создать метод, принимающий число и матрицу, возвращающий матрицу умноженную на число.");

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
                Console.WriteLine("\nWould you like to change the input values (yes/no)?");
                while (Console.ReadLine() == "yes")
                {
                    Task1_1();
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                }
            }
        }

        /// <summary>
        /// Subroutine to demonstrate Task1_2
        /// 1.2. Создать метод, принимающий две матрицы и возвращающий их сумму
        /// </summary>
        internal static void Task1_2()
        {
            Console.WriteLine("1.2. Создать метод, принимающий две матрицы и возвращающий их сумму.");

            var rows = RequestByte("\nPlease enter a number of rows for a matrix.");
            var columns = RequestByte("\nPlease enter a number of columns for the matrix.");

            var firstMatrix = GenerateMatrix(rows, columns, -rows, columns);
            PrintMatrix(firstMatrix, "\nThe first addend matrix:");

            //Kinda have to sleep the thread to get another set of values from random generator

            var secondMatrix = GenerateMatrix(rows, columns, -rows, columns);
            PrintMatrix(secondMatrix, "\nThe second addend matrix:");

            if (ValidateMatrixOperation(firstMatrix, secondMatrix))
            {
                PrintMatrix(AddMatrices(firstMatrix, secondMatrix), "\nResult matrix after addition:");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\nWould you like to change the input values (yes/no)?");
                while (Console.ReadLine() == "yes")
                {
                    Task1_2();
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                }
            }
        }

        /// <summary>
        /// Subroutine to demonstrate Task1_3
        /// 1.3. Создать метод, принимающий две матрицы и возвращающий их разность
        /// </summary>
        internal static void Task1_3()
        {
            Console.WriteLine("1.3. Создать метод, принимающий две матрицы и возвращающий их разность.");

            var rows = RequestByte("\nPlease enter a number of rows for a matrix.");
            var columns = RequestByte("\nPlease enter a number of columns for the matrix.");

            var firstMatrix = GenerateMatrix(rows, columns, -rows, columns);
            PrintMatrix(firstMatrix, "\nThe subtrahend matrix:");

            //Kinda have to sleep the thread to get another set of values from random generator
            Thread.Sleep(10);

            var secondMatrix = GenerateMatrix(rows, columns, -rows, columns);
            PrintMatrix(secondMatrix, "\nThe minuend matrix:");

            int[,] nagated = MatrixChangeSign(secondMatrix);

            if (ValidateMatrixOperation(firstMatrix, nagated))
            {
                PrintMatrix(AddMatrices(firstMatrix, nagated), "\nDifference matrix:");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\nWould you like to change the input values (yes/no)?");
                while (Console.ReadLine() == "yes")
                {
                    Task1_2();
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

            //Task 1 part 2
            Task1_2();

            //Task 1 part 3
            Task1_3();
            

            //Task 1 part 4
            // 1.4. Создать метод, принимающий две матрицу, возвращающий их произведение








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
