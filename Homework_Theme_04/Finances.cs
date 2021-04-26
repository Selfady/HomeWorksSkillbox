﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_04
{

    class Finances
    {
        static void Main(string[] args)
        {
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
    }
}
