/*
    Source: life

    Solution Author: Anderson Urbano

    Problem: In a bag of items, each item has a weight represented by
    an integer. If someone can only carry a max o 2 items at a time
    from the bag and has a maximum weight capacity of W, what is the
    minimum number of trips this person must do in order to carry
    all items from the bag.
*/

using System;

namespace Challenges.Solutions.BagWeight
{
    public class BagWeight
    {
        public static int CalculateMinTrips(int[] items, int maxWeight)
        {
            Array.Sort(items);
            int idx_min = 0;
            int idx_max = items.Length - 1;
            int trips = 0;

            while(idx_min <= idx_max)
            {
                if (idx_min == idx_max)
                {
                    idx_min++;
                    idx_max--;
                }

                else
                {
                    int sumWeights = items[idx_min] + items[idx_max];

                    if (sumWeights > maxWeight)
                    {
                        idx_max--;
                    }

                    else if (sumWeights <= maxWeight)
                    {
                        idx_min++;
                        idx_max--;
                    }
                }

                trips++;
            }

            return trips;
        }
    }
}
