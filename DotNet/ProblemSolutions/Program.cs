using Problems;
using Problems.HackerRank;
using Problems.Other;
using System;

namespace HackerRank
{
    class Program
    {
        static void Main(string[] args)
        {
            IProblem problem = new BagWeight();
            problem.DriverMethod();
            Console.ReadKey();
        }
    }
}
