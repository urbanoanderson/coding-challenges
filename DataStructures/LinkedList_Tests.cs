using System;
using System.Linq;
using NUnit.Framework;

namespace CodingChallenges.DataStructures
{
    public class LinkedList_Tests
    {
        [Test]
        public void Insert_PassValidElements_UpdateCountAndSequence()
        {
            LinkedList<int> list = new LinkedList<int>();

            Assert.IsTrue(list.Count == 0);
            list.InsertFirst(1);
            Assert.IsTrue(list.Count == 1);
            Assert.IsTrue(list.GetEnumerator().SequenceEqual(new int[] { 1 }));
            list.InsertFirst(2);
            Assert.IsTrue(list.Count == 2);
            Assert.IsTrue(list.GetEnumerator().SequenceEqual(new int[] { 2, 1 }));
            list.InsertLast(3);
            Assert.IsTrue(list.Count == 3);
            Assert.IsTrue(list.GetEnumerator().SequenceEqual(new int[] { 2, 1, 3 }));
            Assert.IsTrue(list.First == 2);
            Assert.IsTrue(list.Last == 3);
            Assert.IsTrue(list[1] == 1);
        }

        [Test]
        public void Remove_PassValidElements_UpdateCountAndSequence()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.InsertLast(1);
            list.InsertLast(2);
            list.InsertLast(3);
            list.InsertLast(4);
            list.InsertLast(5);

            list.RemoveFirst();
            Assert.IsTrue(list.Count == 4);
            Assert.IsTrue(list.GetEnumerator().SequenceEqual(new int[] { 2, 3, 4, 5 }));
            list.RemoveLast();
            Assert.IsTrue(list.Count == 3);
            Assert.IsTrue(list.GetEnumerator().SequenceEqual(new int[] { 2, 3, 4 }));
            list.Remove(3);
            Assert.IsTrue(list.Count == 2);
            Assert.IsTrue(list.GetEnumerator().SequenceEqual(new int[] { 2, 4 }));
            list.Remove(4);
            Assert.IsTrue(list.Count == 1);
            Assert.IsTrue(list.GetEnumerator().SequenceEqual(new int[] { 2 }));
        }
    }
}