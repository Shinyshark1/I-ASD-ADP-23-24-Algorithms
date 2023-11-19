using Algorithms.DynamicArrays;
using Algorithms.JsonData;
using Algorithms.JsonData.Sorteren.Models;
using Newtonsoft.Json;

namespace Algorithms.Tests;

/// <summary>
/// You are meant to feed in the data here and see how long it will take.
/// Your unit tests are more a measure of performance rather than a test of functionality.
/// 
/// You need to be able to reason about the operations. Understand the impact of your change. Know what is happening.
/// Calculate the times for alternatives. You should have 1-2 tests per method(?) or implementation(?).
/// </summary>
public class DynamicArrayTests
{
    [Fact]
    public void TheDataSets_Fit_InTheDynamicArray()
    {
        var sortingJson = JsonConstants.ReadDataSetSorting();

        var result1 = Record.Exception(() => new DynamicArray<int>(JsonConvert.DeserializeObject<LijstAflopend2>(sortingJson).Content));
        var result2 = Record.Exception(() => new DynamicArray<int>(JsonConvert.DeserializeObject<LijstOplopend2>(sortingJson).Content));
        var result3 = Record.Exception(() => new DynamicArray<double>(JsonConvert.DeserializeObject<LijstFloat8001>(sortingJson).Content));
        var result4 = Record.Exception(() => new DynamicArray<int>(JsonConvert.DeserializeObject<LijstGesorteerdAflopend3>(sortingJson).Content));
        var result5 = Record.Exception(() => new DynamicArray<int>(JsonConvert.DeserializeObject<LijstGesorteerdOplopend3>(sortingJson).Content));
        var result6 = Record.Exception(() => new DynamicArray<int>(JsonConvert.DeserializeObject<LijstHerhaald1000>(sortingJson).Content));
        var result7 = Record.Exception(() => new DynamicArray<object>(JsonConvert.DeserializeObject<LijstLeeg0>(sortingJson).Content));
        var result8 = Record.Exception(() => new DynamicArray<object>(JsonConvert.DeserializeObject<LijstNull1>(sortingJson).Content));
        var result9 = Record.Exception(() => new DynamicArray<int?>(JsonConvert.DeserializeObject<LijstNull3>(sortingJson).Content));
        var result10 = Record.Exception(() => new DynamicArray<int>(JsonConvert.DeserializeObject<LijstOplopend10000>(sortingJson).Content));
        var result11 = Record.Exception(() => new DynamicArray<int>(JsonConvert.DeserializeObject<LijstWillekeurig10000>(sortingJson).Content));
        var result12 = Record.Exception(() => new DynamicArray<int>(JsonConvert.DeserializeObject<LijstWillekeurig3>(sortingJson).Content));

        Assert.Null(result1);
        Assert.Null(result2);
        Assert.Null(result3);
        Assert.Null(result4);
        Assert.Null(result5);
        Assert.Null(result6);
        Assert.Null(result7);
        Assert.Null(result8);
        Assert.Null(result9);
        Assert.Null(result10);
        Assert.Null(result11);
        Assert.Null(result12);
    }

    [Fact]
    public void Remove_Halves_WhenPossible()
    {
        var dynamicArray = new DynamicArray<int>(JsonConvert.DeserializeObject<LijstOplopend10000>(JsonConstants.ReadDataSetSorting()).Content);

        // We keep track of our previous length as the Remove() method changes it before we need it.
        int previousLength = dynamicArray.ArrayLength;
        int amountOfItems = dynamicArray.Count;

        for (int i = 0; i < amountOfItems; i++)
        {
            dynamicArray.Remove(dynamicArray[^1]);

            // We halve when possible.
            if (dynamicArray.Count == previousLength / 2)
            {
                Assert.Equal(previousLength / 2, dynamicArray.ArrayLength);
                previousLength = dynamicArray.ArrayLength;
            }
        }
    }

    [Fact]
    public void RemoveWithShrink_Shrinks_WhenPossible()
    {
        var dynamicArray = new DynamicArray<int>(JsonConvert.DeserializeObject<LijstOplopend10000>(JsonConstants.ReadDataSetSorting()).Content);

        // We keep track of our previous length as the Remove() method changes it before we need it.
        int previousLength = dynamicArray.ArrayLength;
        int amountOfItems = dynamicArray.Count;

        for (int i = 0; i < amountOfItems; i++)
        {
            dynamicArray.Remove_WithShrinkByOne(dynamicArray[^1]);

            // We always shrink if possible, so we'd go from 10, 9, 8, etc...
            Assert.Equal(previousLength - 1, dynamicArray.ArrayLength);
            previousLength = dynamicArray.ArrayLength;
        }
    }

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
