using System;

namespace Homework_Theme_07
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is a batch of solutions for \"Homework_Theme_07 7.8 Homework\"");
            var page1 = new Note(1, "blablabla");
            page1.Summary = "About bla.";
            Console.WriteLine(page1.Print());
            var page2 = new Note(2, "bla?") {Edited = true};
            Console.WriteLine(page2.Print());
            
            Console.ReadKey();
        }
    }
}
