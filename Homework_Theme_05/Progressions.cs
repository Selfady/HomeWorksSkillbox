using System;
using System.CodeDom.Compiler;

namespace Homework_Theme_05
{
    /// <summary>
    /// Methods to progressions and operations on them.
    /// </summary>
    public class Progressions
    {
        /// <summary>
        /// Method to generate n members of Arithmetic Progression with given first number and difference.
        /// </summary>
        /// <param name="a1">First number.</param>
        /// <param name="d">Difference.</param>
        /// <param name="n">Number of elements to generate.</param>
        /// <returns>An array of n elements of Arithmetic Progression.</returns>
        public static double[] GenerateArithmeticProgression(double a1, double d, ushort n)
        {
            double[] result = new double[n];
            for (int i = 0; i < n; i++)
            {
                result[i] = a1 + (double)i * d;
            }

            return result;
        }
        /// <summary>
        /// Method to generate n members of Geometric Progression with given first number and common ratio.
        /// </summary>
        /// <param name="a1">First number.</param>
        /// <param name="cr">Common ratio.</param>
        /// <param name="n">Number of elements to generate.</param>
        /// <returns>An array of n elements of Geometric Progression.</returns>
        public static double[] GenerateGeometricProgression(double a1, double cr, ushort n)
        {
            if (cr == 0)
            {
                throw new Exception("Common ratio cannot be 0.");
            }

            double[] result = new double[n];
            double temp = a1;
            for (int i = 0; i <= n-1; i++)
            {
                if (i == 0)
                {
                    result[i] = temp;
                }
                else
                {
                    temp *= cr;
                    result[i] = temp;
                }
            }

            return result;

        }
        /// <summary>
        /// Prints a header message and a progression into the console.
        /// </summary>
        /// <param name="progression">A matrix to print.</param>
        /// <param name="message">A header message to print.</param>
        public static void PrintProgression(double[] progression, string message)
        {
            var elements = progression.GetLength(0);
            const byte digitsWithSpace = 18;

            Console.WriteLine(message);

            for (int i = 0; i < elements; i++)
            {
                Console.Write($"{progression[i],digitsWithSpace}");
            }
        }
        /// <summary>
        /// An enum to link a progression to its type.
        /// </summary>
        public enum Sequence
        {
            Arithmetic,
            Geometric,
            ArithmeticAndGeometric,
            NeitherArithmeticNorGeometric
        }

        /// <summary>
        /// Method to check if a sequence is a progression.
        /// </summary>
        /// <param name="progression">Progression to get check if a sequence is a progression.</param>
        /// <returns>Type of the sequence.</returns>
        public static int IsProgression(double[] progression)
        {
            double NumberOfElements = progression.GetLength(0);

            double first = progression[0];
            bool arithmetic = true, geometric = true;

            if (first == 0)
            {
                geometric = false;
            }

            double difference, commonRatio = 0;

            switch (NumberOfElements)
            {
                case 0:
                    return (int) Sequence.NeitherArithmeticNorGeometric;
                case 1:
                    return first != 0 ? (int) Sequence.ArithmeticAndGeometric : (int) Sequence.Arithmetic;
                case 2:
                    if (first != 0 && progression[1] != 0)
                        return (int) Sequence.ArithmeticAndGeometric;
                    else
                    {
                        geometric = false;
                        return (int) Sequence.Arithmetic;
                    }
                default:
                    difference = progression[1] - first;
                    if (geometric)
                    {
                        commonRatio = progression[1] / first;
                    }

                    break;
            }

            for (int i = 0; i < NumberOfElements; i++)
            {
                if (i == 0)
                    continue;
                if (i == 1)
                {
                    difference = progression[i] - first;
                    if (progression[i] != 0 && geometric)
                    {
                        commonRatio = progression[i] / first;
                    }
                    else
                    {
                        geometric = false;
                    }
                }

                if (!(arithmetic && (progression[i] == (progression[i - 1] + difference))))
                {
                    arithmetic = false;
                }

                if (!(geometric && (progression[i] == (progression[i - 1] * commonRatio))))
                {
                    geometric = false;
                }
            }

            if (arithmetic && geometric)
            {
                return (int) Sequence.ArithmeticAndGeometric;
            }

            if (arithmetic)
            {
                return (int) Sequence.Arithmetic;
            }
            
            if (geometric)
            {
                return (int) Sequence.Geometric;
            }
            
            return (int) Sequence.NeitherArithmeticNorGeometric;
        }

        /// <summary>
        /// This method returns the value of Ackermann Function for two given non negative integer numbers.
        /// </summary>
        /// <param name="m">First number.</param>
        /// <param name="n">Second number.</param>
        /// <returns>The value of Ackermann Function.</returns>
        public static ulong AckermannFunction(ulong m, ulong n)
        {
            //if (!(m >= 0 && n >= 0))
            //{
            //    throw new Exception("input values must be non-negative integer numbers.");
            //}

            ulong result = default;

            if (m > 0 && n > 0)
            {
                return AckermannFunction(m - 1, AckermannFunction(m, n - 1));
            }

            if (m > 0 && n == 0)
            {
                return AckermannFunction(m - 1, 1);
            }

            if (m == 0)
            {
                n++;
                result = n;
                return result;
            }

            return result;
        }
    }
}