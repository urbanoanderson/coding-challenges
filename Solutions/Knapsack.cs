/*
    Source: classic computer science problem. Has 3 main variations:
        - Zero-One: There can be at most 1 copy of each item
        - Bounded: There is a max number of copies of each item
        - Unbounded: There can be an unlimited number of copies of each item
*/

using System;
using System.Collections.Generic;

namespace CodingChallenges.Solutions.Knapsack
{
    public static class ChallengeSolution
    {
        public static (uint[], uint) SolveZeroOne(uint[] values, uint[] weights, uint capacity)
        {
            uint[] stock = new uint[values.Length];
            Array.Fill<uint>(stock, 1);

            return SolveBounded(values, weights, stock, capacity);
        }

        public static (uint[], uint) SolveUnbounded(uint[] values, uint[] weights, uint capacity)
        {
            uint[] stock = new uint[values.Length];
            Array.Fill<uint>(stock, uint.MaxValue);

            return SolveBounded(values, weights, stock, capacity);
        }

        public static (uint[], uint) SolveBounded(uint[] values, uint[] weights, uint[] stock, uint capacity)
        {
            if (values == null || weights == null || stock == null || (values.Length != weights.Length) || (values.Length != stock.Length))
                throw new InvalidOperationException();

            Dictionary<(int, uint, uint), SolutionInstance> solutionMap = new Dictionary<(int, uint, uint), SolutionInstance>();

            SolutionInstance bestSolution = new SolutionInstance()
            {
                CapacityLeft = capacity,
                ValueSum = 0,
                ChosenItems = new uint[values.Length],
            };

            bestSolution = RecursiveSolve(values, weights, stock, bestSolution, 0, solutionMap);

            return (bestSolution.ChosenItems, bestSolution.ValueSum);
        }

        private static SolutionInstance RecursiveSolve(uint[] values, uint[] weights, uint[] stock, SolutionInstance currentSolution, int itemIdx,
            Dictionary<(int, uint, uint), SolutionInstance> solutionMap)
        {
            if (itemIdx >= values.Length || currentSolution.CapacityLeft <= 0)
                return currentSolution;

            var solutionId = (itemIdx, currentSolution.CapacityLeft, currentSolution.ValueSum);

            if (solutionMap.ContainsKey(solutionId))
                return solutionMap[solutionId];

            SolutionInstance solutionNotAdding = SolutionInstance.Clone(currentSolution);
            solutionNotAdding = RecursiveSolve(values, weights, stock, solutionNotAdding, itemIdx + 1, solutionMap);

            SolutionInstance solutionAdding = currentSolution;

            if (currentSolution.CanAddItem(itemIdx, values, weights, stock))
            {
                solutionAdding = SolutionInstance.Clone(currentSolution);
                solutionAdding.AddItem(itemIdx, values, weights, stock);
                solutionAdding = RecursiveSolve(values, weights, stock, solutionAdding, itemIdx, solutionMap);
            }

            currentSolution = SolutionInstance.GetBestSolution(solutionNotAdding, solutionAdding);
            solutionMap.Add(solutionId, currentSolution);

            return currentSolution;
        }

        private class SolutionInstance
        {
            public uint CapacityLeft { get; set; }
            public uint ValueSum { get; set; }
            public uint[] ChosenItems { get; set; }

            public bool CanAddItem(int itemIdx, uint[] values, uint[] weights, uint[] stock)
            {
                return this.CapacityLeft >= weights[itemIdx]
                    && this.ChosenItems[itemIdx] < stock[itemIdx];
            }

            public void AddItem(int itemIdx, uint[] values, uint[] weights, uint[] stock)
            {
                this.CapacityLeft -= weights[itemIdx];
                this.ValueSum += values[itemIdx];
                this.ChosenItems[itemIdx]++;
            }

            public static SolutionInstance Clone(SolutionInstance x)
            {
                return new SolutionInstance()
                {
                    CapacityLeft = x.CapacityLeft,
                    ValueSum = x.ValueSum,
                    ChosenItems = (uint[])x.ChosenItems.Clone(),
                };
            }

            public static SolutionInstance GetBestSolution(SolutionInstance a, SolutionInstance b)
            {
                return a.ValueSum >= b.ValueSum ? a : b;
            }
        }
    }
}