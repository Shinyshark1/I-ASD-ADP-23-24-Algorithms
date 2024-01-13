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
    }
}
