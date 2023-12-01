namespace Algorithms.SelectionSort
{
    public static class SelectionSort
    {
        public static int[] Sort(int[] array)
        {
            int arrayLength = array.Length;

            // We start out on the left hand side of the array.
            // We check up to the second to last index; this is because everything should already be sorted by then.
            // Checking the last index should not cause a sort.
            for (int currentIndex = 0; currentIndex < arrayLength - 1; currentIndex++)
            {
                // We keep track of the index with the lowest number. 
                int indexWithLowestNumber = currentIndex;

                // Then we move to the right through the array, skipping the index we are already on.
                for (int compareIndex = currentIndex + 1; compareIndex < arrayLength; compareIndex++)
                {
                    // If the index we are checking has a value that is lower than the value of our index with the lowest number,
                    // we update the index with the lowest number.
                    if (array[compareIndex] < array[indexWithLowestNumber])
                    {
                        indexWithLowestNumber = compareIndex;
                    }
                }

                // Once we've gone through a full iteration of moving right, we have our lowest number in the indexWithLowestNumber.
                // We must now swap it to our currentIndex in the left hand side loop.
                // Our currentIndex then moves up by one, leaving the lowest number out of future iterations.
                (array[currentIndex], array[indexWithLowestNumber]) = (array[indexWithLowestNumber], array[currentIndex]);
            }

            return array;
        }
    }
}
