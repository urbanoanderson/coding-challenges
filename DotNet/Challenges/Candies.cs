/*
    Source: https://www.hackerrank.com/challenges/candies

    Solution Author: Anderson Urbano
*/

using System;
using System.Linq;

namespace Challenges.Candies
{
    public class Candies
    {
        private int[] _students;
        private long[] _candies;

        public long CalculateMinCandies(int[] arr)
        {
            _students = arr;
            _candies = new long[_students.Length];
            for (int i = 0; i < _students.Length; i++)
                _candies[i] = -1;

            for (int i = 0; i < _students.Length; i++)
            {
                ComputeCandiesForIndex(i);
            }

            return _candies.Sum();
        }

        private void ComputeCandiesForIndex(int i)
        {
            //If value was already calculated or out of bounds
            if (OutOfBounds(i) || _candies[i] != -1)
                return;

            bool winLeft = Wins(i, i - 1);
            bool winRight = Wins(i, i + 1);

            //Lose to both: A >= B <= C
            if (!winLeft && !winRight)
            {
                _candies[i] = 1;
                return;
            }

            //Wins to both: A < B > C
            else if (winLeft && winRight)
            {
                ComputeCandiesForIndex(i+1);

                if (NumCandies(i - 1) == -1)
                    _candies[i - 1] = 1;

                _candies[i] = Math.Max(NumCandies(i - 1) + 1, NumCandies(i + 1) + 1);
                return;
            }

            //Lose to left: A >= B > C
            else if (!winLeft && winRight)
            {
                ComputeCandiesForIndex(i + 1);
                _candies[i] = NumCandies(i+1)+1;
                return;
            }

            //Lose to right: A < B <= C
            else if (winLeft && !winRight)
            {
                if (NumCandies(i - 1) != -1)
                    _candies[i] = NumCandies(i - 1) + 1;
                else
                {
                    ComputeCandiesForIndex(i + 1);
                    _candies[i] = NumCandies(i + 1) - 1;
                }
                return;
            }
        }

        private long NumCandies(int i)
        {
            if (OutOfBounds(i))
                return 0;
            else
                return _candies[i];
        }

        private bool Wins(int curIdx, int cmpIdx)
        {
            if (OutOfBounds(curIdx) || OutOfBounds(cmpIdx) || _students[curIdx] <= _students[cmpIdx])
                return false;
            return true;
        }

        private bool OutOfBounds(int i)
        {
            return (i < 0 || i >= _students.Length);
        }
    }
}
