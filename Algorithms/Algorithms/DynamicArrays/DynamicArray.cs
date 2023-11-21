namespace Algorithms.DynamicArrays
{
    public class DynamicArray<T> : IDynamicArray<T>
    {
        private T[] _innerArray;
        private int _innerCount;

        public DynamicArray()
        {
            _innerCount = 0;
            _innerArray = Array.Empty<T>();
        }

        public DynamicArray(T[] array)
        {
            _innerCount = array.Length;
            _innerArray = array;
        }

        public DynamicArray(IEnumerable<T> values)
        {
            _innerCount = values.Count();
            _innerArray = new T[_innerCount];

            var index = 0;
            foreach (T? value in values)
            {
                _innerArray[index] = value;
                index++;
            }
        }

        public T this[int index]
        {
            get => _innerArray[index];
            set => _innerArray[index] = value;
        }

        public int Count => _innerCount;
        public int ArrayLength => _innerArray.Length;

        public void Add(T item)
        {
            DoubleArrayIfRequired();

            _innerArray[_innerCount] = item;
            _innerCount++;
        }

        public void Insert(int index, T item)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("Items may not be inserted on a negative index.");
            }

            DoubleArrayIfRequired();
            if (index > _innerCount)
            {
                Add(item);
                return;
            }

            _innerArray = InsertIntoArray(index, item);
        }

        private T[] InsertIntoArray(int index, T item)
        {
            var temporaryArray = new T[_innerArray.Length + 1];
            var indexOffset = 0;
            for (int i = 0; i < _innerArray.Length; i++)
            {
                if (i == index)
                {
                    indexOffset = 1;
                    temporaryArray[index] = item;
                }

                temporaryArray[i + indexOffset] = _innerArray[i];
            }

            _innerCount++;
            return temporaryArray;
        }

        public bool Remove(T item)
        {
            List<int> indexesToRemove = GetIndexesToRemove(item);
            if (indexesToRemove.Count == 0)
            {
                return false;
            }

            _innerArray = DefragmentArray(indexesToRemove);
            _innerCount -= indexesToRemove.Count;

            HalfArrayIfPossible();
            return true;
        }

        public bool Remove_WithShrinkByOne(T item)
        {
            List<int> indexesToRemove = GetIndexesToRemove(item);
            if (indexesToRemove.Count == 0)
            {
                return false;
            }

            _innerArray = DefragmentArray(indexesToRemove);
            _innerCount -= indexesToRemove.Count;

            ShrinkArrayIfPossible();
            return true;
        }

        private List<int> GetIndexesToRemove(T item)
        {
            var indexesToRemove = new List<int>();
            for (int i = 0; i < _innerArray.Length; i++)
            {
                if (_innerArray[i]?.Equals(item) == true)
                {
                    indexesToRemove.Add(i);
                }
            }

            return indexesToRemove;
        }

        private T[] DefragmentArray(List<int> indexesToRemove)
        {
            var temporaryArray = new T[_innerArray.Length];
            var indexOffset = 0;
            for (int i = 0; i < _innerArray.Length; i++)
            {
                if (indexesToRemove.Contains(i))
                {
                    indexOffset++;
                    continue;
                }

                temporaryArray[i - indexOffset] = _innerArray[i];
            }

            return temporaryArray;
        }

        public bool RemoveAtIndex(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("Items may not be removed at a negative index.");
            }

            if (index > _innerCount)
            {
                return false;
            }

            _innerArray = DefragmentArray(new List<int> { index });
            _innerCount--;

            HalfArrayIfPossible();
            return true;
        }

        public void DoubleArrayIfRequired()
        {
            if (_innerCount >= _innerArray.Length)
            {
                var temporaryArray = new T[(_innerCount * 2)];
                Array.Copy(_innerArray, temporaryArray, _innerArray.Length);
                _innerArray = temporaryArray;
            }
        }

        public void ExpandArrayByOneIfRequired()
        {
            if (_innerCount >= _innerArray.Length)
            {
                var temporaryArray = new T[(_innerCount)];
                Array.Copy(_innerArray, temporaryArray, temporaryArray.Length);
                _innerArray = temporaryArray;
            }
        }

        public void HalfArrayIfPossible()
        {
            if (_innerCount <= (_innerArray.Length / 2))
            {
                var temporaryArray = new T[(_innerCount)];
                Array.Copy(_innerArray, temporaryArray, temporaryArray.Length);
                _innerArray = temporaryArray;
            }
        }

        public void ShrinkArrayIfPossible()
        {
            if (_innerCount < _innerArray.Length)
            {
                var temporaryArray = new T[(_innerCount)];
                Array.Copy(_innerArray, temporaryArray, temporaryArray.Length);
                _innerArray = temporaryArray;
            }
        }

        public void Clear()
        {
            _innerArray = Array.Empty<T>();
            _innerCount = 0;
        }

        public bool Contains(T item)
        {
            foreach (var arrayItem in _innerArray)
            {
                if (arrayItem?.Equals(item) == true)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
