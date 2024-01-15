using Algorithms.AVLSearchTree.Exceptions;
using Algorithms.AVLSearchTree.Models;

namespace Algorithms.AVLSearchTree
{
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
        public TreeNode? Find(int key)
        {
            var node = RecursiveFind(_root, key);
            return node;
            // In order | L -> N -> R
        }

        private TreeNode? RecursiveFind(TreeNode? currentNode, int key)
        {
            if (currentNode == null)
            {
                return null;
            }
            else if (key < currentNode.Key) //L
            {
                return RecursiveFind(currentNode.Left, key);
            }
            else if (currentNode.Key == key) //N
            {
                return currentNode;
            }
            else if (key > currentNode.Key) //R
            {
                return RecursiveFind(currentNode.Right, key);
            }

            // This is unreachable as all cases are covered, but I prefer not to use else to assume the right hand side for clarity of code.
            return null;
        }

        /// <summary>
        /// Finds the highest valued <see cref="TreeNode"/> in the subtree of the provided <see cref="TreeNode"/>.
        /// </summary>
        /// <remarks>
        /// If no <see cref="TreeNode"/> is provided, the search will begin from the root of the tree.
        /// </remarks>
        public TreeNode? FindMaximum(TreeNode? node = null)
        {
            node ??= _root;
            return RecursiveFindMaximum(node);
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

        /// <summary>
        /// Finds the lowest valued <see cref="TreeNode"/> in the subtree of the provided <see cref="TreeNode"/>.
        /// </summary>
        /// <remarks>
        /// If no <see cref="TreeNode"/> is provided, the search will begin from the root of the tree.
        /// </remarks>
        public TreeNode? FindMinimum(TreeNode? node = null)
        {
            // No order, we just find the L node.
            node ??= _root;
            return RecursiveFindMinimum(node);
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

        #region Insert

        public void Insert(int value)
        {
            if (_root == null)
            {
                _root = new TreeNode(value);
                BalanceTree(_root);
                return;
            }

            RecursivelyInsertNode(_root, value);
        }

        private void RecursivelyInsertNode(TreeNode currentNode, int key)
        {
            // We cannot insert duplicate values for our tree.
            if (currentNode.Key == key)
            {
                throw new DuplicateTreeNodeKeyException($"A duplicate key is not allowed, offending value: '{key}'");
            }

            // If the value is smaller than our value, we move to the left.
            if (key < currentNode.Key)
            {
                // If left is null, we insert here and stop.
                if (currentNode.Left == null)
                {
                    // the height of this node is the height of the previous node + 1
                    currentNode.Left = new TreeNode(key);
                    BalanceTree(currentNode.Left);
                    return;
                }

                RecursivelyInsertNode(currentNode.Left, key);
            }
            // If the value is larger than our value, we move to the right.
            else if (key > currentNode.Key)
            {
                // If right is null, we insert here and stop.
                if (currentNode.Right == null)
                {
                    currentNode.Right = new TreeNode(key);
                    BalanceTree(currentNode.Right);
                    return;
                }

                RecursivelyInsertNode(currentNode.Right, key);
            }
        }

        #endregion

        #region Remove

        public bool Remove(int value)
        {
            var node = Find(value);
            if (node == null)
            {
                return false;
            }

            // If there is no parent, we have the root.
            if (node.Parent == null)
            {
                // TODO: Figure out what we do to remove the root.
                RemoveRootNode(node);
                BalanceTree(_root);
                return true;
            }

            // Post order | L -> R -> N
            switch (node.GetFamilySituation())
            {
                case FamilyEnum.NoChildren:
                    RemoveChildlessNode(node);
                    break;
                case FamilyEnum.OneChild:
                    RemoveNodeWithOneChild(node);
                    break;
                case FamilyEnum.TwoChildren:
                    RemoveNodeWithTwoChildren(node);
                    break;
                default:
                    throw new TreeNodeExcessiveFamilyException("Your family tree has grown too large.");
            }

            BalanceTree(node);
            return true;
        }

        private void RemoveRootNode(TreeNode node)
        {
            switch (node.GetFamilySituation())
            {
                case FamilyEnum.NoChildren:
                    _root = null;
                    break;
                case FamilyEnum.OneChild:
                    var childNode = _root.Left ?? _root.Right;
                    _root = childNode;
                    _root.Parent = null;
                    break;
                case FamilyEnum.TwoChildren:
                    RemoveNodeWithTwoChildren(_root);
                    break;
                default:
                    throw new TreeNodeExcessiveFamilyException("Your family tree has grown too large.");
            }
        }

        private static void RemoveChildlessNode(TreeNode node)
        {
            var parentNode = node.Parent!;
            if (parentNode.Left?.Key == node.Key)
            {
                parentNode.Left = null;
            }
            else if (parentNode.Right?.Key == node.Key)
            {
                parentNode.Right = null;
            }
        }

        private static void RemoveNodeWithOneChild(TreeNode node)
        {
            // We have to link the one child of our node to the parent of our node.
            if (node.Left != null)
            {
                node.Parent!.Left = node.Left;
            }
            else if (node.Right != null)
            {
                node.Parent!.Right = node.Right;
            }
        }

        private void RemoveNodeWithTwoChildren(TreeNode node)
        {
            var smallestNode = FindMinimum(node.Right);

            // Swap the values.
            node.Key = smallestNode.Key;
            node.Value = smallestNode.Value;

            // Remove the duplicate smallest node.
            RemoveChildlessNode(smallestNode);
        }

        #endregion

        #region Rotations

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
                    // LR Case
                    else if (currentNode.Left != null && currentNode.Left.BalanceFactor < 0)
                    {
                        currentNode.Left = RotateLeft(currentNode.Left);
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
                    // RL Case
                    else if (currentNode.Right != null && currentNode.Right.BalanceFactor > 0)
                    {
                        currentNode.Right = RotateRight(currentNode.Right);
                        currentNode = RotateLeft(currentNode);
                    }
                }

                // A node with no parent must be the current root.
                if (currentNode.Parent == null)
                {
                    _root = currentNode;
                }

                // We keep the loop going!
                currentNode = currentNode.Parent;
            }
        }

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
