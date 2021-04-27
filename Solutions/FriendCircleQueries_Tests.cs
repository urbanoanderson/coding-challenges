using System.Linq;
using NUnit.Framework;

namespace Challenges.Solutions.FriendCircleQueries
{
    public class ChallengeSolution_Tests
    {
        private static readonly object[] testcases =
        {
            new object[]
            {
                new int[][] { new int[] {1, 2}, new int[] {3, 4}, new int[] {2, 3} },
                new int[] {2, 2, 4}
            },

            new object[]
            {
                new int[][] { new int[] {1000000000, 23}, new int[] {11, 3778}, new int[] {7, 47}, new int[] {11, 1000000000} },
                new int[] {2, 2, 2, 4}
            },

            new object[]
            {
                new int[][] { new int[] {1, 2}, new int[] {3, 4}, new int[] {1, 3}, new int[] {5, 7}, new int[] {5, 6}, new int[] {7, 4} },
                new int[] {2, 2, 4, 4, 4, 7}
            },

            new object[]
            {
                new int[][] { new int[] {6, 4}, new int[] {5, 9}, new int[] {8, 5}, new int[] {4, 1}, new int[] {1, 5}, new int[] {7, 2}, new int[] {4, 2}, new int[] {7, 6} },
                new int[] {2, 2, 3, 3, 6, 6, 8, 8}
            },
        };

        [Test, TestCaseSource(nameof(testcases))]
        public void Tests(int[][] input, int[] expected)
        {
            int[] result = ChallengeSolution.Solve(input);
            Assert.IsTrue(result.SequenceEqual(expected));
        }
    }
}