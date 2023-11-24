namespace Algorithms.PriorityQueue.SecondAttempt
{
    public class GenericPriorityQueue<TPriority, TItem> : IGenericPriorityQueue<TPriority, TItem> where TPriority : IComparable<TPriority>
    {
        private List<KeyValuePair<TPriority, TItem>> _priorityCollection = new();

        public GenericPriorityQueue(IEnumerable<TPriority> items)
        {
            if(typeof(TPriority) != typeof(TItem))
            {
                throw new ArgumentException("TPriority and TItem must be of the same type.");
            }

            foreach (var item in items)
            {
                TItem castedItem = (TItem)Convert.ChangeType(item, typeof(TItem));
                _priorityCollection.Add(new KeyValuePair<TPriority, TItem>(item, castedItem));
            }
        }

        public GenericPriorityQueue() { }

        public void Insert(TPriority priority, TItem item)
        {
            _priorityCollection.Add(new KeyValuePair<TPriority, TItem>(priority, item));
        }

        public TItem? FindNextValue()
        {
            if (_priorityCollection.Count == 0)
            {
                return default;
            }

            KeyValuePair<TPriority, TItem> priorityItem = DeterminePriorityItem();
            return priorityItem.Value;
        }

        public KeyValuePair<TPriority, TItem> FindNext()
        {
            if (_priorityCollection.Count == 0)
            {
                return default;
            }

            return DeterminePriorityItem();
        }

        private KeyValuePair<TPriority, TItem> DeterminePriorityItem()
        {
            KeyValuePair<TPriority, TItem> priorityItem = _priorityCollection[0];
            foreach (var item in _priorityCollection.Skip(1))
            {
                if (priorityItem.Key.CompareTo(item.Key) < 0)
                {
                    priorityItem = item;
                }
            }

            return priorityItem;
        }

        public bool DeleteNext()
        {
            return _priorityCollection.Remove(FindNext());
        }

        public int Count => _priorityCollection.Count;
    }
}
