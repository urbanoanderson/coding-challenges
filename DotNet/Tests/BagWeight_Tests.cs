using NUnit.Framework;

namespace Challenges.BagWeight
{
    public class BagWeight_Tests
    {
        [TestCase(new int[] { 4, 2, 3, 5, 6 }, 8, 3)]
        public void Tests(int[] items, int maxWeight, int expected)
        {
            int result = BagWeight.CalculateMinTrips(items, maxWeight);
            Assert.IsTrue(result == expected);
        }
    }
}