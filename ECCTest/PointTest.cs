using Microsoft.VisualStudio.TestTools.UnitTesting;
using ECC;
using System.Collections.Generic;

namespace ECCTest
{
    [TestClass]
    public class PointTest
    {
        [TestMethod]
        [DynamicData(nameof(GetHashCodeInput))]
        public void GetHashCode_ReturnsCorrectHashCode(bool expected, Point[] points)
        {
            Assert.AreEqual(expected, points[0].GetHashCode() == points[1].GetHashCode());
        }

        public static IEnumerable<object[]> GetHashCodeInput
        {
            get
            {
                return new[] {
                    new object[] { true,  new Point[] { new Point(3, -7, 5, 7), new Point(3, -7, 5, 7) } },
                    new object[] { false,  new Point[] { new Point(3, -7, 5, 7), new Point(18, 77, 5, 7) } },
                    new object[] { true, new Point[] {
                        new Point(new FieldElement(192, 223), new FieldElement(105, 223), new FieldElement(0, 223), new FieldElement(7, 223)),
                        new Point(new FieldElement(192, 223), new FieldElement(105, 223), new FieldElement(0, 223), new FieldElement(7, 223)) } },
                     new object[] { false, new Point[] {
                        new Point(new FieldElement(1, 223), new FieldElement(193, 223), new FieldElement(0, 223), new FieldElement(7, 223)),
                        new Point(new FieldElement(17, 223), new FieldElement(56, 223), new FieldElement(0, 223), new FieldElement(7, 223)) } },
                     new object[] { true, new Point[] { new Point(null, null, 5, 7), new Point(null, null, 5, 7) } }
                };
            }
        }
    }
}
