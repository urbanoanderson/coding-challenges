/*
    Source: https://www.hackerrank.com/challenges/friend-circle-queries

    Theme: disjointed sets (useful link: https://www.hackerearth.com/practice/notes/disjoint-set-union-union-find/)

    Solution Author: Anderson Urbano
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenges.Solutions.FriendCircleQueries
{
    public class DisjointedSets
    {
        private readonly Dictionary<int, int> arr;

        private readonly Dictionary<int, int> sizes;

        public DisjointedSets()
        {
            this.arr = new Dictionary<int, int>();
            this.sizes = new Dictionary<int, int>();
            this.MaxSetSize = 0;
        }

        public int MaxSetSize { get; private set; }

        public void Union(int a, int b)
        {
            this.InitElementIfNew(a);
            this.InitElementIfNew(b);

            if (this.IsSameSet(a, b))
            {
                return;
            }

            int root_a = this.Root(a);
            int root_b = this.Root(b);

            if (this.sizes[root_a] < this.sizes[root_b])
            {
                this.arr[root_a] = this.arr[root_b];
                this.sizes[root_b] += this.sizes[root_a];
                this.MaxSetSize = Math.Max(this.sizes[root_b], this.MaxSetSize);
            }
            else
            {
                this.arr[root_b] = this.arr[root_a];
                this.sizes[root_a] += this.sizes[root_b];
                this.MaxSetSize = Math.Max(this.sizes[root_a], this.MaxSetSize);
            }
        }

        public bool IsSameSet(int a, int b)
        {
            return this.Root(a) == this.Root(b);
        }

        private void InitElementIfNew(int x)
        {
            if (!this.arr.ContainsKey(x))
            {
                this.arr[x] = x;
                this.sizes[x] = 1;
            }
        }

        private int Root(int x)
        {
            while(this.arr[x] != x)
            {
                x = this.arr[x];
            }

            return x;
        }
    }

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
