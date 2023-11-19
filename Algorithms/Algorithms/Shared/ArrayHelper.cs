namespace Algorithms.Shared
{
    public class ArrayHelper
    {
        public static void CopyArray<T>(T[] source, T[] destination, int length)
        {
            if (source == null || destination == null)
            {
                throw new ArgumentNullException(source == null ? nameof(source) : nameof(destination));
            }

            if (length < 0 || length > source.Length || length > destination.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(length), "Length is out of range.");
            }

            for (int i = 0; i < length; i++)
            {
                destination[i] = source[i];
            }
        }
    }
}
