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
            this.root = this.Remove(this.root, item);
        }

        private TreeNode Remove(TreeNode subtree, T item)
        {
            // Found a leaf
            if (subtree == null)
                return null;

            // Found the item to remove
            else if (subtree.Value.Equals(item))
            {
                // item has no children
                if (subtree.LeftChild == null && subtree.RightChild == null)
                {
                    return null;
                }

                // item only has left child
                else if (subtree.RightChild == null)
                {
                    TreeNode result = subtree.LeftChild;
                    subtree.LeftChild = null;
                    return result;
                }

                // item only has right child
                else if (subtree.LeftChild == null)
                {
                    TreeNode result = subtree.RightChild;
                    subtree.RightChild = null;
                    return result;
                }

                /*
                    item has two children:
                    We have to find the next minimum value to assume the place of the removed item
                    and them remove the original node of the next minimum value (that will have 0 or 1 child)
                */
                else
                {
                    TreeNode nextMinimum = subtree.RightChild;

                    while (nextMinimum.LeftChild != null)
                        nextMinimum = nextMinimum.LeftChild;

                    subtree.Value = nextMinimum.Value;
                    subtree.RightChild = this.Remove(subtree.RightChild, nextMinimum.Value);
                    return subtree;
                }
            }

            // Search on the left
            else if (this.ShouldBeLeftChild(item, subtree.Value))
            {
                subtree.LeftChild = this.Remove(subtree.LeftChild, item);
                return subtree;
            }

            // Search on the right
            else
            {
                subtree.RightChild = this.Remove(subtree.RightChild, item);
                return subtree;
            }
        }

        // This implementation allows two or more of the same item to be added to the tree
        // and also sets a convention of adding equal values as left child nodes
        private bool ShouldBeLeftChild(T childItem, T parentItem)
        {
            return (childItem.CompareTo(parentItem) <= 0);
        }
    }
}