namespace Algorithms.SelectionSort
{
    public static class SelectionSort
    {
        public static int[] Sort(int[] array)
        {
            int arrayLength = array.Length;
            for (int currentIndex = 0; currentIndex < arrayLength - 1; currentIndex++)
            {
                int indexWithLowestNumber = currentIndex;
                for (int compareIndex = currentIndex + 1; compareIndex < arrayLength; compareIndex++)
                {
                    if (array[compareIndex] < array[indexWithLowestNumber])
                    {
                        indexWithLowestNumber = compareIndex;
                    }
                }

                (array[currentIndex], array[indexWithLowestNumber]) = (array[indexWithLowestNumber], array[currentIndex]);
            }

            return array;
        }
    }
}
