/*
    Useful link: https://www.hackerearth.com/practice/notes/disjoint-set-union-union-find/
*/

using System;
using System.Collections.Generic;

namespace CodingChallenges.DataStructures
{
    public class DisjointSets
    {
        private readonly Dictionary<int, int> arr;

        private readonly Dictionary<int, int> sizes;

        public DisjointSets()
        {
            this.arr = new Dictionary<int, int>();
            this.sizes = new Dictionary<int, int>();
            this.MaxSetSize = 0;
        }

        public int MaxSetSize { get; private set; }

        public void Union(int a, int b)
        {
            this.InitUnitSetIfNew(a);
            this.InitUnitSetIfNew(b);

            if (this.IsSameSet(a, b))
            {
                return;
            }

            int root_a = this.GetRootOf(a);
            int root_b = this.GetRootOf(b);

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

        public void InitUnitSetIfNew(int x)
        {
            if (!this.arr.ContainsKey(x))
            {
                this.arr[x] = x;
                this.sizes[x] = 1;
                this.MaxSetSize = Math.Max(1, this.MaxSetSize);
            }
        }

        public bool IsSameSet(int a, int b)
        {
            return this.arr.ContainsKey(a)
                && this.arr.ContainsKey(b)
                && (this.GetRootOf(a) == this.GetRootOf(b));
        }

        private int GetRootOf(int x)
        {
            // Do path compression
            if (this.arr[x] != x)
            {
                this.arr[x] = this.GetRootOf(this.arr[x]);
                this.sizes[x] = this.sizes[this.arr[x]];
            }

            return this.arr[x];
        }
    }
}