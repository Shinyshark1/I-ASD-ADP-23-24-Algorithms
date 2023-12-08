namespace Algorithms.Hashtable
{
    public class Hashtable<T> : IHashtable<T>
    {
        // We use 10.007 as it is a prime number nearest to 10.000
        private const int _hashtablePrimeNumber = 10007;
        private KeyValuePair<string, T>[] _items;

        public Hashtable(int size = _hashtablePrimeNumber)
        {
            _items = new KeyValuePair<string, T>[size];
        }

        public void Insert(string key, T value)
        {
            // A key is required, otherwise we can never find the value.
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new InvalidOperationException("The provided key cannot be empty.");
            }

            // We check for duplicates, as they are not allowed in our hashtable.
            int? potentialKeyIndex = GetKeyIndex(key);
            if (potentialKeyIndex != null)
            {
                throw new InvalidOperationException($"Duplicate keys are not allowed in this hashtable. Offending key: '{key}'");
            }

            int hashedIndex = HashFunction(key);
            if (_items[hashedIndex].Key != null)
            {
                hashedIndex = FindNextLinearHashedIndex(hashedIndex, hashedIndex + 1);
            }

            _items[hashedIndex] = new KeyValuePair<string, T>(key, value);
        }

        public T Get(string key)
        {
            int? potentialKeyIndex = GetKeyIndex(key);
            if (potentialKeyIndex is not int keyIndex)
            {
                return default;
            }

            return _items[keyIndex].Value;
        }

        public bool Update(string key, T value)
        {
            int? potentialKeyIndex = GetKeyIndex(key);
            if (potentialKeyIndex is not int keyIndex)
            {
                return false;
            }

            _items[keyIndex] = new KeyValuePair<string, T>(key, value);
            return true;
        }

        public bool Delete(string key)
        {
            int? potentialKeyIndex = GetKeyIndex(key);
            if (potentialKeyIndex is not int keyIndex)
            {
                return false;
            }

            string keyValue = null;
            if (_items[GetNextIndex(keyIndex)].Key != null)
            {
                // We have to lazy delete this as the next key is not empty, so we might be part of a chain of keys.
                keyValue = string.Empty;
            }

            _items[keyIndex] = new KeyValuePair<string, T>(keyValue, default(T));
            return true;
        }


        private int FindNextLinearHashedIndex(int startingPosition, int hashedIndex)
        {
            // If we have found a free spot, we return that index.
            if (_items[hashedIndex].Key == null || _items[hashedIndex].Key == string.Empty)
            {
                return hashedIndex;
            }

            // If our search is about to get us out of bounds, we begin from index 0.
            if (hashedIndex == _items.Length - 1)
            {
                // We set it  to -1 to counteract the +1 in the recursive call.
                hashedIndex = -1;
            }

            // If we've gone all the way around and we were still unable to find a position, we throw an exception.
            if (hashedIndex == startingPosition)
            {
                throw new Exception("There is no more space in the hashtable.");
            }

            return FindNextLinearHashedIndex(startingPosition, hashedIndex + 1);
        }

        /// <summary>
        /// Retrieves the actual index for the key.
        /// This takes into account wrapping around the array to attempt and find the index.
        /// </summary>
        /// <returns>The index of the key if it is found, otherwise null.</returns>
        private int? GetKeyIndex(string key)
        {
            int hashedIndex = HashFunction(key);
            for (int i = hashedIndex; i < _items.Length; i++)
            {
                // If our index would exceed the lenght of our hashtable, we return to the start.
                if (i > _items.Length - 1)
                {
                    i = 0;
                }

                // The chain has been broken so we can stop searching; our key will not appear further ahead.
                if (_items[i].Key == null)
                {
                    break;
                }

                if (_items[i].Key == key)
                {
                    return i;
                }
            }

            return null;
        }

        /// <summary>
        /// Returns the next index, keeping in mind the possibility that our next index would be the start of the array.
        /// </summary>
        private int GetNextIndex(int currentIndex)
        {
            // If our current index is larger than or equal to the size of the array
            // we return the index starting from 0 minus the length of the array.
            if (currentIndex >= _items.Length - 1)
            {
                return currentIndex - (_items.Length - 1);
            }

            return currentIndex;
        }

        private int HashFunction(string key)
        {
            int total = 0;
            foreach (char letter in key.ToLower())
            {
                // We minus 97 as 'a' is 97 in ASCII. We want 0 to be the lowest available index.
                total += letter - 97;
            }

            return total % _hashtablePrimeNumber;
        }
    }
}
