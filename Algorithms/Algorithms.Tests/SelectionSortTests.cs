﻿using Algorithms.JsonData;
using Algorithms.JsonData.Sorteren.Models;
using Algorithms.Shared;
using Algorithms.Tests.Shared;
using Newtonsoft.Json;

namespace Algorithms.Tests
{
    public class SelectionSortTests
    {
        [Fact]
        public void SelectionSort_CanSort_IntArrays()
        {
            var sortingJson = JsonConstants.ReadDataSetSorting();

            // Arrange & Act
            var firstArray = SelectionSort.SelectionSort.Sort(JsonConvert.DeserializeObject<LijstAflopend2>(sortingJson).Content);
            var secondArray = SelectionSort.SelectionSort.Sort(JsonConvert.DeserializeObject<LijstOplopend2>(sortingJson).Content);
            var fourthArray = SelectionSort.SelectionSort.Sort(JsonConvert.DeserializeObject<LijstGesorteerdAflopend3>(sortingJson).Content);
            var fifthArray = SelectionSort.SelectionSort.Sort(JsonConvert.DeserializeObject<LijstGesorteerdOplopend3>(sortingJson).Content);
            var sixthArray = SelectionSort.SelectionSort.Sort(JsonConvert.DeserializeObject<LijstHerhaald1000>(sortingJson).Content);
            var seventhArray = SelectionSort.SelectionSort.Sort(JsonConvert.DeserializeObject<LijstLeeg0>(sortingJson).Content);
            var tenthArray = SelectionSort.SelectionSort.Sort(JsonConvert.DeserializeObject<LijstOplopend10000>(sortingJson).Content);
            var eleventhArray = SelectionSort.SelectionSort.Sort(JsonConvert.DeserializeObject<LijstWillekeurig10000>(sortingJson).Content);
            var twelfthArray = SelectionSort.SelectionSort.Sort(JsonConvert.DeserializeObject<LijstWillekeurig3>(sortingJson).Content);

            //var thirdArray = SelectionSort.SelectionSort.Sort(JsonConvert.DeserializeObject<LijstFloat8001>(sortingJson).Content);    | double[]
            //var eighthArray = SelectionSort.SelectionSort.Sort(JsonConvert.DeserializeObject<LijstNull1>(sortingJson).Content);       | int?[]
            //var ninthArray = SelectionSort.SelectionSort.Sort(JsonConvert.DeserializeObject<LijstNull3>(sortingJson).Content);        | int?[]

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
