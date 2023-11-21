// See https://aka.ms/new-console-template for more information

using Algorithms.DoublyLinkedList.Benchmarks;
using Algorithms.DynamicArrays.Benchmarks;
using Algorithms.Stack.Benchmarks;

public class Program
{
    private static void Main(string[] args)
    {
        //Run_DynamicArrayBenchmarks();

        Run_DoublyLinkedListBenchmarks();

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
        var benchmarkInstance = new StackBenchmarks();

        benchmarkInstance.Push_Benchmark(10);
        Console.WriteLine();
        benchmarkInstance.Push_Benchmark(100);
        Console.WriteLine();
        benchmarkInstance.Push_Benchmark(1000);
        Console.WriteLine();
        benchmarkInstance.Push_Benchmark(10000);
        Console.WriteLine();
        benchmarkInstance.Push_Benchmark(100000);
        Console.WriteLine();
        benchmarkInstance.Push_Benchmark(1000000);
        Console.WriteLine();
        benchmarkInstance.Push_Benchmark(10000000);
        Console.WriteLine();
        benchmarkInstance.Push_Benchmark(100000000);
        Console.WriteLine();
        benchmarkInstance.Push_Benchmark(1000000000);
        Console.WriteLine();

        benchmarkInstance.Pop_Benchmark(10);
        Console.WriteLine();
        benchmarkInstance.Pop_Benchmark(100);
        Console.WriteLine();
        benchmarkInstance.Pop_Benchmark(1000);
        Console.WriteLine();
        benchmarkInstance.Pop_Benchmark(10000);
        Console.WriteLine();
        benchmarkInstance.Pop_Benchmark(100000);
        Console.WriteLine();
        benchmarkInstance.Pop_Benchmark(1000000);
        Console.WriteLine();
        benchmarkInstance.Pop_Benchmark(10000000);
        Console.WriteLine();
        benchmarkInstance.Pop_Benchmark(100000000);
        Console.WriteLine();
        benchmarkInstance.Pop_Benchmark(1000000000);
        Console.WriteLine();
    }
}