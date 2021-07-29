/*
    Source: https://www.hackerrank.com/challenges/climbing-the-leaderboard
*/

using System;
using System.Collections.Generic;

namespace CodingChallenges.Solutions.ClimbingLeaderboard
{
    public static class ChallengeSolution
    {
        public static List<int> Solve(List<int> ranked, List<int> player)
        {
            Stack<int> rankedStack = new Stack<int>();
            Dictionary<int, int> rankPositions = new Dictionary<int, int>();
            int lastScore = int.MinValue;
            int lastPosition = 0;

            foreach (int score in ranked)
            {
                if (score != lastScore)
                {
                    lastScore = score;
                    lastPosition++;

                    rankedStack.Push(score);
                    rankPositions.Add(lastScore, lastPosition);
                }
            }

            List<int> result = new List<int>();

            foreach (int playerScore in player)
            {
                int position = -1;

                while (position < 0)
                {
                    if (rankedStack.Count == 0)
                    {
                        position = 1;
                    }
                    else if (playerScore < rankedStack.Peek())
                    {
                        position = rankPositions[rankedStack.Peek()] + 1;
                    }
                    else if (playerScore >= rankedStack.Peek())
                    {
                        rankedStack.Pop();
                    }
                }

                result.Add(position);
            }

            return result;
        }
    }
}