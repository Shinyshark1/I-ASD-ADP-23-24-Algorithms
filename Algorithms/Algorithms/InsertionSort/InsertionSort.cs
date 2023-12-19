namespace Algorithms.InsertionSort
{
    public static class InsertionSort
    {
        public static int[] Sort(int[] array)
        {
            var initialSortingIndex = 1;
            for (int i = initialSortingIndex; i < array.Length; i++)
            {
                int toBeInserted = array[i];
                int j = i;

                while (j > 0 && toBeInserted < array[j - 1])
                {
                    array[j] = array[j - 1];
                    j--;
                }

                array[j] = toBeInserted;
            }

            return array;
        }
    }
}
