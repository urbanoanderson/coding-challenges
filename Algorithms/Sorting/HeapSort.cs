using CodingChallenges.DataStructures;

namespace CodingChallenges.Algorithms.Sorting
{
    /*
        Time complexity:
            Average: O(n*log(n))
            Worst case: O(n*log(n))
        Space complexity:
            O(n)
    */
    public class HeapSort
    {
        public static int[] CopyAndSort(int[] arr)
        {
            int[] copy = (int[])arr.Clone();
            SortInPlace(copy);
            return copy;
        }

        public static int[] SortInPlace(int[] arr)
        {
            MinHeap<int> heap = new MinHeap<int>();

            foreach (var item in arr)
                heap.Insert(item);

            for (int i = 0; i < arr.Length; i++)
                arr[i] = heap.Pop();

            return arr;
        }
    }
}