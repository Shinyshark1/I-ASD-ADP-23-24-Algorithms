namespace Algorithms.AVLSearchTree.Models
{
    public class TreeNode
    {
        public TreeNode(int value, int height)
        {
            Key = value;
            Value = value;
            Left = null;
            Right = null;
            Height = height;
        }

        // Normally we'd have a key AND a value but we only need to insert ints here.
        // For the sake of simplicity, we treat the key AND the value as seperate entities in-case we'd ever want to implement <T>
        public int Key { get; set; }
        public int Value { get; set; }
        public int Height { get; set; }
        public TreeNode? Left { get; set; }
        public TreeNode? Right { get; set; }

        // Finds the depth of the node by recursively going through the tree.
        public int Size(TreeNode? node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                return
                    Size(node.Left) + 1
                    +
                    Size(node.Right) + 1;
            }
        }
    }
}
