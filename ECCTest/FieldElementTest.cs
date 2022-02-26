using Microsoft.VisualStudio.TestTools.UnitTesting;
using ECC;

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
    }
}
