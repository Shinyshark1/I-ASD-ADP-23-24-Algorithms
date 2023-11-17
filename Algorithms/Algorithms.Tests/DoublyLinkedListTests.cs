using Algorithms.DoublyLinkedList;

namespace Algorithms.Tests
{
    public class DoublyLinkedListTests
    {
        [Fact]
        public void Add_OnEmptyList_AddsANewItem_OnHeadAndTail()
        {
            // Arrange
            string[] data = new string[] { "apple" };

            // Act
            var linkedList = new DoublyLinkedList<string>(data);

            // Assert

            // The head knows what its next node is and the tail knows what its previous node is.
            Assert.Equal("apple", linkedList.Head.NextNode.Value);
            Assert.Equal("apple", linkedList.Tail.PreviousNode.Value);

            // The head has no previous node and the tail has no next node.
            Assert.Null(linkedList.Head.PreviousNode);
            Assert.Null(linkedList.Tail.NextNode);
        }
    }
}
