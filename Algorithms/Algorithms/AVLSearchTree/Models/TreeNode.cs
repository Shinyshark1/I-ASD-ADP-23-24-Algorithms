namespace Algorithms.AVLSearchTree.Models
{
    public class TreeNode
    {
        public TreeNode(int value, int depth)
        {
            Key = value;
            Value = value;
            Left = null;
            Right = null;
            Depth = depth;
        }

        // Normally we'd have a key AND a value but we only need to insert ints here.
        // For the sake of simplicity, we treat the key AND the value as seperate entities in-case we'd ever want to implement <T>
        public int Key { get; set; }
        public int Value { get; set; }

        public int Depth { get; set; }
        public int Height => GetHeight(this);

        public TreeNode? Left { get; set; }
        public TreeNode? Right { get; set; }
        public TreeNode? Parent { get; set; }

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
