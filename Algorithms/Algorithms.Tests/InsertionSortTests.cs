using Algorithms.JsonData;
using Algorithms.JsonData.Sorteren.Models;
using Algorithms.Shared;
using Algorithms.Tests.Shared;
using Newtonsoft.Json;

namespace Algorithms.Tests
{
    public class InsertionSortTests
    {
        [Fact]
        public void InsertionSort_CanSort_IntArrays()
        {
            var sortingJson = JsonConstants.ReadDataSetSorting();

            // Arrange & Act
            var firstArray = InsertionSort.InsertionSort.Sort(JsonConvert.DeserializeObject<LijstAflopend2>(sortingJson).Content);
            var secondArray = InsertionSort.InsertionSort.Sort(JsonConvert.DeserializeObject<LijstOplopend2>(sortingJson).Content);
            var fourthArray = InsertionSort.InsertionSort.Sort(JsonConvert.DeserializeObject<LijstGesorteerdAflopend3>(sortingJson).Content);
            var fifthArray = InsertionSort.InsertionSort.Sort(JsonConvert.DeserializeObject<LijstGesorteerdOplopend3>(sortingJson).Content);
            var sixthArray = InsertionSort.InsertionSort.Sort(JsonConvert.DeserializeObject<LijstHerhaald1000>(sortingJson).Content);
            var seventhArray = InsertionSort.InsertionSort.Sort(JsonConvert.DeserializeObject<LijstLeeg0>(sortingJson).Content);
            var tenthArray = InsertionSort.InsertionSort.Sort(JsonConvert.DeserializeObject<LijstOplopend10000>(sortingJson).Content);
            var eleventhArray = InsertionSort.InsertionSort.Sort(JsonConvert.DeserializeObject<LijstWillekeurig10000>(sortingJson).Content);
            var twelfthArray = InsertionSort.InsertionSort.Sort(JsonConvert.DeserializeObject<LijstWillekeurig3>(sortingJson).Content);

            //var thirdArray = InsertionSort.InsertionSort.Sort(JsonConvert.DeserializeObject<LijstFloat8001>(sortingJson).Content);    | double[]
            //var eighthArray = InsertionSort.InsertionSort.Sort(JsonConvert.DeserializeObject<LijstNull1>(sortingJson).Content);       | int?[]
            //var ninthArray = InsertionSort.InsertionSort.Sort(JsonConvert.DeserializeObject<LijstNull3>(sortingJson).Content);        | int?[]

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
