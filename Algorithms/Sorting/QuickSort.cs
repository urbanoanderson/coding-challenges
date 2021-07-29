using CodingChallenges.Common;

namespace CodingChallenges.Algorithms.Sorting
{
    /*
        Time complexity:
            Average: O(n*log(n))
            Worst case: O(n^2) (when array is reverse sorted)
        Space complexity:
            O(n)
    */
    public class QuickSort
    {
        public static int[] CopyAndSort(int[] arr)
        {
            int[] copy = (int[])arr.Clone();
            SortInPlace(copy);
            return copy;
        }

        public static void SortInPlace(int[] arr)
        {
            Sort(arr, 0, arr.Length - 1);
        }

        private static void Sort(int[] arr, int leftIdx, int rightIdx)
        {
            if (arr == null || leftIdx < 0 || rightIdx >= arr.Length || rightIdx <= leftIdx)
                return;

            // Always choose the last elem as pivot
            int pivotItem = arr[rightIdx];

            // from leftIdx to (partitionIdx-1) will contain elements < pivot
            // from partitionIdx to rightIdx will contain elements >= pivot
            int partitionIdx = leftIdx;

            for (int idx = leftIdx; idx < rightIdx; idx++)
            {
                if (arr[idx] < pivotItem)
                {
                    Utils.Swap(arr, partitionIdx, idx);
                    partitionIdx++;
                }
            }

            // Swap pivot with element at partitionIdx so that pivot will be placed
            // at its correct position in arr[partitionIdx]
            Utils.Swap(arr, partitionIdx, rightIdx);

            // Divide and conquer
            Sort(arr, leftIdx, partitionIdx - 1);
            Sort(arr, partitionIdx + 1, rightIdx);
        }
    }
}