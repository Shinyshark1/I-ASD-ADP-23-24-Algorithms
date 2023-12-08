using Algorithms.Shared;
using System.Diagnostics;

namespace Algorithms.QuickSort.Benchmark
{
    public class QuickSortBenchmarks
    {
        public static void Sort_Benchmark(int size)
        {
            Console.WriteLine($"Starting benchmark for sorting {size} items.");
            int[] firstArray = DataSetHelper.CreateRandomDataSet(size);
            int[] secondArray = (int[])firstArray.Clone();
            var sw = new Stopwatch();

            sw.Start();
            QuickSort.Sort(firstArray);
            sw.Stop();

            var firstResult = sw.Elapsed;
            Console.WriteLine($"Size: {size} - Elapsed time: {firstResult} | Parallel");

            sw.Restart();

            sw.Start();
            QuickSort.Sort_WithoutParallel(secondArray);
            sw.Stop();

            var secondResult = sw.Elapsed;
            Console.WriteLine($"Size: {size} - Elapsed time: {secondResult} | Normal");

            Console.WriteLine($"Sort Parallel: {RatioCalculator.CalculateTimeSpanRatio(firstResult, firstResult)}");
            Console.WriteLine($"Sort Normally: {RatioCalculator.CalculateTimeSpanRatio(firstResult, secondResult)}");
        }
    }
}
