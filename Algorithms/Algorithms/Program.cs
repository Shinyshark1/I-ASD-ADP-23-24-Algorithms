// See https://aka.ms/new-console-template for more information

using Algorithms.DoublyLinkedList.Benchmarks;
using Algorithms.DynamicArrays.Benchmarks;

public class Program
{
    private static void Main(string[] args)
    {
        //TODO: Figure out why shrinking is faster than halving, which makes no sense.
        //Run_DynamicArrayBenchmarks();

        Run_DoublyLinkedListBenchmarks();
    }

    private static void Run_DynamicArrayBenchmarks()
    {
        var benchmarkInstance = new DynamicArrayBenchmarks();

        benchmarkInstance.Shrink_Benchmarks();
    }

    private static void Run_DoublyLinkedListBenchmarks()
    {
        var benchmarkInstance = new DoublyLinkedListBenchmarks();

        benchmarkInstance.Remove_Benchmark();
    }
}