using System;
using System.Linq;
using NUnit.Framework;

namespace CodingChallenges.Solutions.Knapsack
{
    public class ChallengeSolution_Tests
    {
        private static readonly object[] testcasesZeroOne =
        {
            new object[]
            {
                new uint[] { 1 }, new uint[] { 1 }, 0u,
                new uint[] { 0 }, 0u,
            },
            new object[]
            {
                new uint[] { 1 }, new uint[] { 1 }, 1u,
                new uint[] { 1 }, 1u,
            },
            new object[]
            {
                new uint[] { 1 }, new uint[] { 1 }, 2u,
                new uint[] { 1 }, 1u,
            },
            new object[]
            {
                new uint[] { 1, 3, 5 }, new uint[] { 5, 3, 1 }, 3u,
                new uint[] { 0, 0, 1 }, 5u,
            },
            new object[]
            {
                new uint[] { 1, 3, 5 }, new uint[] { 5, 3, 1 }, 5u,
                new uint[] { 0, 1, 1 }, 8u,
            },
        };

        private static readonly object[] testcasesUnbounded =
        {
            new object[]
            {
                new uint[] { 1 }, new uint[] { 1 }, 0u,
                new uint[] { 0 }, 0u,
            },
            new object[]
            {
                new uint[] { 1 }, new uint[] { 1 }, 1u,
                new uint[] { 1 }, 1u,
            },
            new object[]
            {
                new uint[] { 1 }, new uint[] { 1 }, 2u,
                new uint[] { 2 }, 2u,
            },
            new object[]
            {
                new uint[] { 1, 3, 5 }, new uint[] { 5, 3, 1 }, 3u,
                new uint[] { 0, 0, 3 }, 15u,
            },
            new object[]
            {
                new uint[] { 1, 3, 5 }, new uint[] { 5, 3, 1 }, 5u,
                new uint[] { 0, 0, 5 }, 25u,
            },
        };

        private static readonly object[] testcasesBounded =
        {
            new object[]
            {
                new uint[] { 1 }, new uint[] { 1 }, new uint[] { 2 }, 0u,
                new uint[] { 0 }, 0u,
            },
            new object[]
            {
                new uint[] { 1 }, new uint[] { 1 }, new uint[] { 2 }, 1u,
                new uint[] { 1 }, 1u,
            },
            new object[]
            {
                new uint[] { 1 }, new uint[] { 1 }, new uint[] { 2 }, 3u,
                new uint[] { 2 }, 2u,
            },
            new object[]
            {
                new uint[] { 1, 3, 5 }, new uint[] { 5, 3, 1 }, new uint[] { 2, 2, 2 }, 3u,
                new uint[] { 0, 0, 2 }, 10u,
            },
            new object[]
            {
                new uint[] { 1, 3, 5 }, new uint[] { 5, 3, 1 }, new uint[] { 2, 2, 2 }, 5u,
                new uint[] { 0, 1, 2 }, 13u,
            },
        };

        [Test]
        public void CheckInvalidInputs()
        {
            Assert.Throws<InvalidOperationException>(() => ChallengeSolution.SolveBounded(null, new uint[1], new uint[1], 1));
            Assert.Throws<InvalidOperationException>(() => ChallengeSolution.SolveBounded(new uint[1], null, new uint[1], 1));
            Assert.Throws<InvalidOperationException>(() => ChallengeSolution.SolveBounded(new uint[1], new uint[2], new uint[1], 1));
            Assert.Throws<InvalidOperationException>(() => ChallengeSolution.SolveBounded(new uint[1], new uint[1], new uint[2], 1));
        }

        [Test, TestCaseSource(nameof(testcasesZeroOne))]
        public void TestZeroOne(uint[] values, uint[] weights, uint capacity, uint[] expectedSet, uint expectedSum)
        {
            (uint[] outputSet, uint outputSum) = ChallengeSolution.SolveZeroOne(values, weights, capacity);
            this.AssertResult(outputSet, outputSum, expectedSet, expectedSum);
        }

        [Test, TestCaseSource(nameof(testcasesUnbounded))]
        public void TestUnbounded(uint[] values, uint[] weights, uint capacity, uint[] expectedSet, uint expectedSum)
        {
            (uint[] outputSet, uint outputSum) = ChallengeSolution.SolveUnbounded(values, weights, capacity);
            this.AssertResult(outputSet, outputSum, expectedSet, expectedSum);
        }

        [Test, TestCaseSource(nameof(testcasesBounded))]
        public void TestBounded(uint[] values, uint[] weights, uint[] stock, uint capacity, uint[] expectedSet, uint expectedSum)
        {
            (uint[] outputSet, uint outputSum) = ChallengeSolution.SolveBounded(values, weights, stock, capacity);
            this.AssertResult(outputSet, outputSum, expectedSet, expectedSum);
        }

        private void AssertResult(uint[] outputSet, uint outputSum, uint[] expectedSet, uint expectedSum)
        {
            Assert.IsTrue(outputSet.SequenceEqual(expectedSet));
            Assert.IsTrue(outputSum == expectedSum);
        }
    }
}