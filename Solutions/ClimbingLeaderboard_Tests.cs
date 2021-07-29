using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CodingChallenges.Solutions.ClimbingLeaderboard
{
    public class ChallengeSolution_Tests
    {
        private static readonly object[] testcases =
        {
            new object[]
            {
                new List<int> { 50 },
                new List<int> { 60 },
                new List<int> { 1 },
            },
            new object[]
            {
                new List<int> { 50 },
                new List<int> { 40 },
                new List<int> { 2 },
            },
            new object[]
            {
                new List<int> { 100, 90, 90, 80 },
                new List<int> { 70, 80, 105 },
                new List<int> { 4, 3, 1 },
            },
            new object[]
            {
                new List<int> { 100, 100, 50, 40, 40, 20, 10 },
                new List<int> { 5, 25, 50, 120 },
                new List<int> { 6, 4, 2, 1 },
            },
            new object[]
            {
                new List<int> { 100, 90, 90, 80, 75, 60 },
                new List<int> { 50, 65, 77, 90, 102 },
                new List<int> { 6, 5, 4, 2, 1 },
            },
        };

        [Test, TestCaseSource(nameof(testcases))]
        public void Tests(List<int> ranked, List<int> player, List<int> expected)
        {
            var result = ChallengeSolution.Solve(ranked, player);
            Assert.IsTrue(result.SequenceEqual(expected));
        }
    }
}