/*
    Source: https://www.hackerrank.com/challenges/magic-square-forming

    Solution Author: Anderson Urbano
*/

using System;
using System.Collections.Generic;

namespace Challenges.Solutions.FormingMagicSquare
{
    public static class FormingMagicSquare
    {
        private static List<int[][]> precomputedMagicSquares = new List<int[][]>
        {
            new int[][] { new int[] {4, 9, 2}, new int[] {3, 5, 7}, new int[] {8, 1, 6} },
            new int[][] { new int[] {2, 9, 4}, new int[] {7, 5, 3}, new int[] {6, 1, 8} },
            new int[][] { new int[] {8, 1, 6}, new int[] {3, 5, 7}, new int[] {4, 9, 2} },
            new int[][] { new int[] {6, 1, 8}, new int[] {7, 5, 3}, new int[] {2, 9, 4} },
            new int[][] { new int[] {8, 3, 4}, new int[] {1, 5, 9}, new int[] {6, 7, 2} },
            new int[][] { new int[] {4, 3, 8}, new int[] {9, 5, 1}, new int[] {2, 7, 6} },
            new int[][] { new int[] {6, 7, 2}, new int[] {1, 5, 9}, new int[] {8, 3, 4} },
            new int[][] { new int[] {2, 7, 6}, new int[] {9, 5, 1}, new int[] {4, 3, 8} },
        };

        public static int Solution(int[][] input)
        {
            int minCost = int.MaxValue;

            foreach (var magicSquare in precomputedMagicSquares)
            {
                int transformCost = GetTrasformationCost(input, magicSquare);
                minCost = Math.Min(minCost, transformCost);
            }

            return minCost;
        }

        private static int GetTrasformationCost(int[][] input, int[][] magicSquare)
        {
            int cost = 0;

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    cost += Math.Abs(input[i][j] - magicSquare[i][j]);
                }
            }

            return cost;
        }
    }
}