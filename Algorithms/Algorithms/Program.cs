﻿// See https://aka.ms/new-console-template for more information

using Algorithms.BinarySearch.Benchmarks;
using Algorithms.Deque.Benchmarks;
using Algorithms.DoublyLinkedList.Benchmarks;
using Algorithms.DynamicArrays.Benchmarks;
using Algorithms.Hashtable.Benchmarks;
using Algorithms.InsertionSort.Benchmarks;
using Algorithms.JsonData;
using Algorithms.JsonData.Grafen.Models;
using Algorithms.MergeSort.Benchmarks;
using Algorithms.PriorityQueue.Benchmarks;
using Algorithms.QuickSort.Benchmark;
using Algorithms.SelectionSort.Benchmarks;
using Algorithms.Shared;
using Algorithms.Stack.Benchmarks;
using Newtonsoft.Json;

public class Program
{
    private static void Main(string[] args)
    {
        //Run_DynamicArrayBenchmarks();

        //Run_DoublyLinkedListBenchmarks();

        //Run_StackBenchmarks();

        //Run_PriorityQueueBenchmarks();

        //Run_DequeBenchmarks();

        //Run_BinarySearchBenchmarks();

        //Run_SelectionSortBenchmarks();

        //Run_InsertionSortBenchmarks();

        //Run_MergeSortBenchmarks();

        //Run_QuickSortBenchmarks();

        //Run_HashtableBenchmarks();

        var graphData = JsonConstants.ReadDataSetGraphing();
        var test = JsonConvert.DeserializeObject<GraphData>(graphData);
        Console.WriteLine();
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

    private static void Run_BinarySearchBenchmarks()
    {
        List<int> benchmarkValues;
        var benchmarkInstance = new BinarySearchBenchmarks();

        benchmarkValues = new List<int> { 10, 100, 1000, 10000 };
        BenchmarkHelper.StartBenchmark("Add");
        foreach (int value in benchmarkValues)
        {
            benchmarkInstance.Add_Benchmark(value);
            Console.WriteLine();
        }

        benchmarkValues = new List<int> { 10, 100, 1000, 10000 };
        BenchmarkHelper.StartBenchmark("RemoveAt");
        foreach (int value in benchmarkValues)
        {
            benchmarkInstance.RemoveAt_Benchmark(value);
            Console.WriteLine();
        }

        benchmarkValues = new List<int> { 10, 100, 1000, 10000 };
        BenchmarkHelper.StartBenchmark("IndexOf");
        foreach (int value in benchmarkValues)
        {
            benchmarkInstance.IndexOf_Benchmark(value);
            Console.WriteLine();
        }
    }

    private static void Run_SelectionSortBenchmarks()
    {
        Console.WriteLine("-== Random arrays ==-");

        // warm-up
        SelectionSortBenchmarks.Sort_Benchmark(100);

        // Actual benchmarks.
        SelectionSortBenchmarks.Sort_Benchmark(1000);
        SelectionSortBenchmarks.Sort_Benchmark(10000);
        SelectionSortBenchmarks.Sort_Benchmark(100000);
        SelectionSortBenchmarks.Sort_Benchmark(1000000);

        Console.WriteLine();
        Console.WriteLine("-== Sorted arrays ==-");

        // warm-up
        SelectionSortBenchmarks.Sort_SortedArray_Benchmark(100);

        // Actual benchmarks.
        SelectionSortBenchmarks.Sort_SortedArray_Benchmark(1000);
        SelectionSortBenchmarks.Sort_SortedArray_Benchmark(10000);
        SelectionSortBenchmarks.Sort_SortedArray_Benchmark(100000);
        SelectionSortBenchmarks.Sort_SortedArray_Benchmark(1000000);

        Console.WriteLine();
        Console.WriteLine("-== Reversed arrays ==-");

        // warm-up
        SelectionSortBenchmarks.Sort_ReversedArray_Benchmark(100);

        // Actual benchmarks.
        SelectionSortBenchmarks.Sort_ReversedArray_Benchmark(1000);
        SelectionSortBenchmarks.Sort_ReversedArray_Benchmark(10000);
        SelectionSortBenchmarks.Sort_ReversedArray_Benchmark(100000);
        SelectionSortBenchmarks.Sort_ReversedArray_Benchmark(1000000);

        Console.WriteLine();
        Console.WriteLine("-== Equal arrays ==-");

        // warm-up
        SelectionSortBenchmarks.Sort_EqualArray_Benchmark(100);

        // Actual benchmarks.
        SelectionSortBenchmarks.Sort_EqualArray_Benchmark(1000);
        SelectionSortBenchmarks.Sort_EqualArray_Benchmark(10000);
        SelectionSortBenchmarks.Sort_EqualArray_Benchmark(100000);
        SelectionSortBenchmarks.Sort_EqualArray_Benchmark(1000000);
    }

    private static void Run_InsertionSortBenchmarks()
    {
        Console.WriteLine("-== Random arrays ==-");

        // warm-up
        InsertionSortBenchmarks.Sort_Benchmark(100);

        // Actual benchmarks.
        InsertionSortBenchmarks.Sort_Benchmark(1000);
        InsertionSortBenchmarks.Sort_Benchmark(10000);
        InsertionSortBenchmarks.Sort_Benchmark(100000);
        InsertionSortBenchmarks.Sort_Benchmark(1000000);

        Console.WriteLine();
        Console.WriteLine("-== Sorted arrays ==-");

        // warm-up
        InsertionSortBenchmarks.Sort_SortedArray_Benchmark(100);

        // Actual benchmarks.
        InsertionSortBenchmarks.Sort_SortedArray_Benchmark(1000);
        InsertionSortBenchmarks.Sort_SortedArray_Benchmark(10000);
        InsertionSortBenchmarks.Sort_SortedArray_Benchmark(100000);
        InsertionSortBenchmarks.Sort_SortedArray_Benchmark(1000000);

        Console.WriteLine();
        Console.WriteLine("-== Reversed arrays ==-");

        // warm-up
        InsertionSortBenchmarks.Sort_ReversedArray_Benchmark(100);

        // Actual benchmarks.
        InsertionSortBenchmarks.Sort_ReversedArray_Benchmark(1000);
        InsertionSortBenchmarks.Sort_ReversedArray_Benchmark(10000);
        InsertionSortBenchmarks.Sort_ReversedArray_Benchmark(100000);
        InsertionSortBenchmarks.Sort_ReversedArray_Benchmark(1000000);

        Console.WriteLine();
        Console.WriteLine("-== Equal arrays ==-");

        // warm-up
        InsertionSortBenchmarks.Sort_EqualArray_Benchmark(100);

        // Actual benchmarks.
        InsertionSortBenchmarks.Sort_EqualArray_Benchmark(1000);
        InsertionSortBenchmarks.Sort_EqualArray_Benchmark(10000);
        InsertionSortBenchmarks.Sort_EqualArray_Benchmark(100000);
        InsertionSortBenchmarks.Sort_EqualArray_Benchmark(1000000);
    }

    private static void Run_MergeSortBenchmarks()
    {
        Console.WriteLine("-== Random arrays ==-");

        // warm-up
        MergeSortBenchmarks.Sort_Benchmark(100);

        // Actual benchmarks.
        MergeSortBenchmarks.Sort_Benchmark(1000);
        MergeSortBenchmarks.Sort_Benchmark(10000);
        MergeSortBenchmarks.Sort_Benchmark(100000);
        MergeSortBenchmarks.Sort_Benchmark(1000000);

        Console.WriteLine();
        Console.WriteLine("-== Sorted arrays ==-");

        // warm-up
        MergeSortBenchmarks.Sort_SortedArray_Benchmark(100);

        // Actual benchmarks.
        MergeSortBenchmarks.Sort_SortedArray_Benchmark(1000);
        MergeSortBenchmarks.Sort_SortedArray_Benchmark(10000);
        MergeSortBenchmarks.Sort_SortedArray_Benchmark(100000);
        MergeSortBenchmarks.Sort_SortedArray_Benchmark(1000000);

        Console.WriteLine();
        Console.WriteLine("-== Reversed arrays ==-");

        // warm-up
        MergeSortBenchmarks.Sort_ReversedArray_Benchmark(100);

        // Actual benchmarks.
        MergeSortBenchmarks.Sort_ReversedArray_Benchmark(1000);
        MergeSortBenchmarks.Sort_ReversedArray_Benchmark(10000);
        MergeSortBenchmarks.Sort_ReversedArray_Benchmark(100000);
        MergeSortBenchmarks.Sort_ReversedArray_Benchmark(1000000);

        Console.WriteLine();
        Console.WriteLine("-== Equal arrays ==-");

        // warm-up
        MergeSortBenchmarks.Sort_EqualArray_Benchmark(100);

        // Actual benchmarks.
        MergeSortBenchmarks.Sort_EqualArray_Benchmark(1000);
        MergeSortBenchmarks.Sort_EqualArray_Benchmark(10000);
        MergeSortBenchmarks.Sort_EqualArray_Benchmark(100000);
        MergeSortBenchmarks.Sort_EqualArray_Benchmark(1000000);
    }

    private static void Run_QuickSortBenchmarks()
    {
        Console.WriteLine("-== Random arrays ==-");

        // warm-up
        QuickSortBenchmarks.Sort_Benchmark(100);

        // Actual benchmarks.
        QuickSortBenchmarks.Sort_Benchmark(1000);
        QuickSortBenchmarks.Sort_Benchmark(10000);
        QuickSortBenchmarks.Sort_Benchmark(100000);
        QuickSortBenchmarks.Sort_Benchmark(1000000);

        Console.WriteLine();
        Console.WriteLine("-== Sorted arrays ==-");

        // warm-up
        QuickSortBenchmarks.Sort_SortedArray_Benchmark(100);

        // Actual benchmarks.
        QuickSortBenchmarks.Sort_SortedArray_Benchmark(1000);
        QuickSortBenchmarks.Sort_SortedArray_Benchmark(10000);
        QuickSortBenchmarks.Sort_SortedArray_Benchmark(100000);
        QuickSortBenchmarks.Sort_SortedArray_Benchmark(1000000);

        Console.WriteLine();
        Console.WriteLine("-== Reversed arrays ==-");

        // warm-up
        QuickSortBenchmarks.Sort_ReversedArray_Benchmark(100);

        // Actual benchmarks.
        QuickSortBenchmarks.Sort_ReversedArray_Benchmark(1000);
        QuickSortBenchmarks.Sort_ReversedArray_Benchmark(10000);
        QuickSortBenchmarks.Sort_ReversedArray_Benchmark(100000);
        QuickSortBenchmarks.Sort_ReversedArray_Benchmark(1000000);

        Console.WriteLine();
        Console.WriteLine("-== Equal arrays ==-");

        // warm-up
        QuickSortBenchmarks.Sort_EqualArray_Benchmark(100);

        // Actual benchmarks.
        QuickSortBenchmarks.Sort_EqualArray_Benchmark(1000);
        QuickSortBenchmarks.Sort_EqualArray_Benchmark(10000);
        QuickSortBenchmarks.Sort_EqualArray_Benchmark(100000);
        QuickSortBenchmarks.Sort_EqualArray_Benchmark(1000000);
    }

    private static void Run_HashtableBenchmarks()
    {
        // 100000 causes the hashtable to be full.
        var benchmarkValues = new List<int> { 10, 100, 1000, 10000 };
        BenchmarkHelper.StartBenchmark("Insert");
        foreach (int value in benchmarkValues)
        {
            HashtableBenchmarks.Insert_Benchmark(value);
            Console.WriteLine();
        }

        benchmarkValues = new List<int> { 10, 100, 1000, 10000 };
        BenchmarkHelper.StartBenchmark("Get");
        foreach (int value in benchmarkValues)
        {
            HashtableBenchmarks.Get_Benchmark(value);
            Console.WriteLine();
        }

        benchmarkValues = new List<int> { 10, 100, 1000, 10000 };
        BenchmarkHelper.StartBenchmark("Delete");
        foreach (int value in benchmarkValues)
        {
            HashtableBenchmarks.Delete_Benchmark(value);
            Console.WriteLine();
        }

        benchmarkValues = new List<int> { 10, 100, 1000, 10000 };
        BenchmarkHelper.StartBenchmark("Update");
        foreach (int value in benchmarkValues)
        {
            HashtableBenchmarks.Update_Benchmark(value);
            Console.WriteLine();
        }
    }
}