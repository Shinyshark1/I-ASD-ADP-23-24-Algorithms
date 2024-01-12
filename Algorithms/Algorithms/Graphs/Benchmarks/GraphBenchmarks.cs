using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Graphs.Benchmarks
{
    public static class GraphBenchmarks
    {
        public static void AddVertex_Benchmark(int size)
        {
            var graph = new Graph();
            var sw = new Stopwatch();

            Console.WriteLine($"Starting AddVertex benchmark with {size} items.");
            sw.Start();
            for (int i = 0; i < size; i++)
            {
                graph.AddVertex($"{i}");
            }

            sw.Stop();
            Console.WriteLine($"Size: {size} - Elapsed time: {sw.Elapsed}");
        }

        public static void RemoveVertex_Benchmark(int size)
        {
            var graph = new Graph();
            for (int i = 0; i < size; i++)
            {
                graph.AddVertex($"{i}");
            }

            var sw = new Stopwatch();

            Console.WriteLine($"Starting RemoveVertex benchmark with {size} items.");
            sw.Start();
            for (int i = 0; i < size; i++)
            {
                graph.RemoveVertex($"{i}");
            }

            sw.Stop();
            Console.WriteLine($"Size: {size} - Elapsed time: {sw.Elapsed}");
        }

        public static void AddEdge_Benchmark(int size)
        {
            var graph = new Graph();
            for (int i = 0; i < size; i++)
            {
                graph.AddVertex($"{i}");
            }

            var random = new Random();
            var sw = new Stopwatch();

            Console.WriteLine($"Starting AddEdge benchmark with {size} items.");
            sw.Start();

            for (int i = 0; i < size; i++)
            {
                var randomVertex = random.Next(size);
                if(randomVertex == i)
                {
                    randomVertex++;
                }

                var currentVertex = graph.GetVertex($"{i}");
                var adjacentVertex = graph.GetVertex($"{randomVertex}");
                graph.AddEdge(currentVertex, adjacentVertex, 0);
            }

            sw.Stop();
            Console.WriteLine($"Size: {size} - Elapsed time: {sw.Elapsed}");
        }

        // Unweighted

        // Weighted
    }
}
