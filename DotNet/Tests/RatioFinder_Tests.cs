using System;
using Challenges.Tests;
using NUnit.Framework;

namespace Challenges.RatioFinder
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
            ratioFinder.AddRation("a", "b", 100.0);

            Assert.IsTrue(TestHelper.DoubleEquals(ratioFinder.GetRatio("a", "b"), 100.0));
            Assert.IsTrue(TestHelper.DoubleEquals(ratioFinder.GetRatio("b", "a"), 0.01));
        }

        [Test]
        public void IndirectRatioSingleStepSinglePath()
        {
            ratioFinder.AddRation("a", "b", 2.0);
            ratioFinder.AddRation("b", "c", 3.0);

            Assert.IsTrue(TestHelper.DoubleEquals(ratioFinder.GetRatio("a", "c"), 6.0));
            Assert.IsTrue(TestHelper.DoubleEquals(ratioFinder.GetRatio("c", "a"), 1.0/6.0));
        }

        [Test]
        public void IndirectRatioSingleStepMultiPath()
        {
            ratioFinder.AddRation("a", "b", 2.0);
            ratioFinder.AddRation("b", "c", 3.0);
            ratioFinder.AddRation("a", "d", 1.0);
            ratioFinder.AddRation("d", "c", 6.0);

            Assert.IsTrue(TestHelper.DoubleEquals(ratioFinder.GetRatio("a", "c"), 6.0));
            Assert.IsTrue(TestHelper.DoubleEquals(ratioFinder.GetRatio("c", "a"), 1.0/6.0));
        }

        [Test]
        public void IndirectRatioMultiStepSinglePath()
        {
            ratioFinder.AddRation("a", "b", 2.0);
            ratioFinder.AddRation("b", "c", 3.0);
            ratioFinder.AddRation("c", "d", 4.0);
            ratioFinder.AddRation("d", "e", 5.0);

            Assert.IsTrue(TestHelper.DoubleEquals(ratioFinder.GetRatio("a", "e"), 120.0));
            Assert.IsTrue(TestHelper.DoubleEquals(ratioFinder.GetRatio("e", "a"), 1.0/120.0));
        }

        [Test]
        public void IndirectRatioMultiStepMultiPath()
        {
            ratioFinder.AddRation("a", "b", 2.0);
            ratioFinder.AddRation("b", "c", 3.0);
            ratioFinder.AddRation("c", "x", 4.0);
            ratioFinder.AddRation("a", "d", 8.0);
            ratioFinder.AddRation("d", "e", 1.5);
            ratioFinder.AddRation("e", "x", 2.0);

            Assert.IsTrue(TestHelper.DoubleEquals(ratioFinder.GetRatio("a", "x"), 24.0));
            Assert.IsTrue(TestHelper.DoubleEquals(ratioFinder.GetRatio("x", "a"), 1.0/24.0));
        }

        [Test]
        public void RatioNotFoundThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => this.ratioFinder.GetRatio("a", "c"));
            this.ratioFinder.AddRation("a", "b", 2.0);
            Assert.Throws<ArgumentException>(() => this.ratioFinder.GetRatio("a", "c"));
        }
    }
}