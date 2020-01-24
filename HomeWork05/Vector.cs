using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorPolynomial
{
    class Vector
    {
        public double X { get; }
        public double Y { get; }
        public double Z { get; }
        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        //Различные перегрузки операций
        public static Vector operator +(Vector a, Vector b) => new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        public static Vector operator -(Vector a, Vector b) => new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        public static Vector operator *(double b, Vector a) => a * b;
        public static Vector operator *(Vector a, double b) => new Vector(a.X * b, a.Y * b, a.Z * b);
        public static Vector operator /(Vector a, double b) => new Vector(a.X / b, a.Y / b, a.Z / b);
        public static Vector operator +(Vector a, double b) => new Vector(a.X + b, a.Y + b, a.Z + b);
        public static Vector operator +(double b, Vector a) => a + b;
        public static Vector operator -(Vector a, double b) => new Vector(a.X - b, a.Y - b, a.Z - b);
        public static Vector operator -(double b, Vector a) => a + b;
        public static bool operator ==(Vector a, Vector b) => a.X == b.X && a.Y == b.Y && a.Z == b.Z;
        public static bool operator !=(Vector a, Vector b) => !(a == b);
        public override string ToString() => $"{{X={X}, Y={Y}, Z={Z}}}";
    }
}
