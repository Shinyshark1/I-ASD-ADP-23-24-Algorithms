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

        public TreeNode Find(int value)
        {
            // In order | L -> N -> R
            throw new NotImplementedException();
        }

        public TreeNode FindMaximum()
        {
            // In order | L -> N -> R
            throw new NotImplementedException();
        }

        public TreeNode FindMinimum()
        {
            // In order | L -> N -> R
            throw new NotImplementedException();
        }

        public void Insert(int value)
        {
            // TODO: Rotate after mutation
            if (Root == null)
            {
                Root = new TreeNode(value);
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
                    currentNode.Left = new TreeNode(value);
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
