using Algorithms.Shared;
using System.Diagnostics;

namespace Algorithms.DoublyLinkedList.Benchmarks
{
    public class DoublyLinkedListBenchmarks
    {
        public void Remove_Benchmark(int size)
        {
            Console.WriteLine($"Starting 'Remove {size} items' benchmark.");
            DoublyLinkedList<int> testData;
            var sw = new Stopwatch();

            testData = new DoublyLinkedList<int>(DataSetHelper.CreateOrderedDataSet(size));

            // First we test the normal remove. This will move through the list once and remove an item as it goes.
            // It will traverse the whole list only once in doing so.
            sw.Start();
            testData.Remove(1);
            sw.Stop();

            var firstResult = sw.Elapsed;
            Console.WriteLine($"Size: {size} - Elapsed time: {firstResult}");

            sw.Restart();

            testData = new DoublyLinkedList<int>(DataSetHelper.CreateOrderedDataSet(size));

            // This test removes recursively. It is a lazy way that reuses the IndexOf method.
            // Each time an item is found, we just recursively call the remove method.
            // The method stops working when no index could be found to be removed.
            sw.Start();
            testData.Remove_WithRecursion(1);
            sw.Stop();

            var secondResult = sw.Elapsed;
            Console.WriteLine($"Size: {size} - Elapsed time: {secondResult}");

            Console.WriteLine($"Removing: {RatioCalculator.CalculateTimeSpanRatio(firstResult, firstResult)}");
            Console.WriteLine($"Removing with recursion: {RatioCalculator.CalculateTimeSpanRatio(firstResult, secondResult)}");
        }
    }
}
