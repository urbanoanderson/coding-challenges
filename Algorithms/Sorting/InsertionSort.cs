using CodingChallenges.Common;

namespace CodingChallenges.Algorithms.Sorting
{
    /*
        Time complexity:
            O(n^2)
        Space complexity:
            O(n)
    */
    public class InsertionSort
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

            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (arr[j] < arr[j - 1])
                        Utils.Swap(arr, j, j - 1);
                    else
                        break;
                }
            }
        }
    }
}