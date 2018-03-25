using System;
using MathExpressions;
using NUnit.Framework;

namespace MathExtensions.Tests
{
    [TestFixture]
    public class PolynomialTests
    {
        public const int DefaultCapacity = 32;

        [Test]
        [TestCase(2.65, 3.41, 645, 345.432, 332)]
        [TestCase(1.54, 0, 0, 12.4)]
        [TestCase(3.19, 435425.43543)]
        public void PolynomialConstructorsTests(params double[] actual)
        {
            double[] expected = new double[DefaultCapacity];
            Polynomial polynomial = new Polynomial(actual);

            Array.Copy(polynomial.Coefficients, expected, polynomial.Coefficients.Length);

            CollectionAssert.AreEqual(expected, polynomial.Coefficients);
        }

        [Test]
        [TestCase(2.65, 3.41, 645, 345.432, 332, ExpectedResult = 4)]
        [TestCase(1.54, 0, 12.4, 0, ExpectedResult = 2)]
        [TestCase(3.19, 435425.43543, ExpectedResult = 1)]
        public int PolynomialDegreeTests(params double[] actual)
        {
            Polynomial polynomial = new Polynomial(actual);

            return polynomial.Degree;
        }

        [Test]
        [TestCase(new double[] { 2.65, 3.41, 645, 345.432, 332 }, new double[] { 3.12, 4.67, -2.4, 0, 5 }, ExpectedResult = "337x^4+345,432x^3+642,6x^2+8,08x^1+5,77x^0")]
        [TestCase(new double[] { 1.54, 0, 12.4, 0 }, new double[] { 3.12, 4.67, -2.4, 0, 5 }, ExpectedResult = "5x^4+10x^2+4,67x^1+4,66x^0")]
        [TestCase(new double[] {3.19, 435425.43543}, new double[] { -3.23, 232435.43543}, ExpectedResult = "667860,87086x^1-0,04x^0")]
        public string PolynomialAddTests(double[] source1, double[] source2)
        {
            Polynomial value1 = new Polynomial(source1);
            Polynomial value2 = new Polynomial(source2);

            Polynomial actual = value1 + value2;

            return actual.ToString();
        }

        [Test]
        [TestCase(new double[] { 2.65, 3.41, 645, 345.432, 332 }, new double[] { 3.12, 4.67, -2.4, 0, 5 }, ExpectedResult = "327x^4+345,432x^3+647,4x^2-1,26x^1-0,47x^0")]
        [TestCase(new double[] { 1.54, 0, 12.4, 0 }, new double[] { 3.12, 4.67, -2.4, 0, 5 }, ExpectedResult = "-5x^4+14,8x^2-4,67x^1-1,58x^0")]
        [TestCase(new double[] { 3.19, 435425.43543 }, new double[] { -3.23, 232435.43543 }, ExpectedResult = "202990x^1+6,42x^0")]
        public string PolynomialSubstructTests(double[] source1, double[] source2)
        {
            Polynomial value1 = new Polynomial(source1);
            Polynomial value2 = new Polynomial(source2);

            Polynomial actual = value1 - value2;

            return actual.ToString();
        }

        [Test]
        [TestCase(new double[] { 2.65, 3.41, 645, 345.432, 332 }, 10, ExpectedResult = "3320x^4+3454,32x^3+6450x^2+34,1x^1+26,5x^0")]
        [TestCase(new double[] { 1.54, 0, 12.4, 0 }, -2.5, ExpectedResult = "-31x^2-3,85x^0")]
        [TestCase(new double[] { 3.19, 435425.43543 }, 3.12, ExpectedResult = "1358527,3585416x^1+9,9528x^0")]
        public string PolynomialMultilplyTests(double[] source1, double value2)
        {
            Polynomial value1 = new Polynomial(source1);

            Polynomial actual = value1 * value2;

            return actual.ToString();
        }

        [Test]
        [TestCase(new double[] { 2.65, 3.41, 645, 345.432, 332 }, 10, ExpectedResult = "33,2x^4+34,5432x^3+64,5x^2+0,341x^1+0,265x^0")]
        [TestCase(new double[] { 1.54, 0, 12.4, 0 }, -2.5, ExpectedResult = "-4,96x^2-0,616x^0")]
        [TestCase(new double[] { 3.19, 435425.43543 }, 3.12, ExpectedResult = "139559,434432692x^1+1,0224358974359x^0")]
        public string PolynomialDivideTests(double[] source1, double value2)
        {
            Polynomial value1 = new Polynomial(source1);

            Polynomial actual = value1 / value2;

            return actual.ToString();
        }

        [Test]
        [TestCase(new double[] { 2, 3}, new double[] { 3, 4, -2, 0, 5 }, ExpectedResult = "15x^5+10x^4-6x^3+8x^2+17x^1+6x^0")]
        public string PolynomialMultiplyTests(double[] source1, double[] source2)
        {
            Polynomial value1 = new Polynomial(source1);
            Polynomial value2 = new Polynomial(source2);

            Polynomial actual = value1 * value2;

            return actual.ToString();
        }

        [Test]
        [TestCase(new double[] { 2.65, 3.41, 645, 345.432, 332 }, new double[] { 3.12, 4.67, -2.4, 0, 5 }, ExpectedResult = false)]
        [TestCase(new double[] { 1.54, 0, 12.4, 0 }, new double[] { 1.54, 0, 12.39, 0 }, ExpectedResult = false)]
        [TestCase(new double[] { 1.54, 0, 0, 0 }, new double[] { 1.54, 0, 12.39, 0 }, ExpectedResult = false)]
        [TestCase(new double[] { 1.54, 0, 12.4, 0 }, new double[] { 1.54, 0, 12.4, 0 }, ExpectedResult = true)]
        public bool PolynomialEqualsTests(double[] source1, double[] source2)
        {
            Polynomial value1 = new Polynomial(source1);
            Polynomial value2 = new Polynomial(source2);

            return value1 == value2;
        }

        [Test]
        [TestCase(new double[] { 2.65, 3.41, 645, 345.432, 332 }, new double[] { 3.12, 4.67, -2.4, 0, 5 }, ExpectedResult = true)]
        [TestCase(new double[] { 1.54, 0, 12.4, 0 }, new double[] { 1.54, 0, 12.39, 0 }, ExpectedResult = true)]
        [TestCase(new double[] { 1.54, 0, 0, 0 }, new double[] { 1.54, 0, 12.39, 0 }, ExpectedResult = true)]
        [TestCase(new double[] { 1.54, 0, 12.4, 0 }, new double[] { 1.54, 0, 12.4, 0 }, ExpectedResult = false)]
        public bool PolynomialCompareTests(double[] source1, double[] source2)
        {
            Polynomial value1 = new Polynomial(source1);
            Polynomial value2 = new Polynomial(source2);

            return value1 != value2;
        }

        [Test]
        public void PolynomialArgumentNullExceptionTests()
            => Assert.Throws<ArgumentNullException>(() => new Polynomial(null));

        [Test]
        public void PolynomialArgumentOutOfRangeExceptionTests()
            => Assert.Throws<ArgumentOutOfRangeException>(() => new Polynomial());
    }
}
