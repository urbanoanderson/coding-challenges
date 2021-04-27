/*
    Source: https://www.hackerrank.com/challenges/candies

    Solution Author: Anderson Urbano
*/

using System;
using System.Linq;

namespace Challenges.Solutions.Candies
{
    public static class ChallengeSolution
    {
        private static int[] students;
        private static long[] candies;

        public static long Solve(int[] arr)
        {
            students = arr;
            candies = new long[students.Length];

            for (int i = 0; i < students.Length; i++)
            {
                candies[i] = -1;
            }

            for (int i = 0; i < students.Length; i++)
            {
                ComputeCandiesForIndex(i);
            }

            return candies.Sum();
        }

        private static void ComputeCandiesForIndex(int i)
        {
            //If value was already calculated or out of bounds
            if (OutOfBounds(i) || candies[i] != -1)
            {
                return;
            }

            bool winLeft = Wins(i, i - 1);
            bool winRight = Wins(i, i + 1);

            //Lose to both: A >= B <= C
            if (!winLeft && !winRight)
            {
                candies[i] = 1;
                return;
            }

            //Wins to both: A < B > C
            else if (winLeft && winRight)
            {
                ComputeCandiesForIndex(i+1);

                if (NumCandies(i - 1) == -1)
                {
                    candies[i - 1] = 1;
                }

                candies[i] = Math.Max(NumCandies(i - 1) + 1, NumCandies(i + 1) + 1);
                return;
            }

            //Lose to left: A >= B > C
            else if (!winLeft && winRight)
            {
                ComputeCandiesForIndex(i + 1);
                candies[i] = NumCandies(i+1)+1;
                return;
            }

            //Lose to right: A < B <= C
            else if (winLeft && !winRight)
            {
                if (NumCandies(i - 1) != -1)
                {
                    candies[i] = NumCandies(i - 1) + 1;
                }
                else
                {
                    ComputeCandiesForIndex(i + 1);
                    candies[i] = NumCandies(i + 1) - 1;
                }
                return;
            }
        }

        private static long NumCandies(int i)
        {
            if (OutOfBounds(i))
            {
                return 0;
            }
            else
            {
                return candies[i];
            }
        }

        private static bool Wins(int curIdx, int cmpIdx)
        {
            if (OutOfBounds(curIdx) || OutOfBounds(cmpIdx) || students[curIdx] <= students[cmpIdx])
            {
                return false;
            }

            return true;
        }

        private static bool OutOfBounds(int i)
        {
            return (i < 0 || i >= students.Length);
        }
    }
}
