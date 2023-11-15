using Algorithms.JsonData;
using Algorithms.JsonData.Sorteren.Models;
using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;

namespace Algorithms.DynamicArrays.Benchmarks
{
    [MemoryDiagnoser]
    public class DynamicArrayBenchmark_Shrink
    {
        public DynamicArray<int> PopulateData()
        {
            var sortingJson = JsonConstants.ReadDataSetSorting();
            return new DynamicArray<int>(JsonConvert.DeserializeObject<LijstHerhaald1000>(sortingJson).Content);
        }

        [Benchmark(Baseline = true)]
        public int HalfWhenPossible()
        {
            var data = PopulateData();
            for (int i = 0; i < data.Count; i++)
            {
                data.Remove(data[^1]);
            }

            return data.Count;
        }

        [Benchmark]
        public int ShrinkEachTime()
        {
            var data = PopulateData();
            for (int i = 0; i < data.Count; i++)
            {
                data.Remove_WithShrinkByOne(data[^1]);
            }

            return data.Count;
        }
    }
}
