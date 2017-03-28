using System;
using System.Collections.Generic;
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

            GradeBook book = new GradeBook(); //create new instance of GradeBook, book pointer to GradeBook object

            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            GradeStatistics stats = book.ComputeStatistics();

            Console.WriteLine("Average Grade: " + stats.AverageGrade);
            Console.WriteLine("Highest Grade: " + stats.HighestGrade);
            Console.WriteLine(" Lowest Grade: " + stats.LowestGrade);
            

            //Example of using book pointing (by reference) to GradeBook object
            //GradeBook book2 = book;
            //book2.AddGrade(75);
        }
    }
}
