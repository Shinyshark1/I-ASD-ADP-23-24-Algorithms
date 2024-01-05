using Algorithms.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Hashtable.Benchmarks
{
    public static class HashtableBenchmarks
    {
        // Insert
        public static void Insert_Benchmark(int size)
        {
            var hashtable = new Hashtable<int>();
            var keyValuePairs = DataSetHelper.CreateRandomKeyValuePairs(size);

            Console.WriteLine($"Starting Insert benchmark with {size} items.");
            var sw = new Stopwatch();
            sw.Start();

            foreach (var keyValuePair in keyValuePairs) 
            {
                hashtable.Insert(keyValuePair.Key, keyValuePair.Value);
            }

            sw.Stop();
            Console.WriteLine($"Size: {size} - Elapsed time: {sw.Elapsed}");
        }

        // Get
        public static void Get_Benchmark(int size)
        {
            var hashtable = new Hashtable<int>();
            var random = new Random();
            var keyValuePairs = DataSetHelper.CreateRandomKeyValuePairs(size);

            string key = string.Empty;
            int randomIndex = random.Next(size);
            for (int i = 0; i < keyValuePairs.Count; i++)
            {
                var keyValuePair = keyValuePairs.ElementAt(i);
                hashtable.Insert(keyValuePair.Key, keyValuePair.Value);
                if(i == randomIndex)
                {
                    key = keyValuePair.Key;
                }
            }

            Console.WriteLine($"Starting Get benchmark with {size} items, using key '{key}'");
            var sw = new Stopwatch();
            sw.Start();

            hashtable.Get(key);

            sw.Stop();
            Console.WriteLine($"Size: {size} - Elapsed time: {sw.Elapsed}");
        }

        // Delete
        public static void Delete_Benchmark(int size)
        {
            var hashtable = new Hashtable<int>();
            var keyValuePairs = DataSetHelper.CreateRandomKeyValuePairs(size);

            for (int i = 0; i < keyValuePairs.Count; i++)
            {
                var keyValuePair = keyValuePairs.ElementAt(i);
                hashtable.Insert(keyValuePair.Key, keyValuePair.Value);
            }

            Console.WriteLine($"Starting Delete benchmark with {size} items");
            var sw = new Stopwatch();
            sw.Start();

            foreach (var keyValuePair in keyValuePairs)
            {
                hashtable.Delete(keyValuePair.Key);
            }

            sw.Stop();
            Console.WriteLine($"Size: {size} - Elapsed time: {sw.Elapsed}");
        }

        // Update
        public static void Update_Benchmark(int size)
        {
            var hashtable = new Hashtable<int>();
            var keyValuePairs = DataSetHelper.CreateRandomKeyValuePairs(size);

            for (int i = 0; i < keyValuePairs.Count; i++)
            {
                var keyValuePair = keyValuePairs.ElementAt(i);
                hashtable.Insert(keyValuePair.Key, keyValuePair.Value);
            }

            Console.WriteLine($"Starting Update benchmark with {size} items");
            var sw = new Stopwatch();
            sw.Start();

            foreach (var keyValuePair in keyValuePairs)
            {
                hashtable.Update(keyValuePair.Key, 1337);
            }

            sw.Stop();
            Console.WriteLine($"Size: {size} - Elapsed time: {sw.Elapsed}");
        }
    }
}
