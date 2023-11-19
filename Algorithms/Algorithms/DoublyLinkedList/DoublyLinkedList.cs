namespace Algorithms.DoublyLinkedList
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        private Node<T> Head { get; init; } = new();
        private Node<T> Tail { get; init; } = new();

        public DoublyLinkedList(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Add(array[i]);
            }
        }

        public T this[int index]
        {
            get => Get(index).Value;
            set => Get(index).Value = value;
        }

        private Node<T> Get(int index)
        {
            var node = Head.NextNode;

            for (int i = 0; i <= index; i++)
            {
                if (node.NextNode == null)
                {
                    throw new IndexOutOfRangeException();
                }

                if (i == index)
                {
                    return node;
                }

                node = node.NextNode;
            }

            throw new IndexOutOfRangeException();
        }

        public void Add(T item)
        {
            var newNode = new Node<T> { Value = item };

            var previous = Tail.PreviousNode ?? Head;

            previous.NextNode = newNode;
            newNode.NextNode = Tail;

            Tail.PreviousNode = newNode;
            newNode.PreviousNode = previous;
        }

        public bool Contains(T item)
        {
            var node = Head.NextNode;
            while (true)
            {
                if (node?.NextNode == null)
                {
                    return false;
                }

                if (node.Value.Equals(item))
                {
                    return true;
                }

                node = node.NextNode;
            }
        }

        public int? IndexOf(T item)
        {
            var node = Head.NextNode;
            var index = 0;
            while (true)
            {
                if (node?.NextNode == null)
                {
                    return null;
                }

                if (node.Value.Equals(item))
                {
                    return index;
                }

                index++;
                node = node.NextNode;
            }
        }

        public void Remove(int index)
        {
            var node = Get(index);
            RemoveNode(node);
        }

        public void Remove(T item)
        {
            var node = Head.NextNode;

            while (true)
            {
                if (node?.NextNode == null)
                {
                    return;
                }

                var nextNode = node.NextNode;
                if (node.Value.Equals(item))
                {
                    RemoveNode(node);
                }

                node = nextNode;
            }
        }

        /// <summary>
        /// In this method, we are lazy and use recursion to just find an index and remove the next item each time.
        /// We use this for the benchmark only.
        /// </summary>
        public void Remove_WithRecursion(T item)
        {
            var index = IndexOf(item);
            if (index is not int convertedIndex)
            {
                return;
            }

            Remove(convertedIndex);
            Remove_WithRecursion(item);
        }

        private void RemoveNode(Node<T> node)
        {
            if (node.PreviousNode.PreviousNode == null && node.NextNode.NextNode == null)
            {
                node.PreviousNode.NextNode = null;
                node.NextNode.PreviousNode = null;
            }
            else
            {
                node.PreviousNode.NextNode = node.NextNode;
                node.NextNode.PreviousNode = node.PreviousNode;
            }
        }
    }
}
