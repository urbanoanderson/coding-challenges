using System;
using NUnit.Framework;

namespace CodingChallenges.DataStructures
{
    public class Trie_Tests
    {
        [Test]
        public void PublicMethods_PassNullArgument_ThrowsArgumentNullException()
        {
            Trie trie = new Trie();
            Assert.Throws<ArgumentNullException>(() => new Trie(null));
            Assert.Throws<ArgumentNullException>(() => trie.Add(null));
            Assert.Throws<ArgumentNullException>(() => trie.Search(null));
            Assert.Throws<ArgumentNullException>(() => trie.StartsWith(null));
        }

        [Test]
        public void SearchAndStartsWith_PassEmptyString_ReturnsTrue()
        {
            Trie trie = new Trie();
            Assert.IsTrue(trie.Search(string.Empty));
            Assert.IsTrue(trie.StartsWith(string.Empty));
        }

        [Test]
        public void Add_PassNonEmptyStrings_EnablesFindingTheWords()
        {
            string[] inputWords = new string[] { "test", "te123", "test2", "a" };
            Trie trie = new Trie();

            foreach (string word in inputWords)
                trie.Add(word);

            foreach (string word in inputWords)
            {
                Assert.IsTrue(trie.Search(word));
                Assert.IsTrue(trie.StartsWith(word));
            }

            Assert.IsTrue(trie.StartsWith("te"));
            Assert.IsFalse(trie.StartsWith("b"));
        }
    }
}