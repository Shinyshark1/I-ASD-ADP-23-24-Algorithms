using Algorithms.JsonData;
using Algorithms.JsonData.Sorteren.Models;
using Newtonsoft.Json;
using CustomStack = Algorithms.Stack;

namespace Algorithms.Tests
{
    public class StackTests
    {
        [Fact]
        public void TheDataSets_Fit_InTheStack()
        {
            var sortingJson = JsonConstants.ReadDataSetSorting();

            var result1 = Record.Exception(() => new CustomStack.Stack<int>(JsonConvert.DeserializeObject<LijstAflopend2>(sortingJson).Content));
            var result2 = Record.Exception(() => new CustomStack.Stack<int>(JsonConvert.DeserializeObject<LijstOplopend2>(sortingJson).Content));
            var result3 = Record.Exception(() => new CustomStack.Stack<double>(JsonConvert.DeserializeObject<LijstFloat8001>(sortingJson).Content));
            var result4 = Record.Exception(() => new CustomStack.Stack<int>(JsonConvert.DeserializeObject<LijstGesorteerdAflopend3>(sortingJson).Content));
            var result5 = Record.Exception(() => new CustomStack.Stack<int>(JsonConvert.DeserializeObject<LijstGesorteerdOplopend3>(sortingJson).Content));
            var result6 = Record.Exception(() => new CustomStack.Stack<int>(JsonConvert.DeserializeObject<LijstHerhaald1000>(sortingJson).Content));
            var result7 = Record.Exception(() => new CustomStack.Stack<int>(JsonConvert.DeserializeObject<LijstLeeg0>(sortingJson).Content));
            var result8 = Record.Exception(() => new CustomStack.Stack<int?>(JsonConvert.DeserializeObject<LijstNull1>(sortingJson).Content));
            var result9 = Record.Exception(() => new CustomStack.Stack<int?>(JsonConvert.DeserializeObject<LijstNull3>(sortingJson).Content));
            var result10 = Record.Exception(() => new CustomStack.Stack<int>(JsonConvert.DeserializeObject<LijstOplopend10000>(sortingJson).Content));
            var result11 = Record.Exception(() => new CustomStack.Stack<int>(JsonConvert.DeserializeObject<LijstWillekeurig10000>(sortingJson).Content));
            var result12 = Record.Exception(() => new CustomStack.Stack<int>(JsonConvert.DeserializeObject<LijstWillekeurig3>(sortingJson).Content));

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
        public void Push_AddsItem_ToTheTop()
        {
            // Arrange
            var stack = new CustomStack.Stack<string>();

            // Act
            stack.Push("firstItem");
            stack.Push("secondItem");
            stack.Push("thirdItem");

            // Assert
            Assert.Equal("thirdItem", stack.Top());
        }

        [Fact]
        public void Pop_Removes_TheTopItem()
        {
            // Arrange
            var stack = new CustomStack.Stack<string>(new string[] { "apple", "pear" });

            // Act
            stack.Pop();

            // Assert
            Assert.Equal("apple", stack.Top());
        }

        [Fact]
        public void Top_Returns_TheTopItem()
        {
            // Arrange
            var stack = new CustomStack.Stack<string>(new string[] { "apple", "pear" });

            // Assert
            Assert.Equal("pear", stack.Top());
        }

        [Fact]
        public void Top_ReturnsDefault_WhenThereIsNoItem()
        {
            // Arrange
            var intStack = new CustomStack.Stack<int>();
            var stringStack = new CustomStack.Stack<string>();
            var objectStack = new CustomStack.Stack<object>();

            // Assert
            Assert.Equal(default, intStack.Top());
            Assert.Equal(default, stringStack.Top());
            Assert.Equal(default, objectStack.Top());
        }

        [Fact]
        public void IsEmpty_Returns_TheCorrectBoolean()
        {
            // Arrange
            var stack = new CustomStack.Stack<string>(new string[] { "apple" });

            // Assert
            Assert.False(stack.IsEmpty());

            stack.Pop();

            Assert.True(stack.IsEmpty());
        }

        [Fact]
        public void Size_Returns_TheCorrectSize()
        {
            // Arrange
            var stack = new CustomStack.Stack<string>(new string[] { "apple", "pear" });

            // Assert
            Assert.Equal(2, stack.Size());
        }
    }
}
