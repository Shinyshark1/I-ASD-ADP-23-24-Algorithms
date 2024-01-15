using System.Diagnostics;

namespace Algorithms.AVLSearchTree.Benchmarks
{
    public static class AvlSearchTreeBenchmarks
    {
        public static void Find_Benchmark(int size)
        {
            var avlSearchTree = new AvlSearchTree();
            for (int i = 0; i < size; i++)
            {
                avlSearchTree.Insert(i);
            }

            Console.WriteLine($"Starting Find benchmark with {size} items.");
            var sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < size; i++)
            {
                avlSearchTree.Find(i);
            }

            sw.Stop();
            Console.WriteLine($"Size: {size} - Elapsed time: {sw.Elapsed}");
        }

        public static void FindMaximum_Benchmark(int size)
        {
            var avlSearchTree = new AvlSearchTree();
            for (int i = 0; i < size; i++)
            {
                avlSearchTree.Insert(i);
            }

            Console.WriteLine($"Starting FindMaximum benchmark with {size} items.");
            var sw = new Stopwatch();
            sw.Start();

            avlSearchTree.FindMaximum();

            sw.Stop();
            Console.WriteLine($"Size: {size} - Elapsed time: {sw.Elapsed}");
        }

        public static void FindMinimum_Benchmark(int size)
        {
            var avlSearchTree = new AvlSearchTree();
            for (int i = 0; i < size; i++)
            {
                avlSearchTree.Insert(i);
            }

            Console.WriteLine($"Starting FindMinimum benchmark with {size} items.");
            var sw = new Stopwatch();
            sw.Start();

            avlSearchTree.FindMinimum();

            sw.Stop();
            Console.WriteLine($"Size: {size} - Elapsed time: {sw.Elapsed}");
        }

        // Insert
        public static void Insert_Benchmark(int size)
        {
            var avlSearchTree = new AvlSearchTree();
            var sw = new Stopwatch();

            Console.WriteLine($"Starting Insert benchmark with {size} items.");
            sw.Start();
            for (int i = 0; i < size; i++)
            {
                avlSearchTree.Insert(i);
            }

            sw.Stop();
            Console.WriteLine($"Size: {size} - Elapsed time: {sw.Elapsed}");
        }

        // Remove
        public static void Remove_Benchmark(int size)
        {
            var avlSearchTree = new AvlSearchTree();
            for (int i = 0; i < size; i++)
            {
                avlSearchTree.Insert(i);
            }

            Console.WriteLine($"Starting Remove benchmark with {size} items.");
            var sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < size; i++)
            {
                avlSearchTree.Remove(i);
            }

            sw.Stop();
            Console.WriteLine($"Size: {size} - Elapsed time: {sw.Elapsed}");
        }

    }
}
