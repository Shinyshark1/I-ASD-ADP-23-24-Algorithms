using Algorithms.DynamicArrays;
using Algorithms.JsonData.Sorteren.Models;
using Algorithms.JsonData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.BinarySearch;

namespace Algorithms.Tests
{
    public class BinarySearchTests
    {
        [Fact]
        public void TheDataSets_Fit_InTheBinarySearch()
        {
            var sortingJson = JsonConstants.ReadDataSetSorting();

            var result1 = Record.Exception(() => new BinarySearch<int>(JsonConvert.DeserializeObject<LijstAflopend2>(sortingJson).Content));
            var result2 = Record.Exception(() => new BinarySearch<int>(JsonConvert.DeserializeObject<LijstOplopend2>(sortingJson).Content));
            var result3 = Record.Exception(() => new BinarySearch<double>(JsonConvert.DeserializeObject<LijstFloat8001>(sortingJson).Content));
            var result4 = Record.Exception(() => new BinarySearch<int>(JsonConvert.DeserializeObject<LijstGesorteerdAflopend3>(sortingJson).Content));
            var result5 = Record.Exception(() => new BinarySearch<int>(JsonConvert.DeserializeObject<LijstGesorteerdOplopend3>(sortingJson).Content));
            var result6 = Record.Exception(() => new BinarySearch<int>(JsonConvert.DeserializeObject<LijstHerhaald1000>(sortingJson).Content));
            var result7 = Record.Exception(() => new BinarySearch<int>(JsonConvert.DeserializeObject<LijstLeeg0>(sortingJson).Content));
            var result10 = Record.Exception(() => new BinarySearch<int>(JsonConvert.DeserializeObject<LijstOplopend10000>(sortingJson).Content));
            var result11 = Record.Exception(() => new BinarySearch<int>(JsonConvert.DeserializeObject<LijstWillekeurig10000>(sortingJson).Content));
            var result12 = Record.Exception(() => new BinarySearch<int>(JsonConvert.DeserializeObject<LijstWillekeurig3>(sortingJson).Content));

            Assert.Null(result1);
            Assert.Null(result2);
            Assert.Null(result3);
            Assert.Null(result4);
            Assert.Null(result5);
            Assert.Null(result6);
            Assert.Null(result7);
            Assert.Null(result10);
            Assert.Null(result11);
            Assert.Null(result12);
        }
    }
}
