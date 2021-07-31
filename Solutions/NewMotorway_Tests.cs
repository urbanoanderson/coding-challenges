using CodingChallenges.Common;
using NUnit.Framework;

namespace CodingChallenges.Solutions.NewMotorway
{
    public class ChallengeSolution_Tests
    {
        private static readonly object[] testcases =
        {
            new object[]
            {
                new int[] { 1, 5, 9, 12 },
                7,
            },
            new object[]
            {
                new int[] { 5, 15 },
                0,
            },
            new object[]
            {
                new int[] { 2, 6, 7, 8, 12 },
                9,
            },
        };

        [Test, TestCaseSource(nameof(testcases))]
        public void Tests(int[] input, int expected)
        {
            var result = ChallengeSolution.Solve(input);
            Assert.IsTrue(result == expected, TestHelper.GetTestErrorMessage(result));
        }
    }
}