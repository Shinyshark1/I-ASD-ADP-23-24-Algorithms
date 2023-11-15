using Algorithms.JsonData;
using Algorithms.JsonData.Sorteren.Models;
using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;

namespace Algorithms.DynamicArrays.Benchmarks
{
    [MemoryDiagnoser]
    public class DynamicArrayBenchmark_Shrink
    {
        private DynamicArray<int> PopulateData()
        {
            var sortingJson = JsonConstants.ReadDataSetSorting();
            return new DynamicArray<int>(JsonConvert.DeserializeObject<LijstHerhaald1000>(sortingJson).Content);
        }

        [Benchmark(Baseline = true)]
        public void HalfWhenPossible()
        {
            var data = PopulateData();
            for (int i = 0; i < data.Count; i++)
            {
                Console.WriteLine($"Removing {i}/{data.Count}");
                data.Remove(data[^1]);
            }
        }

        [Benchmark]
        public void ShrinkEachTime()
        {
            var data = PopulateData();
            for (int i = 0; i < data.Count; i++)
            {
                Console.WriteLine($"Removing {i}/{data.Count}");
                data.Remove_WithShrinkByOne(data[^1]);
            }
        }
    }
}
