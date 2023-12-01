namespace Algorithms.Tests.Shared
{
    public static class SortHelper
    {
        public static bool IsSorted(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                // If our current index is larger than our next index, the sort was unsuccesful.
                if (array[i] > array[i + 1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
