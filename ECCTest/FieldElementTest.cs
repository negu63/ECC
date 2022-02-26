using Microsoft.VisualStudio.TestTools.UnitTesting;
using ECC;
using System.Numerics;

namespace ECCTest
{
    [TestClass]
    public class FieldElementTest
    {
        readonly BigInteger prime = 31;

        [TestMethod]
        public void ToString_ReturnsFormattedString()
        {
            FieldElement f1 = new(2, prime);

            Assert.IsTrue(f1.ToString() == "FieldElement_31(2)");
        }

        [TestMethod]
        [DataRow("2", "2")]
        [DataRow("2", "15")]
        public void GetHashCode_ReturnsCorrectHashCode(string num1, string num2)
        {
            FieldElement f1 = new(BigInteger.Parse(num1), prime);
            FieldElement f2 = new(BigInteger.Parse(num2), prime);

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
            FieldElement f1 = new(BigInteger.Parse(num1), prime);
            FieldElement f2 = new(BigInteger.Parse(num2), prime);

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

        [TestMethod]
        [DataRow("2", "2")]
        [DataRow("2", "15")]
        public void OverrideEquals_ReturnsTrueOnlyIfTheyAreEqual(string num1, string num2)
        {
            FieldElement f1 = new(BigInteger.Parse(num1), prime);
            object f2 = new FieldElement(BigInteger.Parse(num2), prime);

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
