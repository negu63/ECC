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
                    new object[] { false,  new Point[] { new Point(3, -7, 5, 7), new Point(18, 77, 5, 7) } }
                };
            }
        }
    }
}
