using Algorithms.PriorityQueue.FirstAttempt;
using Algorithms.PriorityQueue.SecondAttempt;
using Algorithms.Shared;
using System.Diagnostics;

namespace Algorithms.PriorityQueue.Benchmarks
{
    public class PriorityQueueBenchmarks
    {
        public void Insert_Benchmark(int size)
        {
            Console.WriteLine($"Starting insert benchmark with {size} items.");
            var sw = new Stopwatch();

            PriorityQueue<int> priorityQueue = new();
            sw.Start();
            for (int i = 0; i < size; i++)
            {
                priorityQueue.Insert(i);
            }
            sw.Stop();

            var firstResult = sw.Elapsed;
            Console.WriteLine($"Priority Queue: {firstResult}");

            sw.Reset();

            GenericPriorityQueue<int, int> genericPriorityQueue = new();
            sw.Start();
            for (int i = 0; i < size; i++)
            {
                genericPriorityQueue.Insert(i, i);
            }
            sw.Stop();

            var secondResult = sw.Elapsed;
            Console.WriteLine($"Generic Priority Queue: {secondResult}");

            Console.WriteLine($"Ratio #1: {RatioCalculator.CalculateTimeSpanRatio(firstResult, firstResult)}");
            Console.WriteLine($"Ratio #2: {RatioCalculator.CalculateTimeSpanRatio(firstResult, secondResult)}");
        }

        public void FindNext_Benchmark(int size)
        {
            Console.WriteLine($"Starting FindNext benchmark with {size} items.");
            var sw = new Stopwatch();

            PriorityQueue<int> priorityQueue = new(DataSetHelper.CreateOrderedDataSet(size));
            sw.Start();
            priorityQueue.FindNext();
            sw.Stop();

            var firstResult = sw.Elapsed;
            Console.WriteLine($"Priority Queue: {firstResult}");

            sw.Reset();

            GenericPriorityQueue<int, int> genericPriorityQueue = new(DataSetHelper.CreateOrderedDataSet(size));
            sw.Start();
            genericPriorityQueue.FindNext();
            sw.Stop();

            var secondResult = sw.Elapsed;
            Console.WriteLine($"Generic Priority Queue: {secondResult}");

            Console.WriteLine($"Ratio #1: {RatioCalculator.CalculateTimeSpanRatio(firstResult, firstResult)}");
            Console.WriteLine($"Ratio #2: {RatioCalculator.CalculateTimeSpanRatio(firstResult, secondResult)}");
        }

        public void DeleteNext_Benchmark(int size)
        {
            Console.WriteLine($"Starting DeleteNext benchmark with {size} items.");
            var sw = new Stopwatch();
            var count = 0;

            PriorityQueue<int> priorityQueue = new(DataSetHelper.CreateOrderedDataSet(size));
            count = priorityQueue.Count;

            sw.Start();
            for (int i = 0; i < count; i++)
            {
                priorityQueue.DeleteNext();
            }
            sw.Stop();

            var firstResult = sw.Elapsed;
            Console.WriteLine($"Priority Queue: {firstResult}");

            sw.Reset();

            GenericPriorityQueue<int, int> genericPriorityQueue = new(DataSetHelper.CreateOrderedDataSet(size));
            count = genericPriorityQueue.Count;

            sw.Start();
            for (int i = 0; i < count; i++)
            {
                genericPriorityQueue.DeleteNext();
            }
            sw.Stop();

            var secondResult = sw.Elapsed;
            Console.WriteLine($"Generic Priority Queue: {secondResult}");

            Console.WriteLine($"Ratio #1: {RatioCalculator.CalculateTimeSpanRatio(firstResult, firstResult)}");
            Console.WriteLine($"Ratio #2: {RatioCalculator.CalculateTimeSpanRatio(firstResult, secondResult)}");
        }
    }
}
