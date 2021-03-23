using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SUT_demo1;

namespace SUT_demo1.Tests
{
    [TestFixture] // attribute
    public class ProgramTest
    {
        static int myExpectedResult;
        static Program p1;

        [SetUp] // code here is executed before tests are executed
        public static void Init()
        {
            p1 = new Program(); // create an object of class Program
        }

        [Test]
        // name = methodName _StateUnderTest_ExpectedBehaviour
        public static void Add_SimpleValues_Calculated_1()
        {
            // AAA pattern
            // Arrange
            // Act
            // Assert
            myExpectedResult = 9; // what my code should be returning
            int actualResult = p1.Add(4, 5); // call the SUT method
            Assert.AreEqual(myExpectedResult, actualResult);

        }
        [Test]
        public static void Add_SimpleValues_Calculated_2()
        {
            myExpectedResult = 0; // what my code should be returning
            int actualResult = p1.Add(0, 0); // call the SUT method
            Assert.AreEqual(myExpectedResult, actualResult);


        }
                

        // paramaterised test – allows us group a bunch of tests
        
        [TestCase(-1, 10, ExpectedResult = 9)]
        [TestCase(5, 15, ExpectedResult = 20)]
        [TestCase(15, 15, ExpectedResult = 30)]
        [TestCase(0,0,ExpectedResult = 0)]
        [TestCase(0, -1, ExpectedResult = -1)]
        public int Add_simpleValues_Calculate_2(int a, int b)
        {
            int actualResult = p1.Add(a, b);
            return actualResult;
        }



        [Test]
        public static void Add_NotImplement_ExceptionThrown()
        {
            var ex = Assert.Throws<NotImplementedException>(() => { p1.Add(43, 6); });
            Assert.That(ex.Message.Contains("not implemented"));

        }







        [Test]
        public void CheckingRange_inRangeValue_TrueExpected()
        {
            Assert.IsFalse(p1.CheckRange(5));
        }
        [Test]
        public void CheckInRange_PassingOutOfRangeValue_CausesAnException()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => { p1.CheckRange(43); });
            //var ex = p1.CheckRange(43);
            //Assert.AreEqual("Specified argument was out of the range of valid values.", ex.Message);

            //Assert.Contains("range error", ex.Message) ;
            Assert.That(ex.Message.Contains("range error"));
        }
    }

}
