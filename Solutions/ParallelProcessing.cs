/*
    Source: https://www.hackerrank.com/test/33gp893pqhs/questions/7qot7o5lplm

    Solution Author: Anderson Urbano
*/

using System.Collections.Generic;

namespace Challenges.Solutions.ParallelProcessing
{
    public static class ParallelProcessing
    {
        private class ParallelFile
        {
            public int SingleCoreTime { get; set; }
            public int MultiCoreTime { get; set; }
            public int Gain { get => SingleCoreTime - MultiCoreTime; }
        }

        public static long Solution(int[] files, int numCores, int limit)
        {
            long minTime = 0;
            List<ParallelFile> possiblePar = new List<ParallelFile>();

            foreach (int file in files)
            {
                if (file % numCores == 0)
                {
                    possiblePar.Add(new ParallelFile { SingleCoreTime = file, MultiCoreTime = file/numCores });
                }
                else
                {
                    minTime += file;
                }
            }

            possiblePar.Sort((x, y) => x.Gain - y.Gain);

            for (int i = 0; i < possiblePar.Count; i++)
            {
                if (possiblePar.Count - i <= limit)
                {
                    minTime += possiblePar[i].MultiCoreTime;
                }
                else
                {
                    minTime += possiblePar[i].SingleCoreTime;
                }
            }

            return minTime;
        }
    }
}