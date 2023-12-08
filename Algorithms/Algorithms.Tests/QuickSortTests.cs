using Algorithms.JsonData;
using Algorithms.JsonData.Sorteren.Models;
using Algorithms.Shared;
using Algorithms.Tests.Shared;
using Newtonsoft.Json;

namespace Algorithms.Tests
{
    public class QuickSortTests
    {
        [Fact]
        public void QuickSort_CanSort_IntArrays()
        {
            var sortingJson = JsonConstants.ReadDataSetSorting();

            // Arrange & Act
            var firstArray = QuickSort.QuickSort.Sort(JsonConvert.DeserializeObject<LijstAflopend2>(sortingJson).Content);
            var secondArray = QuickSort.QuickSort.Sort(JsonConvert.DeserializeObject<LijstOplopend2>(sortingJson).Content);
            var fourthArray = QuickSort.QuickSort.Sort(JsonConvert.DeserializeObject<LijstGesorteerdAflopend3>(sortingJson).Content);
            var fifthArray = QuickSort.QuickSort.Sort(JsonConvert.DeserializeObject<LijstGesorteerdOplopend3>(sortingJson).Content);
            var sixthArray = QuickSort.QuickSort.Sort(JsonConvert.DeserializeObject<LijstHerhaald1000>(sortingJson).Content);
            var seventhArray = QuickSort.QuickSort.Sort(JsonConvert.DeserializeObject<LijstLeeg0>(sortingJson).Content);
            var tenthArray = QuickSort.QuickSort.Sort(JsonConvert.DeserializeObject<LijstOplopend10000>(sortingJson).Content);
            var eleventhArray = QuickSort.QuickSort.Sort(JsonConvert.DeserializeObject<LijstWillekeurig10000>(sortingJson).Content);
            var twelfthArray = QuickSort.QuickSort.Sort(JsonConvert.DeserializeObject<LijstWillekeurig3>(sortingJson).Content);

            //var thirdArray = QuickSort.QuickSort.Sort(JsonConvert.DeserializeObject<LijstFloat8001>(sortingJson).Content);    | double[]
            //var eighthArray = QuickSort.QuickSort.Sort(JsonConvert.DeserializeObject<LijstNull1>(sortingJson).Content);       | int?[]
            //var ninthArray = QuickSort.QuickSort.Sort(JsonConvert.DeserializeObject<LijstNull3>(sortingJson).Content);        | int?[]

            // Assert
            Assert.True(SortHelper.IsSorted(firstArray));
            Assert.True(SortHelper.IsSorted(secondArray));
            Assert.True(SortHelper.IsSorted(fourthArray));
            Assert.True(SortHelper.IsSorted(fifthArray));
            Assert.True(SortHelper.IsSorted(sixthArray));
            Assert.True(SortHelper.IsSorted(seventhArray));
            Assert.True(SortHelper.IsSorted(tenthArray));
            Assert.True(SortHelper.IsSorted(eleventhArray));
            Assert.True(SortHelper.IsSorted(twelfthArray));
        }

        [Fact]
        public void QuickSort_Sort_SortsTheArrays()
        {
            // Arrange
            int[] firstArray = DataSetHelper.CreateRandomDataSet(20);
            int[] secondArray = DataSetHelper.CreateRandomDataSet(20);
            int[] thirdArray = DataSetHelper.CreateRandomDataSet(20);

            //Act
            QuickSort.QuickSort.Sort(firstArray);
            QuickSort.QuickSort.Sort(secondArray);
            QuickSort.QuickSort.Sort(thirdArray);

            //Assert
            Assert.True(SortHelper.IsSorted(firstArray));
            Assert.True(SortHelper.IsSorted(secondArray));
            Assert.True(SortHelper.IsSorted(thirdArray));
        }
    }
}
