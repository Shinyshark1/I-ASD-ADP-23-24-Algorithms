namespace Algorithms.QuickSort
{
    public class QuickSort
    {
        public static int[] Sort(int[] array)
        {
            InternalQuickSort(array, 0, array.Length - 1);
            return array;
        }

        private static int[] InternalQuickSort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(array, low, high);
                Parallel.Invoke(
                    () => InternalQuickSort(array, low, pivotIndex - 1),
                    () => InternalQuickSort(array, pivotIndex + 1, high)
                );
            }

            return array;
        }

        public static int[] Sort_WithoutParallel(int[] array)
        {
            InternalQuickSort_WithoutParallel(array, 0, array.Length - 1);
            return array;
        }

        private static int[] InternalQuickSort_WithoutParallel(int[] array, int low, int high)
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
            int pivotIndex = DeterminePivotIndex(array, low, high);
            Swap(array, pivotIndex, high);
            int pivotValue = array[high];

            int i = low - 1;
            for (int j = low; j < high; j++)
            {
                if (array[j] < pivotValue)
                {
                    i++;
                    Swap(array, i, j);
                }
            }

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
