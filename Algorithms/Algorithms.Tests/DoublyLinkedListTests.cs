using Algorithms.DoublyLinkedList;

namespace Algorithms.Tests
{
    public class DoublyLinkedListTests
    {
        [Fact]
        public void Add_AddsAnItem_OnTheEnd()
        {
            // Arrange
            string[] data = new string[] { "apple" };

            // Act
            var linkedList = new DoublyLinkedList<string>(data);
            linkedList.Add("kaas");
            linkedList.Add("tosti");

            // Assert

            // The head knows what its next node is and the tail knows what its previous node is.
            Assert.Equal("apple", linkedList[0]);
            Assert.Equal("kaas", linkedList[1]);
            Assert.Equal("tosti", linkedList[2]);
        }

        [Fact]
        public void Get_RetrievesTheCorrect_NodeValue()
        {
            // Arrange
            string[] data = new string[] { "apple", "banana", "cherry" };
            
            // Act
            var linkedList = new DoublyLinkedList<string>(data);

            // Assert
            Assert.Equal("apple", linkedList[0]);
            Assert.Equal("banana", linkedList[1]);
            Assert.Equal("cherry", linkedList[2]);
        }

        [Fact]
        public void Get_ThrowsWhen_IndexIsOutOfBounds()
        {
            // Arrange
            string[] data = new string[] { "apple", "banana", "cherry" };

            // Act
            var linkedList = new DoublyLinkedList<string>(data);

            // Assert
            Assert.Throws<IndexOutOfRangeException>(() => linkedList[3]);
            Assert.Throws<IndexOutOfRangeException>(() => linkedList[-1]);
        }

        [Fact]
        public void Set_ReplacesValue_InLinkedList()
        {
            // Arrange
            string[] data = new string[] { "apple", "banana", "cherry" };

            // Act
            var linkedList = new DoublyLinkedList<string>(data);
            linkedList[0] = "kaas";
            linkedList[2] = "tosti";

            // Assert
            Assert.Equal("kaas", linkedList[0]);
            Assert.Equal("banana", linkedList[1]);
            Assert.Equal("tosti", linkedList[2]);
        }

        [Fact]
        public void IndexOf_Finds_TheIndex()
        {
            // Arrange
            string[] data = new string[] { "apple", "banana", "cherry" };

            // Act
            var linkedList = new DoublyLinkedList<string>(data);

            // Assert
            Assert.Equal(0, linkedList.IndexOf("apple"));
            Assert.Equal(1, linkedList.IndexOf("banana"));
            Assert.Equal(2, linkedList.IndexOf("cherry"));
            Assert.Null(linkedList.IndexOf("I do not exist."));
        }

        [Fact]
        public void Remove_WithIndex_RemovesTheItem()
        {
            // Arrange
            string[] data = new string[] { "apple", "banana", "cherry" };

            // Act
            var linkedList = new DoublyLinkedList<string>(data);
            linkedList.Remove(1);
            linkedList.Remove(1);

            // Assert
            // This should throw an IndexOutOfRangeException as the last index is 0.
            Assert.Throws<IndexOutOfRangeException>(() => linkedList[1]);
        }

        [Fact]
        public void Remove_WithItem_RemovesAllItems()
        {
            // Arrange
            string[] data = new string[] { "apple", "banana", "cherry", "apple", "pineapple", "apple" };

            // Act
            var linkedList = new DoublyLinkedList<string>(data);
            linkedList.Remove("apple");

            // Assert
            Assert.Equal(0, linkedList.IndexOf("banana"));
            Assert.Equal(1, linkedList.IndexOf("cherry"));
            Assert.Equal(2, linkedList.IndexOf("pineapple"));

            // This should throw an IndexOutOfRangeException as the last index is 2.
            Assert.Throws<IndexOutOfRangeException>(() => linkedList[3]);
        }
    }
}
