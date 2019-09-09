using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Challenges.RangeDictionary
{
    public class RangeDictionary_Tests
    {
        private void AssertGetValuesMethod(RangeDictionary<string> data, int start, int end, HashSet<string> values)
        {
            for (int i = start; i <= end; i++)
            {
                ISet<string> output = data.GetValues(i);

                Assert.IsTrue(output.Count == values.Count);
                foreach (string v in values)
                    Assert.IsTrue(output.Contains(v));
            }
        }

        [Test]
        public void TestCase1()
        {
            RangeDictionary<string> dataStructure = new RangeDictionary<string>();
            dataStructure.AddRange(1, 3, "A");
            dataStructure.AddRange(3, 5, "B");
            dataStructure.AddRange(4, 10, "C");

            AssertGetValuesMethod(dataStructure, 1, 2, new HashSet<string>() { "A" });
            AssertGetValuesMethod(dataStructure, 3, 3, new HashSet<string>() { "A", "B" });
            AssertGetValuesMethod(dataStructure, 4, 5, new HashSet<string>() { "B", "C" });
            AssertGetValuesMethod(dataStructure, 6, 10, new HashSet<string>() { "C" });
        }

        [Test]
        public void TestCase2()
        {
            RangeDictionary<string> dataStructure = new RangeDictionary<string>();
            dataStructure.AddRange(1, 3, "A");
            dataStructure.AddRange(1, 3, "B");

            AssertGetValuesMethod(dataStructure, 1, 3, new HashSet<string>() { "A", "B" });
        }

        [Test]
        public void TestCase3()
        {
            RangeDictionary<string> dataStructure = new RangeDictionary<string>();
            dataStructure.AddRange(1, 3, "A");
            dataStructure.AddRange(5, 7, "B");

            AssertGetValuesMethod(dataStructure, 1, 3, new HashSet<string>() { "A" });
            AssertGetValuesMethod(dataStructure, 5, 7, new HashSet<string>() { "B" });
        }

        [Test]
        public void TestCase4()
        {
            RangeDictionary<string> dataStructure = new RangeDictionary<string>();
            dataStructure.AddRange(1, 3, "A");

            Assert.IsTrue(dataStructure.GetValues(5).SequenceEqual(new List<string>()));
        }

        [Test]
        public void TestCase5()
        {
            RangeDictionary<string> dataStructure = new RangeDictionary<string>();
            dataStructure.AddRange(1, 10, "A");
            dataStructure.AddRange(15, 20, "B");
            dataStructure.AddRange(4, 18, "C");

            AssertGetValuesMethod(dataStructure, 1, 3, new HashSet<string>() { "A" });
            AssertGetValuesMethod(dataStructure, 4, 10, new HashSet<string>() { "A", "C" });
            AssertGetValuesMethod(dataStructure, 11, 14, new HashSet<string>() { "C" });
            AssertGetValuesMethod(dataStructure, 15, 18, new HashSet<string>() { "C", "B" });
            AssertGetValuesMethod(dataStructure, 19, 20, new HashSet<string>() { "B" });
        }
    }
}