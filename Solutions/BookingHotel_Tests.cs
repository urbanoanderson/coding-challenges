using NUnit.Framework;

namespace Challenges.Solutions.BookingHotel
{
    public class BookingHotel_Tests
    {
        [TestCase("Regular: 16Mar2009(mon), 17Mar2009(tues), 18Mar2009(wed)", "Lakewood")]
        [TestCase("Regular: 20Mar2009(fri), 21Mar2009(sat), 22Mar2009(sun)", "Bridgewood")]
        [TestCase("Rewards: 26Mar2009(thur), 27Mar2009(fri), 28Mar2009(sat)", "Ridgewood")]
        public void Tests(string input, string expected)
        {
            string result = BookingHotel.Solution(input);
            Assert.IsTrue(result == expected);
        }
    }
}