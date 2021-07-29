using NUnit.Framework;

namespace CodingChallenges.Solutions.ParallelProcessing
{
    public class ChallengeSolution_Tests
    {
        private static readonly object[] testcases =
        {
            new object[]
            {
                new int[] { 4, 1, 3, 2, 8 }, 4, 1,
                12,
            },
            new object[]
            {
                new int[] { 3, 3, 1, 5 }, 1, 5,
                12,
            },
        };

        [Test, TestCaseSource(nameof(testcases))]
        public void Tests(int[] files, int cores, int limit, long expected)
        {
            var result = ChallengeSolution.Solve(files, cores, limit);
            Assert.IsTrue(result == expected);
        }
    }
}