using Algorithms.JsonData;
using Algorithms.JsonData.Sorteren.Models;
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
                array.Remove(array[0]);
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
                array.Remove_WithShrinkByOne(array[0]);
            }

            return false;
        }

        /// <summary>
        /// The idea is that shrinking takes more time than halving, as shrinking would copy the array far more than halving.
        /// If you have 10.000 items, you halve at 5000 whereas you would shrink 5000 times by the time you reach 5000.
        /// </summary>
        public void CustomBenchmark()
        {
            Console.WriteLine("Starting benchmark...");
            var sw = new Stopwatch();

            sw.Start();
            ShrinkEachTime(new DynamicArray<int>(JsonConvert.DeserializeObject<LijstOplopend10000>(JsonConstants.ReadDataSetSorting()).Content));
            sw.Stop();

            sw.Reset();

            Console.WriteLine($"{nameof(ShrinkEachTime)} - Elapsed time: {sw.Elapsed}");

            sw.Start();
            HalfWhenPossible(new DynamicArray<int>(JsonConvert.DeserializeObject<LijstOplopend10000>(JsonConstants.ReadDataSetSorting()).Content));
            sw.Stop();

            Console.WriteLine($"{nameof(HalfWhenPossible)} - Elapsed time: {sw.Elapsed}");
        }
    }
}
