using System;
using CodingChallenges.Common;
using NUnit.Framework;

namespace CodingChallenges.Solutions.RatioFinder
{
    public class RatioFinder_Tests
    {
        private RatioFinder ratioFinder;

        [SetUp]
        public void GlobalSetup()
        {
            ratioFinder = new RatioFinder();
        }

        [Test]
        public void DirectRatio()
        {
            ratioFinder.AddRatio("a", "b", 100.0);

            Assert.IsTrue(TestHelper.DoubleEquals(ratioFinder.GetRatio("a", "b"), 100.0));
            Assert.IsTrue(TestHelper.DoubleEquals(ratioFinder.GetRatio("b", "a"), 0.01));
        }

        [Test]
        public void IndirectRatioSingleStepSinglePath()
        {
            ratioFinder.AddRatio("a", "b", 2.0);
            ratioFinder.AddRatio("b", "c", 3.0);

            Assert.IsTrue(TestHelper.DoubleEquals(ratioFinder.GetRatio("a", "c"), 6.0));
            Assert.IsTrue(TestHelper.DoubleEquals(ratioFinder.GetRatio("c", "a"), 1.0/6.0));
        }

        [Test]
        public void IndirectRatioSingleStepMultiPath()
        {
            ratioFinder.AddRatio("a", "b", 2.0);
            ratioFinder.AddRatio("b", "c", 3.0);
            ratioFinder.AddRatio("a", "d", 1.0);
            ratioFinder.AddRatio("d", "c", 6.0);

            Assert.IsTrue(TestHelper.DoubleEquals(ratioFinder.GetRatio("a", "c"), 6.0));
            Assert.IsTrue(TestHelper.DoubleEquals(ratioFinder.GetRatio("c", "a"), 1.0/6.0));
        }

        [Test]
        public void IndirectRatioMultiStepSinglePath()
        {
            ratioFinder.AddRatio("a", "b", 2.0);
            ratioFinder.AddRatio("b", "c", 3.0);
            ratioFinder.AddRatio("c", "d", 4.0);
            ratioFinder.AddRatio("d", "e", 5.0);

            Assert.IsTrue(TestHelper.DoubleEquals(ratioFinder.GetRatio("a", "e"), 120.0));
            Assert.IsTrue(TestHelper.DoubleEquals(ratioFinder.GetRatio("e", "a"), 1.0/120.0));
        }

        [Test]
        public void IndirectRatioMultiStepMultiPath()
        {
            ratioFinder.AddRatio("a", "b", 2.0);
            ratioFinder.AddRatio("b", "c", 3.0);
            ratioFinder.AddRatio("c", "x", 4.0);
            ratioFinder.AddRatio("a", "d", 8.0);
            ratioFinder.AddRatio("d", "e", 1.5);
            ratioFinder.AddRatio("e", "x", 2.0);

            Assert.IsTrue(TestHelper.DoubleEquals(ratioFinder.GetRatio("a", "x"), 24.0));
            Assert.IsTrue(TestHelper.DoubleEquals(ratioFinder.GetRatio("x", "a"), 1.0/24.0));
        }

        [Test]
        public void IndirectRatioMultiStepSinglePathWithCycles()
        {
            ratioFinder.AddRatio("a", "e", 4.0);
            ratioFinder.AddRatio("a", "c", 2.0);
            ratioFinder.AddRatio("c", "d", 3.0);
            ratioFinder.AddRatio("d", "a", 1/6.0);
            ratioFinder.AddRatio("a", "b", 2.0);
            ratioFinder.AddRatio("b", "x", 3.0);

            Assert.IsTrue(TestHelper.DoubleEquals(ratioFinder.GetRatio("a", "x"), 6.0));
            Assert.IsTrue(TestHelper.DoubleEquals(ratioFinder.GetRatio("x", "a"), 1.0/6.0));
        }

        [Test]
        public void RatioNotFoundThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => this.ratioFinder.GetRatio("a", "c"));
            this.ratioFinder.AddRatio("a", "b", 2.0);
            this.ratioFinder.AddRatio("c", "d", 2.0);
            Assert.Throws<ArgumentException>(() => this.ratioFinder.GetRatio("a", "c"));
        }
    }
}