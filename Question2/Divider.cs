using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question2
{
    public class Divider
    {
        public bool isDivisible(long n, long x, long y)
        {
            // your code
            //throw new System.NotImplementedException("not implemented");
            if (n % x == 0 && n % y == 0)
                return true;
            else
                return false;


        }


    }
}
