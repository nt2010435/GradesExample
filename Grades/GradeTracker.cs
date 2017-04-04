using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public abstract class GradeTracker : IGradeTracker
    {
        public abstract void AddGrade(float grade);
        public abstract GradeStatistics ComputeStatistics();
        public abstract void WriteGrades(TextWriter destination);
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

        protected string _name; //private field
    }
}
