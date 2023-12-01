namespace Algorithms.InsertionSort
{
    public static class InsertionSort
    {
        public static int[] Sort(int[] array)
        {
            // We start our sort from the 2nd index of our array.
            // This is because the 1st index of the array will be used for our initial sort.
            var initialSortingIndex = 1;

            for (int i = initialSortingIndex; i < array.Length; i++)
            {
                // We collect the value of our sorting index.
                int toBeInserted = array[i];

                // We set our j to be equal to i, that way we can track the swap items by moving one index back.
                int j = i;

                // We move backwards through our array to see if our current value is smaller than the preceeding value.
                // We always check if j is larger than 0, as 0 - 1 would result in an IndexOutOfBoundsException.
                while (j > 0 && toBeInserted < array[j - 1])
                {
                    // If it is the case, we move the larger number up one position.
                    // This means we temporarily lose our toBeInserted array value.
                    // Luckily, we have it saved in our toBeInserted variable.
                    array[j] = array[j - 1];

                    // We deduce j by one so that we can keep moving backwards.
                    j--;
                }

                // When we break out of the loop, our toBeInserted item is on the right index.
                // We can then set our toBeInserted value back in the array; causing it to reappear.
                array[j] = toBeInserted;
            }

            return array;
        }
    }
}
