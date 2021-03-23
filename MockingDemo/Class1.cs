using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;


namespace MockingDemo
{
    public class SomeClass
    {
        
        public SomeClass() { }

        public int CalcPay(int hours, int rate)
        {
            return hours * rate;
        }

        public int CalcHours(int s, int e) // stub
        {
            return 8 ; // stub
        }
    }

    [TestFixture]
    public class Test
    {
        [Test]
        public void Test_A_Calls_B()
        {
          
            SomeClass sc = new SomeClass();
            int hours = sc.CalcHours(9, 18); // stub
            int pay = sc.CalcPay(hours,10);
            Assert.AreEqual(80, pay);
        }
    }
}
