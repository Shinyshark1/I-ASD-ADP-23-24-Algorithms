namespace Algorithms.MergeSort
{
    /// <summary>
    /// TODO: Make it parallel
    /// </summary>
    public static class MergeSort
    {
        // When comparing two arrays, if there is a tie between the values we take the start value.
        // This causes the Merge Sort to be stable; it had a smaller index at the start and it keeps a smaller index in the end.

        public static int[] Sort(int[] array)
        {
            int[] temporaryArray = new int[array.Length];
            MergeAndSort(array, temporaryArray, 0, array.Length - 1);

            return array;
        }

        public static int[] SortWithoutParallel(int[] array)
        {
            int[] temporaryArray = new int[array.Length];
            MergeAndSortWithoutParallel(array, temporaryArray, 0, array.Length - 1);

            return array;
        }

        private static void MergeAndSort(int[] array, int[] temporaryArray, int start, int end)
        {
            // This makes sure that we stop when we have only one element, as the middle would be 0.5 (which is 0 as integer)
            if (start < end)
            {
                int middle = (start + end) / 2;

                // Parallelize the recursive calls
                Parallel.Invoke(
                    () => MergeAndSort(array, temporaryArray, start, middle),
                    () => MergeAndSort(array, temporaryArray, middle + 1, end)
                );

                // When the start side is all the way deconstructed to singular items
                // And the end side if all the way deconstructed to singular items
                // All of the recursive methods will continue into this merge.
                Merge(array, temporaryArray, start, middle, end);
            }
        }

        private static void MergeAndSortWithoutParallel(int[] array, int[] temporaryArray, int start, int end)
        {
            // This makes sure that we stop when we have only one element, as the middle would be 0.5 (which is 0 as integer)
            if (start < end)
            {
                int middle = (start + end) / 2;

                // We merge and sort the start side all the way down.
                MergeAndSortWithoutParallel(array, temporaryArray, start, middle);
                // We merge and sort the end side all the way down
                MergeAndSortWithoutParallel(array, temporaryArray, middle + 1, end);

                // When the start side is all the way deconstructed to singular items
                // And the end side if all the way deconstructed to singular items
                // All of the recursive methods will continue into this merge.
                Merge(array, temporaryArray, start, middle, end);
            }
        }

        private static void Merge(int[] array, int[] temporaryArray, int start, int middle, int end)
        {
            int startIndex = start;
            int rightIndex = middle + 1;
            int mergedIndex = start;

            // We sort until we have exhausted either side completely.
            while (startIndex <= middle && rightIndex <= end)
            {
                // If our left hand item is smaller or equal to our right hand item, we insert our left hand item.
                if (array[startIndex] <= array[rightIndex])
                {
                    temporaryArray[mergedIndex] = array[startIndex];
                    startIndex++;
                }
                // Otherwise we insert our right hand item.
                else
                {
                    temporaryArray[mergedIndex] = array[rightIndex];
                    rightIndex++;
                }

                mergedIndex++;
            }

            // Copy over the remaining elements from the left hand side.
            while (startIndex <= middle)
            {
                temporaryArray[mergedIndex] = array[startIndex];
                startIndex++;
                mergedIndex++;
            }

            // Copy over the remaining elements from the right hand side.
            while (rightIndex <= end)
            {
                temporaryArray[mergedIndex] = array[rightIndex];
                rightIndex++;
                mergedIndex++;
            }

            // Copy the merged elements back to the original array.
            // This allows us to not have to make new arrays each time.
            // By using 'start' and 'end', we move the parts of the array that were used in this current merge.
            for (int i = start; i <= end; i++)
            {
                array[i] = temporaryArray[i];
            }
        }
    }
}
