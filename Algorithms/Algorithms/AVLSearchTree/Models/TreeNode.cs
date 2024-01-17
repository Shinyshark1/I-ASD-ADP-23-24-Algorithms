namespace Algorithms.AVLSearchTree.Models
{
    public class TreeNode
    {
        public TreeNode(int value)
        {
            Key = value;
            Value = value;
            Left = null;
            Right = null;
        }

        public int Key { get; set; }
        public int Value { get; set; }

        public int Depth => GetDepth(this);
        public int Height => GetHeight(this);
        public int BalanceFactor => GetHeight(Left) - GetHeight(Right);

        private TreeNode? _left;
        public TreeNode? Left
        {
            get => _left;
            set
            {
                _left = value;
                if (_left != null)
                {
                    if (Parent == _left)
                    {
                        var newParent = _left.Parent;
                        Parent = newParent;
                    }

                    _left.Parent = this;
                }
            }
        }

        private TreeNode? _right;
        public TreeNode? Right
        {
            get => _right;
            set
            {
                _right = value;
                if (_right != null)
                {
                    if (Parent == _right)
                    {
                        var newParent = _right.Parent;
                        Parent = newParent;
                    }

                    _right.Parent = this;
                }
            }
        }

        private TreeNode? _parent;
        public TreeNode? Parent
        {
            get => _parent;
            set
            {
                _parent = value;
                if (_parent == null)
                {
                    return;
                }

                if (_parent.Left != this && _parent.Right != this)
                {
                    if (_parent.Key < Key)
                    {
                        _parent.Right = this;
                    }
                    else
                    {
                        _parent.Left = this;
                    }
                }
            }
        }

        private int GetDepth(TreeNode? node)
        {
            int depth = -1;
            while (node != null)
            {
                depth++;
                node = node.Parent;
            }

            return depth;
        }

        private int GetHeight(TreeNode? node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                return Math.Max(GetHeight(node.Left), GetHeight(node.Right)) + 1;
            }
        }

        public FamilyEnum GetFamilySituation()
        {
            if (Left == null && Right == null)
            {
                return FamilyEnum.NoChildren;
            }

            if (Left != null && Right != null)
            {
                return FamilyEnum.TwoChildren;
            }

            return FamilyEnum.OneChild;
        }
    }
}
