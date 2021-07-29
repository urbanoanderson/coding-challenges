using System.Linq;
using NUnit.Framework;

namespace CodingChallenges.Algorithms.Sorting
{
    public class Sorting_Tests
    {
        private static readonly object[] testcases =
        {
            new object[]
            {
                new int[] { 1 },
                new int[] { 1 },
            },
            new object[]
            {
                new int[] { 3, 2, 1 },
                new int[] { 1, 2, 3 },
            },
            new object[]
            {
                new int[] { 1, 2, 3 },
                new int[] { 1, 2, 3 },
            },
            new object[]
            {
                new int[] { 4, 1, 3, 2, 5 },
                new int[] { 1, 2, 3, 4, 5 },
            },
        };

        [Test, TestCaseSource(nameof(testcases))]
        public void QuickSortTests(int[] input, int[] expected)
        {
            var result = QuickSort.CopyAndSort(input);

            Assert.IsTrue(result.SequenceEqual(expected));
        }

        [Test, TestCaseSource(nameof(testcases))]
        public void MergeSortTests(int[] input, int[] expected)
        {
            var result = MergeSort.CopyAndSort(input);

            Assert.IsTrue(result.SequenceEqual(expected));
        }

        [Test, TestCaseSource(nameof(testcases))]
        public void HeapSortTests(int[] input, int[] expected)
        {
            var result = HeapSort.CopyAndSort(input);

            Assert.IsTrue(result.SequenceEqual(expected));
        }

        [Test, TestCaseSource(nameof(testcases))]
        public void BubbleSortTests(int[] input, int[] expected)
        {
            var result = BubbleSort.CopyAndSort(input);

            Assert.IsTrue(result.SequenceEqual(expected));
        }

        [Test, TestCaseSource(nameof(testcases))]
        public void SelectionSortTests(int[] input, int[] expected)
        {
            var result = SelectionSort.CopyAndSort(input);

            Assert.IsTrue(result.SequenceEqual(expected));
        }

        [Test, TestCaseSource(nameof(testcases))]
        public void InsertionSortTests(int[] input, int[] expected)
        {
            var result = InsertionSort.CopyAndSort(input);

            Assert.IsTrue(result.SequenceEqual(expected));
        }
    }
}