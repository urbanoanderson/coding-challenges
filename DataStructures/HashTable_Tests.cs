using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CodingChallenges.DataStructures
{
    public class HashTable_Tests
    {
        private HashTable<string, int> hashTable;

        [SetUp]
        public void TestInitialize()
        {
           this.hashTable = new HashTable<string, int>();
        }

        [Test]
        public void AddOrUpdate_PassNullKey_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => this.hashTable.AddOrUpdate(null, 1));
        }

        [Test]
        public void ContainsKey_PassNullKey_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => this.hashTable.ContainsKey(null));
        }

        [Test]
        public void ContainsKey_ElementDoesNotExist_ReturnsFalse()
        {
            Assert.IsFalse(this.hashTable.ContainsKey(string.Empty));
        }

        [Test]
        public void GetValue_PassNullKey_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => this.hashTable.GetValue(null));
        }

        [Test]
        public void GetValue_ElementDoesNotExist_ThrowsKeyNotFoundException()
        {
            Assert.Throws<KeyNotFoundException>(() => this.hashTable.GetValue(string.Empty));
            Assert.Throws<KeyNotFoundException>(() => { var x = this.hashTable[string.Empty]; });
        }

        [Test]
        public void Remove_PassNullKey_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => this.hashTable.Remove(null));
        }

        [Test]
        public void Remove_ElementDoesNotExist_ThrowsKeyNotFoundException()
        {
            Assert.Throws<KeyNotFoundException>(() => this.hashTable.Remove(string.Empty));
        }

        [Test]
        public void HappyTestTests()
        {
            string key1 = "test";
            string key2 = string.Empty;
            string key3 = "a";

            Assert.IsTrue(this.hashTable.Count == 0);

            this.hashTable.AddOrUpdate(key1, 1);

            Assert.IsTrue(this.hashTable.Count == 1);
            Assert.IsTrue(this.hashTable[key1] == 1);
            Assert.IsTrue(this.hashTable.GetValue(key1) == 1);
            Assert.IsTrue(this.hashTable.ContainsKey(key1));

            this.hashTable.AddOrUpdate(key2, 2);

            Assert.IsTrue(this.hashTable.Count == 2);
            Assert.IsTrue(this.hashTable[key2] == 2);
            Assert.IsTrue(this.hashTable.GetValue(key2) == 2);
            Assert.IsTrue(this.hashTable.ContainsKey(key2));

            this.hashTable.AddOrUpdate(key3, 3);

            Assert.IsTrue(this.hashTable.Count == 3);
            Assert.IsTrue(this.hashTable[key3] == 3);
            Assert.IsTrue(this.hashTable.GetValue(key3) == 3);
            Assert.IsTrue(this.hashTable.ContainsKey(key3));

            this.hashTable.Remove(key2);

            Assert.IsTrue(this.hashTable.Count == 2);
            Assert.IsFalse(this.hashTable.ContainsKey(key2));
        }
    }
}