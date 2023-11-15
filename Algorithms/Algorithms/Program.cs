// See https://aka.ms/new-console-template for more information

using Algorithms.DynamicArrays;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

public class Program
{
    private static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<DynamicArrayBenchmarks>();

        //var sortingJson = JsonConstants.ReadDataSetSorting();

        //var result1 = new DynamicArray<int>(JsonConvert.DeserializeObject<LijstAflopend2>(sortingJson).Content);
        //var result2 = new DynamicArray<int>(JsonConvert.DeserializeObject<LijstOplopend2>(sortingJson).Content);
        //var result3 = new DynamicArray<double>(JsonConvert.DeserializeObject<LijstFloat8001>(sortingJson).Content);
        //var result4 = new DynamicArray<int>(JsonConvert.DeserializeObject<LijstGesorteerdAflopend3>(sortingJson).Content);
        //var result5 = new DynamicArray<int>(JsonConvert.DeserializeObject<LijstGesorteerdOplopend3>(sortingJson).Content);
        //var result6 = new DynamicArray<int>(JsonConvert.DeserializeObject<LijstHerhaald1000>(sortingJson).Content);
        //var result7 = new DynamicArray<object>(JsonConvert.DeserializeObject<LijstLeeg0>(sortingJson).Content);
        //var result8 = new DynamicArray<object>(JsonConvert.DeserializeObject<LijstNull1>(sortingJson).Content);
        //var result9 = new DynamicArray<int?>(JsonConvert.DeserializeObject<LijstNull3>(sortingJson).Content);
        //var result10 = new DynamicArray<int>(JsonConvert.DeserializeObject<LijstOplopend10000>(sortingJson).Content);
        //var result11 = new DynamicArray<int>(JsonConvert.DeserializeObject<LijstWillekeurig10000>(sortingJson).Content);
        //var result12 = new DynamicArray<int>(JsonConvert.DeserializeObject<LijstWillekeurig3>(sortingJson).Content);

        //Console.WriteLine("Test");
    }

    public class DemoBenchmark
    {
        [Benchmark]
        public void TestAdd()
        {
        }

        [Benchmark]
        public void TestMinus()
        {
        }

        [Benchmark]
        public void TestMultiply()
        {
        }

        [Benchmark]
        public void TestDivide()
        {
        }
    }
}