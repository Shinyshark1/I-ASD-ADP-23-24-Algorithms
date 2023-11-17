namespace Algorithms.DoublyLinkedList
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        public Node<T> Head { get; init; } = new();
        public Node<T> Tail { get; init; } = new();

        public DoublyLinkedList(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Add(array[i]);
            }
        }

        public T this[int index] 
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException(); 
        }

        // Done
        public void Add(T item)
        {
            var newNode = new Node<T> { Value = item };

            // Grab the tail node.
            var previous = Tail.PreviousNode;

            // If the previous doesn't exist, we have a head and a tail.
            // the previous would be the head.
            previous ??= Head;

            // We set the new node as the next node for our previous node.
            previous.NextNode = newNode;

            // Because we insert on the end, the tail becomes the next node for our new node.
            newNode.NextNode = Tail;

            // Now we have to configure the connection backwards; the tail gets the new node as the previous node.
            Tail.PreviousNode = newNode;

            // The node that was configured as the next node for the previous node, should now have the new node as the previous node.
            newNode.PreviousNode = previous;
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Remove(int index)
        {
            throw new NotImplementedException();
        }

        public void Remove(T item)
        {
            throw new NotImplementedException();
        }
    }
}
