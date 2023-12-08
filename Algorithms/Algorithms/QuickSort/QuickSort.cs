namespace Algorithms.QuickSort
{
    public class QuickSort
    {
        public static int[] Sort(int[] array)
        {
            InternalQuickSort(array, 0, array.Length - 1);
            return array;
        }

        // This works in the same way as the Merge Sort.
        private static int[] InternalQuickSort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(array, low, high);
                InternalQuickSort(array, low, pivotIndex - 1);
                InternalQuickSort(array, pivotIndex + 1, high);
            }

            return array;
        }

        private static int Partition(int[] array, int low, int high)
        {
            // We find the pivot index by using our median strategy.
            int pivotIndex = DeterminePivotIndex(array, low, high);

            // We have to swap our pivot to the end of our current selection so that it is in the right spot.
            Swap(array, pivotIndex, high);

            // Now that our pivot has been swapped to be in the right position, we can pick it up from our high spot.
            int pivot = array[high];

            int i = low - 1;
            for (int j = low; j < high; j++)
            {
                // If we find an item that is smaller than our pivot we move it to the low part of our array.
                // We keep moving our low part up by one each time this happens.
                if (array[j] < pivot)
                {
                    i++;
                    Swap(array, i, j);
                }
            }

            // Now that we're done, we move our pivot behind all the items that were smaller than it and infront of all the items that were larger than it.
            Swap(array, i + 1, high);
            return i + 1;
        }

        private static int DeterminePivotIndex(int[] array, int lowIndex, int highIndex)
        {
            int middleIndex = (lowIndex + highIndex) / 2;
            var median = DetermineMedian(array[lowIndex], array[middleIndex], array[highIndex]);

            if (median == array[lowIndex])
            {
                return lowIndex;
            }

            if (median == array[middleIndex])
            {
                return middleIndex;
            }

            return highIndex;
        }

        private static void Swap(int[] array, int i, int j)
        {
            (array[i], array[j]) = (array[j], array[i]);
        }

        private static int DetermineMedian(int num1, int num2, int num3)
        {
            if ((num2 < num1 && num1 < num3) || (num2 > num1 && num1 > num3))
            {
                return num1;
            }

            if ((num1 < num2 && num2 < num3) || (num1 > num2 && num2 > num3))
            {
                return num2;
            }

            return num3;
        }
    }
}
