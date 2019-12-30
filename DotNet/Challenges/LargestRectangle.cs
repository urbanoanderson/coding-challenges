/*
    Source: https://www.hackerrank.com/challenges/largest-rectangle/problem

    Solution Author: Anderson Urbano

    Problem: Skyline Real Estate Developers is planning to demolish a number of old,
    unoccupied buildings and construct a shopping mall in their place.
    Your task is to find the largest solid area in which the mall can be constructed.
*/


using System;

namespace Challenges.LargestRectangle
{
    public class LargestRectangle
    {
        public static long GetMaxArea(int[] h)
        {
            long maxArea = h[0];

            for(int startIdx = 0; startIdx < h.Length; startIdx++)
            {
                long seqMinH = h[startIdx];

                for(int endIdx = startIdx; endIdx < h.Length; endIdx++)
                {
                    seqMinH = Math.Min(seqMinH, h[endIdx]);
                    long seqArea = seqMinH * (endIdx - startIdx + 1);
                    long seqPotential = seqMinH * (h.Length - startIdx);

                    if(seqPotential <= maxArea)
                        break;

                    if(seqArea > maxArea)
                        maxArea = seqArea;
                }
            }

            return maxArea;
        }
    }
}