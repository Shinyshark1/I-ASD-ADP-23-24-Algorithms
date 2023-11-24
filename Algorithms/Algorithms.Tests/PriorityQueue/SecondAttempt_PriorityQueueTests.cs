using Algorithms.JsonData;
using Algorithms.JsonData.Sorteren.Models;
using Algorithms.PriorityQueue.SecondAttempt;
using Newtonsoft.Json;

namespace Algorithms.Tests.PriorityQueue
{
    public class SecondAttempt_PriorityQueueTests
    {
        [Fact]
        public void TheDataSets_Fit_InTheDynamicArray()
        {
            var sortingJson = JsonConstants.ReadDataSetSorting();

            var result1 = Record.Exception(() => new GenericPriorityQueue<int, int>(JsonConvert.DeserializeObject<LijstAflopend2>(sortingJson).Content));
            var result2 = Record.Exception(() => new GenericPriorityQueue<int, int>(JsonConvert.DeserializeObject<LijstOplopend2>(sortingJson).Content));
            var result3 = Record.Exception(() => new GenericPriorityQueue<double, double>(JsonConvert.DeserializeObject<LijstFloat8001>(sortingJson).Content));
            var result4 = Record.Exception(() => new GenericPriorityQueue<int, int>(JsonConvert.DeserializeObject<LijstGesorteerdAflopend3>(sortingJson).Content));
            var result5 = Record.Exception(() => new GenericPriorityQueue<int, int>(JsonConvert.DeserializeObject<LijstGesorteerdOplopend3>(sortingJson).Content));
            var result6 = Record.Exception(() => new GenericPriorityQueue<int, int>(JsonConvert.DeserializeObject<LijstHerhaald1000>(sortingJson).Content));
            var result7 = Record.Exception(() => new GenericPriorityQueue<int, int>(JsonConvert.DeserializeObject<LijstLeeg0>(sortingJson).Content));
            var result10 = Record.Exception(() => new GenericPriorityQueue<int, int>(JsonConvert.DeserializeObject<LijstOplopend10000>(sortingJson).Content));
            var result11 = Record.Exception(() => new GenericPriorityQueue<int, int>(JsonConvert.DeserializeObject<LijstWillekeurig10000>(sortingJson).Content));
            var result12 = Record.Exception(() => new GenericPriorityQueue<int, int>(JsonConvert.DeserializeObject<LijstWillekeurig3>(sortingJson).Content));

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

            // It is not possible to convert this data to a GenericPriorityQueue<int?, int?> because nullable types can not satisfy the interface constraints.
            // It does not make sense as well to make a priority queue that would hold null values in this way; what priority would a null value have?
            // In order to determine a priority, a value must be compared. Null values can not be compared with non-null values.

            // var result8 = Record.Exception(() => new GenericPriorityQueue<int?, int?>(JsonConvert.DeserializeObject<LijstNull1>(sortingJson).Content));
            // var result9 = Record.Exception(() => new GenericPriorityQueue<int?, int?>(JsonConvert.DeserializeObject<LijstNull3>(sortingJson).Content));
        }

        [Fact]
        public void Insert_AddsItem_ToTheQueue()
        {
            // Arrange
            var queue = new GenericPriorityQueue<int, string>();

            // Act
            queue.Insert(10, "King");
            queue.Insert(10, "Queen");
            queue.Insert(9, "Princess");
            queue.Insert(9, "Prince");
            queue.Insert(8, "Courtier");
            queue.Insert(7, "Court Jester");
            queue.Insert(6, "Royal Cook");
            queue.Insert(8, "Poison Tester");
            queue.Insert(7, "Advisor");
            queue.Insert(4, "Stablekeep");

            // Assert
            Assert.Equal(10, queue.Count);
        }

        [Fact]
        public void FindNext_Finds_TheHighestAvailablePriority()
        {
            // Arrange
            var queue = new GenericPriorityQueue<int, string>();

            // Act
            queue.Insert(9, "Prince");
            queue.Insert(8, "Courtier");
            queue.Insert(10, "King");
            queue.Insert(9, "Princess");
            queue.Insert(4, "Stablekeep");
            queue.Insert(7, "Advisor");
            queue.Insert(8, "Poison Tester");
            queue.Insert(10, "Queen");
            queue.Insert(6, "Royal Cook");
            queue.Insert(7, "Court Jester");

            // Assert
            // Note that the first match in the list is returned. In this scenario, the king is found before the queen.
            Assert.Equal("King", queue.FindNextValue());
        }

        [Fact]
        public void DeleteNext_Removes_TheHighestAvailablePriorityItem()
        {
            // Arrange
            var queue = new GenericPriorityQueue<int, string>();

            // Act
            queue.Insert(9, "Prince");
            queue.Insert(8, "Courtier");
            queue.Insert(10, "King");
            queue.Insert(9, "Princess");
            queue.Insert(4, "Stablekeep");
            queue.Insert(7, "Advisor");
            queue.Insert(8, "Poison Tester");
            queue.Insert(10, "Queen");
            queue.Insert(6, "Royal Cook");
            queue.Insert(7, "Court Jester");

            queue.DeleteNext();

            // Assert
            // Note that the first match in the list is returned. In this scenario, the king is no longer present. The queen is found.
            Assert.Equal("Queen", queue.FindNextValue());
        }
    }
}
