namespace Algorithms.PriorityQueue.SecondAttempt
{
    public interface IGenericPriorityQueue<TPriority, TItem> where TPriority : IComparable<TPriority>
    {
        /// <summary>
        /// Inserts a new item into the queue.
        /// </summary>
        public void Insert(TPriority priority, TItem item);

        /// <summary>
        /// Finds the item in the queue with the highest priority, and returns it.
        /// </summary>
        public TItem FindNextValue();

        /// <summary>
        /// Finds the item in the queue with the highest priority, and returns the corresponding KeyValuePair.
        /// </summary>
        KeyValuePair<TPriority, TItem> FindNext();

        /// <summary>
        /// Finds the item in the queue with the highest priority, and removes it.
        /// </summary>
        public bool DeleteNext();
    }
}
