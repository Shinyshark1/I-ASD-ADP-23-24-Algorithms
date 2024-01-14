using Algorithms.AVLSearchTree.Exceptions;
using Algorithms.AVLSearchTree.Models;

namespace Algorithms.AVLSearchTree
{
    // The height in left and right subtree nodes may be 1 at most, if it becomes 2 we have to rebalance it.
    public class AvlSearchTree
    {
        private TreeNode? _root { get; set; }

        public AvlSearchTree()
        {
            _root = null;
        }

        #region Find Methods

        /// <summary>
        /// Attempts to find a node with the specified value using in-order (L -> N -> R) traversal.
        /// </summary>
        /// <returns>The <see cref="TreeNode"/> with the specified value or <see langword="null"/> if none can be found.</returns>
        public TreeNode? Find(int value)
        {
            var node = RecursiveFind(_root, value);
            return node;
            // In order | L -> N -> R
        }

        private TreeNode? RecursiveFind(TreeNode? currentNode, int value)
        {
            if (currentNode == null)
            {
                return null;
            }
            else if (value < currentNode.Value) //L
            {
                return RecursiveFind(currentNode.Left, value);
            }
            else if (currentNode.Value == value) //N
            {
                return currentNode;
            }
            else if (value > currentNode.Value) //R
            {
                return RecursiveFind(currentNode.Right, value);
            }

            // This is unreachable as all cases are covered, but I prefer not to use else to assume the right hand side for clarity of code.
            return null;
        }


        public TreeNode? FindMaximum()
        {
            return RecursiveFindMaximum(_root);
        }

        public TreeNode? RecursiveFindMaximum(TreeNode? node)
        {
            // If our Root is null, this would be null.
            if (node == null)
            {
                return null;
            }

            // If there are no more nodes on the right, this node is the highest one.
            if (node.Right == null)
            {
                return node;
            }

            // Recursion!!!!
            return RecursiveFindMaximum(node.Right);
        }


        public TreeNode? FindMinimum()
        {
            // No order, we just find the L node.
            return RecursiveFindMinimum(_root);
        }

        public TreeNode? RecursiveFindMinimum(TreeNode? node)
        {
            // If our Root is null, this would be null.
            if (node == null)
            {
                return null;
            }

            // If there are no more nodes on the left, this node is the lowest one.
            if (node.Left == null)
            {
                return node;
            }

            // Recursion!!!!
            return RecursiveFindMinimum(node.Left);
        }

        #endregion

        private void BalanceTree(TreeNode newNode)
        {
            TreeNode? currentNode = newNode;
            while (currentNode != null)
            {
                if (currentNode.BalanceFactor > 1)
                {
                    // LL Case
                    if (currentNode.Left != null && currentNode.Left.BalanceFactor >= 0)
                    {
                        currentNode = RotateRight(currentNode);
                    }
                }
                else if (currentNode.BalanceFactor < -1)
                {
                    // RR Case
                    if (currentNode.Right != null && currentNode.Right.BalanceFactor <= 0)
                    {
                        currentNode = RotateLeft(currentNode);
                    }
                }

                // A node with no parent must be the root.
                if (currentNode.Parent == null)
                {
                    _root = currentNode;
                }

                currentNode = currentNode.Parent;
            }
        }

        public void Insert(int value)
        {
            // TODO: Rotate after mutation
            if (_root == null)
            {
                _root = new TreeNode(value);
                BalanceTree(_root);
                return;
            }

            RecursivelyInsertNode(_root, value);
        }

        private void RecursivelyInsertNode(TreeNode currentNode, int value)
        {
            // We cannot insert duplicate values for our tree.
            if (currentNode.Value == value)
            {
                throw new DuplicateTreeNodeKeyException($"A duplicate value is not allowed, offending value: '{value}'");
            }

            // If the value is smaller than our value, we move to the left.
            if (value < currentNode.Value)
            {
                // If left is null, we insert here and stop.
                if (currentNode.Left == null)
                {
                    // the height of this node is the height of the previous node + 1
                    currentNode.Left = new TreeNode(value);
                    BalanceTree(currentNode.Left);
                    return;
                }

                RecursivelyInsertNode(currentNode.Left, value);
            }
            // If the value is larger than our value, we move to the right.
            else if (value > currentNode.Value)
            {
                // If right is null, we insert here and stop.
                if (currentNode.Right == null)
                {
                    currentNode.Right = new TreeNode(value);
                    BalanceTree(currentNode.Right);
                    return;
                }

                RecursivelyInsertNode(currentNode.Right, value);
            }
        }

        {
            // TODO: Rotate after mutation

            // Post order | L -> R -> N
            throw new NotImplementedException();
        }

        private void RotateLL()
        {
            // 1
        #region Rotations

        private TreeNode RotateLL(TreeNode k2)
        {
            TreeNode k1 = k2.Left!;
            k2.Left = k1.Right;
            k1.Right = k2;
            return k1;
        }

        {
            // 3
        }

        #endregion

        #region Rotations

        /// <summary>
        /// This is used for LL scenarios.
        /// </summary>
        private TreeNode RotateRight(TreeNode k2)
        {
            TreeNode k1 = k2.Left!;
            k2.Left = k1.Right;
            k1.Right = k2;
            return k1;
        }

        /// <summary>
        /// This is used for RR scenarios.
        /// </summary>
        private TreeNode RotateLeft(TreeNode k2)
        {
            TreeNode k1 = k2.Right!;
            k2.Right = k1.Left;
            k1.Left = k2;
            return k1;
        }

        #endregion
    }
}
