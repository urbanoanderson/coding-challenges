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

namespace Challenges.Solutions.RatioFinder
{
    public class RatioFinder
    {
        private readonly Dictionary<string, Dictionary<string, double>> ratioMap;

        public RatioFinder()
        {
            this.ratioMap = new Dictionary<string, Dictionary<string, double>>();
        }

        public void AddRatio(string unitFrom, string unitTo, double ratio)
        {
            if (!this.ratioMap.ContainsKey(unitFrom))
            {
                this.ratioMap.Add(unitFrom, new Dictionary<string, double>());
            }

            if (!this.ratioMap.ContainsKey(unitTo))
            {
                this.ratioMap.Add(unitTo, new Dictionary<string, double>());
            }

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
                var path = SearchConversionPath(unitFrom, unitTo);

                if (path.Count == 0)
                {
                    throw new ArgumentException($"could not determine ratio from '{unitFrom}' to '{unitTo}'");
                }
                else
                {
                    string prevUnit = path.Pop();
                    double ratio = 1.0;

                    while (path.Count > 0)
                    {
                        string unit = path.Pop();
                        ratio *= this.ratioMap[prevUnit][unit];
                        prevUnit = unit;
                    }

                    this.ratioMap[unitFrom].Add(unitTo, 1.0/ratio);
                    this.ratioMap[unitTo].Add(unitFrom, ratio);
                }
            }

            return this.ratioMap[unitFrom][unitTo];
        }

        public double Convert(string unitFrom, string unitTo, double value)
        {
            return value * this.GetRatio(unitFrom, unitTo);
        }

        private Stack<string> SearchConversionPath(string unitFrom, string unitTo)
        {
            List<string> marked = new List<string>();
            Stack<string> path = new Stack<string>();

            path.Push(unitFrom);

            while (path.Count > 0 && path.Peek() != unitTo)
            {
                string selectedNeighbor = null;
                string current = path.Peek();
                marked.Add(current);

                foreach (var neighborKeypair in this.ratioMap[current])
                {
                    string neighbor = neighborKeypair.Key;

                    if(!marked.Contains(neighbor))
                    {
                        selectedNeighbor = neighbor;
                        break;
                    }
                }

                if (selectedNeighbor != null)
                {
                    path.Push(selectedNeighbor);
                }
                else
                {
                    path.Pop();
                }
            }

            return path;
        }
    }
}