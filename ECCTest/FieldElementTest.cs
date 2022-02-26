using Microsoft.VisualStudio.TestTools.UnitTesting;
using ECC;
using System.Numerics;

namespace ECCTest
{
    [TestClass]
    public class FieldElementTest
    {
        [TestMethod]
        public void ToString_ReturnsFormattedString()
        {
            FieldElement f1 = new(2, 31);

            Assert.IsTrue(f1.ToString() == "FieldElement_31(2)");
        }

        [TestMethod]
        [DataRow("2", "2")]
        [DataRow("2", "15")]
        public void GetHashCode_ReturnsCorrectHashCode(string num1, string num2)
        {
            FieldElement f1 = new(BigInteger.Parse(num1), 31);
            FieldElement f2 = new(BigInteger.Parse(num2), 31);

            bool isSameHashCode = f1.GetHashCode() == f2.GetHashCode();

            if (num1 == num2)
            {
                Assert.IsTrue(isSameHashCode);
            }
            else
            {
                Assert.IsFalse(isSameHashCode);
            }
        }

        [TestMethod]
        [DataRow("2", "2")]
        [DataRow("2", "15")]
        public void Equals_ReturnsTrueOnlyIfTheyAreEqual(string num1, string num2)
        {
            FieldElement f1 = new(BigInteger.Parse(num1), 31);
            FieldElement f2 = new(BigInteger.Parse(num2), 31);

            bool areEqual = f1.Equals(f2);

            if (num1 == num2)
            {
                Assert.IsTrue(areEqual);
            }
            else
            {
                Assert.IsFalse(areEqual);
            }
        }
    }
}
