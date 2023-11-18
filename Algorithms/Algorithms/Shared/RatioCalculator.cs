namespace Algorithms.Shared
{
    public class RatioCalculator
    {
        /// <summary>
        /// Calculates the ratio of two integers.
        /// </summary>
        /// <param name="numerator">The numerator.</param>
        /// <param name="denominator">The denominator.</param>
        /// <returns>The ratio as a double, or double.NaN if the denominator is zero.</returns>
        public static double CalculateRatio(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                // Handle division by zero
                // You might want to handle this differently depending on your requirements
                return double.NaN;
            }

            return (double)numerator / denominator;
        }

        /// <summary>
        /// Calculates the ratio of two TimeSpan values.
        /// </summary>
        /// <param name="baseTimeSpan">The base TimeSpan (e.g., normal remove time).</param>
        /// <param name="compareToTimeSpan">The TimeSpan to compare to the base (e.g., recursive remove time).</param>
        /// <returns>The ratio as a double, or double.NaN if the base TimeSpan is zero.</returns>
        public static double CalculateTimeSpanRatio(TimeSpan baseTimeSpan, TimeSpan compareToTimeSpan)
        {
            if (baseTimeSpan == TimeSpan.Zero)
            {
                // Handle division by zero
                return double.NaN;
            }

            return compareToTimeSpan.TotalMilliseconds / baseTimeSpan.TotalMilliseconds;
        }
    }
}
