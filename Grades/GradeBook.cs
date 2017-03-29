using System;
using System.Collections.Generic;
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
                if (!String.IsNullOrEmpty(value))
                {
                    if(_name != value)
                    {
                        NameChanged(_name, value);
                    }
                    _name = value;
                }
            }
        }

        public NameChangedDelegate NameChanged;

        private string _name; //private field

        // grade stores in grades field, private encapsulates grades field
        private List<float> grades;
    }
}
