namespace Algorithms.Deque
{
    public interface IDeque
    {
        /// <summary>
        /// Inserts an item on the left side of the queue.
        /// </summary>
        public void InsertLeft();

        /// <summary>
        /// Inserts an item on the right side of the queue.
        /// </summary>
        public void InsertRight();

        /// <summary>
        /// Deletes an item on the left side of the queue.
        /// </summary>
        public void DeleteLeft();

        /// <summary>
        /// Deletes an item on the right side of the queue.
        /// </summary>
        public void DeleteRight();

        public int Count { get; }
    }
}
