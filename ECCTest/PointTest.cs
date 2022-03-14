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
            bool actual = points[0].GetHashCode() == points[1].GetHashCode();

            Assert.AreEqual(expected, actual);
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

        [TestMethod]
        [DynamicData(nameof(ToStringInput))]
        public void ToString_ReturnsFormattedString(string expected, Point point)
        {
            string actual = point.ToString();

            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> ToStringInput
        {
            get
            {
                return new[] {
                    new object[] { "Point(infinity)", new Point(null, null, 5, 7) },
                    new object[] {
                        "Point(192, 105)_0_7 FieldElement(223)",
                        new Point(new FieldElement(192, 223), new FieldElement(105, 223), new FieldElement(0, 223), new FieldElement(7, 223)) },
                    new object[] { "Point(3, -7)_5_7", new Point(3, -7, 5, 7) }
                };
            }
        }

        [TestMethod]
        [DynamicData(nameof(EqualsInput))]
        public void Equals_ReturnsTrueOnlyIfTheyAreEqual(bool expected, Point[] points)
        {
            bool actual = points[0].Equals(points[1]);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DynamicData(nameof(EqualsInput))]
        public void OverrideEquals_ReturnsTrueOnlyIfTheyAreEqual(bool expected, object[] points)
        {
            bool actual = ((Point)points[0]).Equals(points[1]);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DynamicData(nameof(EqualsInput))]
        public void EqualOperator_ReturnsTrueOnlyIfTheyAreEqual(bool expected, Point[] points)
        {
            bool actual = points[0] == points[1];

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DynamicData(nameof(EqualsInput))]
        public void NotEqualOperator_ReturnsTrueOnlyIfTheyAreNotEqual(bool expected, Point[] points)
        {
            bool actual = points[0] != points[1];

            Assert.AreEqual(!expected, actual);
        }

        public static IEnumerable<object[]> EqualsInput
        {
            get
            {
                return new[] {
                    new object[] { true, new Point[] { new Point(3, -7, 5, 7), new Point(3, -7, 5, 7) } },
                    new object[] { false, new Point[] { new Point(3, -7, 5, 7), new Point(18, 77, 5, 7) } },
                };
            }
        }

        [TestMethod]
        [DynamicData(nameof(AddInput))]
        public void Add_Point(Point expected, Point[] points)
        {
            Point actual = points[0] + points[1];

            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> AddInput
        {
            get
            {
                Point p1 = new((object)null, null, 5, 7);
                Point p2 = new(2, 5, 5, 7);
                Point p3 = new(2, -5, 5, 7);

                return new[]
                {
                    new object[] { p2, new Point[] { p1, p2 } },
                    new object[] { p2, new Point[] { p2, p1 } },
                    new object[] { p1, new Point[] { p2, p3 } }
                };
            }
        }
    }
}
