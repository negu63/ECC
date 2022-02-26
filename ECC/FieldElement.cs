﻿using System;
using System.Numerics;

namespace ECC
{
    public class FieldElement
    {
        private BigInteger Num { get; set; }
        private BigInteger Prime { get; set; }

        public FieldElement(BigInteger num, BigInteger prime)
        {
            try
            {
                if (num >= prime || num < 0)
                {
                    throw new Exception($"Num {num} not in field range 0 to {prime - 1}");
                }
                this.Num = num;
                this.Prime = prime;
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
            return this.Num == other.Num && this.Prime == other.Prime;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as FieldElement);
        }
    }
}
