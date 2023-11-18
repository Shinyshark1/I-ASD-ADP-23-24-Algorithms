using Algorithms.JsonData;
using Algorithms.JsonData.Sorteren.Models;
using Algorithms.Shared;
using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Algorithms.DynamicArrays.Benchmarks
{
    [MemoryDiagnoser]
    public class DynamicArrayBenchmarks
    {
        public static IEnumerable<DynamicArray<int>> Data => new[]
        {
            new DynamicArray<int>(JsonConvert.DeserializeObject<LijstOplopend10000>(JsonConstants.ReadDataSetSorting()).Content)
        };

        [Benchmark(Baseline = true)]
        [ArgumentsSource(nameof(Data))]
        public bool HalfWhenPossible(DynamicArray<int> array)
        {
            var count = array.Count;
            for (int i = 0; i < count; i++)
            {
                array.Remove(array[^1]);
            }

            return false;
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public bool ShrinkEachTime(DynamicArray<int> array)
        {
            var count = array.Count;
            for (int i = 0; i < count; i++)
            {
                array.Remove_WithShrinkByOne(array[^1]);
            }

            return false;
        }

        /// <summary>
        /// The idea is that shrinking takes more time than halving, as shrinking would copy the array far more than halving.
        /// If you have 10.000 items, you halve at 5000 whereas you would shrink 5000 times by the time you reach 5000.
        /// </summary>
        public void Shrink_Benchmarks()
        {
            Console.WriteLine("Starting shrink benchmark.");
            DynamicArray<int> testData;
            var sw = new Stopwatch();

            testData = new DynamicArray<int>(JsonConvert.DeserializeObject<LijstOplopend10000>(JsonConstants.ReadDataSetSorting()).Content);

            sw.Start();
            HalfWhenPossible(testData);
            sw.Stop();

            var firstResult = sw.Elapsed;
            Console.WriteLine($"Half: {firstResult}");

            sw.Reset();

            testData = new DynamicArray<int>(JsonConvert.DeserializeObject<LijstOplopend10000>(JsonConstants.ReadDataSetSorting()).Content);

            sw.Start();
            ShrinkEachTime(testData);
            sw.Stop();

            var secondResult = sw.Elapsed;
            Console.WriteLine($"Shrink: {secondResult}");

            Console.WriteLine($"Ratio #1: {RatioCalculator.CalculateTimeSpanRatio(firstResult, firstResult)}");
            Console.WriteLine($"Ratio #2: {RatioCalculator.CalculateTimeSpanRatio(firstResult, secondResult)}");
        }
    }
}
