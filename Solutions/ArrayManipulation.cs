/*
    Source: https://www.hackerrank.com/challenges/crush/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=arrays

    Solution Author: Anderson Urbano
*/

using System;

namespace Challenges.Solutions.ArrayManipulation
{
    public static class ArrayManipulation
    {
        /* Calculates solution by adding the slope increases instead of keeping track of all values*/
        public static long Solution(int n, int[][] queries)
        {
            long[] array = new long[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = 0;
            }

            // each query consists of [a, b, k]
            foreach (var query in queries)
            {
                // array[a] += k
                array[query[0]-1] += query[2];

                // array[b] -= k (if b is not the last element)
                if (query[1] < array.Length)
                {
                    array[query[1]] -= query[2];
                }
            }

            long sum = 0;
            long maxValue = long.MinValue;
            for (int i = 0; i < n; i++)
            {
                sum += array[i];
                maxValue = Math.Max(maxValue, sum);
            }

            return maxValue;
        }
    }
}
