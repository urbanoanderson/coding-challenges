using System;
using System.Linq;
using NUnit.Framework;

namespace CodingChallenges.DataStructures
{
    public class Heap_Tests
    {
        private readonly int[] sampleMaxHeap = { 100, 19, 36, 17, 3, 25, 1, 2, 7 };

        [Test]
        public void Insert_PassNullItem_ThrowsArgumentNullException()
        {
            MaxHeap<string> heap = new MaxHeap<string>();

            Assert.Throws<ArgumentNullException>(() => heap.Insert(null));
        }

        [Test]
        public void Insert_PassValidItems_InsertSuccessful()
        {
            int[] input = this.sampleMaxHeap;

            MaxHeap<int> heap = this.CreateMaxHeapFromArray(input);

            Assert.IsTrue(heap.Count == input.Length);
        }

        [Test]
        public void RemoveAt_PassInvalidIndex_ThrowsArgumentNullException()
        {
            MaxHeap<int> heap = this.CreateMaxHeapFromArray(sampleMaxHeap);

            Assert.Throws<ArgumentException>(() => heap.RemoveAt(-1));
        }

        [Test]
        public void RemoveAt_RemoveRootItem_RemoveSuccessful()
        {
            int[] input = this.sampleMaxHeap;
            int[] expected = { 36, 19, 25, 17, 3, 7, 1, 2 };

            MaxHeap<int> heap = this.CreateMaxHeapFromArray(input);

            heap.Pop();

            Assert.IsTrue(heap.GetItems().SequenceEqual(expected));
        }

        [Test]
        public void RemoveAt_RemoveLastItem_RemoveSuccessful()
        {
            int[] input = this.sampleMaxHeap;
            int[] expected = { 100, 19, 36, 17, 3, 25, 1, 2 };

            MaxHeap<int> heap = this.CreateMaxHeapFromArray(input);

            heap.RemoveAt(input.Length - 1);

            Assert.IsTrue(heap.GetItems().SequenceEqual(expected));
        }

        public MaxHeap<int> CreateMaxHeapFromArray(int[] arr)
        {
            MaxHeap<int> heap = new MaxHeap<int>();

            foreach (var item in arr)
                heap.Insert(item);

            return heap;
        }
    }
}