using System;

namespace Homework_Theme_05
{
    /// <summary>
    /// Methods to request data from user in console.
    /// </summary>
    public class Dialogues
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
        public static int RequestInt(string message)
        {
            int parsed;
            Console.WriteLine(message);

            while (!int.TryParse(Console.ReadLine(), out parsed))
            {
                Console.WriteLine($"Enter a number in range from {int.MinValue} to {int.MaxValue}");
            }

            return parsed;
        }
    }
}