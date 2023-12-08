using Algorithms.JsonData;
using Algorithms.JsonData.Sorteren.Models;
using Algorithms.Shared;
using Algorithms.Tests.Shared;
using Newtonsoft.Json;

namespace Algorithms.Tests
{
    public class MergeSortTests
    {
        [Fact]
        public void MergeSort_CanSort_IntArrays()
        {
            var sortingJson = JsonConstants.ReadDataSetSorting();

            // Arrange & Act
            var firstArray = MergeSort.MergeSort.Sort(JsonConvert.DeserializeObject<LijstAflopend2>(sortingJson).Content);
            var secondArray = MergeSort.MergeSort.Sort(JsonConvert.DeserializeObject<LijstOplopend2>(sortingJson).Content);
            var fourthArray = MergeSort.MergeSort.Sort(JsonConvert.DeserializeObject<LijstGesorteerdAflopend3>(sortingJson).Content);
            var fifthArray = MergeSort.MergeSort.Sort(JsonConvert.DeserializeObject<LijstGesorteerdOplopend3>(sortingJson).Content);
            var sixthArray = MergeSort.MergeSort.Sort(JsonConvert.DeserializeObject<LijstHerhaald1000>(sortingJson).Content);
            var seventhArray = MergeSort.MergeSort.Sort(JsonConvert.DeserializeObject<LijstLeeg0>(sortingJson).Content);
            var tenthArray = MergeSort.MergeSort.Sort(JsonConvert.DeserializeObject<LijstOplopend10000>(sortingJson).Content);
            var eleventhArray = MergeSort.MergeSort.Sort(JsonConvert.DeserializeObject<LijstWillekeurig10000>(sortingJson).Content);
            var twelfthArray = MergeSort.MergeSort.Sort(JsonConvert.DeserializeObject<LijstWillekeurig3>(sortingJson).Content);

            //var thirdArray = MergeSort.MergeSort.Sort(JsonConvert.DeserializeObject<LijstFloat8001>(sortingJson).Content);    | double[]
            //var eighthArray = MergeSort.MergeSort.Sort(JsonConvert.DeserializeObject<LijstNull1>(sortingJson).Content);       | int?[]
            //var ninthArray = MergeSort.MergeSort.Sort(JsonConvert.DeserializeObject<LijstNull3>(sortingJson).Content);        | int?[]

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
        public void MergeSort_Sort_SortsTheArrays()
        {
            // Arrange
            int[] firstArray = DataSetHelper.CreateRandomDataSet(20);
            int[] secondArray = DataSetHelper.CreateRandomDataSet(20);
            int[] thirdArray = DataSetHelper.CreateRandomDataSet(20);

            // Act
            MergeSort.MergeSort.Sort(firstArray);
            MergeSort.MergeSort.Sort(secondArray);
            MergeSort.MergeSort.Sort(thirdArray);

            // Assert
            Assert.True(SortHelper.IsSorted(firstArray));
            Assert.True(SortHelper.IsSorted(secondArray));
            Assert.True(SortHelper.IsSorted(thirdArray));
        }
    }
}
