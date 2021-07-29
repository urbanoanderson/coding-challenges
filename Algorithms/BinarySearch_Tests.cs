using System;
using NUnit.Framework;

namespace CodingChallenges.Algorithms
{
    public class BinarySearch_Tests
    {
        private static readonly object[] testcases =
        {
            new object[]
            {
                new int[] { 1 }, 1,
                true,
            },
            new object[]
            {
                new int[] { 1 }, 2,
                false,
            },
            new object[]
            {
                new int[] { 3, 2, 1 }, 2,
                true,
            },
            new object[]
            {
                new int[] { 3, 2, 1 }, 4,
                false,
            },
            new object[]
            {
                new int[] { 4, 1, 3, 2 }, 4,
                true,
            },
            new object[]
            {
                new int[] { 4, 1, 3, 2 }, 5,
                false,
            },
        };

        [Test]
        public void Find_PassNullItem_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => BinarySearch.Search(null, 1));
        }

        [Test, TestCaseSource(nameof(testcases))]
        public void MergeSortTests(int[] arr, int item, bool expected)
        {
            var result = BinarySearch.Search(arr, item);

            Assert.IsTrue(result == expected);
        }
    }
}