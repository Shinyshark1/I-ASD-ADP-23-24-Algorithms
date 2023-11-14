using Algorithms.DynamicArrays;

namespace Algorithms.Tests;

public class DynamicArrayTests
{
    [Fact]
    public void Add_AddsAnItem()
    {
        // Arrange
        var dynamicArray = new DynamicArray<int>(new int[] { 1, 2, 3 });

        // Act
        dynamicArray.Add(999);
        dynamicArray.Add(1337);

        // Assert
        Assert.Equal(999, dynamicArray[3]);
        Assert.Equal(1337, dynamicArray[4]);
    }

    [Fact]
    public void Insert_AddsAnItem_OnProvidedIndex()
    {
        // Arrange
        var dynamicArray = new DynamicArray<string>(new string[] { "apple", "pear", "apple", "orange" });

        // Act
        dynamicArray.Insert(2, "bad apple");

        // Assert
        Assert.Equal("bad apple", dynamicArray[2]);
    }

    [Fact]
    public void Insert_OnNegativeIndex_Throws()
    {
        // Arrange
        var dynamicArray = new DynamicArray<int>(new int[] { 1, 2, 3 });

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => dynamicArray.Insert(-100, 500));
    }

    [Fact]
    public void Remove_RemovesAnItem()
    {
        // Arrange
        var dynamicArray = new DynamicArray<string>(new string[] { "apple", "pear", "apple", "orange" });

        // Act
        dynamicArray.Remove("apple");

        // Assert
        Assert.Equal("pear", dynamicArray[0]);
        Assert.Equal("orange", dynamicArray[1]);
    }

    [Fact]
    public void RemoveAtIndex_RemovesAnItem_OnProvidedIndex()
    {
        // Arrange
        var dynamicArray = new DynamicArray<string>(new string[] { "apple", "pear", "apple", "orange" });

        // Act
        // Because we only remove an index, we should still have three items remaining.
        dynamicArray.RemoveAtIndex(2);

        // Assert
        Assert.Equal(3, dynamicArray.Count);
        Assert.Equal("apple", dynamicArray[0]);
    }

    [Fact]
    public void Count_ReturnsTheCorrectCount_AfterAdd()
    {
        // Arrange
        var dynamicArray = new DynamicArray<int>(new int[] { 1, 2, 3 });

        // Act
        // By adding an item, the array has doubled in size. The size of the array is now 6, but we should want to see 4 as an actual count.
        dynamicArray.Add(4);

        // Assert
        Assert.Equal(4, dynamicArray.Count);
    }

    [Fact]
    public void Count_ReturnsCorrectCount_AfterRemove()
    {
        // Arrange
        var dynamicArray = new DynamicArray<string>(new string[] { "apple", "pear", "apple", "orange" });

        // Act
        // Because remove deletes all equal instances, we have removed 2 out of 4 items.
        // We are thus left with 2 items.
        dynamicArray.Remove("apple");

        // Assert
        Assert.Equal(2, dynamicArray.Count);
    }

    [Fact]
    public void Clear_ClearsTheArray()
    {
        // Arrange
        var dynamicArray = new DynamicArray<int>(new int[] { 1, 2, 3 });

        // Act & Assert
        Assert.Equal(3, dynamicArray.Count);
        dynamicArray.Clear();
        Assert.Equal(0, dynamicArray.Count);
    }

    [Fact]
    public void Contains_FindsTheItem_InTheArray()
    {
        // Arrange
        var dynamicArray = new DynamicArray<string>(new string[] { "apple", "pear", "apple", "orange" });

        // Act
        var result = dynamicArray.Contains("pear");

        // Assert
        Assert.True(result);
    }
}
