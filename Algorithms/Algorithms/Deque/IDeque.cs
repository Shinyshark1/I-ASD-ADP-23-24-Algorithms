namespace Algorithms.Deque
{
    public interface IDeque<T>
    {
        /// <summary>
        /// Inserts an item on the start of the queue.
        /// </summary>
        public void InsertLeft(T item);

        /// <summary>
        /// Inserts an item on the end of the queue.
        /// </summary>
        public void InsertRight(T item);

        /// <summary>
        /// Retrieves an item on the start of the queue and removes it from the queue.
        /// </summary>
        public T? DeleteLeft();

        /// <summary>
        /// Retrieves an item on the end of the queue and removes it from the queue.
        /// </summary>
        public T? DeleteRight();

        public int Count { get; }
    }
}
