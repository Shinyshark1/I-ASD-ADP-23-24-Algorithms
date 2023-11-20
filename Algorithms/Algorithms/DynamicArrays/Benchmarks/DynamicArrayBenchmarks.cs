using Algorithms.Shared;
using System.Diagnostics;

namespace Algorithms.DynamicArrays.Benchmarks
{
    public class DynamicArrayBenchmarks
    {
        public void HalveWhenPossible(DynamicArray<int> array)
        {
            var count = array.Count;
            for (int i = 0; i < count; i++)
            {
                array.Remove(array[^1]);
            }
        }

        public void ShrinkEachTime(DynamicArray<int> array)
        {
            var count = array.Count;
            for (int i = 0; i < count; i++)
            {
                array.Remove_WithShrinkByOne(array[^1]);
            }
        }

        public void Shrink_Benchmarks(int size)
        {
            Console.WriteLine($"Starting {size} items benchmark.");
            DynamicArray<int> testData;
            var sw = new Stopwatch();

            testData = new DynamicArray<int>(DataSetHelper.CreateDataSet(size));

            sw.Start();
            HalveWhenPossible(testData);
            sw.Stop();

            var firstResult = sw.Elapsed;
            Console.WriteLine($"Half: {firstResult}");

            sw.Reset();

            testData = new DynamicArray<int>(DataSetHelper.CreateDataSet(size));

            sw.Start();
            ShrinkEachTime(testData);
            sw.Stop();

            var secondResult = sw.Elapsed;
            Console.WriteLine($"Shrink: {secondResult}");

            Console.WriteLine($"Ratio #1: {RatioCalculator.CalculateTimeSpanRatio(firstResult, firstResult)}");
            Console.WriteLine($"Ratio #2: {RatioCalculator.CalculateTimeSpanRatio(firstResult, secondResult)}");
        }
    }
}
