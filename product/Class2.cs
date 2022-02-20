using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace product
{
    class Class2 : Class1
    {
        public override int Jam(int a, int b)
        {
        return a + b;
        }

        public override int menha(int a, int b)
        {
            return a - b;
        }

        public override int Zarb(int a, int b)
        {
            return a * b;
        }
    }
}
