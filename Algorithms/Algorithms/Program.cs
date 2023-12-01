// See https://aka.ms/new-console-template for more information

using Algorithms.Deque.Benchmarks;
using Algorithms.DoublyLinkedList.Benchmarks;
using Algorithms.DynamicArrays.Benchmarks;
using Algorithms.InsertionSort.Benchmarks;
using Algorithms.PriorityQueue.Benchmarks;
using Algorithms.SelectionSort.Benchmarks;
using Algorithms.Shared;
using Algorithms.Stack.Benchmarks;

public class Program
{
    private static void Main(string[] args)
    {
        //Run_DynamicArrayBenchmarks();

        //Run_DoublyLinkedListBenchmarks();

        //Run_StackBenchmarks();

        //Run_PriorityQueueBenchmarks();

        //Run_DequeBenchmarks();

        //Run_SelectionSortBenchmarks();

        Run_InsertionSortBenchmarks();

        //var array = DataSetHelper.CreateRandomDataSet(10);
        //Console.WriteLine($"Unsorted array with {array.Length} elements with their indexes:");
        //for (int i = 0; i < array.Length; i++)
        //{
        //    Console.WriteLine($"Array[{i}]: {array[i]}");
        //}

        //InsertionSort.Sort(array);
        //Console.WriteLine();

        //Console.WriteLine($"Sorted array with {array.Length} elements with their indexes:");
        //for (int i = 0; i < array.Length; i++)
        //{
        //    Console.WriteLine($"Array[{i}]: {array[i]}");
        //}
    }

    private static void Run_DynamicArrayBenchmarks()
    {
        List<int> benchmarkValues;
        var benchmarkInstance = new DynamicArrayBenchmarks();

        benchmarkValues = new List<int> { 10, 100, 1000, 10000, 100000, 1000000, 10000000 };
        BenchmarkHelper.StartBenchmark("Add");
        foreach (int value in benchmarkValues)
        {
            benchmarkInstance.Add_Benchmark(value);
            Console.WriteLine();
        }

        benchmarkValues = new List<int> { 10, 100, 1000, 10000, 100000, 200000 };
        BenchmarkHelper.StartBenchmark("Shrink and Halve");
        foreach (int value in benchmarkValues)
        {
            benchmarkInstance.ShrinkAndHalve_Benchmark(value);
            Console.WriteLine();
        }
    }

    private static void Run_DoublyLinkedListBenchmarks()
    {
        List<int> benchmarkValues;
        var benchmarkInstance = new DoublyLinkedListBenchmarks();

        benchmarkValues = new List<int> { 10, 100, 1000, 10000, 100000, 1000000, 10000000 };
        BenchmarkHelper.StartBenchmark("Remove");
        foreach (int value in benchmarkValues)
        {
            benchmarkInstance.Remove_Benchmark(value);
            Console.WriteLine();
        }
    }

    private static void Run_StackBenchmarks()
    {
        List<int> benchmarkValues;
        var benchmarkInstance = new StackBenchmarks();

        benchmarkValues = new List<int> { 10, 100, 1000, 10000, 100000, 1000000, 10000000 };
        BenchmarkHelper.StartBenchmark("Push");
        foreach (int value in benchmarkValues)
        {
            benchmarkInstance.Push_Benchmark(value);
            Console.WriteLine();
        }

        benchmarkValues = new List<int> { 10, 100, 1000, 10000, 100000, 1000000, 10000000 };
        BenchmarkHelper.StartBenchmark("Pop");
        foreach (var item in benchmarkValues)
        {
            benchmarkInstance.Pop_Benchmark(item);
            Console.WriteLine();
        }

        benchmarkValues = new List<int> { 10, 100, 1000, 10000, 100000, 1000000, 10000000 };
        BenchmarkHelper.StartBenchmark("Top");
        foreach (var item in benchmarkValues)
        {
            benchmarkInstance.Top_Benchmark(item);
            Console.WriteLine();
        }
    }

    private static void Run_PriorityQueueBenchmarks()
    {
        List<int> benchmarkValues;
        var benchmarkInstance = new PriorityQueueBenchmarks();

        benchmarkValues = new List<int> { 10, 100, 1000, 10000, 100000, 1000000, 10000000 };
        BenchmarkHelper.StartBenchmark("Insert");
        foreach (int value in benchmarkValues)
        {
            benchmarkInstance.Insert_Benchmark(value);
            Console.WriteLine();
        }

        benchmarkValues = new List<int> { 10, 100, 1000, 10000, 100000, 1000000, 10000000 };
        BenchmarkHelper.StartBenchmark("FindNext");
        foreach (int value in benchmarkValues)
        {
            benchmarkInstance.FindNext_Benchmark(value);
            Console.WriteLine();
        }

        benchmarkValues = new List<int> { 10, 100, 1000, 10000, 100000 };
        BenchmarkHelper.StartBenchmark("DeleteNext");
        foreach (int value in benchmarkValues)
        {
            benchmarkInstance.DeleteNext_Benchmark(value);
            Console.WriteLine();
        }
    }

    private static void Run_DequeBenchmarks()
    {
        List<int> benchmarkValues;
        var benchmarkInstance = new DequeBenchmarks();

        benchmarkValues = new List<int> { 10, 100, 1000, 10000, 100000, 1000000, 10000000, 100000000 };
        BenchmarkHelper.StartBenchmark("InsertLeft");
        foreach (int value in benchmarkValues)
        {
            benchmarkInstance.InsertLeft_Benchmark(value);
            Console.WriteLine();
        }

        benchmarkValues = new List<int> { 10, 100, 1000, 10000, 100000, 1000000, 10000000, 100000000 };
        BenchmarkHelper.StartBenchmark("InsertRight");
        foreach (int value in benchmarkValues)
        {
            benchmarkInstance.InsertRight_Benchmark(value);
            Console.WriteLine();
        }

        benchmarkValues = new List<int> { 10, 100, 1000, 10000, 100000, 1000000, 10000000, 100000000 };
        BenchmarkHelper.StartBenchmark("DeleteLeft");
        foreach (int value in benchmarkValues)
        {
            benchmarkInstance.DeleteLeft_Benchmark(value);
            Console.WriteLine();
        }

        benchmarkValues = new List<int> { 10, 100, 1000, 10000, 100000, 1000000, 10000000, 100000000 };
        BenchmarkHelper.StartBenchmark("DeleteRight");
        foreach (int value in benchmarkValues)
        {
            benchmarkInstance.DeleteRight_Benchmark(value);
            Console.WriteLine();
        }
    }

    private static void Run_SelectionSortBenchmarks()
    {
        // warm-up
        SelectionSortBenchmarks.Sort_Benchmark(100);

        // Actual benchmarks.
        SelectionSortBenchmarks.Sort_Benchmark(1000);
        SelectionSortBenchmarks.Sort_Benchmark(10000);
        SelectionSortBenchmarks.Sort_Benchmark(100000);
        SelectionSortBenchmarks.Sort_Benchmark(1000000);
    }

    private static void Run_InsertionSortBenchmarks()
    {
        // warm-up
        InsertionSortBenchmarks.Sort_Benchmark(100);

        // Actual benchmarks.
        InsertionSortBenchmarks.Sort_Benchmark(1000);
        InsertionSortBenchmarks.Sort_Benchmark(10000);
        InsertionSortBenchmarks.Sort_Benchmark(100000);
        InsertionSortBenchmarks.Sort_Benchmark(1000000);
    }
}