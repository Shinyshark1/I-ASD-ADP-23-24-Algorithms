namespace Algorithms.Stack
{
    public class Stack<T> : IStack<T>
    {
        private List<T> _stackItems;

        public Stack()
        {
            _stackItems = new();
        }

        public Stack(T[] array)
        {
            _stackItems = array.ToList();
        }

        public void Push(T value)
        {
            _stackItems.Add(value);
        }

        public T? Top()
        {
            return _stackItems.LastOrDefault();
        }

        public void Pop()
        {
            if (IsEmpty())
            {
                return;
            }

            _stackItems.RemoveAt(_stackItems.Count - 1);
        }

        public bool IsEmpty()
        {
            return _stackItems.Count == 0;
        }

        public int Size()
        {
            return _stackItems.Count;
        }
    }
}
