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

        // Normally we'd have a key AND a value but we only need to insert ints here.
        // For the sake of simplicity, we treat the key AND the value as seperate entities in-case we'd ever want to implement <T>
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
                    // If our parent is about to become our child we have to swap parents.
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
                    // If our parent is about to become our child we have to swap parents.
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

                // If our parent has neither left nor right as a reference to us, a desync is about to occur.
                if (_parent.Left != this && _parent.Right != this)
                {
                    if (_parent.Value < Value)
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
            // We start at -1 so that our root stays at the conventional 0.
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
