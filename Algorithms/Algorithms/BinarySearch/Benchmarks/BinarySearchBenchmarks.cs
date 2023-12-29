using Algorithms.Deque;
using Algorithms.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.BinarySearch.Benchmarks
{
    public class BinarySearchBenchmarks
    {
        public void Add_Benchmark(int size)
        {
            Console.WriteLine($"Starting Add benchmark with {size} items.");
            var binarySearch = new BinarySearch<int>();

            var sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < size; i++)
            {
                binarySearch.Add(i);
            }
            sw.Stop();

            Console.WriteLine($"Size: {size} - Elapsed time: {sw.Elapsed}");
        }

        // RemoveAt benchmark
        public void RemoveAt_Benchmark(int size)
        {
            Console.WriteLine($"Starting Add benchmark with {size} items.");
            var binarySearch = new BinarySearch<int>(DataSetHelper.CreateRandomDataSet(size));

            var sw = new Stopwatch();
            sw.Start();
            for (int i = size - 1; i > 0; i--)
            {
                binarySearch.RemoveAt(i);
            }
            sw.Stop();

            Console.WriteLine($"Size: {size} - Elapsed time: {sw.Elapsed}");
        }

        public void IndexOf_Benchmark(int size)
        {
            Console.WriteLine($"Starting Add benchmark with {size} items.");
            var binarySearch = new BinarySearch<int>(DataSetHelper.CreateRandomDataSet(size));

            var random = new Random();
            var sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < size; i++)
            {
                binarySearch.IndexOf(random.Next(size));
            }
            sw.Stop();

            Console.WriteLine($"Size: {size} - Elapsed time: {sw.Elapsed}");
        }
    }
}
