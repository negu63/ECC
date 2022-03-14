using Microsoft.VisualStudio.TestTools.UnitTesting;
using ECC;
using System.Collections.Generic;
using System.Numerics;

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
                BigInteger prime = 223;
                BigInteger a = 5;
                BigInteger b = 7;
                Point p1 = new(3, -7, a, b);
                Point p2 = new(18, 77, a, b);
                FieldElement f1 = new(192, prime);
                FieldElement f2 = new(105, prime);
                FieldElement f3 = new(0, prime);
                FieldElement f4 = new(7, prime);
                FieldElement f5 = new(1, prime);
                FieldElement f6 = new(193, prime);
                FieldElement f7 = new(17, prime);
                FieldElement f8 = new(56, prime);

                return new[] {
                    new object[] { true,  new Point[] { p1, p1 } },
                    new object[] { false,  new Point[] { p1, p2 } },
                    new object[] { true, new Point[] { new Point(f1, f2, f3, f4), new Point(f1, f2, f3, f4) } },
                    new object[] { false, new Point[] { new Point(f5, f6, f3, f4), new Point(f7, f8, f3, f4) } },
                    new object[] { true, new Point[] { new Point(null, null, a, b), new Point(null, null, a, b) } }
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
                BigInteger prime = 223;
                BigInteger a = 5;
                BigInteger b = 7;
                FieldElement f1 = new(192, prime);
                FieldElement f2 = new(105, prime);
                FieldElement f3 = new(0, prime);
                FieldElement f4 = new(7, prime);

                return new[] {
                    new object[] { "Point(infinity)", new Point(null, null, a, b) },
                    new object[] { $"Point(192, 105)_0_7 FieldElement({prime})", new Point(f1, f2, f3, f4) },
                    new object[] { $"Point(3, -7)_{a}_{b}", new Point(3, -7, a, b) }
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
                BigInteger a = 5;
                BigInteger b = 7;
                Point p1 = new(3, -7, a, b);
                Point p2 = new(18, 77, a, b);

                return new[] {
                    new object[] { true, new Point[] { p1, p1 } },
                    new object[] { false, new Point[] { p1, p2 } },
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
                BigInteger a = 5;
                BigInteger b = 7;
                Point p1 = new((object)null, null, a, b);
                Point p2 = new(2, 5, a, b);
                Point p3 = new(2, -5, a, b);
                Point p4 = new(3, 7, a, b);
                Point p5 = new(-1, -1, a, b);
                Point p6 = new(2, -5, a, b);
                Point p7 = new(-1, 1, a, b);
                Point p8 = new(18, -77, a, b);

                return new[]
                {
                    new object[] { p2, new Point[] { p1, p2 } },
                    new object[] { p2, new Point[] { p2, p1 } },
                    new object[] { p1, new Point[] { p2, p3 } },
                    new object[] { p6, new Point[] { p4, p5 } },
                    new object[] { p8, new Point[] { p7, p7 } }
                };
            }
        }
    }
}
