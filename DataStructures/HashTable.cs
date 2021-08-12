using System;
using System.Collections.Generic;

namespace CodingChallenges.DataStructures
{
    public class HashTable<TKey, TValue> where TKey : IEquatable<TKey>
    {
        private const int INITIAL_CAPACITY = 4;

        private List<(TKey, TValue)>[] container;

        public HashTable()
        {
            this.container = new List<(TKey, TValue)>[INITIAL_CAPACITY];
            this.Count = 0;
        }

        public int Count { get; private set; }

        public int Capacity { get => this.container.Length; }

        public TValue this[TKey index]
        {
            get => this.GetValue(index);
            set => this.AddOrUpdate(index, value);
        }

        public void AddOrUpdate(TKey key, TValue value)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            if (this.Count == this.container.Length)
                this.IncreaseCapacity();

            this.Count++;
            int index = this.GetIndex(key);

            if (this.container[index] == null)
                this.container[index] = new List<(TKey, TValue)>();

            bool updated = false;

            for (int i = 0; i < this.container[index].Count; i++)
            {
                var keyValPair = this.container[index][i];

                if (keyValPair.Item1.Equals(key))
                {
                    keyValPair.Item2 = value;
                    updated = true;
                    break;
                }
            }

            if (!updated)
                this.container[index].Add((key, value));
        }

        public TValue Remove(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            // This implementation throws KeyNotFoundException if attempting to remove a key that does not exist
            TValue removedValue = this.GetValue(key);

            int index = this.GetIndex(key);

            for (int i = 0; i < this.container[index].Count; i++)
            {
                var keyValPair = this.container[index][i];

                if (keyValPair.Item1.Equals(key))
                {
                    this.container[index].RemoveAt(i);
                    this.Count--;
                    break;
                }
            }

            return removedValue;
        }

        public bool ContainsKey(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            // Using exception handling for an easier implementation but
            // it's not the most efficient way of checking this
            try
            {
                this.GetValue(key);
            }
            catch (KeyNotFoundException)
            {
                return false;
            }

            return true;
        }

        public TValue GetValue(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            int index = this.GetIndex(key);

            if (index < 0 || index > this.Capacity || this.container[index] == null)
                throw new KeyNotFoundException();

            foreach (var keyValPair in this.container[index])
            {
                if (keyValPair.Item1.Equals(key))
                    return keyValPair.Item2;
            }

            throw new KeyNotFoundException();
        }

        private int GetIndex(TKey key)
        {
            return Math.Abs(this.HashFunction(key)) % this.Capacity;
        }

        private int HashFunction(TKey key)
        {
            // Using the default GetHashCode method that every object has in C#
            return key.GetHashCode();
        }

        // This implementation does not consider limits on usable memory
        // Also not reducing capacity if enough elements are removed
        private void IncreaseCapacity()
        {
            Array.Resize(ref this.container, this.container.Length * 2);
        }
    }
}