using NUnit.Framework;

namespace Challenges.MatrixClusterCount
{
    public class MatrixClusterCount_Tests
    {
        private  static readonly object[] testcases =
        {
            new object[] { new bool[,] { { true, true }, { false, false } }, 1 },
            new object[] { new bool[,] { { true }, { false } }, 1 },
        };

        [Test, TestCaseSource(nameof(testcases))]
        public void Tests(bool[,] input, long expected)
        {
            long result = MatrixClusterCount.CountClusters(input);
            Assert.IsTrue(result == expected);
        }
    }
}