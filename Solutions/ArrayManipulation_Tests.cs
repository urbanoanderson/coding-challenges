using NUnit.Framework;

namespace Challenges.Solutions.ArrayManipulation
{
    public class ChallengeSolution_Tests
    {
        private static readonly object[] testcases =
        {
            new object[] { 5, new int[][] {
                new int[] { 1, 2, 100 },
                new int[] { 2, 5, 100 },
                new int[] { 3, 4, 100 } },
                200 },
        };

        [Test, TestCaseSource(nameof(testcases))]
        public void Tests(int n, int[][] queries, long expected)
        {
            var result = ChallengeSolution.Solve(n, queries);
            Assert.IsTrue(result == expected);
        }
    }
}