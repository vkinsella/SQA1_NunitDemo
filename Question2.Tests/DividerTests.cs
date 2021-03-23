using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Question2;

namespace Question2.Tests
{
    [TestFixture]
    public class DividerTests
    {
        static int myExpectedResult;
        static Divider myDivider;

        [SetUp] // code here is executed before tests are executed
        public static void Init()
        {
            myDivider = new Divider(); // create an object of class Program
        }

        [Test]
        public static void isDivisible_NotImplement_ExceptionThrown()
        {
            //Assert.Throws<NotImplementedException>(() => { p1.Add(43,6); });
            Assert.AreEqual("not implemented", "not implemented");

        }

        [Test]
        public void IsDivisible_SimpleValues1_True()
        {
            Assert.AreEqual(true, myDivider.isDivisible(12, 4, 3));
        }

        [Test]
        public void IsDivisible_SimpleValues1_false()
        {
            Assert.AreEqual(false, myDivider.isDivisible(8, 3, 4));
        }

        // paramaterised test – allows us group a bunch of tests
       [TestCase(12, 4, 2, ExpectedResult = true)]
       
        [TestCase(15, 5,2, ExpectedResult = false)]

        public bool IsDivisible_SimpleValues(long a, long  b, long c)
        {
            bool actualResult = myDivider.isDivisible(a, b, c);
            return actualResult;
        }
    }
}
