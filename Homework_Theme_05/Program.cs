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
            Console.WriteLine("\n2.1. Создать метод, принимающий  текст и возвращающий слово, содержащее минимальное количество букв.");
            Console.WriteLine("\nPlease write a string of text.");

            Console.WriteLine($"\nOne of the shortest words is: {StringMagic.OneOfTheShortestWords(Console.ReadLine())}");

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// Subroutine to demonstrate Task2_2
        /// Создать метод, принимающий  текст и возвращающий слово(слова) с максимальным количеством букв 
        /// Примечание: слова в тексте могут быть разделены символами (пробелом, точкой, запятой)
        /// </summary>
        internal static void Task2_2()
        {
            Console.WriteLine("\n2.2. Создать метод, принимающий  текст и возвращающий слово(слова) с максимальным количеством букв.");
            Console.WriteLine("\nPlease write a string of text.");
            
            Console.WriteLine($"\nAll the longest words are: {string.Join(", ", StringMagic.AllTheLongestWords(Console.ReadLine()))}");

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// Subroutine to demonstrate Task3
        /// Задание 3. Создание метода, принимающего строку и возвращающего новую строку, в которой удалены все рядом стоящие повторяющиеся символы.
        /// </summary>
        internal static void Task3()
        {
            Console.WriteLine("\n3. Создание метода, принимающего строку и возвращающего новую строку, в которой удалены все рядом стоящие повторяющиеся символы.");
            Console.WriteLine("\nPlease write a string of text.");
            Console.WriteLine($"\nEye friendly string is: {StringMagic.RemoveSymbolsThatRepeat(Console.ReadLine())}");

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// Subroutine to demonstrate Task4
        /// Задание 4. Написание метода, определяющего, является ли последовательность чисел прогрессией
        /// Создан метод, который принимает массив чисел как параметр.
        /// Метод определяет, являются ли числа в массиве арифметической или геометрической прогрессией или массив не содержит прогрессии.
        /// Метод возвращает результат в виде строки или перечисления.
        /// </summary>
        internal static void Task4()
        {
            Console.WriteLine("\n4. Задание 4. Написание метода, определяющего, является ли последовательность чисел прогрессией" +
                              "\nСоздан метод, который принимает массив чисел как параметр." +
                              "\nМетод определяет, являются ли числа в массиве арифметической или геометрической прогрессией или массив не содержит прогрессии." +
                              "\nМетод возвращает результат в виде строки или перечисления.");

            ushort numberOfElements = 6;
            double differenceOrCommonRatio = -3.5d;
            double first = -5d;
            double[] arithmetic = Progressions.GenerateArithmeticProgression(first, differenceOrCommonRatio, numberOfElements);
            double[] geometric = Progressions.GenerateGeometricProgression(first, differenceOrCommonRatio, numberOfElements);

            double[] oneElementZero = {0};
            double[] oneElementNotZero = { 5.5 };
            double[] twoElementsZero = { 0,0 };
            double[] twoElementNotZero = { 5.5, 5.5 };
            double[] threeElementsNonZero = { 0, 1, 2 };
            double[] fourElementsNotZero = { -1, 3, -9, 27 };
            double[] fiveRandomElements = { -1, 68, 32.784, 23423, -2521.2352 };


            Progressions.PrintProgression(arithmetic, $"\nThe first {numberOfElements} elements of Arithmetic Progression with a1 = {first} and difference = {differenceOrCommonRatio}");
            Console.WriteLine($"\nThis progression is { (Progressions.Sequence)Progressions.IsProgression(arithmetic) }");

            Progressions.PrintProgression(geometric,$"\nThe first {numberOfElements} elements of Geometric Progression with a1 = {first} and common ratio = {differenceOrCommonRatio}");
            Console.WriteLine($"\nThis progression is { (Progressions.Sequence)Progressions.IsProgression(geometric) }");

            Progressions.PrintProgression(oneElementZero, $"\nThe first {oneElementZero.Length} element(s) of a sequence with a1 = {oneElementZero[0]}");
            Console.WriteLine($"\nThis progression is { (Progressions.Sequence)Progressions.IsProgression(oneElementZero) }");

            Progressions.PrintProgression(oneElementNotZero, $"\nThe first {oneElementNotZero.Length} element(s) of a sequence with a1 = {oneElementNotZero[0]}");
            Console.WriteLine($"\nThis progression is { (Progressions.Sequence)Progressions.IsProgression(oneElementNotZero) }");

            Progressions.PrintProgression(twoElementsZero, $"\nThe first {twoElementsZero.Length} element(s) of a sequence with a1 = {twoElementsZero[0]}");
            Console.WriteLine($"\nThis progression is { (Progressions.Sequence)Progressions.IsProgression(twoElementsZero) }");

            Progressions.PrintProgression(twoElementNotZero, $"\nThe first {twoElementNotZero.Length} element(s) of a sequence with a1 = {twoElementNotZero[0]}");
            Console.WriteLine($"\nThis progression is { (Progressions.Sequence)Progressions.IsProgression(twoElementNotZero) }");

            Progressions.PrintProgression(threeElementsNonZero, $"\nThe first {threeElementsNonZero.Length} element(s) of a sequence with a1 = {threeElementsNonZero[0]}");
            Console.WriteLine($"\nThis progression is { (Progressions.Sequence)Progressions.IsProgression(threeElementsNonZero) }");

            Progressions.PrintProgression(fourElementsNotZero, $"\nThe first {fourElementsNotZero.Length} element(s) of a sequence with a1 = {fourElementsNotZero[0]}");
            Console.WriteLine($"\nThis progression is { (Progressions.Sequence)Progressions.IsProgression(fourElementsNotZero) }");

            Progressions.PrintProgression(fiveRandomElements, $"\nThe first {fiveRandomElements.Length} element(s) of a sequence with a1 = {fiveRandomElements[0]}");
            Console.WriteLine($"\nThis progression is { (Progressions.Sequence)Progressions.IsProgression(fiveRandomElements) }");

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// Subroutine to demonstrate Task5
        /// *Задание 5
        /// Вычислить, используя рекурсию, функцию Аккермана:
        /// A(2, 5), A(1, 2)
        /// A(n, m) = m + 1, если n = 0,
        ///         = A(n - 1, 1), если n <> 0, m = 0,
        ///         = A(n - 1, A(n, m - 1)), если n> 0, m > 0.
        /// </summary>
        internal static void Task5()
        {
            Console.WriteLine("\n. Задание 5. Вычислить, используя рекурсию, функцию Аккермана: A(2, 5), A(1, 2)");
            Console.WriteLine($"\nAckermann Function for m = 2 and n = 5 equals: {Progressions.AckermannFunction(2, 5)}");
            Console.WriteLine($"\nAckermann Function for m = 1 and n = 2 equals: {Progressions.AckermannFunction(1, 2)}");

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// The program that demonstrates Homework_Theme_05
        /// </summary>
        private static void Main()
        {
            //I have to use unicode for input/output values
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            Console.WriteLine("Вы запустили пачку решений для \"Homework_Theme_05 5.5 Домашняя работа\".");

            ////Task 1 part 1
            Task1_1();

            ////Task 1 part 2
            Task1_2();

            ////Task 1 part 3
            Task1_3();

            ////Task 1 part 4
            Task1_4();

            //Task 2 part 1
            Task2_1();

            //Task 2 part 2
            Task2_2();

            //Task 3
            Task3();

            //Task 4
            Task4();

            //Task 5
            Task5();

            Console.ReadKey();
        }
    }
}
