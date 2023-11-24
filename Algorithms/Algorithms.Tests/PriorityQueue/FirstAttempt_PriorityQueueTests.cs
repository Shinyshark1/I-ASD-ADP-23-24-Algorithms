using Algorithms.JsonData;
using Algorithms.JsonData.Sorteren.Models;
using Algorithms.PriorityQueue.FirstAttempt;
using Algorithms.PriorityQueue.FirstAttempt.Models;
using Newtonsoft.Json;

namespace Algorithms.Tests.PriorityQueue
{
    public class FirstAttempt_PriorityQueueTests
    {
        [Fact]
        public void TheDataSets_Fit_InThePriorityQueue()
        {
            var sortingJson = JsonConstants.ReadDataSetSorting();

            var result1 = Record.Exception(() => new PriorityQueue<int>(JsonConvert.DeserializeObject<LijstAflopend2>(sortingJson).Content));
            var result2 = Record.Exception(() => new PriorityQueue<int>(JsonConvert.DeserializeObject<LijstOplopend2>(sortingJson).Content));
            var result3 = Record.Exception(() => new PriorityQueue<double>(JsonConvert.DeserializeObject<LijstFloat8001>(sortingJson).Content));
            var result4 = Record.Exception(() => new PriorityQueue<int>(JsonConvert.DeserializeObject<LijstGesorteerdAflopend3>(sortingJson).Content));
            var result5 = Record.Exception(() => new PriorityQueue<int>(JsonConvert.DeserializeObject<LijstGesorteerdOplopend3>(sortingJson).Content));
            var result6 = Record.Exception(() => new PriorityQueue<int>(JsonConvert.DeserializeObject<LijstHerhaald1000>(sortingJson).Content));
            var result7 = Record.Exception(() => new PriorityQueue<int>(JsonConvert.DeserializeObject<LijstLeeg0>(sortingJson).Content));

            // These two cannot be parsed directly because nullable types in C# can not satisfy any interface constraints.
            var nullableList = JsonConvert.DeserializeObject<LijstNull1>(sortingJson).Content;
            var nonNullabelList = nullableList.Where(x => x.HasValue).Select(x => x.Value).ToList();
            var result8 = Record.Exception(() => new PriorityQueue<int>(nonNullabelList));

            nullableList = JsonConvert.DeserializeObject<LijstNull3>(sortingJson).Content;
            nonNullabelList = nullableList.Where(x => x.HasValue).Select(x => x.Value).ToList();
            var result9 = Record.Exception(() => new PriorityQueue<int>(nonNullabelList));

            var result10 = Record.Exception(() => new PriorityQueue<int>(JsonConvert.DeserializeObject<LijstOplopend10000>(sortingJson).Content));
            var result11 = Record.Exception(() => new PriorityQueue<int>(JsonConvert.DeserializeObject<LijstWillekeurig10000>(sortingJson).Content));
            var result12 = Record.Exception(() => new PriorityQueue<int>(JsonConvert.DeserializeObject<LijstWillekeurig3>(sortingJson).Content));

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
        public void Insert_AddsItem_ToTheQueue()
        {
            // Arrange
            var queue = new PriorityQueue<PriorityTestModel>();

            // Act
            queue.Insert(new PriorityTestModel(PriorityEnum.LowestPriority));
            queue.Insert(new PriorityTestModel(PriorityEnum.LowPriority));
            queue.Insert(new PriorityTestModel(PriorityEnum.MediumPriority));
            queue.Insert(new PriorityTestModel(PriorityEnum.HighPriority));
            queue.Insert(new PriorityTestModel(PriorityEnum.HighestPriority));

            // Assert
            Assert.Equal(5, queue.Count);
        }

        [Fact]
        public void FindNext_Finds_TheHighestAvailablePriority()
        {
            // Arrange
            var queue = new PriorityQueue<PriorityTestModel>();

            // Act
            queue.Insert(new PriorityTestModel(PriorityEnum.LowestPriority));
            queue.Insert(new PriorityTestModel(PriorityEnum.LowPriority));
            queue.Insert(new PriorityTestModel(PriorityEnum.MediumPriority));
            queue.Insert(new PriorityTestModel(PriorityEnum.LowestPriority));
            queue.Insert(new PriorityTestModel(PriorityEnum.LowPriority));
            queue.Insert(new PriorityTestModel(PriorityEnum.LowestPriority));
            queue.Insert(new PriorityTestModel(PriorityEnum.LowPriority));
            queue.Insert(new PriorityTestModel(PriorityEnum.LowestPriority));
            queue.Insert(new PriorityTestModel(PriorityEnum.LowPriority));
            queue.Insert(new PriorityTestModel(PriorityEnum.LowestPriority));
            queue.Insert(new PriorityTestModel(PriorityEnum.LowPriority));

            // Assert
            Assert.Equal(PriorityEnum.MediumPriority, queue.FindNext().Priority);
        }

        [Fact]
        public void DeleteNext_Removes_TheHighestAvailablePriorityItem()
        {
            // Arrange
            var queue = new PriorityQueue<PriorityTestModel>();

            // Act
            queue.Insert(new PriorityTestModel(PriorityEnum.LowestPriority));
            queue.Insert(new PriorityTestModel(PriorityEnum.MediumPriority));
            queue.Insert(new PriorityTestModel(PriorityEnum.LowPriority));

            queue.DeleteNext();

            // Assert
            Assert.Equal(PriorityEnum.LowPriority, queue.FindNext().Priority);
        }
    }
}
