using System;
using System.Collections.Generic;

namespace CodingChallenges.DataStructures
{
    public class LinkedList<T>
    {
        private class ListNode
        {
            public T Value { get; set; }
            public ListNode Next { get; set; }
            public ListNode() { }
            public ListNode(T val) => this.Value = val;
        }

        private ListNode start;

        private ListNode end;

        public int Count { get; private set; }

        public T First { get => this.start != null ? this.start.Value : throw new IndexOutOfRangeException(); }

        public T Last { get => this.end != null ? this.end.Value : throw new IndexOutOfRangeException(); }

        // This operation emulates random accessing but it's slow in a Linked list like this
        // because to access any given index it is necessary to iterate the list until the index
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                    throw new IndexOutOfRangeException();

                ListNode aux = this.start;
                for (int i = 0; i < index; i++)
                    aux = aux.Next;

                return aux.Value;
            }
        }

        public bool Find(T item)
        {
            for (ListNode node = this.start; node != null; node = node.Next)
            {
                if (node.Value.Equals(item))
                    return true;
            }

            return false;
        }

        public IEnumerable<T> GetEnumerator()
        {
            for (ListNode node = this.start; node != null; node = node.Next)
            {
                yield return node.Value;
            }
        }

        public void InsertFirst(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            ListNode newNode = new ListNode(item);
            this.Count++;

            if (this.start == null)
            {
                this.start = newNode;
                this.end = this.start;
            }
            else
            {
                newNode.Next = this.start;
                this.start = newNode;
            }
        }

        public void InsertLast(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            ListNode newNode = new ListNode(item);
            this.Count++;

            if (this.start == null)
            {
                this.start = newNode;
                this.end = this.start;
            }
            else
            {
                this.end.Next = newNode;
                this.end = newNode;
            }
        }

        public void RemoveFirst()
        {
            if (this.start != null)
            {
                if (this.start == this.end)
                {
                    this.start = null;
                    this.end = null;
                }
                else
                {
                    this.start = this.start.Next;
                }

                this.Count--;
            }
        }

        public void RemoveLast()
        {
            if (this.start == null)
                return;

            if (this.start == this.end)
            {
                this.start = null;
                this.end = null;
            }
            else
            {
                ListNode aux = this.start;

                while (aux.Next != this.end)
                    aux = aux.Next;

                aux.Next = aux.Next.Next;
                this.end = aux.Next;
            }

            this.Count--;
        }

        public void Remove(T item)
        {
            for (ListNode previous = null, node = this.start; node != null; previous = node, node = node.Next)
            {
                if (node.Value.Equals(item))
                {
                    if (node == this.start)
                        this.RemoveFirst();
                    else
                    {
                        if (node == this.end)
                            this.end = previous;

                        previous.Next = node.Next;
                        this.Count--;
                    }
                }
            }
        }
    }
}