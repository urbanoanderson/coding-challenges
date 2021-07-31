

using System;
using System.Collections.Generic;
using CodingChallenges.DataStructures;

namespace CodingChallenges.Algorithms
{
    public static class Djikstra
    {
        private const int INFINITE_DISTANCE = int.MaxValue;

        private class Connection : IEquatable<Connection>, IComparable<Connection>
        {
            public int From { get; set; }
            public int To { get; set; }
            public int Cost { get; set; }
            public int CompareTo(Connection other) => this.Cost - other.Cost;
            public bool Equals(Connection other) => this.Cost == other.Cost;
        }

        public static (IEnumerable<int>, int) ShortestPath(int[][] graph, int start, int dest, int noConnectionIndicator = -1)
        {
            // This map keeps track of from what is the best path to each node from start
            Dictionary<int, Connection> shortestToMap = new Dictionary<int, Connection>();
            for (int i = 0; i < graph.Length; i++)
            {
                Connection c = new Connection()
                {
                    From = start,
                    To = i,
                    Cost = ((i == start) ? 0 : INFINITE_DISTANCE)
                };

                shortestToMap.Add(i, c);
            }

            // The search queue keeps track of what connections need to be explored next
            MinHeap<Connection> searchQueue = new MinHeap<Connection>();
            searchQueue.Insert(shortestToMap[start]);

            while (searchQueue.Count > 0)
            {
                Connection p = searchQueue.Pop();

                if (p.Cost < shortestToMap[p.To].Cost)
                    shortestToMap[p.To] = p;

                // Find all neighbors of p.To
                for (int j = 0; j < graph[p.To].Length; j++)
                {
                    // If there is a connection and the connection is worth exploring
                    if (p.To != j
                    && graph[p.To][j] != noConnectionIndicator
                    && (p.Cost + graph[p.To][j]) <= shortestToMap[j].Cost)
                    {
                        searchQueue.Insert(new Connection() { From = p.To, To = j, Cost = p.Cost + graph[p.To][j] });
                    }
                }
            }

            List<int> shortestPath = new List<int>();

            // If no path was found
            if (shortestToMap[dest].Cost == INFINITE_DISTANCE)
                return (shortestPath, noConnectionIndicator);

            // Goes through the map and puts together a list with the path
            GetPathList(shortestPath, shortestToMap, start, dest);

            return (shortestPath, shortestToMap[dest].Cost);
        }

        private static void GetPathList(List<int> path, Dictionary<int, Connection> shortestToMap, int start, int dest)
        {
            if (shortestToMap[dest].Cost == INFINITE_DISTANCE)
                return;

            if (start == dest)
            {
                path.Add(start);
                return;
            }

            GetPathList(path, shortestToMap, start, shortestToMap[dest].From);
            path.Add(dest);
        }
    }
}