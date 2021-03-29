using System;

namespace Challenges.Common
{
    public static class TestHelper
    {
        public static bool FloatEquals(float a, float b, float minDiff = 0.0001f)
        {
            return Math.Abs(a - b) <= minDiff;
        }

        public static bool DoubleEquals(double a, double b, double minDiff = 0.0001)
        {
            return Math.Abs(a - b) <= minDiff;
        }
    }
}