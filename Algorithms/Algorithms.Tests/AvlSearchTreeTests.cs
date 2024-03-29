﻿using Algorithms.AVLSearchTree;
using Algorithms.AVLSearchTree.Exceptions;
using Algorithms.JsonData;
using Algorithms.JsonData.Sorteren.Models;
using Newtonsoft.Json;

namespace Algorithms.Tests
{
    public class AvlSearchTreeTests
    {
        [Fact]
        public void TheDataSets_Fit_InTheAvlSearchTree()
        {
            var sortingJson = JsonConstants.ReadDataSetSorting();

            var result1 = Record.Exception(() => new AvlSearchTree(JsonConvert.DeserializeObject<LijstAflopend2>(sortingJson).Content));
            var result2 = Record.Exception(() => new AvlSearchTree(JsonConvert.DeserializeObject<LijstOplopend2>(sortingJson).Content)); ;
            var result3 = Record.Exception(() => new AvlSearchTree(JsonConvert.DeserializeObject<LijstGesorteerdAflopend3>(sortingJson).Content));
            var result4 = Record.Exception(() => new AvlSearchTree(JsonConvert.DeserializeObject<LijstGesorteerdOplopend3>(sortingJson).Content));
            var result5 = Record.Exception(() => new AvlSearchTree(JsonConvert.DeserializeObject<LijstHerhaald1000>(sortingJson).Content));
            var result6 = Record.Exception(() => new AvlSearchTree(JsonConvert.DeserializeObject<LijstLeeg0>(sortingJson).Content));
            var result7 = Record.Exception(() => new AvlSearchTree(JsonConvert.DeserializeObject<LijstOplopend10000>(sortingJson).Content));
            var result8 = Record.Exception(() => new AvlSearchTree(JsonConvert.DeserializeObject<LijstWillekeurig10000>(sortingJson).Content));
            var result9 = Record.Exception(() => new AvlSearchTree(JsonConvert.DeserializeObject<LijstWillekeurig3>(sortingJson).Content));

            Assert.Null(result1);
            Assert.Null(result2);
            Assert.Null(result3);
            Assert.IsType<DuplicateTreeNodeKeyException>(result4);
            Assert.IsType<DuplicateTreeNodeKeyException>(result5);
            Assert.Null(result6);
            Assert.Null(result7);
            Assert.Null(result8);
            Assert.Null(result9);
        }

        [Fact]
        public void LL_Scenario_RotatesCorrectly()
        {
            // Arrange
            var avlTree = new AvlSearchTree();

            // Act
            avlTree.Insert(50);
            avlTree.Insert(60);
            avlTree.Insert(40);
            avlTree.Insert(45);
            avlTree.Insert(30);

            // This insert causes an imbalance on the left side of the subtree on the left side of the tree.
            // This is an LL Scenario.
            // In our code, we will now RotateRight to fix this.
            avlTree.Insert(20);

            var root = avlTree.Find(40);

            // Assert - 40 became the new root.
            Assert.Null(root.Parent);
            Assert.Equal(40, root.Key);

            Assert.Equal(30, root.Left.Key);
            Assert.Equal(20, root.Left.Left.Key);

            Assert.Equal(50, root.Right.Key);
            Assert.Equal(45, root.Right.Left.Key);
            Assert.Equal(60, root.Right.Right.Key);
        }

        [Fact]
        public void RR_Scenario_RotatesCorrectly()
        {
            // Arrange
            var avlTree = new AvlSearchTree();

            // Act
            avlTree.Insert(50);
            avlTree.Insert(40);
            avlTree.Insert(60);
            avlTree.Insert(55);
            avlTree.Insert(70);

            // This insert causes an imbalance on the right side of the subtree on the right side of the tree.
            // This is an RR Scenario.
            // In our code, we will now RotateLeft to fix this.
            avlTree.Insert(80);

            var root = avlTree.Find(60);

            // Assert - 60 became the new root.
            Assert.Null(root.Parent);
            Assert.Equal(60, root.Key);

            Assert.Equal(50, root.Left.Key);
            Assert.Equal(55, root.Left.Right.Key);
            Assert.Equal(40, root.Left.Left.Key);

            Assert.Equal(70, root.Right.Key);
            Assert.Equal(80, root.Right.Right.Key);
        }

        [Fact]
        public void LR_Scenario_RotatesCorrectly()
        {
            // Arrange
            var avlTree = new AvlSearchTree();

            // Act
            avlTree.Insert(50);
            avlTree.Insert(60);
            avlTree.Insert(40);
            avlTree.Insert(30);

            // This insert causes an imbalance on the left side of the subtree on the right side of the tree.
            // This is an LR Scenario.
            avlTree.Insert(35);

            var root = avlTree.Find(50);

            // Assert - 50 became the new root.
            Assert.Null(root.Parent);
            Assert.Equal(50, root.Key);
            Assert.Equal(60, root.Right.Key);

            Assert.Equal(35, root.Left.Key);
            Assert.Equal(30, root.Left.Left.Key);
            Assert.Equal(40, root.Left.Right.Key);
        }

