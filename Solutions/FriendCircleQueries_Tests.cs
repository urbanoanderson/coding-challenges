using System.Linq;
using NUnit.Framework;

namespace Challenges.Solutions.FriendCircleQueries
{
    public class FriendCircleQueries_Tests
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
        };

        [Test, TestCaseSource(nameof(testcases))]
        public void Tests(int[][] input, int[] expected)
        {
            int[] result = FriendCircleQueries.Solution(input);
            Assert.IsTrue(result.SequenceEqual(expected));
        }
    }
}