using System;
using System.Collections.Generic;

namespace CodingChallenges.DataStructures
{
    public class Trie
    {
        private class TrieNode
        {
            public char Value { get; set; }
            public bool IsWord { get; set; }
            public Dictionary<char, TrieNode> Children { get; set; }
        }

        private TrieNode root;

        public Trie()
        {
            this.root = new TrieNode()
            {
                IsWord = false,
                Children = new Dictionary<char, TrieNode>(),
            };
        }

        public Trie(string initialWord) : base()
        {
            this.Add(initialWord);
        }

        public void Add(string word)
        {
            if (word == null)
                throw new ArgumentNullException(nameof(word));

            if (word == string.Empty)
                return;

            TrieNode temp = this.root;

            for (int charIdx = 0; charIdx < word.Length; charIdx++)
            {
                if (!temp.Children.ContainsKey(word[charIdx]))
                {
                    temp.Children[word[charIdx]] = new TrieNode()
                    {
                        Value = word[charIdx],
                        IsWord = (charIdx == (word.Length - 1)),
                        Children = new Dictionary<char, TrieNode>(),
                    };
                }

                temp = temp.Children[word[charIdx]];
            }
        }

        public bool Search(string word)
        {
            if (word == null)
                throw new ArgumentNullException(nameof(word));

            // This implementation considers that "" is always present
            if (word == string.Empty)
                return true;

            TrieNode lastCharNode = this.GetLastCharNode(word);

            return lastCharNode != null && lastCharNode.IsWord;
        }

        public bool StartsWith(string word)
        {
            if (word == null)
                throw new ArgumentNullException(nameof(word));

            if (word == string.Empty)
                return true;

            TrieNode lastCharNode = this.GetLastCharNode(word);

            return lastCharNode != null;
        }

        private TrieNode GetLastCharNode(string word)
        {
            TrieNode temp = this.root;

            for (int charIdx = 0; charIdx < word.Length; charIdx++)
            {
                if (!temp.Children.ContainsKey(word[charIdx]))
                    return null;

                temp = temp.Children[word[charIdx]];
            }

            return temp;
        }
    }
}