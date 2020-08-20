using NUnit.Framework;

namespace Challenges.MatrixClusterCount
{
    public class MatrixClusterCount_Tests
    {
        private static readonly object[] testcases =
        {
            new object[] { new bool[,] { { false } }, 0 },
            new object[] { new bool[,] { { true }, { false } }, 1 },
            new object[] { new bool[,] { { true, true }, { false, false } }, 1 },
            new object[] { new bool[,] { { true, false, true }, { false, false, false }, { true, false, true } }, 4 },
            new object[] { new bool[,] {
                { true, true, true },
                { false, false, true },
                { true, false, true }
               }, 2 },
            new object[] { new bool[,] {
                { true, true, false, false },
                { false, false, true, false },
                { false, false, false, false },
                { true, true, true, true },
                }, 3 },
            new object[] { new bool[,] {
                { true, false, true, false },
                { false, true, false, true },
                { true, false, true, false },
                }, 6 },
            new object[] { new bool[,] {
                { true, false, false },
                { false, true, false },
                { false, false, true }
               }, 3 },
            new object[] { new bool[,] {
                { false, false, true, false },
                { true, false, true, false },
                { true, true, false, false },
                }, 2 },
            new object[] { new bool[,] {
                { true, true, true },
                { true, true, true },
                { true, true, true }
               }, 1 },
        };

        [Test, TestCaseSource(nameof(testcases))]
        public void Tests(bool[,] input, int expected)
        {
            int result = MatrixClusterCount.CountClusters(input);
            Assert.IsTrue(result == expected);
        }
    }
}