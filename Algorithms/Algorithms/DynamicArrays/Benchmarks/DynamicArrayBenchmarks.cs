using Algorithms.Shared;
using System.Diagnostics;

namespace Algorithms.DynamicArrays.Benchmarks
{
    public class DynamicArrayBenchmarks
    {
        public void ShrinkAndHalve_Benchmark(int size)
        {
            Console.WriteLine($"Starting {size} items benchmark.");
            DynamicArray<int> testData;
            var sw = new Stopwatch();
            var count = 0;

            testData = new DynamicArray<int>(DataSetHelper.CreateDataSet(size));

            sw.Start();
            count = testData.Count;
            for (int i = 0; i < count; i++)
            {
                testData.Remove(testData[^1]);
            }
            sw.Stop();

            var firstResult = sw.Elapsed;
            Console.WriteLine($"Half: {firstResult}");

            sw.Reset();

            testData = new DynamicArray<int>(DataSetHelper.CreateDataSet(size));

            sw.Start();
            count = testData.Count;
            for (int i = 0; i < count; i++)
            {
                testData.Remove_WithShrinkByOne(testData[^1]);
            }
            sw.Stop();

            var secondResult = sw.Elapsed;
            Console.WriteLine($"Shrink: {secondResult}");

            Console.WriteLine($"Ratio #1: {RatioCalculator.CalculateTimeSpanRatio(firstResult, firstResult)}");
            Console.WriteLine($"Ratio #2: {RatioCalculator.CalculateTimeSpanRatio(firstResult, secondResult)}");
        }
    }
}
