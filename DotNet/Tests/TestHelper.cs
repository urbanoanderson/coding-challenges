using System;

namespace Challenges.Tests
{
    public static class TestHelper
    {
        public static bool DoubleEquals(double a, double b, double minDiff = 0.0001)
        {
            if (Math.Abs(a - b) <= minDiff)
                return true;
            return false;
        }
    }
}