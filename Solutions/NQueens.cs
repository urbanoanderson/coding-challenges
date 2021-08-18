/*
    Source: classic computer science problem. Given a chessboard of an arbitrary size NxN, place
        N queens inside in a way that no 2 queens attack each other
*/

using System;
using System.Collections.Generic;

namespace CodingChallenges.Solutions.NQueens
{
    public static class ChallengeSolution
    {
        /*
        This implementation returns a collection of all possible solutions. Each
        solution is in the format of an array that has N elements
        and each element contains the index number of the row in which the queen
        is placed.
        */
        public static IEnumerable<int[]> Solve(int n)
        {
            if (n <= 0)
                throw new ArgumentException(nameof(n));

            List<int[]> knownSolutions = new List<int[]>();
            int[] board = new int[n];

            PlaceQueen(knownSolutions, board, 0);

            return knownSolutions;
        }

        private static void PlaceQueen(List<int[]> knownSolutions, int[] board, int col)
        {
            if (col == board.Length)
            {
                knownSolutions.Add((int[])board.Clone());
                return;
            }

            for (int row = 0; row < board.Length; row++)
            {
                if (!AttackDetected(board, row, col))
                {
                    board[col] = row;
                    PlaceQueen(knownSolutions, board, col + 1);
                }
            }
        }

        private static bool AttackDetected(int[] board, int row, int col)
        {
            for (int c = 0; c < col; c++)
            {
                // Same row or diagonal detected (same col is impossible)
                if (board[c] == row
                    || col - row == c - board[c]
                    || col + row == c + board[c])
                {
                    return true;
                }
            }

            return false;
        }
    }
}