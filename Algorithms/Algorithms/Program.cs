// See https://aka.ms/new-console-template for more information

using Algorithms.JsonData;
using Algorithms.JsonData.Sorteren.Models;
using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;

public class Program
{
    private static void Main(string[] args)
    {
        var sortingJson = JsonConstants.ReadDataSetSorting();

        var result1 = JsonConvert.DeserializeObject<LijstAflopend2>(sortingJson);
        var result2 = JsonConvert.DeserializeObject<LijstOplopend2>(sortingJson);
        var result3 = JsonConvert.DeserializeObject<LijstFloat8001>(sortingJson);
        var result4 = JsonConvert.DeserializeObject<LijstGesorteerdAflopend3>(sortingJson);
        var result5 = JsonConvert.DeserializeObject<LijstGesorteerdOplopend3>(sortingJson);
        var result6 = JsonConvert.DeserializeObject<LijstHerhaald1000>(sortingJson);
        var result7 = JsonConvert.DeserializeObject<LijstLeeg0>(sortingJson);
        var result8 = JsonConvert.DeserializeObject<LijstNull1>(sortingJson);
        var result9 = JsonConvert.DeserializeObject<LijstNull3>(sortingJson);
        var result10 = JsonConvert.DeserializeObject<LijstOplopend10000>(sortingJson);
        var result11 = JsonConvert.DeserializeObject<LijstWillekeurig10000>(sortingJson);
        var result12 = JsonConvert.DeserializeObject<LijstWillekeurig3>(sortingJson);

        Console.WriteLine("lol");
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