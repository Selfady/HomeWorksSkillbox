using System;
using System.Text;
using System.Threading;

namespace Homework_Theme_05
{
    class Program
    {
        /// <summary>
        /// Subroutine to demonstrate Task1_1
        /// 1.1. Создать метод, принимающий число и матрицу, возвращающий матрицу умноженную на число
        /// </summary>
         internal static void Task1_1()
        {
            Console.WriteLine("\n1.1. Создать метод, принимающий число и матрицу, возвращающий матрицу умноженную на число.");

            var rows = Dialogues.RequestByte("\nPlease enter a number of rows for a matrix.");
            var columns = Dialogues.RequestByte("\nPlease enter a number of columns for the matrix.");

            var firstMatrix = Matrix.GenerateMatrix(rows, columns,-rows,columns);
            Matrix.PrintMatrix(firstMatrix, "\nThe matrix:");

            var scalar = Dialogues.RequestInt("\nPlease enter a scalar to multiply the first matrix by.");

            if (Matrix.ValidateMatrixOperation(firstMatrix, scalar))
            {
                Matrix.PrintMatrix(Matrix.MultiplyMatrixByScalar(firstMatrix, scalar), "\nResult matrix multiplied by the scalar:");
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\nWould you like to change the input values (yes/no)?");
                while (Console.ReadLine() == "yes")
                {
                    Task1_1();
                    Console.WriteLine("\nPress any key to continue.");
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
            Console.WriteLine("\n1.2. Создать метод, принимающий две матрицы и возвращающий их сумму.");

            var rows = Dialogues.RequestByte("\nPlease enter a number of rows for a matrix.");
            var columns = Dialogues.RequestByte("\nPlease enter a number of columns for the matrix.");

            var firstMatrix = Matrix.GenerateMatrix(rows, columns, -rows, columns);
            Matrix.PrintMatrix(firstMatrix, "\nThe first addend matrix:");

            //Kinda have to sleep the thread to get another set of values from random generator
            Thread.Sleep(10);

            var secondMatrix = Matrix.GenerateMatrix(rows, columns, -rows, columns);
            Matrix.PrintMatrix(secondMatrix, "\nThe second addend matrix:");

            if (Matrix.ValidateMatrixOperation(firstMatrix, secondMatrix))
            {
                Matrix.PrintMatrix(Matrix.AddMatrices(firstMatrix, secondMatrix), "\nResult matrix after addition:");
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\nWould you like to change the input values (yes/no)?");
                while (Console.ReadLine() == "yes")
                {
                    Task1_2();
                    Console.WriteLine("\nPress any key to continue.");
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
            Console.WriteLine("\n1.3. Создать метод, принимающий две матрицы и возвращающий их разность.");

            var rows = Dialogues.RequestByte("\nPlease enter a number of rows for a matrix.");
            var columns = Dialogues.RequestByte("\nPlease enter a number of columns for the matrix.");

            var firstMatrix = Matrix.GenerateMatrix(rows, columns, -rows, columns);
            Matrix.PrintMatrix(firstMatrix, "\nThe subtrahend matrix:");

            //Kinda have to sleep the thread to get another set of values from random generator
            Thread.Sleep(10);

            var secondMatrix = Matrix.GenerateMatrix(rows, columns, -rows, columns);
            Matrix.PrintMatrix(secondMatrix, "\nThe minuend matrix:");

            int[,] nagated = Matrix.MatrixChangeSign(secondMatrix);

            if (Matrix.ValidateMatrixOperation(firstMatrix, nagated))
            {
                Matrix.PrintMatrix(Matrix.AddMatrices(firstMatrix, nagated), "\nDifference matrix:");
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\nWould you like to change the input values (yes/no)?");
                while (Console.ReadLine() == "yes")
                {
                    Task1_3();
                    Console.WriteLine("\nPress any key to continue.");
                    Console.ReadKey();
                }
            }
        }

        /// <summary>
        /// Subroutine to demonstrate Task1_4
        /// 1.4. Создать метод, принимающий две матрицы, возвращающий их произведение
        /// </summary>
        internal static void Task1_4()
        {
            Console.WriteLine("\n1.4. Создать метод, принимающий две матрицы, возвращающий их произведение.");

            var rows = Dialogues.RequestByte("\nPlease enter a number of rows for a matrix.");
            var columns = Dialogues.RequestByte("\nPlease enter a number of columns for the matrix.");

            var firstMatrix = Matrix.GenerateMatrix(rows, columns, -rows, columns);
            Matrix.PrintMatrix(firstMatrix, "\nThe left matrix:");

            //Kinda have to sleep the thread to get another set of values from random generator
            Thread.Sleep(10);

            var rowsSecond = Dialogues.RequestByte("\nPlease enter a number of rows for the second matrix.");

            while (columns != rowsSecond)
            {
                Console.WriteLine("Multiplication of two matrices is defined if and only if the number of columns of the left matrix is the same as the number of rows of the right matrix.");
                rowsSecond = Dialogues.RequestByte("\nPlease enter a number of rows for the second matrix.");
            }

            var columnsSecond = Dialogues.RequestByte("\nPlease enter a number of columns for the second matrix.");

            var secondMatrix = Matrix.GenerateMatrix(rowsSecond, columnsSecond, -rowsSecond, columnsSecond);
            Matrix.PrintMatrix(secondMatrix, "\nThe right matrix:");
            
            if (Matrix.ValidateMatrixOperation(firstMatrix, secondMatrix,true))
            {
                Matrix.PrintMatrix(Matrix.MultiplyMatrices(firstMatrix, secondMatrix), "\nFirst Matrix x Second matrix:");
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\nWould you like to change the input values (yes/no)?");
                while (Console.ReadLine() == "yes")
                {
                    Task1_4();
                    Console.WriteLine("\nPress any key to continue.");
                    Console.ReadKey();
                }
            }
        }

        /// <summary>
        /// Subroutine to demonstrate Task2_1
        /// Создать метод, принимающий  текст и возвращающий слово, содержащее минимальное количество букв
        /// </summary>
        internal static void Task2_1()
        {
            Console.WriteLine("\nPlease write a string of text.");
            var str = Console.ReadLine();
            Console.WriteLine(str.Split( ));


        }


        static void Main(string[] args)
        {
            //I have to use unicode for input/output values
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            Console.WriteLine("Вы запустили пачку решений для \"Homework_Theme_05 5.5 Домашняя работа\".");

            ////Task 1 part 1
            //Task1_1();

            ////Task 1 part 2
            //Task1_2();

            ////Task 1 part 3
            //Task1_3();

            ////Task 1 part 4
            //Task1_4();

            //Task 2 part 1
            Task2_1();

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
