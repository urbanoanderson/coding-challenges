using System;
using System.Collections.Generic;
using CodingChallenges.Common;

namespace CodingChallenges.DataStructures
{
    /* MAX HEAPS are heaps where the parents are always greater or equal then their children */
    public class MaxHeap<T> : Heap<T>
        where T : IComparable, IEquatable<T>
    {
        public MaxHeap() : base((a, b) => a.CompareTo(b) > 0) { }
    }

    /* MIN HEAPS are heaps where the parents are always smaller or equal then their children */
    public class MinHeap<T> : Heap<T>
        where T : IComparable, IEquatable<T>
    {
        public MinHeap() : base((a, b) => a.CompareTo(b) < 0) { }
    }

    public class Heap<T> where T : IEquatable<T>
    {
        private readonly List<T> items;

        private readonly Func<T, T, bool> shouldBeParentFunc;
        public Heap(Func<T, T, bool> shouldBeParentFunc)
        {
            this.shouldBeParentFunc = shouldBeParentFunc;
            this.items = new List<T>();
        }

        public int Count { get => this.items.Count; }

        public IEnumerable<T> GetItems()
        {
            foreach (var item in this.items)
                yield return item;
        }

        public void Insert(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            this.items.Add(item);
            int itemIdx = this.LastIdx();
            int parentIdx = this.ParentIdx(itemIdx);

            while (this.shouldBeParentFunc(this.items[itemIdx], this.items[parentIdx]))
            {
                Utils.Swap(this.items, parentIdx, itemIdx);
                itemIdx = parentIdx;
                parentIdx = this.ParentIdx(itemIdx);
            }
        }

        public void Remove(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            for (int idx = 0; idx < this.items.Count; idx++)
            {
                if (this.items[idx].Equals(item))
                {
                    this.RemoveAt(idx);
                    return;
                }
            }
        }

        public T Pop()
        {
            return this.RemoveAt(0);
        }

        public T RemoveAt(int idx)
        {
            if (idx < 0 || idx > this.LastIdx())
                throw new ArgumentException(nameof(idx));

            // Swap current item with last item and delete last element of list
            Utils.Swap(this.items, idx, this.LastIdx());
            T removedItem = this.items[this.LastIdx()];
            this.items.RemoveAt(this.LastIdx());

            // Heapify idx to fix heap order
            this.HeapifyDown(idx);

            return removedItem;
        }

        private int LeftChildIdx(int itemIdx) => (2 * itemIdx) + 1;

        private int RightChildIdx(int itemIdx) => (2 * itemIdx) + 2;

        private int ParentIdx(int itemIdx) => (itemIdx - 1) / 2;

        private int LastIdx() => this.items.Count - 1;

        private bool IsIndexValid(int idx) => (idx >= 0 && idx < this.items.Count);

        private void HeapifyDown(int idx)
        {
            if (idx < 0 || idx >= this.items.Count)
                return;

            int leftChildIdx = this.LeftChildIdx(idx);
            int rightChildIdx = this.RightChildIdx(idx);
            bool leftChildIdxExists = this.IsIndexValid(leftChildIdx);
            bool rightChildIdxExists = this.IsIndexValid(rightChildIdx);

            int heirIdx;

            if (!leftChildIdxExists && !rightChildIdxExists)
                return;
            else if (leftChildIdxExists && !rightChildIdxExists)
                heirIdx = leftChildIdx;
            else if (!leftChildIdxExists && rightChildIdxExists)
                heirIdx = rightChildIdx;
            else
                heirIdx = this.shouldBeParentFunc(this.items[leftChildIdx], this.items[rightChildIdx]) ? leftChildIdx : rightChildIdx;

            if (this.shouldBeParentFunc(this.items[heirIdx], this.items[idx]))
            {
                Utils.Swap(this.items, idx, heirIdx);
                this.HeapifyDown(heirIdx);
            }
        }
    }
}