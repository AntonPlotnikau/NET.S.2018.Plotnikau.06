using System;
using NUnit.Framework;
using JuggedArrayOperations;

namespace JuggedArrayOperations.Tests
{
    [TestFixture]
    public class SortsTests
    {
        [Test]
        [TestCase(new int[] { 23, 67 ,67 ,342 ,234 }, null, new int[] { 0, -3, 12 }, new int[] { int.MaxValue, -24 }, new int[] { int.MaxValue, int.MinValue })]
        public void SortByAscendingOrderOfElementsSumTests(int[] source1, int[] source2, int[] source3, int[] source4, int[] source5)
        {
            int[][] actual = new int[5][];
            actual[0] = source1;
            actual[1] = source2;
            actual[2] = source3;
            actual[3] = source4;
            actual[4] = source5;

            int[][] expected = new int[5][];
            expected[0] = source5;
            expected[1] = source3;
            expected[2] = source1;
            expected[3] = source4;
            expected[4] = source2;

            Sorts.SortByAscendingOrderOfElementsSum(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(new int[] { 23, 67, 67, 342, 234 }, null, new int[] { 0, -3, 12 }, new int[] { int.MaxValue, -24 }, new int[] { int.MaxValue, int.MinValue })]
        public void SortByDescendingOrderOfElementsSumTests(int[] source1, int[] source2, int[] source3, int[] source4, int[] source5)
        {
            int[][] actual = new int[5][];
            actual[0] = source1;
            actual[1] = source2;
            actual[2] = source3;
            actual[3] = source4;
            actual[4] = source5;

            int[][] expected = new int[5][];
            expected[0] = source2;
            expected[1] = source4;
            expected[2] = source1;
            expected[3] = source3;
            expected[4] = source5;

            Sorts.SortByDescendingOrderOfElementsSum(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(new int[] { 23, 67, 67, 342, 234 }, null, new int[] { 0, -3, 12 }, new int[] { int.MaxValue, -24 }, new int[] { int.MaxValue, int.MinValue })]
        public void SortByAscendingOrderOfMaxElementsTests(int[] source1, int[] source2, int[] source3, int[] source4, int[] source5)
        {
            int[][] actual = new int[5][];
            actual[0] = source1;
            actual[1] = source2;
            actual[2] = source3;
            actual[3] = source4;
            actual[4] = source5;

            int[][] expected = new int[5][];
            expected[0] = source3;
            expected[1] = source1;
            expected[2] = source4;
            expected[3] = source5;
            expected[4] = source2;

            Sorts.SortByAscendingOrderOfMaxElements(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(new int[] { 23, 67, 67, 342, 234 }, null, new int[] { 0, -3, 12 }, new int[] { int.MaxValue, -24 }, new int[] { int.MaxValue, int.MinValue })]
        public void SortByDescendingOrderOfMaxElementsTests(int[] source1, int[] source2, int[] source3, int[] source4, int[] source5)
        {
            int[][] actual = new int[5][];
            actual[0] = source1;
            actual[1] = source2;
            actual[2] = source3;
            actual[3] = source4;
            actual[4] = source5;

            int[][] expected = new int[5][];
            expected[0] = source2;
            expected[1] = source4;
            expected[2] = source5;
            expected[3] = source1;
            expected[4] = source3;

            Sorts.SortByDescendingOrderOfMaxElements(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(new int[] { 23, 67, 67, 342, 234 }, null, new int[] { 0, -3, 12 }, new int[] { int.MaxValue, -24 }, new int[] { int.MaxValue, int.MinValue })]
        public void SortByAscendingOrderOfMinElementsTests(int[] source1, int[] source2, int[] source3, int[] source4, int[] source5)
        {
            int[][] actual = new int[5][];
            actual[0] = source1;
            actual[1] = source2;
            actual[2] = source3;
            actual[3] = source4;
            actual[4] = source5;

            int[][] expected = new int[5][];
            expected[0] = source5;
            expected[1] = source4;
            expected[2] = source3;
            expected[3] = source1;
            expected[4] = source2;

            Sorts.SortByAscendingOrderOfMinElements(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(new int[] { 23, 67, 67, 342, 234 }, null, new int[] { 0, -3, 12 }, new int[] { int.MaxValue, -24 }, new int[] { int.MaxValue, int.MinValue })]
        public void SortByDescendingOrderOfMinElementsTests(int[] source1, int[] source2, int[] source3, int[] source4, int[] source5)
        {
            int[][] actual = new int[5][];
            actual[0] = source1;
            actual[1] = source2;
            actual[2] = source3;
            actual[3] = source4;
            actual[4] = source5;

            int[][] expected = new int[5][];
            expected[0] = source2;
            expected[1] = source1;
            expected[2] = source3;
            expected[3] = source4;
            expected[4] = source5;

            Sorts.SortByDescendingOrderOfMinElements(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void SortsArgumentNullExceptionTests()
            => Assert.Throws<ArgumentNullException>(() => Sorts.SortByAscendingOrderOfElementsSum(null));

        [Test]
        public void SortsArgumentOutOfRangeExceptionTests()
            => Assert.Throws<ArgumentOutOfRangeException>(() => Sorts.SortByAscendingOrderOfElementsSum(new int[0][]));
    }
}
