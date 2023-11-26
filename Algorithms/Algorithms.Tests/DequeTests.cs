using Algorithms.JsonData;
using Algorithms.JsonData.Sorteren.Models;
using Newtonsoft.Json;

namespace Algorithms.Tests
{
    public class DequeTests
    {
        [Fact]
        public void TheDataSets_Fit_InTheDeque()
        {
            var sortingJson = JsonConstants.ReadDataSetSorting();

            var result1 = Record.Exception(() => new Deque.Deque<int>(JsonConvert.DeserializeObject<LijstAflopend2>(sortingJson).Content));
            var result2 = Record.Exception(() => new Deque.Deque<int>(JsonConvert.DeserializeObject<LijstOplopend2>(sortingJson).Content));
            var result3 = Record.Exception(() => new Deque.Deque<double>(JsonConvert.DeserializeObject<LijstFloat8001>(sortingJson).Content));
            var result4 = Record.Exception(() => new Deque.Deque<int>(JsonConvert.DeserializeObject<LijstGesorteerdAflopend3>(sortingJson).Content));
            var result5 = Record.Exception(() => new Deque.Deque<int>(JsonConvert.DeserializeObject<LijstGesorteerdOplopend3>(sortingJson).Content));
            var result6 = Record.Exception(() => new Deque.Deque<int>(JsonConvert.DeserializeObject<LijstHerhaald1000>(sortingJson).Content));
            var result7 = Record.Exception(() => new Deque.Deque<int>(JsonConvert.DeserializeObject<LijstLeeg0>(sortingJson).Content));
            var result8 = Record.Exception(() => new Deque.Deque<int?>(JsonConvert.DeserializeObject<LijstNull1>(sortingJson).Content));
            var result9 = Record.Exception(() => new Deque.Deque<int?>(JsonConvert.DeserializeObject<LijstNull3>(sortingJson).Content));
            var result10 = Record.Exception(() => new Deque.Deque<int>(JsonConvert.DeserializeObject<LijstOplopend10000>(sortingJson).Content));
            var result11 = Record.Exception(() => new Deque.Deque<int>(JsonConvert.DeserializeObject<LijstWillekeurig10000>(sortingJson).Content));
            var result12 = Record.Exception(() => new Deque.Deque<int>(JsonConvert.DeserializeObject<LijstWillekeurig3>(sortingJson).Content));

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
        public void InsertLeft_Inserts_OnTheLeft()
        {
            // Arrange
            var deque = new Deque.Deque<string>();

            // Act
            deque.InsertLeft("Cat");
            deque.InsertLeft("Dog");
            deque.InsertLeft("Mouse");

            // Assert
            Assert.Equal("Mouse", deque.DeleteLeft());
            Assert.Equal("Dog", deque.DeleteLeft());
            Assert.Equal("Cat", deque.DeleteLeft());
        }

        [Fact]
        public void InsertRight_Inserts_OnTheRight()
        {
            // Arrange
            var deque = new Deque.Deque<string>();

            // Act
            deque.InsertRight("Cat");
            deque.InsertRight("Dog");
            deque.InsertRight("Mouse");

            // Assert
            Assert.Equal("Mouse", deque.DeleteRight());
            Assert.Equal("Dog", deque.DeleteRight());
            Assert.Equal("Cat", deque.DeleteRight());
        }
    }
}
