using System;
using System.Numerics;

namespace ECC
{
    public class FieldElement
    {
        public BigInteger Num { get; private set; }
        public BigInteger Prime { get; private set; }

        public FieldElement(BigInteger num, BigInteger prime)
        {
            try
            {
                if (num >= prime || num < 0)
                {
                    throw new Exception($"Num {num} not in field range 0 to {prime - 1}");
                }
                Num = num;
                Prime = prime;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public override string ToString()
        {
            return $"FieldElement_{Prime}({Num})";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Num, Prime);
        }

        public bool Equals(FieldElement other)
        {
            if (other == null)
            {
                return false;
            }
            return Num == other.Num && Prime == other.Prime;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Equals(obj as FieldElement);
        }

        public static bool operator ==(FieldElement f1, FieldElement f2)
        {
            return Equals(f1, f2);
        }

        public static bool operator !=(FieldElement f1, FieldElement f2)
        {
            return !Equals(f1, f2);
        }

        private static BigInteger Mod(BigInteger x, BigInteger m)
        {
            return (x % m + m) % m;
        }


        public static FieldElement operator +(FieldElement f1, FieldElement f2)
        {
            try
            {
                if (f1.Prime != f2.Prime)
                {
                    throw new Exception("Cannot add two numbers in different Fields");
                }
                BigInteger num = Mod(f1.Num + f2.Num, f1.Prime);
                return new FieldElement(num, f1.Prime);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static FieldElement operator -(FieldElement f1, FieldElement f2)
        {
            try
            {
                if (f1.Prime != f2.Prime)
                {
                    throw new Exception("Cannot subtract two numbers in different Fields");
                }
                BigInteger num = Mod(f1.Num - f2.Num, f1.Prime);
                return new FieldElement(num, f1.Prime);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static FieldElement operator *(FieldElement f1, FieldElement f2)
        {
            try
            {
                if (f1.Prime != f2.Prime)
                {
                    throw new Exception("Cannot multiply two numbers in different Fields");
                }
                BigInteger num = Mod(f1.Num * f2.Num, f1.Prime);
                return new FieldElement(num, f1.Prime);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public FieldElement Pow(BigInteger e)
        {
            BigInteger n = Mod(e, Prime - 1);
            BigInteger num = BigInteger.ModPow(Num, n, Prime);
            return new FieldElement(num, Prime);
        }

        public static FieldElement operator /(FieldElement f1, FieldElement f2)
        {
            try
            {
                if (f1.Prime != f2.Prime)
                {
                    throw new Exception("Cannot divide two numbers in different Fields");
                }
                BigInteger num = Mod(f1.Num * BigInteger.ModPow(f2.Num, f1.Prime - 2, f1.Prime), f1.Prime);
                return new FieldElement(num, f1.Prime);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
