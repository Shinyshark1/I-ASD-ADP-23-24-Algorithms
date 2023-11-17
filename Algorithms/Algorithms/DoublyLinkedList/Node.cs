namespace Algorithms.DoublyLinkedList
{
    public class Node<T>
    {
        public T Value { get; set; }

        public Node<T> NextNode { get; set; }
        
        public Node<T> PreviousNode { get; set; }
    }
}
