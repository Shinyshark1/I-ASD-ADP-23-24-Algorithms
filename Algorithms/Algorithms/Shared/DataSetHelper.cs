namespace Algorithms.Shared
{
    public static class DataSetHelper
    {
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
    }
}