        [Fact]
        public void RL_Scenario_RotatesCorrectly()
        {
            // Arrange
            var avlTree = new AvlSearchTree();

            // Act
            avlTree.Insert(50);
            avlTree.Insert(40);
            avlTree.Insert(60);
            avlTree.Insert(55);
            avlTree.Insert(70);

            // This insert causes an imbalance on the right side of the subtree on the left side of the tree.
            // This is an RL Scenario.
            avlTree.Insert(56);

            var root = avlTree.Find(55);

            // Assert - 50 became the new root.
            Assert.Null(root.Parent);
            Assert.Equal(55, root.Key);
            Assert.Equal(50, root.Left.Key);
            Assert.Equal(40, root.Left.Left.Key);

            Assert.Equal(60, root.Right.Key);
            Assert.Equal(56, root.Right.Left.Key);
            Assert.Equal(70, root.Right.Right.Key);
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
            Assert.Equal(50, rootNode!.Key);
            Assert.Equal(25, node1!.Key);
            Assert.Equal(75, node2!.Key);
            Assert.Equal(40, node3!.Key);
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
            avlTree.Insert(98);
            avlTree.Insert(23);
            avlTree.Insert(7);
            avlTree.Insert(3);
            avlTree.Insert(80);
            avlTree.Insert(64);

            // Act
            var lowestNode = avlTree.FindMinimum();

            // Assert
            Assert.Equal(3, lowestNode.Key);
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
            avlTree.Insert(98);
            avlTree.Insert(23);
            avlTree.Insert(7);
            avlTree.Insert(3);
            avlTree.Insert(80);
            avlTree.Insert(64);

            // Act
            var highestNode = avlTree.FindMaximum();

            // Assert
            Assert.Equal(98, highestNode.Key);
        }


        [Fact]
        public void Remove_RemovesChildlessNode()
        {
            // Arrange
            var avlTree = new AvlSearchTree();
            avlTree.Insert(50);
            avlTree.Insert(40);

            // Act
            avlTree.Remove(40);

            // Assert
            Assert.Null(avlTree.Find(40));
            Assert.Null(avlTree.Find(50).Left);
        }

        [Fact]
        public void Remove_RemovesNode_WithOneChild()
        {
            // Arrange
            var avlTree = new AvlSearchTree();
            avlTree.Insert(50);
            avlTree.Insert(40);
            avlTree.Insert(30);
            avlTree.Insert(20);

            // Act
            avlTree.Remove(30);
            var root = avlTree.Find(40);

            // Assert
            Assert.Null(avlTree.Find(30));
            Assert.True(root.Left.Key == 20);
        }

        [Fact]
        public void Remove_RemovesNode_WithTwoChildren()
        {
            // Arrange
            var avlTree = new AvlSearchTree();
            avlTree.Insert(50);
            avlTree.Insert(40);
            avlTree.Insert(60);
            avlTree.Insert(30);
            avlTree.Insert(20);
            avlTree.Insert(10);
            avlTree.Insert(29);
            avlTree.Insert(28);

            // Act
            avlTree.Remove(20);
            var root = avlTree.Find(30);
            var newConnectingNode = root.Left;

            // Assert
            Assert.Null(avlTree.Find(20));
            Assert.Equal(28, newConnectingNode.Key);
            Assert.Equal(10, newConnectingNode.Left.Key);
            Assert.Equal(29, newConnectingNode.Right.Key);
            Assert.Equal(30, newConnectingNode.Parent.Key);
        }

        [Fact]
        public void Remove_RemovesRoot_WithNoChildren()
        {
            // Arrange
            var avlTree = new AvlSearchTree();
            avlTree.Insert(50);

            // Act
            avlTree.Remove(50);

            // Assert
            Assert.Null(avlTree.Find(50));
        }

        [Fact]
        public void Remove_RemovesRoot_WithOneChild()
        {
            // Arrange
            var avlTree = new AvlSearchTree();
            avlTree.Insert(50);
            avlTree.Insert(40);

            // Act
            avlTree.Remove(50);

            // Assert
            Assert.Null(avlTree.Find(50));
            Assert.Null(avlTree.Find(40).Parent);
            Assert.Equal(40, avlTree.Find(40).Key);
        }

        [Fact]
        public void Remove_RemovesRoot_WithTwoChildren()
        {
            // Arrange
            var avlTree = new AvlSearchTree();
            avlTree.Insert(50);
            avlTree.Insert(60);
            avlTree.Insert(40);
            avlTree.Insert(55);

            // Act
            avlTree.Remove(50);

            // Assert
            Assert.Null(avlTree.Find(50));
            Assert.Null(avlTree.Find(55).Parent);
            Assert.Equal(40, avlTree.Find(55).Left.Key);
            Assert.Equal(60, avlTree.Find(55).Right.Key);
        }
    }
}
