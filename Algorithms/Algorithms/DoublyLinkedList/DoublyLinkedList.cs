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
            // We start on the [0]th node.
            var node = Head.NextNode;
            
            for (int i = 0; i <= index; i++)
            {
                // We should always check if the next node would be null, as it indicates that we have reached the tail.
                if(node.NextNode == null)
                {
                    throw new IndexOutOfRangeException();
                }

                // If the iteration is equal to the index that is being asked for, we retrieve the value.
                if(i == index)
                {
                    return node;
                }

                // Otherwise we move to the next node.
                node = node.NextNode;
            }

            // Indexes start from 0, if someone uses a negative number it is out of bounds as well.
            throw new IndexOutOfRangeException();
        }

        public void Add(T item)
        {
            var newNode = new Node<T> { Value = item };

            // Grab the tail node. If the previous doesn't exist, we have a head and a tail.
            var previous = Tail.PreviousNode ?? Head;

            previous.NextNode = newNode;
            newNode.NextNode = Tail;

            Tail.PreviousNode = newNode;
            newNode.PreviousNode = previous;
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public int? IndexOf(T item)
        {
            var node = Head.NextNode;
            var index = 0;
            while (true)
            {
                // If our next node is null, we are on the tail.
                if(node?.NextNode == null)
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
            // We should loop through the list only once and find our items to remove.
            var node = Head.NextNode;

            while (true)
            {
                // If our next node is null, we are on the tail.
                if (node?.NextNode == null)
                {
                    return;
                }

                // We have to set our next node ahead of time, as it may be removed.
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
        /// THIS IS FOR THE BENCHMARK
        /// </summary>
        public void Remove_WithRecursion(T item)
        {
            var index = IndexOf(item);
            if (index is not int convertedIndex)
            {
                return;
            }

            Remove(convertedIndex);
            Remove(item);
        }

        private void RemoveNode(Node<T> node)
        {
            // if we are head node, and the next node of the node being removes is the tail, we do not set it.
            // If this happens, we have removed the last item from our DoublyLinkedList.
            if(node.PreviousNode.PreviousNode == null && node.NextNode.NextNode == null)
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
