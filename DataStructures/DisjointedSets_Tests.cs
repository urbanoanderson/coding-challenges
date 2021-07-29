using System;
using NUnit.Framework;

namespace CodingChallenges.DataStructures
{
    public class DisjointedSets_Tests
    {
        [Test]
        public void Union_PassTwoElements_UpdateMaxSetSize()
        {
            DisjointedSets d = new DisjointedSets();

            Assert.IsTrue(d.MaxSetSize == 0);
            d.Union(1, 2);
            Assert.IsTrue(d.MaxSetSize == 2);
            d.Union(3, 4);
            Assert.IsTrue(d.MaxSetSize == 2);
            d.Union(2, 3);
            Assert.IsTrue(d.MaxSetSize == 4);
        }

        [Test]
        public void IsSameSet_PassTwoElements_ReturnsIfTheyAreInSameSet()
        {
            DisjointedSets d = new DisjointedSets();

            Assert.IsFalse(d.IsSameSet(1, 2));
            d.InitUnitSetIfNew(1);
            d.InitUnitSetIfNew(2);
            Assert.IsFalse(d.IsSameSet(1, 2));
            d.Union(1, 2);
            Assert.IsTrue(d.IsSameSet(1, 2));
        }
    }
}