using System;
using System.Collections.Generic;

namespace Algorithms.Shared
{
    public static class DataSetHelper
    {
        private static readonly Random _random = new();
        public static string RandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Creates an array of ints in order from 1 to whatever size you give.
        /// </summary>
        /// <param name="size">The size the array should be.</param>
        public static int[] CreateOrderedDataSet(int size)
        {
            int[] data = new int[size];
            for (int i = 0; i < size; i++)
            {
                data[i] = i + 1;
            }

            return data;
        }

        /// <summary>
        /// Creates an array of ints in reversed order.
        /// </summary>
        /// <param name="size">The size the array should be.</param>
        public static int[] CreateReversedDataSet(int size)
        {
            int[] data = new int[size];
            var j = 1;
            for (int i = size - 1; i >= 0; i--)
            {
                data[i] = j;
                j++;
            }

            return data;
        }

        /// <summary>
        /// Creates an array that has all the same numbers.
        /// </summary>
        /// <param name="size">The size the array should be.</param>
        /// <param name="number">The number you want the array to have.</param>
        public static int[] CreateEqualDataSet(int size, int number = 42)
        {
            int[] data = new int[size];
            for (int i = 0; i < size; i++)
            {
                data[i] = number;
            }

            return data;
        }

        /// <summary>
        /// Creates an array of random ints.
        /// </summary>
        /// <param name="size">The size the array should be.</param>
        /// <param name="mininumInt">The lowest number you want to exist in your array.</param>
        /// <param name="maximumInt">The highest number you want to exist in your array.</param>
        public static int[] CreateRandomDataSet(int size, int mininumInt = 1, int maximumInt = 100)
        {
            maximumInt++; // Random takes the maximumInt as upper limit, so to get 100 as max, we have to provide 101.
            var randomGenerator = new Random();


            int[] data = new int[size];
            for (int i = 0; i < size; i++)
            {
                data[i] = randomGenerator.Next(mininumInt, maximumInt);
            }

            return data;
        }

        public static Dictionary<string, int> CreateRandomKeyValuePairs(int size)
        {
            var dictionary = new Dictionary<string, int>();
            for (int i = 0; i < size; i++)
            {
                var randomKey = RandomString(8);
                dictionary.Add(randomKey, _random.Next(size));
            }
            return dictionary;
        }

        /// <summary>
        /// Creates a line list for graphing purposes.
        /// </summary>
        /// <param name="amountOfVertices">How many vertices should be made.</param>
        /// <param name="minimumEdges">The amount of edges a vertex must have at the very least.</param>
        /// <param name="maximumEdges">The amount of edges a vertex may have at the most.</param>
        /// <param name="maximumCost">The maximum cost per node. The cost is randomly determined between 1 and this number. Leave this null if a cost is not desired.</param>
        /// <returns></returns>
        public static List<List<int>> CreateRandomLineList(int amountOfVertices, int minimumEdges, int maximumEdges, int? maximumCost = null)
        {
            var random = new Random();
            var list = new List<List<int>>();

            for (int i = 0; i < amountOfVertices; i++)
            {
                var currentConnections = new List<int>();
                var amountOfEdges = random.Next(minimumEdges, maximumEdges);
                for (int j = 0; j < amountOfEdges; j++)
                {
                    var connection = random.Next(amountOfVertices);
                    while (connection == i || currentConnections.Contains(connection))
                    {
                        connection = random.Next(amountOfVertices);
                    }

                    currentConnections.Add(connection);
                    if(maximumCost is int convertedCost)
                    {
                        list.Add(new List<int> { i, connection, random.Next(1, convertedCost) });
                    }
                    else
                    {
                        list.Add(new List<int> { i, connection });
                    }
                }
            }

            return list;
        }
    }
}
