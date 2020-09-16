using System;
using System.Collections.Generic;

namespace src
{

    class Program
    {
        static void Main(string[] args)
        {

            Ibook book = new DiskBook("Jerry's Grade book");
            book.GradeAdded += onGradeAdded;

            EnterGrades (book);

            var stats = book.Getstat();

            Console.WriteLine($"for the book named {book.Name}");
            Console.WriteLine($"the highest grade is {stats.high}");
            Console.WriteLine($"the lowest grade is {stats.low}");
            Console.WriteLine($"the average number is {stats.average:N1}");
            Console.WriteLine($"the letter average is { stats.letter}");
            

        }

        private static void EnterGrades(Ibook book)
        { 
            while (true)
            {
                Console.WriteLine("Enter a grade or 'Q' to quit ");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);

                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }

            }
        }

        static void onGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
    }
}
