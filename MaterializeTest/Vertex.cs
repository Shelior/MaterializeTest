using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterializeTest
{
    public struct Vertex
    {
        public Vertex(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; set; }
        public double Y { get; set; }

        public static Vertex operator +(Vertex a, Vertex b)
        {
            return new Vertex(a.X + b.X, a.Y + b.Y);
        }

        public static Vertex operator -(Vertex a, Vertex b)
        {
            return new Vertex(a.X - b.X, a.Y - b.Y);
        }

        public static double operator *(Vertex a, Vertex b)
        {
            return a.X * b.Y - a.Y * b.X;
        }
    }
}
