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

        public bool Equals(Point other)
        {
            if (other == null)
            {
                return false;
            }
            return X == other.X && Y == other.Y && A == other.A && B == other.B;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Equals(obj as Point);
        }

        public static bool operator ==(Point p1, Point p2)
        {
            return Equals(p1, p2);
        }

        public static bool operator !=(Point p1, Point p2)
        {
            return !Equals(p1, p2);
        }

        public static Point operator +(Point p1, Point p2)
        {
            try
            {
                if (p1.A != p2.A || p1.B != p2.B)
                {
                    throw new Exception($"Points {p1}, {p2} are not on the same curve");
                }
                else if (p1.X == null)
                {
                    return p2;
                }
                else if (p2.X == null)
                {
                    return p1;
                }
                else if (p1.X == p2.X && p1.Y != p2.Y)
                {
                    return new Point((object)null, null, p1.A, p1.B);
                }
                else if (p1.X != p2.X)
                {
                    dynamic s = (p1.Y - p2.Y) / (p1.X - p2.X);
                    if (p1.X.GetType() == typeof(FieldElement))
                    {
                        FieldElement x = ((FieldElement)s).Pow(2) - p1.X - p2.X;
                        FieldElement y = s * (p1.X - x) - p1.Y;
                        return new Point(x, y, p1.A, p1.B);
                    }
                    else
                    {
                        BigInteger x = BigInteger.Pow(s, 2) - p1.X - p2.X;
                        BigInteger y = s * (p1.X - x) - p1.Y;
                        return new Point(x, y, p1.A, p1.B);
                    }
                }
                else if (p1 == p2 && p1.Y == 0 * p1.X)
                {
                    return new Point((object)null, null, p1.X, p1.Y);
                }
                else if (p1 == p2)
                {
                    if (p1.X.GetType() == typeof(FieldElement))
                    {
                        FieldElement s = (3 * p1.X.Pow(2) + p1.A) / (2 * p1.Y);
                        FieldElement x = s.Pow(2) - 2 * p1.X;
                        FieldElement y = s * (p1.X - x) - p1.Y;
                        return new Point(x, y, p1.A, p1.B);
                    }
                    else
                    {
                        BigInteger s = (3 * BigInteger.Pow(p1.X, 2) + p1.A) / (2 * p1.Y);
                        BigInteger x = BigInteger.Pow(s, 2) - 2 * p1.X;
                        BigInteger y = s * (p1.X - x) - p1.Y;
                        return new Point(x, y, p1.A, p1.B);
                    }
                }
                else
                {
                    throw new Exception($"Points {p1}, {p2} can't be added");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}