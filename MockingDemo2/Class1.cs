using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace MockingDemo2
{
    // This assumes that there is an existing ICreditDecisionService interface
    // and that CreditDecisionService implements it.
    public interface ICreditDecisionService
    {
        string GetDecision(int score);
    }
    public class CreditDecision
    {

        ICreditDecisionService creditDecisionService;
        public CreditDecision(ICreditDecisionService creditDecisionService)
        {
            this.creditDecisionService = creditDecisionService;
        }

        public string MakeCreditDecision(int creditScore)
        {
            return creditDecisionService.GetDecision(creditScore);
        }
    }

    [TestFixture]
    public class CreditDecisionTests
    {
//In a nutshell, this is how it works:

//In our test class, we create a Mock instance for each dependency that
//the system under test relies upon.
//We configure our mock's various expectations and tell it what values to return under what circumstances
//We inject those mock instances(see code below) when creating our system under test
//We execute the method we want to test
//We ask each Mock to verify that all of its expectations were met


        Mock<ICreditDecisionService> mockCreditDecisionService;

        CreditDecision systemUnderTest;

        [TestCase(100, "Declined")]
        [TestCase(549, "Declined")]
        [TestCase(550, "Maybe")]
        [TestCase(674, "Maybe")]
        [TestCase(675, "We look forward to doing business with you!")]
        public void MakeCreditDecision_Always_ReturnsExpectedResult(int creditScore, string expectedResult)
        {
            //In this case, we're telling the mock, "Hey Mock, if your GetDecision method is invoked
            //with this specific number (creditScore), return this response (expectedResult). If it gets
            //invoked with any other number, fail the test immediately". (that's part of MockBehavior.Strict)
            mockCreditDecisionService = new Mock<ICreditDecisionService>(MockBehavior.Strict);
            mockCreditDecisionService.Setup(p => p.GetDecision(creditScore)).Returns(expectedResult);


            systemUnderTest = new CreditDecision(mockCreditDecisionService.Object);
            
            var result = systemUnderTest.MakeCreditDecision(creditScore);

            Assert.That(result, Is.EqualTo(expectedResult));

            mockCreditDecisionService.VerifyAll();
        }
    }
}
