using CodingChallenges.Common;

namespace CodingChallenges.Algorithms.Sorting
{
    /*
        Time complexity:
            Best Case: O(n) (The list is already sorted)
            Average: O(n^2)
            Worst Case: O(n^2) (The list is reverse-sorted)
        Space complexity:
            O(n)
    */
    public class BubbleSort
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

            bool sorted;

            do
            {
                sorted = true;

                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        Utils.Swap(arr, i, i + 1);
                        sorted = false;
                    }
                }
            } while (!sorted);
        }
    }
}