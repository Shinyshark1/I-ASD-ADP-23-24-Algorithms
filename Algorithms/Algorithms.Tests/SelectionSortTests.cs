using Algorithms.Shared;
using Algorithms.Tests.Shared;

namespace Algorithms.Tests
{
    public class SelectionSortTests
    {
        [Fact]
        public void SelectionSort_Sort_SortsTheArrays()
        {
            // Arrange
            int[] firstArray = DataSetHelper.CreateRandomDataSet(20);
            int[] secondArray = DataSetHelper.CreateRandomDataSet(20);
            int[] thirdArray = DataSetHelper.CreateRandomDataSet(20);

            // Act
            SelectionSort.SelectionSort.Sort(firstArray);
            SelectionSort.SelectionSort.Sort(secondArray);
            SelectionSort.SelectionSort.Sort(thirdArray);

            // Assert
            Assert.True(SortHelper.IsSorted(firstArray));
            Assert.True(SortHelper.IsSorted(secondArray));
            Assert.True(SortHelper.IsSorted(thirdArray));
        }
    }
}
