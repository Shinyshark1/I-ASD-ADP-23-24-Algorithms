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
        public void RotateRight_RotatesCorrectly()
        {
            // Arrange
            var avlTree = new AvlSearchTree();

            // Act
            avlTree.Insert(50);
            avlTree.Insert(60);
            avlTree.Insert(40);
            avlTree.Insert(45);
            avlTree.Insert(30);

            // This insert causes an imbalance on the left side of the tree.
            // This is an LL Scenario.
            // In our code, we will now RotateRight to fix this.
            avlTree.Insert(20);

            var root = avlTree.Find(40);

            // Assert - 40 became the new root.
            Assert.Null(root.Parent);
            Assert.Equal(40, root.Value);

            Assert.Equal(30, root.Left.Value);
            Assert.Equal(20, root.Left.Left.Value);

            Assert.Equal(50, root.Right.Value);
            Assert.Equal(45, root.Right.Left.Value);
            Assert.Equal(60, root.Right.Right.Value);
        }

        [Fact]
        public void RotateLeft_RotatesCorrectly()
        {
            // Arrange
            var avlTree = new AvlSearchTree();

            // Act
            avlTree.Insert(50);
            avlTree.Insert(40);
            avlTree.Insert(60);
            avlTree.Insert(55);
            avlTree.Insert(70);

            // This insert causes an imbalance on the right side of the tree.
            // This is an RR Scenario.
            // In our code, we will now RotateLeft to fix this.
            avlTree.Insert(80);

            var root = avlTree.Find(60);

            // Assert - 60 became the new root.
            Assert.Null(root.Parent);
            Assert.Equal(60, root.Value);

            Assert.Equal(50, root.Left.Value);
            Assert.Equal(55, root.Left.Right.Value);
            Assert.Equal(40, root.Left.Left.Value);

            Assert.Equal(70, root.Right.Value);
            Assert.Equal(80, root.Right.Right.Value);
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
        public void Nodes_HaveTheCorrectDepth_AfterBeingInserted()
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
            Assert.Equal(0, rootNode!.Depth);
            Assert.Equal(1, node1!.Depth);
            Assert.Equal(1, node2!.Depth);
            Assert.Equal(2, node3!.Depth);
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
            var avlTree = new AvlSearchTree();
            avlTree.Insert(50);
            avlTree.Insert(25);
            avlTree.Insert(75);
            avlTree.Insert(40);
            avlTree.Insert(90);
            avlTree.Insert(104);
            avlTree.Insert(23);
            avlTree.Insert(7);
            avlTree.Insert(3);
            avlTree.Insert(80);
            avlTree.Insert(64);

            // Act
            var lowestNode = avlTree.FindMinimum();

            // Assert
            Assert.Equal(3, lowestNode.Value);
        }

        [Fact]
        public void FindMaximum_FindsTheHighestNode()
        {
            // Arrange
            var avlTree = new AvlSearchTree();
            avlTree.Insert(50);
            avlTree.Insert(25);
            avlTree.Insert(75);
            avlTree.Insert(40);
            avlTree.Insert(90);
            avlTree.Insert(104);
            avlTree.Insert(23);
            avlTree.Insert(7);
            avlTree.Insert(3);
            avlTree.Insert(80);
            avlTree.Insert(64);

            // Act
            var highestNode = avlTree.FindMaximum();

            // Assert
            Assert.Equal(104, highestNode.Value);
        }
    }
}
