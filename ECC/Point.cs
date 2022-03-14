using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ECC
{
    public class Point
    {
        public dynamic X { get; private set; }
        public dynamic Y { get; private set; }
        public dynamic A { get; private set; }
        public dynamic B { get; private set; }

        public Point(BigInteger x, BigInteger y, BigInteger a, BigInteger b)
        {
            try
            {
                X = x;
                Y = y;
                A = a;
                B = b;

                if (BigInteger.Pow(Y, 2) != (BigInteger.Pow(X, 3) + A * X + B))
                {
                    throw new Exception($"({X}, {Y}) is not on the curve");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public Point(FieldElement x, FieldElement y, FieldElement a, FieldElement b)
        {
            try
            {
                X = x;
                Y = y;
                A = a;
                B = b;

                if (Y.Pow(2) != X.Pow(3) + A * X + B)
                {
                    throw new Exception($"({X.ToString()}, {Y.ToString()}) is not on the curve");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public Point(dynamic x, dynamic y, dynamic a, dynamic b)
        {
            try
            {
                X = x;
                Y = y;
                A = a;
                B = b;

                if (X != null && Y != null)
                {
                    throw new Exception($"({X}, {Y}) is not on the curve");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public override string ToString()
        {
            if (X == null)
            {
                return $"Point(infinity)";
            }
            else if (X.GetType() == typeof(FieldElement))
            {
                return $"Point({X.Num}, {Y.Num})_{A.Num}_{B.Num} FieldElement({X.Prime})";
            }
            else
            {
                return $"Point({X}, {Y})_{A}_{B}";
            }
        }

        public override int GetHashCode()
        {
            if (X == null || Y == null)
            {
                return HashCode.Combine(0, 0, A, B);
            }
            return HashCode.Combine(X, Y, A, B);
        }
    }
}
