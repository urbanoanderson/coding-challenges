using CodingChallenges.Common;

namespace CodingChallenges.Algorithms.Sorting
{
    /*
        Time complexity:
            O(n^2)
        Space complexity:
            O(n)
    */
    public class SelectionSort
    {
        public static int[] CopyAndSort(int[] arr)
        {
            int[] copy = (int[])arr.Clone();
            SortInPlace(copy);
            return copy;
        }

        public static void SortInPlace(int[] arr)
        {
            if (arr == null || arr.Length <= 1)
                return;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                int smallestIdx = i;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[smallestIdx])
                        smallestIdx = j;
                }

                if (smallestIdx != i)
                    Utils.Swap(arr, i, smallestIdx);
            }
        }
    }
}