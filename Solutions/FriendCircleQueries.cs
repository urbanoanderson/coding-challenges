/*
    Source: https://www.hackerrank.com/challenges/friend-circle-queries
*/

using CodingChallenges.DataStructures;

namespace CodingChallenges.Solutions.FriendCircleQueries
{
    public static class ChallengeSolution
    {
        public static int[] Solve(int[][] queries)
        {
            DisjointedSets userMap = new DisjointedSets();
            int[] result = new int[queries.Length];

            for (int i = 0; i < queries.Length; i++)
            {
                int a = queries[i][0];
                int b = queries[i][1];

                userMap.Union(a, b);

                result[i] = userMap.MaxSetSize;
            }

            return result;
        }
    }
}
