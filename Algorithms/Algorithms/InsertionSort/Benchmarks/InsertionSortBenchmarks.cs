using Algorithms.Shared;
using System.Diagnostics;

namespace Algorithms.InsertionSort.Benchmarks
{
    public static class InsertionSortBenchmarks
    {
        public static void Sort_Benchmark(int size)
        {
            Console.WriteLine($"Starting benchmark for sorting {size} items.");
            int[] array = DataSetHelper.CreateRandomDataSet(size);
            var sw = new Stopwatch();

            sw.Start();
            InsertionSort.Sort(array);
            sw.Stop();

            var firstResult = sw.Elapsed;
            Console.WriteLine($"Size: {size} - Elapsed time: {firstResult}");
        }
    }
}
