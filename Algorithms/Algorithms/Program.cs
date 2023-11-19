// See https://aka.ms/new-console-template for more information

using Algorithms.DoublyLinkedList.Benchmarks;
using Algorithms.DynamicArrays.Benchmarks;

public class Program
{
    private static void Main(string[] args)
    {
        //Run_DynamicArrayBenchmarks();

        //Run_DoublyLinkedListBenchmarks();
    }

    private static void Run_DynamicArrayBenchmarks()
    {
        var benchmarkInstance = new DynamicArrayBenchmarks();

        benchmarkInstance.Shrink_Benchmarks(10);
        Console.WriteLine();
        benchmarkInstance.Shrink_Benchmarks(100);
        Console.WriteLine();
        benchmarkInstance.Shrink_Benchmarks(1000);
        Console.WriteLine();
        benchmarkInstance.Shrink_Benchmarks(10000);
        Console.WriteLine();
        benchmarkInstance.Shrink_Benchmarks(100000);
        Console.WriteLine();
        benchmarkInstance.Shrink_Benchmarks(200000);
        Console.WriteLine();
    }

    private static void Run_DoublyLinkedListBenchmarks()
    {
        var benchmarkInstance = new DoublyLinkedListBenchmarks();

        benchmarkInstance.Remove_Benchmark();
    }
}