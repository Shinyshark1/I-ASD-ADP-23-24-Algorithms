using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.BinarySearch
{
    public class BinarySearch<T> where T : IComparable<T>
    {
        private readonly List<T> _list;

        public BinarySearch()
        {
            _list = new List<T>();
        }

        public BinarySearch(IEnumerable<T> list)
        {
            _list = list.ToList();
            _list.Sort();
        }

        public void Add(T item)
        {
            _list.Add(item);
            _list.Sort();
        }

        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
            _list.Sort();
        }

        public int? IndexOf(T item)
        {
            return IndexOfRecursive(item, _list, 0, _list.Count - 1);
        }

        private int? IndexOfRecursive(T item, List<T> list, int leftIndex, int rightIndex)
        {
            if(rightIndex >= leftIndex)
            {
                var middleIndex = (leftIndex + rightIndex) / 2;
                int compareToResult = item.CompareTo(list[middleIndex]);
                
                if(compareToResult < 0)
                {
                    return IndexOfRecursive(item, list, leftIndex, middleIndex - 1);
                }
                else if(compareToResult > 0)
                {
                    return IndexOfRecursive(item, list, middleIndex + 1, rightIndex);
                }
                else
                {
                    return middleIndex;
                }
            }

            return null;
        }

        public int Count => _list.Count;
    }
}
