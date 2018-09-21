/*
    Link: https://www.hackerrank.com/challenges/max-array-sum
    Solution Author: Anderson Urbano
    HackerRank Username: urbanoanderson
*/

using System;

namespace Problems.HackerRank
{
    class MaxArraySum : IProblem
    {
        public void DriverMethod()
        {
            int[] input = new int[] { -2, 3, 4, 5, -3, -1, 9 };
            Console.WriteLine($"Result: {CalculateSubsetSum(input)}");
        }

        public static int CalculateSubsetSum(int[] arr)
        {
            var memory = new int?[arr.Length];
            return CalculateSubsetSum(0, arr, ref memory);
        }

        private static int CalculateSubsetSum(int index, int[] arr, ref int?[] memory)
        {
            // Sum is zero for indexes outside of the array
            if (index >= arr.Length || index < 0)
            {
                return 0;
            }

            // If sum has not been calculated yet
            else if (!memory[index].HasValue)
            {
                // Base case: last element is its own sum
                if (index == arr.Length - 1)
                {
                    memory[index] = arr[index];
                }

                // Recursive case 
                else
                {
                    memory[index] = Math.Max(arr[index], Math.Max(
                        arr[index] + CalculateSubsetSum(index + 2, arr, ref memory),
                        CalculateSubsetSum(index + 1, arr, ref memory)
                        ));
                }
            }

            return memory[index].Value;
        }
    }
}
