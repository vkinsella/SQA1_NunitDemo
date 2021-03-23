using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LateLads;


namespace LateLads.Tests
{
    [TestFixture]

    //https://www.code4it.dev/blog/code-coverage-vs-2019-coverlet
    public class ProgramTests
    {
        static int myExpectedResult;
        static Program p1;

        [SetUp]

        public static void Init()
        {
            // put any set up code, e.g create objects
            p1 = new Program();

        }

        [TestCase(2,4,ExpectedResult = 6)]
        [TestCase(2, 2, ExpectedResult = 4)]
        [TestCase(-2, 4, ExpectedResult = 2)]
        public static int MultipleTests(int a, int b)
        {
            int actualResult = p1.Add(a, b);
            return actualResult;

        }

        [Test]
        public static void Add_SimpleValues_Calculated()
        {
            // Arrange, Act, Assert
            myExpectedResult = 9;
            int actualResult = p1.Add(5, 4);
            Assert.AreEqual(myExpectedResult, actualResult);
        }


        [Test]
        public static void Add_SimpleValues_Calculated2()
        {
            // Arrange, Act, Assert
            myExpectedResult = 0;
            int actualResult = p1.Add(0, 0);
            Assert.AreEqual(myExpectedResult, actualResult);
        }
    }
}
