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
        [DataRow("2", "2", true)]
        [DataRow("2", "15", false)]
        public void GetHashCode_ReturnsCorrectHashCode(string num1, string num2, bool expect)
        {
            FieldElement f1 = new(BigInteger.Parse(num1), prime);
            FieldElement f2 = new(BigInteger.Parse(num2), prime);

            bool isSameHashCode = f1.GetHashCode() == f2.GetHashCode();

            Assert.AreEqual(isSameHashCode, expect);
        }

        [TestMethod]
        [DataRow("2", "2", true)]
        [DataRow("2", "15", false)]
        public void Equals_ReturnsTrueOnlyIfTheyAreEqual(string num1, string num2, bool expect)
        {
            FieldElement f1 = new(BigInteger.Parse(num1), prime);
            FieldElement f2 = new(BigInteger.Parse(num2), prime);

            bool areEqual = f1.Equals(f2);

            Assert.AreEqual(areEqual, expect);
        }

        [TestMethod]
        [DataRow("2", "2", true)]
        [DataRow("2", "15", false)]
        public void OverrideEquals_ReturnsTrueOnlyIfTheyAreEqual(string num1, string num2, bool expect)
        {
            FieldElement f1 = new(BigInteger.Parse(num1), prime);
            object f2 = new FieldElement(BigInteger.Parse(num2), prime);

            bool areEqual = f1.Equals(f2);

            Assert.AreEqual(areEqual, expect);
        }

        [TestMethod]
        [DataRow("2", "2", true)]
        [DataRow("2", "15", false)]
        public void EqualOperator_ReturnsTrueOnlyIfTheyAreEqual(string num1, string num2, bool expect)
        {
            FieldElement f1 = new(BigInteger.Parse(num1), prime);
            FieldElement f2 = new(BigInteger.Parse(num2), prime);

            bool areEqual = f1 == f2;

            Assert.AreEqual(areEqual, expect);
        }

        [TestMethod]
        [DataRow("2", "2", false)]
        [DataRow("2", "15", true)]
        public void NotEqualOperator_ReturnsTrueOnlyIfTheyAreEqual(string num1, string num2, bool expect)
        {
            FieldElement f1 = new(BigInteger.Parse(num1), prime);
            FieldElement f2 = new(BigInteger.Parse(num2), prime);

            bool areNotEqual = f1 != f2;

            Assert.AreEqual(areNotEqual, expect);
        }
    }
}
