using System;

namespace Homework_Theme_05
{
    /// <summary>
    /// Methods to generate and matrices and do basic operations on them.
    /// </summary>
    public class Matrix
    {
        /// <summary>
        /// Generates a matrix with given number of rows and columns
        /// and initializes it with random numbers from int.MinValue to int.MaxValue range. 
        /// </summary>
        /// <param name="rows">Number of rows in the matrix.</param>
        /// <param name="columns">Number of columns in the matrix.</param>
        /// <returns>Initialized array</returns>
        public static int[,] GenerateMatrix(byte rows, byte columns)
        {
            int[,] matrix = new int[rows, columns];
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
        public static int[,] GenerateMatrix(byte rows, byte columns, int min, int max)
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
        public static void PrintMatrix(int[,] matrix, string message)
        {
            var rows = matrix.GetLength(0);
            var columns = matrix.GetLength(1);
            const byte digitsWithSpace = 12;

            Console.WriteLine(message);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{matrix[i, j],digitsWithSpace}");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Changes signs for every element of the matrix.
        /// </summary>
        /// <param name="matrix">Input matrix.</param>
        /// <returns>Output matrix with the opposite signs.</returns>
        public static int[,] MatrixChangeSign(int[,] matrix)
        {
            var rows = matrix.GetLength(0);
            var columns = matrix.GetLength(1);
            var result = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    result[i, j] = matrix[i, j] * -1;
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
        public static int[,] AddMatrices(int[,] matrix1, int[,] matrix2)
        {
            if (!ValidateMatrixSizes(matrix1, matrix2))
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
        public static int[,] MultiplyMatrixByScalar(int[,] matrix, int scalar)
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
        /// Method to multiply two matrices.
        /// </summary>
        /// <param name="matrix">Left matrix.</param>
        /// <param name="matrix2">Right matrix.</param>
        /// <returns>Matrix with result of multiplication.</returns>
        public static int[,] MultiplyMatrices(int[,] matrix, int[,] matrix2)
        {

            if (!ValidateMatrixSizes(matrix, matrix2, true))
            {
                throw new Exception("Multiplication of two matrices is defined if and only if the number of columns " +
                                  "of the left matrix is the same as the number of rows of the right matrix.");
            }

            var rows = matrix.GetLength(0);
            var columns = matrix2.GetLength(1);
            var counter = matrix.GetLength(1);

            var result = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    var temp = 0;

                    for (int k = 0; k < counter; k++)
                    {
                        temp += matrix[i, k] * matrix2[k, j];
                    }

                    result[i, j] = temp;
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
        public static int MatrixExtremum(int[,] matrix, bool maximum)
        {
            var rows = matrix.GetLength(0);
            var columns = matrix.GetLength(1);
            var min = int.MaxValue;
            var max = int.MinValue;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (matrix[i, j] <= min)
                        min = matrix[i, j];
                    if (matrix[i, j] >= max)
                        max = matrix[i, j];
                }
            }

            return maximum ? max : min;
        }

        /// <summary>
        /// A way to check if two matrices have proper dimensions for multiplication.
        /// </summary>
        /// <param name="matrix">The left matrix to check.</param>
        /// <param name="matrix2">The right matrix to check.</param>
        /// <param name="multiplication">Flag true if multiplication should be verified.</param>
        /// <returns></returns>
        public static bool ValidateMatrixSizes(int[,] matrix, int[,] matrix2, bool multiplication)
        {
            if (multiplication)
            {
                return matrix.GetLength(1) == matrix2.GetLength(0);
            }
            else
            {
                return matrix.GetLength(0) == matrix2.GetLength(0) && matrix.GetLength(1) == matrix2.GetLength(1);
            }

        }

        /// <summary>
        /// A way to check if two matrices have the same dimensions.
        /// </summary>
        /// <param name="matrix">The first matrix.</param>
        /// <param name="matrix2">The second matrix.</param>
        /// <returns>true if they have similar sizes and false if not.</returns>
        public static bool ValidateMatrixSizes(int[,] matrix, int[,] matrix2)
        {
            return matrix.GetLength(0) == matrix2.GetLength(0) && matrix.GetLength(1) == matrix2.GetLength(1);
        }

        /// <summary>
        /// Makes sure a matrix can be multiplied by another one without exceeding min/max values for their data type.
        /// </summary>
        /// <param name="matrix">Left matrix to multiply.</param>
        /// <param name="matrix2">Right matrix to multiply.</param>
        /// <param name="multiplication">Flag true if multiplication should be verified.</param>
        /// <returns></returns>
        public static bool ValidateMatrixOperation(int[,] matrix, int[,] matrix2, bool multiplication)
        {
            if (multiplication)
            {
                if (!ValidateMatrixSizes(matrix, matrix2, true))
                {
                    Console.WriteLine(
                        "Multiplication of two matrices is defined if and only if the number of columns " +
                        "of the left matrix is the same as the number of rows of the right matrix.");
                    return false;
                }

                var rows = matrix.GetLength(0);
                var columns = matrix2.GetLength(1);
                var counter = matrix.GetLength(1);
                var result = new decimal[rows, columns];

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        decimal temp = 0;

                        for (int k = 0; k < counter; k++)
                        {
                            temp += (decimal)matrix[i, k] * (decimal)matrix2[k, j];
                        }

                        result[i, j] = temp;

                        if (result[i, j] > int.MaxValue || result[i, j] < int.MinValue)
                        {
                            Console.WriteLine(
                                $"The result matrix cannot be properly created because a result value {result[i, j]}" +
                                $" is below {int.MinValue} or above {int.MaxValue}.");
                            return false;
                        }
                    }
                }

                return true;
            }
            else
            {
                return ValidateMatrixOperation(matrix, matrix2);
            }
        }

        /// <summary>
        /// Makes sure a matrix can be added to another one without exceeding max/min values for their data type.
        /// And some other restriction like their sizes.
        /// </summary>
        /// <param name="matrix">First addend to check.</param>
        /// <param name="matrix2">First addend to check.</param>
        /// <returns></returns>
        public static bool ValidateMatrixOperation(int[,] matrix, int[,] matrix2)
        {
            if (!ValidateMatrixSizes(matrix, matrix2))
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
                    if (result[i, j] > int.MaxValue || result[i, j] < int.MinValue)
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
        public static bool ValidateMatrixOperation(int[,] matrix, int scalar)
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
    }
}