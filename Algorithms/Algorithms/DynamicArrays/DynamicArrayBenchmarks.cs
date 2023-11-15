using BenchmarkDotNet.Attributes;

namespace Algorithms.DynamicArrays
{
    public class DynamicArrayBenchmarks
    {
        [Benchmark(Baseline = true)]
        public void CallName()
        {
            Console.WriteLine("Alan!");
        }

        [Benchmark]
        public void CallNameManyTimes()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Alan!");
            }
        }
    }
}
