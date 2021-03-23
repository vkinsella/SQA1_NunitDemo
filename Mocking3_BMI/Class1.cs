using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace Mocking3_BMI
{
    // This assumes that there is an existing IBMIService interface
    // and that BMIService implements it.
    public interface IBMIService
    {
        int CalcBMI(int h,int w);
    }
    public class HealthDecision
    {

        IBMIService bmiService;
        public HealthDecision(IBMIService bmiService)
        {
            this.bmiService = bmiService;
        }

        public string MakeHealthDecision(int h, int w)
        {
            int x = bmiService.CalcBMI(h,w);
            if (x < 20)
                return "underweight";
            else if (x < 25)
                return "normal";
            else if (x < 30)
                return "overweight";
            else
                return "obese";
            
        }
    }

    [TestFixture]
    public class HealthDecisionTests
    {
        //In a nutshell, this is how it works:

        //In our test class, we create a Mock instance for each dependency that
        //the system under test relies upon.
        //We configure our mock's various expectations and tell it what values to return under what circumstances
        //We inject those mock instances(see code below) when creating our system under test
        //We execute the method we want to test
        //We ask each Mock to verify that all of its expectations were met


        Mock<IBMIService> mockBMIService;

        HealthDecision systemUnderTest;

        [TestCase(5,5,18, "underweight")]
        [TestCase(5,5,22, "normal")]
        [TestCase(5,5,28, "overweight")]
        [TestCase(5,5,35, "obese")]
        public void MakeHealthDecision_Always_ReturnsExpectedResult(int h, int w, int expectedBMI, string expectedResult)
        {
            //In this case, we're telling the mock, "Hey Mock, if your CalcBMI method is invoked
            //with this specific number (h,w), return this response (expectedResult). If it gets
            //invoked with any other number, fail the test immediately". (that's part of MockBehavior.Strict)
            mockBMIService = new Mock<IBMIService>(MockBehavior.Strict);
            mockBMIService.Setup(p => p.CalcBMI(h, w)).Returns(expectedBMI);


            systemUnderTest = new HealthDecision(mockBMIService.Object);

            var result = systemUnderTest.MakeHealthDecision(h,w);

            Assert.That(result, Is.EqualTo(expectedResult));

            mockBMIService.VerifyAll();

           // mockBMIService.Verify(x => x.CalcBMI(1,1), Times.Never);//This test passes
        }
    }
}