using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Example of console app
//Example of using classes and objects to contain grades and compute statistics
namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {

            //GradeBook book = new GradeBook(); //create new instance of GradeBook, book pointer to GradeBook object
            IGradeTracker book = CreateGradeBook();

            //book.NameChanged += new NameChangedDelegate(OnNameChanged);
            //book.NameChanged += new NameChangedDelegate(OnNameChanged2);
            //book.NameChanged += OnNameChanged;
            //book.NameChanged += OnNameChanged2;

            //book.Name = "Test Grade Book";
            //book.Name = "Grade Book";

            //GetBookName(book);

            AddGrades(book);

            SaveGrades(book);

            WriteResults(book);
        }

        private static IGradeTracker CreateGradeBook()
        {
            return new ThrowAwayGradeBook();
        }

        private static void WriteResults(IGradeTracker book)
        {
            GradeStatistics stats = book.ComputeStatistics();

            //Console.WriteLine(book.Name);

            //Console.WriteLine("Average Grade: " + stats.AverageGrade);
            WriteResult("Average", stats.AverageGrade); //Using WriteResult with float parameter

            //Console.WriteLine("Highest Grade: " + stats.HighestGrade);
            //WriteResult("Highest", (int)stats.HighestGrade); //(int) type cast the floating point to integer
            WriteResult("Highest", stats.HighestGrade);

            //Console.WriteLine(" Lowest Grade: " + stats.LowestGrade);
            WriteResult("Lowest", stats.LowestGrade); //Using WriteResult with float parameter

            WriteResult("Grade", stats.LetterGrade);

            WriteResult(stats.LetterGrade, stats.Description);

            //Example of using book pointing (by reference) to GradeBook object
            //GradeBook book2 = book;
            //book2.AddGrade(75);
        }

        private static void SaveGrades(IGradeTracker book)
        {
            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outputFile);
            }

            //book.WriteGrades(Console.Out);
        }

        private static void AddGrades(IGradeTracker book)
        {
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);
        }

        private static void GetBookName(IGradeTracker book)
        {
            try
            {
                Console.WriteLine("Enter a name");
                book.Name = Console.ReadLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //static void OnNameChanged(object sender, NameChangedEventArgs args)
        //{
        //    Console.WriteLine($"Grade book changing name from {args.ExistingName} to {args.NewName}");
        //}

        //static void OnNameChanged(string existingName, string newName)
        //{
        //    Console.WriteLine($"Grade book changing name from {existingName} to {newName}");
        //}

        //static void OnNameChanged2(string existingName, string newName)
        //{
        //    Console.WriteLine("***");
        //}

        //static void WriteResult(string description, int result)
        //{
        //    Console.WriteLine(description + ": " + result);
        //}

        static void WriteResult(string description, string result)
        {
            Console.WriteLine($"{description}: {result}"); //No need to pass description and result as parameters with this format

        }

        static void WriteResult(string description, float result)
        {
            //Console.WriteLine(description + ": " + result);
            //Console.WriteLine("{0}: {1:F2}", description, result); //F2 format output to floating point with 2 decimal digits
            Console.WriteLine($"{description}: {result:F2}"); //No need to pass description and result as parameters with this format

        }
    }
}
