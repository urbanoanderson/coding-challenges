/*
    Source: https://www.hackerrank.com/challenges/encryption/

    Solution Author: Anderson Urbano
*/

using System;
using System.Text;

namespace Challenges.Solutions.Encryption
{
    public static class ChallengeSolution
    {
        private const char INVALID_CHAR = '\0';

        public static string Solution(string input)
        {
            string inputStripped = input.Replace(" ", "");

            if (string.IsNullOrEmpty(inputStripped))
            {
                return string.Empty;
            }

            (int rows, int cols) = GetMatrixSize(inputStripped);
            char[,] matrix = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int strIndex = j + (i * cols);
                    matrix[i, j] = strIndex < inputStripped.Length ? inputStripped[strIndex] : INVALID_CHAR;
                }
            }

            StringBuilder resultBuilder = new StringBuilder();

            for (int j = 0; j < cols; j++)
            {
                for (int i = 0; i < rows; i++)
                {
                    if (matrix[i, j] != INVALID_CHAR)
                    {
                        resultBuilder.Append(matrix[i, j]);
                    }
                }

                if (j != cols - 1)
                {
                    resultBuilder.Append(' ');
                }
            }

            return resultBuilder.ToString();
        }

        private static (int, int) GetMatrixSize(string input)
        {
            double sqrtL = Math.Sqrt(input.Length);
            int floor = (int)Math.Floor(sqrtL);
            int ceil = (int)Math.Ceiling(sqrtL);

            (int, int)[] possibleSizes = new (int, int)[] { (floor, floor), (floor, ceil), (ceil, ceil) };
            (int, int) result = possibleSizes[0];

            foreach (var possibleSize in possibleSizes)
            {
                if (possibleSize.Item1 * possibleSize.Item2 >= input.Length)
                {
                    result = possibleSize;
                    break;
                }
            }

            return result;
        }
    }
}