using System;
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

            Console.WriteLine("Enter a number of rows for Pascal's triangle");
            var input = int.TryParse(Console.ReadLine(),out var numberOfStrings);
            if (!input)
            {
                Console.WriteLine("You entered something strange, but i'll show you Pascal's Triangle for 10 rows");
                numberOfStrings = 10;
            }

            Console.WriteLine("Pascal's triangle");

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
                    Console.WriteLine("I cannot display more strings properly");
                    break;
                }
            }

            #endregion Pascal's triangle

            #region MatrixOperations

            #region Scalar Multiplication

            //default number for matrix scalar multiplication

            //A default value for everything if the user is a QA engineer
            int defaultMatrixDimensionAndScalar = 5;
            int rows, columns, scalar;

            rows = RequestInt("Please enter a number of rows for a matrix:", defaultMatrixDimensionAndScalar);

            columns = RequestInt("Please enter a number of columns for the matrix:", defaultMatrixDimensionAndScalar);

            scalar = RequestInt("Please enter the number to multiply the matrix by:", defaultMatrixDimensionAndScalar);

            //Matrix initialization
            int[,] matrix = new int[rows, columns];

            Console.WriteLine($"Matrix before Scalar multiplication by {scalar}:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = rnd.Next(500);
                    
                    Console.Write($"{matrix[i, j],10} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Matrix after Scalar multiplication by {scalar}:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = matrix[i, j] * 5;

                    Console.Write($"{matrix[i, j],10} ");
                }
                Console.WriteLine();
            }

            # endregion Scalar Multiplication



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
            }
            Console.WriteLine("We'll go with {0}", parsedInt);

            return parsedInt;
        }
    }
}
