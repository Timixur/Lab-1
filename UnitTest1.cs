using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ProgNaCs_PZ_1;

namespace ProgNaCs_PZ_1.Tests
{
    [TestClass]
    public class VectorTests
    {
        [TestMethod]
        public void Constructor_CorrectArray_CreatesVector()
        {
            double[] data = { 1.0, 2.0, 3.0 };
            Vector v = new Vector(data);

            Assert.AreEqual(3, v.Dimension);
            Assert.AreEqual(1.0, v[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullArray_ThrowsException()
        {
            double[] data = null;
            Vector v = new Vector(data);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_EmptyArray_ThrowsException()
        {
            double[] data = new double[0];
            Vector v = new Vector(data);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_NegativeDimension_ThrowsException()
        {
            Vector v = new Vector(-5);
        }

        [TestMethod]
        public void Add_SameDimension_ReturnsCorrectSum()
        {
            Vector v1 = new Vector(new double[] { 1.0, 2.0 });
            Vector v2 = new Vector(new double[] { 3.0, 4.0 });
            Vector expected = new Vector(new double[] { 4.0, 6.0 });
            Vector actual = v1.Add(v2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_DifferentDimension_ThrowsException()
        {
            Vector v1 = new Vector(new double[] { 1.0, 2.0 });
            Vector v2 = new Vector(new double[] { 1.0, 2.0, 3.0 });
            v1.Add(v2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_NullVector_ThrowsException()
        {
            Vector v1 = new Vector(new double[] { 1.0, 2.0 });
            v1.Add(null);
        }

        [TestMethod]
        public void Subtract_SameDimension_ReturnsCorrectDifference()
        {
            Vector v1 = new Vector(new double[] { 5.0, 7.0 });
            Vector v2 = new Vector(new double[] { 2.0, 3.0 });
            Vector expected = new Vector(new double[] { 3.0, 4.0 });

            Vector actual = v1.Subtract(v2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Subtract_DifferentDimension_ThrowsException()
        { 
     
            Vector v1 = new Vector(new double[] { 1.0, 2.0 });
            Vector v2 = new Vector(new double[] { 1.0 });
            v1.Subtract(v2);
        }

        [TestMethod]
        public void Multiply_PositiveNumber_ReturnsMultipliedVector()
        {
            Vector v = new Vector(new double[] { 2.0, -3.0 });
            Vector expected = new Vector(new double[] { 4.0, -6.0 });

            Vector actual = v.Multiply(2.0);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Multiply_Zero_ReturnsZeroVector()
        {
            Vector v = new Vector(new double[] { 5.0, -10.0 });
            Vector expected = new Vector(new double[] { 0.0, 0.0 });

            Vector actual = v.Multiply(0.0);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetMagnitude_Valid2DVector_ReturnsLength()
        {
            Vector v = new Vector(new double[] { 3.0, 4.0 });
            double expected = 5.0;

            double actual = v.GetMagnitude();
            Assert.AreEqual(expected, actual, 0.0001);
        }

        [TestMethod]
        public void GetMagnitude_ZeroVector_ReturnsZero()
        {
            Vector v = new Vector(new double[] { 0.0, 0.0, 0.0 });

            double actual = v.GetMagnitude();
            Assert.AreEqual(0.0, actual, 0.0001);
        }

        [TestMethod]
        public void DotProduct_PerpendicularVectors_ReturnsZero()
        {
            Vector v1 = new Vector(new double[] { 1.0, 0.0 });
            Vector v2 = new Vector(new double[] { 0.0, 1.0 });
            double actual = v1.DotProduct(v2);
            Assert.AreEqual(0.0, actual, 0.0001);
        }

        [TestMethod]
        public void DotProduct_NormalVectors_ReturnsCorrectValue()
        {
            Vector v1 = new Vector(new double[] { 1.0, 2.0 });
            Vector v2 = new Vector(new double[] { 4.0, 5.0 });
            double expected = 14.0;

            double actual = v1.DotProduct(v2);
            Assert.AreEqual(expected, actual, 0.0001);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DotProduct_DifferentDimension_ThrowsException()
        {
            Vector v1 = new Vector(new double[] { 1.0, 2.0 });
            Vector v2 = new Vector(new double[] { 1.0 });
            v1.DotProduct(v2);
        }

        [TestMethod]
        public void ToString_ValidVector_ReturnsFormattedString()
        {
            Vector v = new Vector(new double[] { 1.0, 2.0, 3.0 });
            string expected = "(1; 2; 3)";

            string actual = v.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}