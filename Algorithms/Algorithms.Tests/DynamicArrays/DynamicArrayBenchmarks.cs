using BenchmarkDotNet.Attributes;

namespace Algorithms.Tests.DynamicArrays
{
    [SimpleJob(launchCount: 3, warmupCount: 10, iterationCount: 50)]
    [SimpleJob(launchCount: 3, warmupCount: 10, iterationCount: 100)]
    public class DynamicArrayBenchmarks
    {
        [Benchmark]
        public void CallName()
        {
            Console.WriteLine("Alan!");
        }
    }
}
