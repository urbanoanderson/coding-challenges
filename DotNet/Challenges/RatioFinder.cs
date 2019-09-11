/*
    Source: https://medium.com/@alexgolec/google-interview-problems-ratio-finder-d7aa8bf201e3

    Solution Author: Anderson Urbano

    Problem: Given a set of convertion ratios for different measure units,
    calculate indirect ratios from one unit to another.

    Example: given convertion ratios ["m", "cm", 100.0] and ["cm", "km", 0.00001]
    calculate ratio ["m", "km", 0.001]
*/

using System;
using System.Collections.Generic;

namespace Challenges.RatioFinder
{
    public class RatioFinder
    {
        private Dictionary<string, Dictionary<string, double>> ratioMap;

        public RatioFinder()
        {
            this.ratioMap = new Dictionary<string, Dictionary<string, double>>();
        }

        public void AddRatio(string unitFrom, string unitTo, double ratio)
        {
            if (!this.ratioMap.ContainsKey(unitFrom))
                this.ratioMap.Add(unitFrom, new Dictionary<string, double>());

            if (!this.ratioMap.ContainsKey(unitTo))
                this.ratioMap.Add(unitTo, new Dictionary<string, double>());

            this.ratioMap[unitFrom].Add(unitTo, ratio);
            this.ratioMap[unitTo].Add(unitFrom, 1.0/ratio);
        }

        public double GetRatio(string unitFrom, string unitTo)
        {
            if (!this.ratioMap.ContainsKey(unitFrom))
            {
                throw new ArgumentException($"unit '{unitFrom}' not recognized");
            }
            else if (!this.ratioMap[unitFrom].ContainsKey(unitTo))
            {
                bool ratioNotFound = true;

                // Try to calculate ratio from the graph

                if (ratioNotFound)
                {
                    throw new ArgumentException($"could not determine ratio from '{unitFrom}' to '{unitTo}'");
                }
            }

            return this.ratioMap[unitFrom][unitTo];
        }

        public double Convert(string unitFrom, string unitTo, double value)
        {
            return value * this.GetRatio(unitFrom, unitTo);
        }
    }
}