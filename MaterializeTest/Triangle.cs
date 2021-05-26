using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterializeTest
{
    public struct Triangle
    {
        public Triangle(int a, int b, int c)
        {
            A = a;
            B = b;
            C = c;
        }

        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
    }
}
