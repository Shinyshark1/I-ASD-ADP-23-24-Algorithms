// See https://aka.ms/new-console-template for more information

using Algorithms.DoublyLinkedList.Benchmarks;
using Algorithms.DynamicArrays.Benchmarks;
using Algorithms.Shared;
using Algorithms.Stack.Benchmarks;

public class Program
{
    private static void Main(string[] args)
    {
        Run_DynamicArrayBenchmarks();

        //Run_DoublyLinkedListBenchmarks();

        //Run_StackBenchmarks();
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
}