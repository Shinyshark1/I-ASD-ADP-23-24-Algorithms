namespace Algorithms.MergeSort
{
    public static class MergeSort
    {
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
            if (start < end)
            {
                int middle = (start + end) / 2;
                Parallel.Invoke(
                    () => MergeAndSort(array, temporaryArray, start, middle),
                    () => MergeAndSort(array, temporaryArray, middle + 1, end)
                );

                Merge(array, temporaryArray, start, middle, end);
            }
        }

        private static void MergeAndSortWithoutParallel(int[] array, int[] temporaryArray, int start, int end)
        {
            if (start < end)
            {
                int middle = (start + end) / 2;

                MergeAndSortWithoutParallel(array, temporaryArray, start, middle);
                MergeAndSortWithoutParallel(array, temporaryArray, middle + 1, end);

                Merge(array, temporaryArray, start, middle, end);
            }
        }

        private static void Merge(int[] array, int[] temporaryArray, int start, int middle, int end)
        {
            int startIndex = start;
            int rightIndex = middle + 1;
            int mergedIndex = start;

            while (startIndex <= middle && rightIndex <= end)
            {
                if (array[startIndex] <= array[rightIndex])
                {
                    temporaryArray[mergedIndex] = array[startIndex];
                    startIndex++;
                }
                else
                {
                    temporaryArray[mergedIndex] = array[rightIndex];
                    rightIndex++;
                }

                mergedIndex++;
            }

            while (startIndex <= middle)
            {
                temporaryArray[mergedIndex] = array[startIndex];
                startIndex++;
                mergedIndex++;
            }

            while (rightIndex <= end)
            {
                temporaryArray[mergedIndex] = array[rightIndex];
                rightIndex++;
                mergedIndex++;
            }

            for (int i = start; i <= end; i++)
            {
                array[i] = temporaryArray[i];
            }
        }
    }
}
