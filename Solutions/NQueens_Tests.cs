using System;
using System.Linq;
using NUnit.Framework;

namespace CodingChallenges.Solutions.NQueens
{
    public class ChallengeSolution_Tests
    {
        private static readonly object[] testcases =
        {
            new object[] { 1, 1 },
            new object[] { 2, 0 },
            new object[] { 3, 0 },
            new object[] { 4, 2 },
            new object[] { 5, 10 },
            new object[] { 6, 4 },
            new object[] { 7, 40 },
            new object[] { 8, 92 },
            new object[] { 9, 352 },
            new object[] { 10, 724 },
        };

        [Test]
        public void CheckInvalidInputs()
        {
            Assert.Throws<ArgumentException>(() => ChallengeSolution.Solve(0));
            Assert.Throws<ArgumentException>(() => ChallengeSolution.Solve(-1));
        }

        [Test, TestCaseSource(nameof(testcases))]
        public void TestForNumberOfDifferentSolutions(int n, int expectedNumOfSolutions)
        {
            var result = ChallengeSolution.Solve(n);
            Assert.IsTrue(result.Count() == expectedNumOfSolutions);
        }
    }
}