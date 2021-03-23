using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SUT_demo1;
using fit.Fixtures;
using fit;

namespace SUT_Demo1Fixture 

{
    public class Class1 : ColumnFixture
    {

        public int x;
        public int y;
        public SUT_demo1.Program sut = new SUT_demo1.Program();
        public int Add()
        {
            return sut.Add(x,y);

        }
    }
}
