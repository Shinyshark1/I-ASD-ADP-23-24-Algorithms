using Algorithms.Shared;
using System.Diagnostics;

namespace Algorithms.Deque.Benchmarks
{
    public class DequeBenchmarks
    {
        public void InsertLeft_Benchmark(int size)
        {
            Console.WriteLine($"Starting InsertLeft benchmark with {size} items.");
            var deque = new Deque<int>();

            var sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < size; i++)
            {
                deque.InsertLeft(i);
            }
            sw.Stop();

            Console.WriteLine($"Size: {size} - Elapsed time: {sw.Elapsed}");
        }

        public void InsertRight_Benchmark(int size)
        {
            Console.WriteLine($"Starting InsertRight benchmark with {size} items.");
            var deque = new Deque<int>();

            var sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < size; i++)
            {
                deque.InsertRight(i);
            }
            sw.Stop();

            Console.WriteLine($"Size: {size} - Elapsed time: {sw.Elapsed}");
        }

        public void DeleteLeft_Benchmark(int size)
        {
            Console.WriteLine($"Starting DeleteLeft benchmark with {size} items.");
            var deque = new Deque<int>(DataSetHelper.CreateDataSet(size));

            var sw = new Stopwatch();
            sw.Start();
            while (deque.Count > 0)
            {
                deque.DeleteLeft();
            }
            sw.Stop();

            Console.WriteLine($"Size: {size} - Elapsed time: {sw.Elapsed}");
        }

        public void DeleteRight_Benchmark(int size)
        {
            Console.WriteLine($"Starting DeleteRight benchmark with {size} items.");
            var deque = new Deque<int>(DataSetHelper.CreateDataSet(size));

            var sw = new Stopwatch();
            sw.Start();
            while (deque.Count > 0)
            {
                deque.DeleteRight();
            }
            sw.Stop();

            Console.WriteLine($"Size: {size} - Elapsed time: {sw.Elapsed}");
        }
    }
}
