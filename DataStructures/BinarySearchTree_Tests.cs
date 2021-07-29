using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CodingChallenges.DataStructures
{
    public class BinarySearchTree_Tests
    {
        private int[] sampleItems = { 5, 2, 4, 1, 3 };

        [Test]
        public void Find_PassNullItem_ThrowsArgumentNullException()
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string>();
            Assert.Throws<ArgumentNullException>(() => tree.Find(null));
        }

        [Test]
        public void Find_PassExistantItem_ReturnsTrue()
        {
            BinarySearchTree<int> tree = this.GetPreloadedTree();
            Assert.IsTrue(tree.Find(sampleItems[0]));
        }

        [Test]
        public void Find_PassExistantItem_ReturnsFalse()
        {
            BinarySearchTree<int> tree = this.GetPreloadedTree();
            Assert.IsFalse(tree.Find(6));
        }

        [Test]
        public void Insert_PassNullItem_ThrowsArgumentNullException()
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string>();
            Assert.Throws<ArgumentNullException>(() => tree.Insert(null));
        }

        [Test]
        public void Insert_PassValidItems_InsertSuccessful()
        {
            BinarySearchTree<int> tree = this.GetPreloadedTree();
            Assert.IsTrue(this.sampleItems.Length == tree.Count);
        }

        [Test]
        public void TraversalPreOrder_PassNullAction_ThrowsArgumentNullException()
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string>();
            Assert.Throws<ArgumentNullException>(() => tree.TraversalPreOrder(null));
        }

        [Test]
        public void TraversalPreOrder_PassValidItems_GetCorrectOrder()
        {
            int[] expected = { 5, 2, 1, 4, 3 };
            List<int> result = new List<int>();
            BinarySearchTree<int> tree = this.GetPreloadedTree();

            tree.TraversalPreOrder((item) => result.Add(item));

            Assert.IsTrue(result.SequenceEqual(expected));
        }

        [Test]
        public void TraversalInOrder_PassNullAction_ThrowsArgumentNullException()
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string>();
            Assert.Throws<ArgumentNullException>(() => tree.TraversalInOrder(null));
        }

        [Test]
        public void TraversalInOrder_PassValidItems_GetCorrectOrder()
        {
            int[] expected = { 1, 2, 3, 4, 5 };
            List<int> result = new List<int>();
            BinarySearchTree<int> tree = this.GetPreloadedTree();

            tree.TraversalInOrder((item) => result.Add(item));

            Assert.IsTrue(result.SequenceEqual(expected));
        }

        [Test]
        public void TraversalPostOrder_PassNullAction_ThrowsArgumentNullException()
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string>();
            Assert.Throws<ArgumentNullException>(() => tree.TraversalPostOrder(null));
        }

        [Test]
        public void TraversalPostOrder_PassValidItems_GetCorrectOrder()
        {
            int[] expected = { 1, 3, 4, 2, 5 };
            List<int> result = new List<int>();
            BinarySearchTree<int> tree = this.GetPreloadedTree();

            tree.TraversalPostOrder((item) => result.Add(item));

            Assert.IsTrue(result.SequenceEqual(expected));
        }

        private BinarySearchTree<int> GetPreloadedTree()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();

            foreach (var item in this.sampleItems)
                tree.Insert(item);

            return tree;
        }
    }
}