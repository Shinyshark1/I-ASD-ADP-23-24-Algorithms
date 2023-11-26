namespace Algorithms.Deque
{
    public class Deque<T> : IDeque<T>
    {
        private LinkedList<T> _linkedList = new();

        public Deque(IEnumerable<T> items)
        {
            _linkedList = new LinkedList<T>(items);
        }

        public Deque() { }

        public T? DeleteLeft()
        {
            if (_linkedList?.Count < 1)
            {
                throw new IndexOutOfRangeException("The first item could not be found as the queue is empty.");
            }

            if (_linkedList?.First == null)
            {
                return default;
            }

            var value = _linkedList.First.Value;
            _linkedList.RemoveFirst();

            return value;
        }

        public T? DeleteRight()
        {
            if (_linkedList?.Count < 1)
            {
                throw new IndexOutOfRangeException("The last item could not be found as the queue is empty.");
            }

            if (_linkedList?.Last == null)
            {
                return default;
            }

            var value = _linkedList.Last.Value;
            _linkedList.RemoveLast();

            return value;
        }

        public void InsertLeft(T item) => _linkedList.AddFirst(item);

        public void InsertRight(T item) => _linkedList.AddLast(item);

        public int Count => _linkedList.Count;
    }
}
