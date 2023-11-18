using Algorithms.JsonData;
using Algorithms.JsonData.Sorteren.Models;
using Algorithms.Shared;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Algorithms.DoublyLinkedList.Benchmarks
{
    public class DoublyLinkedListBenchmarks
    {
        public void Remove_Benchmark()
        {
            Console.WriteLine("Starting benchmark...");
            DoublyLinkedList<int> testData;
            var sw = new Stopwatch();

            testData = new DoublyLinkedList<int>(JsonConvert.DeserializeObject<LijstHerhaald1000>(JsonConstants.ReadDataSetSorting()).Content);

            // First we test the normal remove. This will move through the list once and remove an item as it goes.
            // It will traverse the whole list only once in doing so.
            sw.Start();
            testData.Remove(1);
            sw.Stop();

            var firstResult = sw.Elapsed;
            Console.WriteLine($"Normal remove: {firstResult}");

            sw.Restart();

            testData = new DoublyLinkedList<int>(JsonConvert.DeserializeObject<LijstHerhaald1000>(JsonConstants.ReadDataSetSorting()).Content);

            // This test removes recursively. It is a lazy way that reuses the IndexOf method.
            // Each time an item is found, we just recursively call the remove method.
            // The method stops working when no index could be found to be removed.
            sw.Start();
            testData.Remove_WithRecursion(1);
            sw.Stop();

            var secondResult = sw.Elapsed;
            Console.WriteLine($"Recursive remove: {secondResult}");

            Console.WriteLine($"Ratio #1: {RatioCalculator.CalculateTimeSpanRatio(firstResult, firstResult)}");
            Console.WriteLine($"Ratio #2: {RatioCalculator.CalculateTimeSpanRatio(firstResult, secondResult)}");
        }

    }
}
