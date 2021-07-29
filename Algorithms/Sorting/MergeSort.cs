using System;

namespace CodingChallenges.Algorithms.Sorting
{
    /*
        Time complexity:
            Average: O(n*log(n))
            Worst case: O(n*log(n))
        Space complexity:
            O(n)
    */
    public class MergeSort
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

        public static void Sort(int[] arr, int leftIdx, int rightIdx)
        {
            if (arr == null || leftIdx < 0 || rightIdx >= arr.Length || rightIdx <= leftIdx)
                return;

            int middleIdx = (leftIdx + rightIdx) / 2;

            Sort(arr, leftIdx, middleIdx);
            Sort(arr, middleIdx + 1, rightIdx);

            // Merge phase uses a copy of left and right arrays
            int[] leftCopy = new int[middleIdx - leftIdx + 1];
            Array.Copy(arr, leftIdx, leftCopy, 0, leftCopy.Length);
            int[] rightCopy = new int[rightIdx - middleIdx];
            Array.Copy(arr, middleIdx + 1, rightCopy, 0, rightCopy.Length);

            for (int i = leftIdx, iL = 0, iR = 0; i <= rightIdx; i++)
            {
                if (iL < leftCopy.Length && iR < rightCopy.Length)
                {
                    if (leftCopy[iL] <= rightCopy[iR])
                    {
                        arr[i] = leftCopy[iL];
                        iL++;
                    }
                    else
                    {
                        arr[i] = rightCopy[iR];
                        iR++;
                    }
                }
                else if (iL < leftCopy.Length)
                {
                    arr[i] = leftCopy[iL];
                    iL++;
                }
                else
                {
                    arr[i] = rightCopy[iR];
                    iR++;
                }
            }
        }
    }
}