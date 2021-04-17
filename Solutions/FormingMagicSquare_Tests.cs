using NUnit.Framework;

namespace Challenges.Solutions.FormingMagicSquare
{
    public class FormingMagicSquare_Tests
    {
        private static readonly object[] testcases =
        {
            new object[]
            {
                new int[][] { new int[] {5, 3, 4}, new int[] {1, 5, 8}, new int[] {6, 4, 2} },
                7,
            },
            new object[]
            {
                new int[][] { new int[] {4, 9, 2}, new int[] {3, 5, 7}, new int[] {8, 1, 5} },
                1,
            },
            new object[]
            {
                new int[][] { new int[] {4, 8, 2}, new int[] {4, 5, 7}, new int[] {6, 1, 6} },
                4,
            },
        };

        [Test, TestCaseSource(nameof(testcases))]
        public void Tests(int[][] input, int expected)
        {
            var result = FormingMagicSquare.Solution(input);
            Assert.IsTrue(result == expected);
        }
    }
}