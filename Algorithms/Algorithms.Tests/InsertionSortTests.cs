using Algorithms.Shared;
using Algorithms.Tests.Shared;

namespace Algorithms.Tests
{
    public class InsertionSortTests
    {
        [Fact]
        public void InsertionSort_Sort_SortsTheArrays()
        {
            // Arrange
            int[] firstArray = DataSetHelper.CreateRandomDataSet(20);
            int[] secondArray = DataSetHelper.CreateRandomDataSet(20);
            int[] thirdArray = DataSetHelper.CreateRandomDataSet(20);

            // Act
            InsertionSort.InsertionSort.Sort(firstArray);
            InsertionSort.InsertionSort.Sort(secondArray);
            InsertionSort.InsertionSort.Sort(thirdArray);

            // Assert
            Assert.True(SortHelper.IsSorted(firstArray));
            Assert.True(SortHelper.IsSorted(secondArray));
            Assert.True(SortHelper.IsSorted(thirdArray));
        }
    }
}
