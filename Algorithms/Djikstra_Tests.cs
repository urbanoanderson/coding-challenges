using System;
using System.Linq;
using NUnit.Framework;

namespace CodingChallenges.Algorithms
{
    public class Djikstra_Tests
    {
        private const int NO_CONNECTION = -1;

        private static readonly object[] testcases =
        {
            new object[]
            {
                new int[][]
                {
                    new int[] { 0 },
                },
                0, 0,
                new int[] { 0 }, 0,
            },
            new object[]
            {
                new int[][]
                {
                    new int[] { 0, 1 },
                    new int[] { 1, 0 },
                },
                0, 1,
                new int[] { 0, 1 }, 1,
            },
            new object[]
            {
                new int[][]
                {
                    new int[] { 0, NO_CONNECTION },
                    new int[] { NO_CONNECTION, 0 },
                },
                0, 1,
                new int[] { }, NO_CONNECTION,
            },
            new object[]
            {
                new int[][]
                {
                    new int[] { 0, 4, 2, NO_CONNECTION, 7 },
                    new int[] { 4, 0, NO_CONNECTION, 2, NO_CONNECTION },
                    new int[] { 2, NO_CONNECTION, 0, NO_CONNECTION, 3 },
                    new int[] { NO_CONNECTION, 2, NO_CONNECTION, 0, 5 },
                    new int[] { 7, NO_CONNECTION, 3, 5, 0 },
                },
                0, 4,
                new int[] { 0, 2, 4 }, 5,
            },
        };

        [Test, TestCaseSource(nameof(testcases))]
        public void ShortestPathTests(int[][] graph, int from, int to, int[] expectedPath, int expectedCost)
        {
            var result = Djikstra.ShortestPath(graph, from, to, NO_CONNECTION);

            Assert.IsTrue(result.Item1.SequenceEqual(expectedPath));
            Assert.IsTrue(result.Item2 == expectedCost);
        }
    }
}