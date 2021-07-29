using System;

namespace CodingChallenges.DataStructures
{
    public class BinarySearchTree<T> where T : IComparable, IEquatable<T>
    {
        private class TreeNode
        {
            public T Value { get; set; }
            public TreeNode LeftChild { get; set; }
            public TreeNode RightChild { get; set; }
            public TreeNode() { }
            public TreeNode(T val) => this.Value = val;
        }

        private TreeNode root;

        public BinarySearchTree()
        {
            this.root = null;
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void TraversalPreOrder(Action<T> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            Action<TreeNode, Action<T>> recursiveTraversal = null;

            recursiveTraversal = (node, action) =>
            {
                if (node != null)
                {
                    action(node.Value);
                    recursiveTraversal(node.LeftChild, action);
                    recursiveTraversal(node.RightChild, action);
                }
            };

            recursiveTraversal(this.root, action);
        }

        public void TraversalInOrder(Action<T> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            Action<TreeNode, Action<T>> recursiveTraversal = null;

            recursiveTraversal = (node, action) =>
            {
                if (node != null)
                {
                    recursiveTraversal(node.LeftChild, action);
                    action(node.Value);
                    recursiveTraversal(node.RightChild, action);
                }
            };

            recursiveTraversal(this.root, action);
        }

        public void TraversalPostOrder(Action<T> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            Action<TreeNode, Action<T>> recursiveTraversal = null;

            recursiveTraversal = (node, action) =>
            {
                if (node != null)
                {
                    recursiveTraversal(node.LeftChild, action);
                    recursiveTraversal(node.RightChild, action);
                    action(node.Value);
                }
            };

            recursiveTraversal(this.root, action);
        }

        public bool Find(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            bool found = false;
            TreeNode aux = this.root;

            while (aux != null)
            {
                if (aux.Value.Equals(item))
                    return true;
                else if (this.ShouldBeLeftChild(item, aux.Value))
                    aux = aux.LeftChild;
                else
                    aux = aux.RightChild;
            }

            return found;
        }

        public void Insert(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            TreeNode newNode = new TreeNode(item);
            this.Count++;

            if (this.root == null)
            {
                this.root = newNode;
            }
            else
            {
                TreeNode aux = this.root;

                while (aux != null)
                {
                    if (this.ShouldBeLeftChild(newNode.Value, aux.Value))
                    {
                        if (aux.LeftChild == null)
                        {
                            aux.LeftChild = newNode;
                            break;
                        }
                        else
                            aux = aux.LeftChild;
                    }
                    else
                    {
                        if (aux.RightChild == null)
                        {
                            aux.RightChild = newNode;
                            break;
                        }
                        else
                            aux = aux.RightChild;
                    }
                }
            }
        }
        public void Remove(T item)
        {
            throw new NotImplementedException();
        }

        // This implementation allows two or more of the same item to be added to the tree
        // and also sets a convention of adding equal values as left child nodes
        private bool ShouldBeLeftChild(T child, T parent)
        {
            return (child.CompareTo(parent) <= 0);
        }
    }
}