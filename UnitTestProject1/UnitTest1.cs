using Microsoft.VisualStudio.TestTools.UnitTesting;
using SUT_demo1;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Program p1 = new Program();
            int expected = 5;
            Assert.AreEqual(5, p1.Add(2, 3));


        }
    }
}
