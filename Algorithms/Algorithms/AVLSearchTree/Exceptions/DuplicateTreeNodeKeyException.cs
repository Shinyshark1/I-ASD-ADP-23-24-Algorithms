namespace Algorithms.AVLSearchTree.Exceptions
{
    public class DuplicateTreeNodeKeyException : Exception
    {
        public DuplicateTreeNodeKeyException()
        {
        }

        public DuplicateTreeNodeKeyException(string message) : base(message) { }
    }
}
