namespace Algorithms.PriorityQueue.FirstAttempt
{
    public interface IPriorityQueue<T>
    {
        /// <summary>
        /// Inserts a new item into the queue.
        /// </summary>
        public void Insert(T item);

        /// <summary>
        /// Finds the item in the queue with the highest priority, and returns it.
        /// </summary>
        public T FindNext();

        /// <summary>
        /// Finds the item in the queue with the highest priority, and removes it.
        /// </summary>
        public bool DeleteNext();
    }
}
