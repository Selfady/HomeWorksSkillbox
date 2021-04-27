﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Homework_Theme_04
{

    class Program
    {
        static void Main(string[] args)
        {
            #region Finances

            // A 2D array to store the month report. Has 12 rows and 4 columns.
            int[,] report = new int[12, 4];

            //A simple array to store the worst month profits
            int[] worstMonthsProfits = new int[12];
            
            //Random generator to populate report array with data
            Random rnd = new Random();

            //Header output
            Console.WriteLine("{0,10} {1,10} {2,10} {3,10} ", "#month","income","expenses","profit");

            byte numberMonthWithProfit = default;


            //Populating report array with data and put the table in the console
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    //populating first column with the # of month
                    if (j==0)
                    {
                        report[i, j] = i+1;
                    }

                    if (j > 0 && j < 3)
                    {
                        //Here we generate the values for income and expenses
                        report[i, j] = rnd.Next(4);
                    }
                    if (j==3)
                    {
                        //Calculate the value for the last column
                        report[i, j] = report[i,1] - report[i,2];

                        //Calculating the number of months with profit
                        if (report[i, j] > 0)
                            numberMonthWithProfit++;
                    }
                    Console.Write("{0,10} ", report[i, j]);
                    worstMonthsProfits[i] = report[i, 3];
                }
                Console.WriteLine();
            }

            //Sort worst month array
            Array.Sort(worstMonthsProfits);

            //A variable to limit the number of the worst months and skip months with the same profit
            byte count = default;
            Console.WriteLine();

            for (var i = 0; i < worstMonthsProfits.Length; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine($"The worst profit = {worstMonthsProfits[i],5} month(s): {MonthsByProfit(worstMonthsProfits[i], report),25}");
                }
                else if ((i > 0) && (worstMonthsProfits[i] > worstMonthsProfits[i - 1]) && count == 0)
                {
                    Console.WriteLine($"The worst profit = {worstMonthsProfits[i],5} month(s): {MonthsByProfit(worstMonthsProfits[i], report),25}");
                    count++;
                }
                else if ((i > 0) && (worstMonthsProfits[i] > worstMonthsProfits[i - 1]) && count == 1)
                {
                    Console.WriteLine($"The worst profit = {worstMonthsProfits[i],5} month(s): {MonthsByProfit(worstMonthsProfits[i], report),25}");
                    count++;
                }
                else 
                {
                    if (count == 2)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine("\nThe number of months with positive profit: {0}", numberMonthWithProfit);

            #endregion Finances

            #region Pascal's triangle

            Console.WriteLine("\nEnter a number of rows for Pascal's triangle");
            var input = int.TryParse(Console.ReadLine(),out var numberOfStrings);
            if (!input)
            {
                Console.WriteLine("\nYou entered something strange, but i'll show you Pascal's Triangle for 10 rows");
                numberOfStrings = 10;
            }

            Console.WriteLine("\nPascal's triangle");

            //В строке с номером n (нумерация начинается с 0):
            //первое и последнее числа равны 1.
            long current = 1;
            //https://www.youtube.com/watch?v=lbl9nxwFWDw
            //(C от n по к) = X*(C от n по k-1), X = (n-k+1)/k
            for (var n = 0; n < numberOfStrings; n++)
            {
                string output = default;
                for (var k = 0; k <= n; k++)
                {
                   current = k == 0 || n == 0 ? 1 : current * (n - k + 1) / k;

                   output = $"{output,10}{current,10}";

                }

                //Console.WriteLine(Console.WindowWidth-20);
                //Console.WriteLine(output.Length);
                

                if ((Console.WindowWidth) >= output.Length)
                {
                    
                    Console.SetCursorPosition((Console.WindowWidth - output.Length) / 2, Console.CursorTop);
                    Console.WriteLine(output);
                    Console.WriteLine();
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("\nI cannot display more strings properly");
                    break;
                }
            }

            #endregion Pascal's triangle

            #region MatrixOperations

            #region Scalar Multiplication

            //default number for matrix scalar multiplication

            //A default value for everything if the user is a QA engineer
            const int defaultMatrixDimensionAndScalar = 5;

            Console.WriteLine("\nScalar multiplication.");

            var rows = RequestInt("\nPlease enter a number of rows for a matrix:", defaultMatrixDimensionAndScalar);

            var columns = RequestInt("\nPlease enter a number of columns for the matrix:", defaultMatrixDimensionAndScalar);

            var scalar = RequestInt("\nPlease enter the number to multiply the matrix by:", defaultMatrixDimensionAndScalar);

            //Matrix initialization
            int[,] matrixScalar = new int[rows, columns];

            Console.WriteLine($"\nMatrix before Scalar multiplication by {scalar}:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrixScalar[i, j] = rnd.Next(500);
                    
                    Console.Write($"{matrixScalar[i, j],10} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"\nMatrix after Scalar multiplication by {scalar}:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrixScalar[i, j] = matrixScalar[i, j] * scalar;

                    Console.Write($"{matrixScalar[i, j],10} ");
                }
                Console.WriteLine();
            }

            #endregion Scalar Multiplication

            #region Addition&Subscration

            Console.WriteLine("\nMatrix addition and subtraction");

            rows = RequestInt("\nPlease enter a number of rows for a matrix:", defaultMatrixDimensionAndScalar);

            columns = RequestInt("\nPlease enter a number of columns for the matrix:", defaultMatrixDimensionAndScalar);

            //Matrix initialization
            int[,] matrixAdditionSubtraction = new int[rows, columns];
            int[,] matrixAdditionSubtraction2 = new int[rows, columns];
            int[,] matrixAdditionSubtractionResult = new int[rows, columns];

            Console.WriteLine($"\nMatrix 1:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrixAdditionSubtraction[i, j] = rnd.Next(500);

                    Console.Write($"{matrixAdditionSubtraction[i, j],10} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"\nMatrix 2:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrixAdditionSubtraction2[i, j] = rnd.Next(500);

                    Console.Write($"{matrixAdditionSubtraction2[i, j],10} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"\nMatrix 1 + Matrix 2:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrixAdditionSubtractionResult[i, j] = matrixAdditionSubtraction[i,j] + matrixAdditionSubtraction2[i, j];

                    Console.Write($"{matrixAdditionSubtractionResult[i, j],10} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"\nMatrix 1 - Matrix 2:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrixAdditionSubtractionResult[i, j] = matrixAdditionSubtraction[i, j] - matrixAdditionSubtraction2[i, j];

                    Console.Write($"{matrixAdditionSubtractionResult[i, j],10} ");
                }
                Console.WriteLine();
            }

            #endregion Addition&Subscration

            #region Matrix multiplication

            Console.WriteLine("\nMatrix multiplication.");

            rows = RequestInt("\nPlease enter a number of rows for a matrix:", defaultMatrixDimensionAndScalar);

            columns = RequestInt("\nPlease enter a number of columns for the matrix:", defaultMatrixDimensionAndScalar);


            //Array matrixMultiplication initialization
            int[,] matrixMultiplication = new int[rows, columns];

            Console.WriteLine($"\nFirst Matrix before Matrix multiplication.:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrixMultiplication[i, j] = rnd.Next(500);

                    Console.Write($"{matrixMultiplication[i, j],10} ");
                }
                Console.WriteLine();
            }

            var rowsForMultiplication2 = RequestInt("\nPlease enter a number of rows for the second matrix:", defaultMatrixDimensionAndScalar);
            while (columns != rowsForMultiplication2)
            {
                Console.WriteLine("Multiplication of two matrices is defined if and only if the number of columns of the left matrix is the same as the number of rows of the right matrix.");
                rowsForMultiplication2 = RequestInt("\nPlease enter a number of rows for the second matrix:", defaultMatrixDimensionAndScalar);
            }
            
            var columnsForMultiplication2 = RequestInt("\nPlease enter a number of columns for the second matrix:", defaultMatrixDimensionAndScalar);


            //matrix matrixMultiplication2 initialization
            int[,] matrixMultiplication2 = new int[rowsForMultiplication2, columnsForMultiplication2];

            Console.WriteLine($"\nSecond Matrix before Matrix multiplication.:");
            for (int i = 0; i < rowsForMultiplication2; i++)
            {
                for (int j = 0; j < columnsForMultiplication2; j++)
                {
                    matrixMultiplication2[i, j] = rnd.Next(500);

                    Console.Write($"{matrixMultiplication2[i, j],10} ");
                }
                Console.WriteLine();
            }

            //Result matrix initialisation
            int[,] matrixMultiplicationResult = new int[rows, columnsForMultiplication2];

            Console.WriteLine($"\nFirst Matrix x Second matrix:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columnsForMultiplication2; j++)
                {
                    matrixMultiplicationResult[i, j] = 1;

                    //


                    Console.Write($"{matrixMultiplicationResult[i, j],10} ");
                }
                Console.WriteLine();
            }

            #endregion Matrix multiplication 

            #endregion MatrixOperations

            Console.ReadLine();
        }
        /// <summary>
        /// Returns a string that lists months by entered profit
        /// </summary>
        /// <param name="profit">Profit to search for</param>
        /// <param name="array">An array to search in</param>
        /// <returns></returns>
        private static string MonthsByProfit(int profit, int[,] array)
        {
            string output = default;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                if (profit == array[i, array.GetLength(1)-1])
                {
                    output += array[i,0] + " ";
                }
            }
            return output;
        }

        /// <summary>
        /// Requests int value from a user and shows initial message and a message on success/fail
        /// </summary>
        /// <param name="message">Console output to request int form a user</param>
        /// <param name="valueDefault">A default value to be set if user makes a mistake</param>
        /// <returns></returns>
        private static int RequestInt(string message, int valueDefault)
        {
            Console.WriteLine(message);
            if (!int.TryParse(Console.ReadLine(), out var parsedInt))
            {
                parsedInt = valueDefault;
                Console.WriteLine("We'll go with {0}", parsedInt);
            }

            return parsedInt;
        }
    }
}