using Algorithms.AVLSearchTree;
using Algorithms.AVLSearchTree.Exceptions;

namespace Algorithms.Tests
{
    public class AvlSearchTreeTests
    {
        [Fact]
        public void TheDataSets_Fit_InTheAvlSearchTree()
        {
        }

        [Fact]
        public void Insert_Throws_OnDuplicateValue()
        {
            // Arrange
            var avlTree = new AvlSearchTree();

            // Act
            avlTree.Insert(50);
            var exception = Record.Exception(() => avlTree.Insert(50));

            // Assert
            Assert.IsType<DuplicateTreeNodeKeyException>(exception);
        }

        [Fact]
        public void Insert_SetsTheCorrectHeight()
        {
            // Arrange
            var avlTree = new AvlSearchTree();

            // Act
            avlTree.Insert(50);
            avlTree.Insert(25);
            avlTree.Insert(75);
            avlTree.Insert(40);

            var rootNode = avlTree.Find(50);
            var node1 = avlTree.Find(25);
            var node2 = avlTree.Find(75);
            var node3 = avlTree.Find(40);

            // Assert
            Assert.Equal(1, rootNode!.Height);
            Assert.Equal(2, node1!.Height);
            Assert.Equal(2, node2!.Height);
            Assert.Equal(3, node3!.Height);
        }

        [Fact]
        public void Find_FindsTheCorrectNode()
        {
            // Arrange
            var avlTree = new AvlSearchTree();

            // Act
            avlTree.Insert(50);
            avlTree.Insert(25);
            avlTree.Insert(75);
            avlTree.Insert(40);

            var rootNode = avlTree.Find(50);
            var node1 = avlTree.Find(25);
            var node2 = avlTree.Find(75);
            var node3 = avlTree.Find(40);
            var nullNode = avlTree.Find(10);

            // Assert
            Assert.Equal(50, rootNode!.Value);
            Assert.Equal(25, node1!.Value);
            Assert.Equal(75, node2!.Value);
            Assert.Equal(40, node3!.Value);
            Assert.Null(nullNode);
        }

        [Fact]
        public void FindMinimum_FindsTheLowestNode()
        {
            // Arrange
            var AvlTree = new AvlSearchTree();
            AvlTree.Insert(50);
            AvlTree.Insert(25);
            AvlTree.Insert(75);
            AvlTree.Insert(40);
            AvlTree.Insert(90);
            AvlTree.Insert(104);
            AvlTree.Insert(23);
            AvlTree.Insert(7);
            AvlTree.Insert(3);
            AvlTree.Insert(80);
            AvlTree.Insert(64);

            // Act
            var lowestNode = AvlTree.FindMinimum();

            // Assert
            Assert.Equal(3, lowestNode.Value);
        }

        [Fact]
        public void FindMaximum_FindsTheHighestNode()
        {
            // Arrange
            var AvlTree = new AvlSearchTree();
            AvlTree.Insert(50);
            AvlTree.Insert(25);
            AvlTree.Insert(75);
            AvlTree.Insert(40);
            AvlTree.Insert(90);
            AvlTree.Insert(104);
            AvlTree.Insert(23);
            AvlTree.Insert(7);
            AvlTree.Insert(3);
            AvlTree.Insert(80);
            AvlTree.Insert(64);

            // Act
            var highestNode = AvlTree.FindMaximum();

            // Assert
            Assert.Equal(104, highestNode.Value);
        }
    }
}
