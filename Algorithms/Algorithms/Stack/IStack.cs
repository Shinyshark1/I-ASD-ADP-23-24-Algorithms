namespace Algorithms.Stack
{
    public interface IStack<T>
    {
        /// <summary>
        /// Adds the item to the top of the stack.
        /// </summary>
        public void Push(T value);

        /// <summary>
        /// Removes the top item from the stack.
        /// </summary>
        public void Pop();

        /// <summary>
        /// Retrieves the top item from the stack.
        /// </summary>
        public T Top();

        /// <summary>
        /// Checks if the stack is empty.
        /// </summary>
        /// <returns>True if it is empty, false if it is not.</returns>
        public bool IsEmpty();

        /// <summary>
        /// Returns the amount of items that are present in the stack.
        /// </summary>
        public int Size();
    }
}
