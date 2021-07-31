/*
    Source: https://app.codility.com/cert/view/certUW9V8C-VVGAFHXTRJ82NFQQ/details/
*/

namespace CodingChallenges.Solutions.NewMotorway
{
    public static class ChallengeSolution
    {
        public static int Solve(int[] arr)
        {
            int lastIdx = arr.Length - 1;
            long maxCost = 0;
            int[] costs = new int[arr.Length];

            for (int i = 0; i < lastIdx; i++)
            {
                costs[i] = arr[lastIdx] - arr[i];
                maxCost += costs[i];
            }

            long minCost = maxCost;

            for (int motorwayIdx = 0; motorwayIdx < lastIdx; motorwayIdx++)
            {
                long diffCost = 0;

                for (int i = 0; i <= motorwayIdx; i++)
                {
                    diffCost += costs[i] - (arr[motorwayIdx] - arr[i]);
                }

                long cost = maxCost - diffCost;

                if (cost < minCost)
                    minCost = cost;
            }

            int result = (int)(minCost % 1000000007);

            return result;
        }
    }
}