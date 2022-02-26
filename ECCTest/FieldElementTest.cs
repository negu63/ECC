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
        [DataRow("2")]
        public void ToString_ReturnsFormattedString(string num)
        {
            FieldElement f1 = new(BigInteger.Parse(num), prime);

            Assert.IsTrue(f1.ToString() == $"FieldElement_{prime}({BigInteger.Parse(num)})");
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

        [TestMethod]
        [DataRow("2", "15", "17")]
        [DataRow("17", "21", "7")]
        public void Add_FieldElement(string num1, string num2, string expect)
        {
            FieldElement f1 = new(BigInteger.Parse(num1), prime);
            FieldElement f2 = new(BigInteger.Parse(num2), prime);

            FieldElement sum = f1 + f2;

            Assert.AreEqual(sum, new FieldElement(BigInteger.Parse(expect), prime));
        }

        [TestMethod]
        [DataRow("29", "4", "25")]
        [DataRow("15", "30", "16")]
        public void Sub_FieldElement(string num1, string num2, string expect)
        {
            FieldElement f1 = new(BigInteger.Parse(num1), prime);
            FieldElement f2 = new(BigInteger.Parse(num2), prime);

            FieldElement sub = f1 - f2;

            Assert.AreEqual(sub, new FieldElement(BigInteger.Parse(expect), prime));
        }
    }
}
