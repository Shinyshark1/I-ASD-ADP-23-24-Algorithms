using Algorithms.Shared;
using System.Diagnostics;

namespace Algorithms.MergeSort.Benchmarks
{
    public class MergeSortBenchmarks
    {
        public static void Sort_Benchmark(int size)
        {
            Console.WriteLine($"Starting benchmark for sorting {size} items.");
            int[] array = DataSetHelper.CreateRandomDataSet(size);
            var sw = new Stopwatch();

            sw.Start();
            MergeSort.Sort(array);
            sw.Stop();

            var firstResult = sw.Elapsed;
            Console.WriteLine($"Size: {size} - Elapsed time: {firstResult}");
        }
    }
}
