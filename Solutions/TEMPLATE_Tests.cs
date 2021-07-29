using CodingChallenges.Common;
using NUnit.Framework;

namespace CodingChallenges.Solutions.TEMPLATE
{
    public class ChallengeSolution_Tests
    {
        private static readonly object[] testcases =
        {
            new object[]
            {
                "input argument 1",
                "expected output",
            },
        };

        [Test, TestCaseSource(nameof(testcases))]
        public void Tests(string input, string expected)
        {
            var result = ChallengeSolution.Solve(input);
            Assert.IsTrue(result == expected, TestHelper.GetTestErrorMessage(result));
        }
    }
}