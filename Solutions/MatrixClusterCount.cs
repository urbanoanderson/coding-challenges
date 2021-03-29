/*
    Source: Guilherme Henrique

    Solution Author: Anderson Urbano

    Problem: Given a matrix of booleans, find out how many clusters of true values exist.
    A cluster is a set of same values together horizontally or vertically (not diagonally)

    Example: given matrix [[true, true, false], [true, false, true], [false,true,false]]
    Output is 3
*/

using System;
using System.Collections.Generic;

namespace Challenges.Solutions.MatrixClusterCount
{
    public class Cluster
    {
        IDictionary<Tuple<int, int>, bool> cellMap;

        public Cluster()
        {
            this.cellMap = new Dictionary<Tuple<int, int>, bool>();
        }

        public bool HasKey(int i, int j)
        {
            return this.cellMap.ContainsKey(new Tuple<int, int>(i, j));
        }

        public void AddKey(int i, int j)
        {
            this.cellMap.Add(new Tuple<int, int>(i, j), true);
        }
    }

    public static class MatrixClusterCount
    {
        public static int CountClusters(bool[,] matrix)
        {
            IList<Cluster> clusters = new List<Cluster>();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] == true && !ClustersHaveKey(clusters, i, j))
                    {
                        Cluster c = new Cluster();
                        clusters.Add(c);
                        ExploreCluster(c, matrix, i, j);
                    }
                }
            }

            return clusters.Count;
        }

        private static bool ClustersHaveKey(IList<Cluster> clusters, int i, int j)
        {
            foreach (Cluster c in clusters)
            {
                if (c.HasKey(i, j))
                    return true;
            }

            return false;
        }

        public static void ExploreCluster(Cluster c, bool[,] matrix, int i, int j)
        {
            if (i < 0 || i >= matrix.GetLength(0))
                return;

            if (j < 0 || j >= matrix.GetLength(1))
                return;

            if (matrix[i, j] == true && !c.HasKey(i, j))
            {
                c.AddKey(i, j);
                ExploreCluster(c, matrix, i-1, j);
                ExploreCluster(c, matrix, i+1, j);
                ExploreCluster(c, matrix, i, j-1);
                ExploreCluster(c, matrix, i, j+1);
            }
        }
    }
}