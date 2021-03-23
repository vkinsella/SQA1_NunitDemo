using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace demo1
{
    public class Program
    {
        static void Main(string[] args)
        {
        }

        public int Add(int x, int y) // method to return the sum of two integers
        {
            return x - y; // on purpose error, should be +

        }

        public bool CheckRange(int x) // method to check if a number is between 1 and 5 inclusive, if greater than 10 an exception is thrown
        {
            if (x > 10)
                throw new ArgumentOutOfRangeException("x", "number greater than 10)");

            if (x > 1 && x < 5)  // note the off by one on purpose error, >= && <=
                return true;
            else
                return false;

        }
    }
}


  

