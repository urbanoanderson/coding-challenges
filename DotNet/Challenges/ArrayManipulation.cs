/*
    Source: https://www.hackerrank.com/challenges/crush/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=arrays

    Solution Author: Anderson Urbano
*/

using System;

namespace Challenges.ArrayManipulation
{
    public class ArrayManipulation
    {
        public static long Solution(int n, int[][] queries)
        {
            long[] array = new long[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = 0;
            }

            foreach (var query in queries)
            {
                for (int j = query[0]-1; j < query[1]; j++)
                {
                    array[j] += query[2];
                }
            }

            long maxValue = array[0];
            for (int i = 0; i < n; i++)
            {
                if (array[i] > maxValue)
                    maxValue = array[i];
            }

            return maxValue;
        }
    }
}
