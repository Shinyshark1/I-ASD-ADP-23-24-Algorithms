namespace Algorithms.DynamicArrays
{
    public interface IDynamicArray<T>
    {
        T this[int index] { get; set; }

        /// <summary>
        /// Adds the item to the end of the <see cref="IDynamicArray{T}"/>.
        /// </summary>
        public void Add(T item);

        /// <summary>
        /// Adds the item to the <see cref="IDynamicArray{T}"/> at the specified index.
        /// TODO: Write about how this will throw an OutOfRange exception
        /// </summary>
        public void Insert(int index, T item);

        /// <summary>
        /// Attempts to remove the item from the <see cref="DynamicArray{T}"/> if it exists.
        /// Returns true if it was succesfully removed and false if it was not removed.
        /// </summary>
        public bool Remove(T item);

        /// <summary>
        /// Attempts to remove the item from the specified index in the <see cref="DynamicArray{T}"/>.
        /// </summary>
        public bool RemoveAtIndex(int index);

        /// <summary>
        /// Returns the amount of items in the <see cref="IDynamicArray{T}"/>.
        /// </summary>
        public int Count { get; }

        /// <summary>
        /// Empties the <see cref="IDynamicArray{T}"/>.
        /// </summary>
        public void Clear();

        /// <summary>
        /// Checks if the provided item exists in the <see cref="IDynamicArray{T}"/>.
        /// </summary>
        public bool Contains(T item);
    }
}
