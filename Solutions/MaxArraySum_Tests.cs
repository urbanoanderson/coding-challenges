using NUnit.Framework;

namespace Challenges.Solutions.MaxArraySum
{
    public class ChallengeSolution_Tests
    {
        [TestCase(new int[] { 3, 5, -7, 8, 10 }, 15)]
        [TestCase(new int[] { 2, 1, 5, 8, 4 }, 11)]
        [TestCase(new int[] { 3, 7, 4, 6, 5 }, 13)]
        [TestCase(new int[] { -2, 3, 4, 5, -3, -1, 9 }, 17)]
        public void Tests(int[] input, int expected)
        {
            var result = ChallengeSolution.Solve(input);
            Assert.IsTrue(result == expected);
        }
    }
}