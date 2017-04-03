using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Example of using classes, objects, constructor, public classes, public and private methods
namespace Grades
{
    public class GradeBook  //internal class can only used by codes inside the same project 
    {
        public GradeBook() //Constructor: ctor+tab+tab
        {
            // Initialize fields and data of an object, set default values, create other objects for use
            _name = "Emppty";
            grades = new List<float>();
        }

        public GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("GradeBook::ComputeStatistics");

            GradeStatistics stats = new GradeStatistics();
            float sum = 0;

            foreach (float grade in grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }
            stats.AverageGrade = sum / grades.Count;


            return stats;
        }

        public void WriteGrades(TextWriter destination)
        {
            for (int i = 0; i < grades.Count; i++)
            {
                destination.WriteLine(grades[i]);
            }

            //for (int i = grades.Count; i > 0; i--) //reverse order
            //{
            //    destination.WriteLine(grades[i-1]);
            //}
        }

        public void AddGrade(float grade) //Method
        {
            grades.Add(grade);
        }

        public string Name //public Name property
        {
            get
            {
                return _name;
            }

            set
            {
                //if (!String.IsNullOrEmpty(value))
                //{

                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }

                if (_name != value && NameChanged != null)
                {
                    //NameChanged(_name, value);
                    NameChangedEventArgs args = new NameChangedEventArgs();

                    args.ExistingName = _name;
                    args.NewName = value;

                    NameChanged(this, args);
                }
                _name = value;
                //}
            }
        }

        //public NameChangedDelegate NameChanged;
        public event NameChangedDelegate NameChanged;

        private string _name; //private field

        // grade stores in grades field, private encapsulates grades field, 'private' for access within current class only
        //private List<float> grades;

        protected List<float> grades; //'protected' for access within this class or derived class
    }
}
