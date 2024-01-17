using Algorithms.AVLSearchTree.Exceptions;
using Algorithms.AVLSearchTree.Models;

namespace Algorithms.AVLSearchTree
{
    public class AvlSearchTree
    {
        private TreeNode? _root { get; set; }

        public int Height => _root?.Height ?? 0;

        public AvlSearchTree()
        {
            _root = null;
        }

        public AvlSearchTree(IEnumerable<int> values)
        {
            _root = null;
            foreach (var item in values)
            {
                Insert(item);
            }
        }

        #region Find Methods

        public TreeNode? Find(int key)
        {
            var node = RecursiveFind(_root, key);
            return node;
        }

        private TreeNode? RecursiveFind(TreeNode? currentNode, int key)
        {
            if (currentNode == null)
            {
                return null;
            }
            else if (key < currentNode.Key)
            {
                return RecursiveFind(currentNode.Left, key);
            }
            else if (currentNode.Key == key)
            {
                return currentNode;
            }
            else if (key > currentNode.Key)
            {
                return RecursiveFind(currentNode.Right, key);
            }

            return null;
        }


        public TreeNode? FindMaximum(TreeNode? node = null)
        {
            node ??= _root;
            return RecursiveFindMaximum(node);
        }

        public TreeNode? RecursiveFindMaximum(TreeNode? node)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Right == null)
            {
                return node;
            }

            return RecursiveFindMaximum(node.Right);
        }

        public TreeNode? FindMinimum(TreeNode? node = null)
        {
            node ??= _root;
            return RecursiveFindMinimum(node);
        }

        public TreeNode? RecursiveFindMinimum(TreeNode? node)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Left == null)
            {
                return node;
            }

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
            if (currentNode.Key == key)
            {
                throw new DuplicateTreeNodeKeyException($"A duplicate key is not allowed, offending value: '{key}'");
            }

            if (key < currentNode.Key)
            {
                if (currentNode.Left == null)
                {
                    currentNode.Left = new TreeNode(key);
                    BalanceTree(currentNode.Left);
                    return;
                }

                RecursivelyInsertNode(currentNode.Left, key);
            }
            else if (key > currentNode.Key)
            {
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

            if (node.Parent == null)
            {
                RemoveRootNode(node);
                BalanceTree(_root);
                return true;
            }

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

            node.Key = smallestNode.Key;
            node.Value = smallestNode.Value;

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
                    if (currentNode.Left != null && currentNode.Left.BalanceFactor >= 0)
                    {
                        currentNode = RotateRight(currentNode);
                    }
                    else if (currentNode.Left != null && currentNode.Left.BalanceFactor < 0)
                    {
                        currentNode.Left = RotateLeft(currentNode.Left);
                        currentNode = RotateRight(currentNode);
                    }
                }
                else if (currentNode.BalanceFactor < -1)
                {
                    if (currentNode.Right != null && currentNode.Right.BalanceFactor <= 0)
                    {
                        currentNode = RotateLeft(currentNode);
                    }
                    else if (currentNode.Right != null && currentNode.Right.BalanceFactor > 0)
                    {
                        currentNode.Right = RotateRight(currentNode.Right);
                        currentNode = RotateLeft(currentNode);
                    }
                }

                if (currentNode.Parent == null)
                {
                    _root = currentNode;
                }

                currentNode = currentNode.Parent;
            }
        }


        private TreeNode RotateRight(TreeNode k2)
        {
            TreeNode k1 = k2.Left!;
            k2.Left = k1.Right;
            k1.Right = k2;
            return k1;
        }

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
