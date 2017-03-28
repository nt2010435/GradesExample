using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Tests.Types
{
    [TestClass]
    public class TypeTests //Rename 'ReferenceTypeTests' to 'TypeTests'
    {
        [TestMethod]
        public void UsingArrays()
        {
            float[] grades;

            grades = new float[3];
            AddGrades(grades);

            Assert.AreEqual(89.1f, grades[1]);
        }

        private void AddGrades(float[] grades)
        {
            grades[1] = 89.1f;
        }

        [TestMethod]
        public void UppercaseString()
        {
            string name = "test";

            name = name.ToUpper();

            Assert.AreEqual("TEST", name);
        }

        [TestMethod]
        public void AddDaysToDateTime()
        {
            DateTime date = new DateTime(2015, 1, 1);

            date = date.AddDays(1);

            Assert.AreEqual(2, date.Day);
        }

        [TestMethod]
        public void ValueTypesPassByValue1()
        {
            int x = 46;

            IncrementNumber1(ref x);

            Assert.AreEqual(47, x);

        }

        private void IncrementNumber1(ref int number)
        {
            //'x = 46' pass into 'number', but change in 'number += 1' does not go to TestMethod 'ValueTypesPassByValue'
            //Pass by value to method parameter example
            number += 1;
        }

        [TestMethod]
        public void ValueTypesPassByValue()
        {
            int x = 46;

            IncrementNumber(x);

            Assert.AreEqual(46, x);

        }

        private void IncrementNumber(int number)
        {
            //'x = 46' pass into 'number', but change in 'number += 1' does not go to TestMethod 'ValueTypesPassByValue'
            //Pass by value to method parameter example
            number += 1;
        }

        [TestMethod]
        public void ReferenceTypesPassByValue1()
        {
            //Using keyword 'ref' for passing reference pointer
            GradeBook book1 = new GradeBook();
            GradeBook book2 = book1;

            GiveBookAName1(ref book2);
            Assert.AreEqual("A GradeBook", book2.Name);
        }

        private void GiveBookAName1(ref GradeBook bookx)
        {
            //Using keyword 'ref' to pass value to TestMethod 'ReferenceTypesPassByValue1'
            bookx = new GradeBook();
            bookx.Name = "A GradeBook";
        }

        [TestMethod]
        public void ReferenceTypesPassByValue()
        {
            GradeBook book1 = new GradeBook();
            GradeBook book2 = book1;

            GiveBookAName(book2);
            Assert.AreEqual("A GradeBook", book1.Name);
        }

        private void GiveBookAName(GradeBook book)
        {
            //'book1', 'book2', 'book' all reference to object 'GradeBook'. 'book.Name = "A GradeBook"' go to TestMethod 'ReferenceTypesPassByValue'
            //Pass by reference (pointer to an object) method parameter example
            book.Name = "A GradeBook";
        }

        [TestMethod]
        public void StringComparisons()
        {
            string name1 = "Test";
            string name2 = "test";

            bool result = string.Equals(name1, name2, StringComparison.InvariantCultureIgnoreCase);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IntVariablesHoldAValue()
        {
            int x1 = 100;
            int x2 = x1;

            x1 = 4;
            Assert.AreNotEqual(x1, x2);
        }

        [TestMethod]
        public void VariablesHoldAReference()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            g1.Name = "Ex grade book";
            Assert.AreEqual(g1.Name, g2.Name);
        }
    }
}
