using NUnit.Framework;

namespace HackerRank.Candies
{
    public class Candies_Tests
    {
        [TestCase(new int[] { 3 }, 1)]
        [TestCase(new int[] { 1, 2, 2 }, 4)]
        [TestCase(new int[] { 4, 5, 6 }, 6)]
        [TestCase(new int[] { 6, 5, 4 }, 6)]
        [TestCase(new int[] { 6, 6, 6 }, 3)]
        [TestCase(new int[] { 4, 6, 4, 5, 6, 2 }, 10)]
        [TestCase(new int[] { 2, 4, 3, 5, 2, 6, 4, 5 }, 12)]
        [TestCase(new int[] { 2, 4, 2, 6, 1, 7, 8, 9, 2, 1 }, 19)]
        public void Tests(int[] input, long expected)
        {
            long result = (new Candies()).CalculateMinCandies(input);
            Assert.IsTrue(result == expected);
        }

        [Test]
        public void TestBig()
        {
            int arraySize = 100000;
            int[] input = new int[arraySize];
            long expected = 5000050000;

            for (int i = 0; i < arraySize; i++)
                input[i] = arraySize - i;

            long result = (new Candies()).CalculateMinCandies(input);

            Assert.IsTrue(result == expected);
        }
    }
}