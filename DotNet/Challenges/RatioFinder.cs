/*
    Source: https://medium.com/@alexgolec/google-interview-problems-ratio-finder-d7aa8bf201e3

    Solution Author: Anderson Urbano

    Problem: Given a set of convertion retios for different measure units,
    calculate asked converted values

*/

using System;

namespace Challenges.RatioFinder
{
    public class RatioFinder
    {
        public void AddRation(string unitFrom, string unitTo, double ratio)
        {
            throw new NotImplementedException();
        }

        public double GetRatio(string unitFrom, string unitTo)
        {
            throw new NotImplementedException();
        }

        public double Convert(string unitFrom, string unitTo, double value)
        {
            return value * this.GetRatio(unitFrom, unitTo);
        }
    }
}