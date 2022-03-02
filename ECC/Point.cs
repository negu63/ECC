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
        public BigInteger X { get; private set; }
        public BigInteger Y { get; private set; }
        public BigInteger A { get; private set; }
        public BigInteger B { get; private set; }

        public Point(BigInteger x, BigInteger y, BigInteger a, BigInteger b)
        {
            try
            {
                X = x;
                Y = y;
                A = a;
                B = b;
                if (BigInteger.Pow(Y, 2) != (BigInteger.Pow(X, 3) + a * x + b))
                {
                    throw new Exception($"({X}, {Y}) is not on the curve");
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }

        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, A, B);
        }
    }
}
