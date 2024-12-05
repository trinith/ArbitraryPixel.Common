namespace ArbitraryPixel.Common
{
    /// <summary>
    /// Represents an object that generates random numbers.
    /// </summary>
    public interface IRandom
    {
        /// <summary>
        /// Returns a random number within the specified range.
        /// </summary>
        /// <param name="minValue">The minimum, inclusive lower bound of the range.</param>
        /// <param name="maxValue">The maximum, exclusive upper bound of the rannge.</param>
        /// <returns>The randomly generated number.</returns>
        int Next(int minValue, int maxValue);
    }
}
