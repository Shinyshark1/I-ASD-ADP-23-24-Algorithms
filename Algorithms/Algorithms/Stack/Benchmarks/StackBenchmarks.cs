using Algorithms.Shared;
using System.Diagnostics;

namespace Algorithms.Stack.Benchmarks
{
    public class StackBenchmarks
    {
        public void Push_Benchmark(int size)
        {
            Console.WriteLine($"Starting push benchmark with {size} items.");
            Stack<int> stack = new();
            var sw = new Stopwatch();

            sw.Start();
            for (int i = 0; i < size; i++)
            {
                stack.Push(i);
            }
            sw.Stop();

            Console.WriteLine($"Size: {size} - Elapsed time: {sw.Elapsed}");
        }

        public void Pop_Benchmark(int size)
        {
            Console.WriteLine($"Starting pop benchmark with {size} items.");
            Stack<int> stack = new(DataSetHelper.CreateDataSet(size));
            var stackSize = stack.Size();

            var sw = new Stopwatch();

            sw.Start();
            for (int i = 0; i < stackSize; i++)
            {
                stack.Pop();
            }
            sw.Stop();

            Console.WriteLine($"Size: {size} - Elapsed time: {sw.Elapsed}");
        }
    }
}
