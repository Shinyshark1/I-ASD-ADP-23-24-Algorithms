// See https://aka.ms/new-console-template for more information

using Algorithms.DoublyLinkedList.Benchmarks;
using Algorithms.DynamicArrays.Benchmarks;
using Algorithms.Stack.Benchmarks;

public class Program
{
    private static void Main(string[] args)
    {
        //Run_DynamicArrayBenchmarks();

        //Run_DoublyLinkedListBenchmarks();

        //Run_StackBenchmarks();
    }

    private static void Run_DynamicArrayBenchmarks()
    {
        var benchmarkInstance = new DynamicArrayBenchmarks();

        benchmarkInstance.Add_Benchmark(10);
        Console.WriteLine();
        benchmarkInstance.Add_Benchmark(100);
        Console.WriteLine();
        benchmarkInstance.Add_Benchmark(1000);
        Console.WriteLine();
        benchmarkInstance.Add_Benchmark(10000);
        Console.WriteLine();
        benchmarkInstance.Add_Benchmark(100000);
        Console.WriteLine();
        benchmarkInstance.Add_Benchmark(200000);
        Console.WriteLine();
        benchmarkInstance.Add_Benchmark(500000);
        Console.WriteLine();
        benchmarkInstance.Add_Benchmark(1000000);
        Console.WriteLine();
        benchmarkInstance.Add_Benchmark(10000000);
        Console.WriteLine();
        benchmarkInstance.Add_Benchmark(100000000);
        Console.WriteLine();

        benchmarkInstance.ShrinkAndHalve_Benchmark(10);
        Console.WriteLine();
        benchmarkInstance.ShrinkAndHalve_Benchmark(100);
        Console.WriteLine();
        benchmarkInstance.ShrinkAndHalve_Benchmark(1000);
        Console.WriteLine();
        benchmarkInstance.ShrinkAndHalve_Benchmark(10000);
        Console.WriteLine();
        benchmarkInstance.ShrinkAndHalve_Benchmark(100000);
        Console.WriteLine();
        benchmarkInstance.ShrinkAndHalve_Benchmark(200000);
        Console.WriteLine();
    }

    private static void Run_DoublyLinkedListBenchmarks()
    {
        var benchmarkInstance = new DoublyLinkedListBenchmarks();

        benchmarkInstance.Remove_Benchmark(10);
        Console.WriteLine();
        benchmarkInstance.Remove_Benchmark(100);
        Console.WriteLine();
        benchmarkInstance.Remove_Benchmark(1000);
        Console.WriteLine();
        benchmarkInstance.Remove_Benchmark(10000);
        Console.WriteLine();
        benchmarkInstance.Remove_Benchmark(100000);
        Console.WriteLine();
        benchmarkInstance.Remove_Benchmark(1000000);
        Console.WriteLine();
        benchmarkInstance.Remove_Benchmark(10000000);
    }

    private static void Run_StackBenchmarks()
    {
        List<int> benchmarkValues;
        var benchmarkInstance = new StackBenchmarks();

        benchmarkValues = new List<int> { 10, 100, 1000, 10000, 100000, 1000000, 10000000, 100000000, 1000000000 };
        foreach (int value in benchmarkValues)
        {
            benchmarkInstance.Push_Benchmark(value);
            Console.WriteLine();
        }

        benchmarkValues = new List<int> { 10, 100, 1000, 10000, 100000, 1000000, 10000000, 100000000, 1000000000 };
        foreach (var item in benchmarkValues)
        {
            benchmarkInstance.Pop_Benchmark(item);
        }

        benchmarkValues = new List<int> { 10, 100, 1000, 10000, 100000, 1000000, 10000000, 100000000, 1000000000 };
        foreach (var item in benchmarkValues)
        {
            benchmarkInstance.Top_Benchmark(item);
        }
    }
}