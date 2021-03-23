using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;

namespace Mocking_4
{
    public interface IX
    {
        int GetHours(int x, int y);
    }
    public class A 
    {
       
        public A()
        {
           

        }

        public int CalcPay(int hrs, int rate)
        {
            return hrs * rate; ; 
        }
    }

    //public class B :IX
    //{
    //    public B()
    //    {

    //    }

    //    public virtual int GetHours(int startTime, int endTime)
    //    {
    //       return 0;
    //    }

    //}

    [TestFixture]
    public class PayTests
    {
        //In a nutshell, this is how it works:

        //In our test class, we create a Mock instance for each dependency that
        //the system under test relies upon.
        //We configure our mock's various expectations and tell it what values to return under what circumstances
        //We inject those mock instances(see code below) when creating our system under test
        //We execute the method we want to test
        //We ask each Mock to verify that all of its expectations were met


        Mock<IX> mockIX;

        A systemUnderTest;

        [TestCase(5, 5, 0, 0)]
        [TestCase(12, 18, 6, 60)]
        
        public void Calcpay_Always_ReturnsExpectedResult(int h1, int h2, int expectedHours, int expectedResult)
        {
            //In this case, we're telling the mock, "Hey Mock, if your GetHours method is invoked
            //with this specific number (h1,h2), return this response (expectedResult). If it gets
            //invoked with any other number, fail the test immediately". (that's part of MockBehavior.Strict)
            
            
            
            mockIX = new Mock<IX>(MockBehavior.Strict);

            mockIX.Setup(p => p.GetHours(h1, h2)).Returns(expectedHours);


            systemUnderTest = new A();

            var result = systemUnderTest.CalcPay(expectedHours,10);

            Assert.That(result, Is.EqualTo(expectedResult));

            //mockIX.VerifyAll();

            // mockBMIService.Verify(x => x.CalcBMI(1,1), Times.Never);//This test passes
        }
    }
}
