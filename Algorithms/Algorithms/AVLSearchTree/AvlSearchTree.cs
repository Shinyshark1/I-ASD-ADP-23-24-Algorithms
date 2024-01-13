using Algorithms.AVLSearchTree.Exceptions;
using Algorithms.AVLSearchTree.Models;

namespace Algorithms.AVLSearchTree
{
    // The height in left and right subtree nodes may be 1 at most, if it becomes 2 we have to rebalance it.
    public class AvlSearchTree
    {
        private TreeNode? Root { get; set; }

        public AvlSearchTree()
        {
            Root = null;
        }

        /// <summary>
        /// Attempts to find a node with the specified value using in-order (L -> N -> R) traversal.
        /// </summary>
        /// <returns>The <see cref="TreeNode"/> with the specified value or <see langword="null"/> if none can be found.</returns>
        public TreeNode? Find(int value)
        {
            var node = RecursiveFind(Root, value);
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

        public TreeNode FindMaximum()
        {
            // In order | L -> N -> R
            throw new NotImplementedException();
        }

        public TreeNode? FindMinimum()
        {
            // No order, we just find the L node.
            return RecursiveFindMinimum(Root);
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

        public void Insert(int value)
        {
            // TODO: Rotate after mutation
            if (Root == null)
            {
                Root = new TreeNode(value, 1);
                return;
            }

            RecursivelyInsertNode(Root, value);
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
                    currentNode.Left = new TreeNode(value, currentNode.Height + 1);
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
                    currentNode.Right = new TreeNode(value, currentNode.Height + 1);
                    return;
                }

                RecursivelyInsertNode(currentNode.Right, value);
            }
        }

        public void Remove(int value)
        {
            // TODO: Rotate after mutation

            // Post order | L -> R -> N
            throw new NotImplementedException();
        }

        private void RotateLL()
        {
            // 1
        }

        private void RotateLR()
        {
            // 3
        }

        private void RotateRL()
        {
            // 4
        }

        private void RotateRR()
        {
            // 2
        }
    }
}
