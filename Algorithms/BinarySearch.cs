using System;

namespace CodingChallenges.Algorithms
{
    /*
        Time complexity:
            O(log(n))
        Space complexity:
            O(n)
    */
    public class BinarySearch
    {
        public static bool Search(int[] arr, int item)
        {
            if (arr == null)
                throw new ArgumentNullException();

            return Search(arr, item, 0, arr.Length - 1);
        }

        private static bool Search(int[] arr, int item, int leftIdx, int rightIdx)
        {
            if (arr == null || leftIdx < 0 || rightIdx >= arr.Length || rightIdx < leftIdx)
                return false;

            int middleIdx = (leftIdx + rightIdx) / 2;

            return (arr[middleIdx] == item)
                || Search(arr, item, leftIdx, middleIdx - 1)
                || Search(arr, item, middleIdx + 1, rightIdx);
        }
    }
}