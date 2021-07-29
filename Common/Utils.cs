using System.Collections.Generic;

namespace CodingChallenges.Common
{
    public static class Utils
    {
        public static void Swap<T>(T[] arr, int idxA, int idxB)
        {
            T aux = arr[idxA];
            arr[idxA] = arr[idxB];
            arr[idxB] = aux;
        }

        public static void Swap<T>(List<T> arr, int idxA, int idxB)
        {
            T aux = arr[idxA];
            arr[idxA] = arr[idxB];
            arr[idxB] = aux;
        }
    }
}