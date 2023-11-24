namespace Algorithms.PriorityQueue.FirstAttempt
{
    public class PriorityQueue<T> : IPriorityQueue<T> where T : IComparable<T>
    {
        private List<T> _items = new();

        public PriorityQueue(IEnumerable<T> items) => _items = new List<T>(items);
        public PriorityQueue(T[] items) => _items = new List<T>(items);
        public PriorityQueue() { }

        public void Insert(T item)
        {
            _items.Add(item);
        }

        public T? FindNext()
        {
            T? priorityItem = default;
            foreach (T item in _items)
            {
                if (priorityItem == null)
                {
                    priorityItem = item;
                    continue;
                }

                if (priorityItem.CompareTo(item) < 0)
                {
                    priorityItem = item;
                }
            }

            return priorityItem;
        }

        public bool DeleteNext()
        {
            var itemToRemove = FindNext();
            if (itemToRemove == null)
            {
                return false;
            }

            return _items.Remove(itemToRemove);
        }

        public int Count => _items.Count;
    }
}
