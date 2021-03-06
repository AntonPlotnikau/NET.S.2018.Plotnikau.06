﻿using System;
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

            Sorts.BubbleSort(actual, new TestComparers.SumArrayRowIncComparer());

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

            Sorts.BubbleSort(actual, new TestComparers.SumArrayRowDecComparer());

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

            Sorts.BubbleSort(actual, new TestComparers.MaxArrayRowIncComparer());

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

            Sorts.BubbleSort(actual, new TestComparers.MaxArrayRowDecComparer());

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(new int[] { 23, 67, 67, 342, 234 }, null, new int[] { 0, -3, 12 }, new int[] { int.MaxValue, -24 }, new int[] { int.MaxValue, -200000 })]
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

            Sorts.BubbleSort(actual, new TestComparers.MinArrayRowIncComparer());

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

            Sorts.BubbleSort(actual, new TestComparers.MinArrayRowDecComparer());

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void SortsArrayNullExceptionTests()
            => Assert.Throws<ArgumentNullException>(() => Sorts.BubbleSort(null, new TestComparers.MinArrayRowIncComparer()));

        [TestCase(new int[] { 23, 67, 67, 342, 234 }, null, new int[] { 0, -3, 12 }, new int[] { int.MaxValue, -24 }, new int[] { int.MaxValue, int.MinValue })]
        public void SortByAscendingOrderOfElementsSumTestsUsingDelegate(int[] source1, int[] source2, int[] source3, int[] source4, int[] source5)
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

            Sorts.BubbleSort(actual, new TestComparers.SumArrayRowIncComparer().Compare);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(new int[] { 23, 67, 67, 342, 234 }, null, new int[] { 0, -3, 12 }, new int[] { int.MaxValue, -24 }, new int[] { int.MaxValue, int.MinValue })]
        public void SortByDescendingOrderOfElementsSumTestsUsingDelegate(int[] source1, int[] source2, int[] source3, int[] source4, int[] source5)
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

            Sorts.BubbleSort(actual, new TestComparers.SumArrayRowDecComparer().Compare);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(new int[] { 23, 67, 67, 342, 234 }, null, new int[] { 0, -3, 12 }, new int[] { int.MaxValue, -24 }, new int[] { int.MaxValue, int.MinValue })]
        public void SortByAscendingOrderOfMaxElementsTestsUsingDelegate(int[] source1, int[] source2, int[] source3, int[] source4, int[] source5)
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

            Sorts.BubbleSort(actual, new TestComparers.MaxArrayRowIncComparer().Compare);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(new int[] { 23, 67, 67, 342, 234 }, null, new int[] { 0, -3, 12 }, new int[] { int.MaxValue, -24 }, new int[] { int.MaxValue, int.MinValue })]
        public void SortByDescendingOrderOfMaxElementsTestsUsingDelegate(int[] source1, int[] source2, int[] source3, int[] source4, int[] source5)
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

            Sorts.BubbleSort(actual, new TestComparers.MaxArrayRowDecComparer().Compare);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(new int[] { 23, 67, 67, 342, 234 }, null, new int[] { 0, -3, 12 }, new int[] { int.MaxValue, -24 }, new int[] { int.MaxValue, -200000 })]
        public void SortByAscendingOrderOfMinElementsTestsUsingDelegate(int[] source1, int[] source2, int[] source3, int[] source4, int[] source5)
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

            Sorts.BubbleSort(actual, new TestComparers.MinArrayRowIncComparer().Compare);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(new int[] { 23, 67, 67, 342, 234 }, null, new int[] { 0, -3, 12 }, new int[] { int.MaxValue, -24 }, new int[] { int.MaxValue, int.MinValue })]
        public void SortByDescendingOrderOfMinElementsTestsUsingDelegate(int[] source1, int[] source2, int[] source3, int[] source4, int[] source5)
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

            Sorts.BubbleSort(actual, new TestComparers.MinArrayRowDecComparer().Compare);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
