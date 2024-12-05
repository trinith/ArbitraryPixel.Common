namespace ArbitraryPixel.Common
{
    /// <summary>
    /// Represents an object that create IRandom objects.
    /// </summary>
    public interface IRandomFactory
    {
        /// <summary>
        /// Create a new random object using a time dependent default seed value.
        /// </summary>
        /// <returns>The new object.</returns>
        IRandom Create();

        /// <summary>
        /// Create a new random object using the specified seed.
        /// </summary>
        /// <param name="seed"></param>
        /// <returns>The new object.</returns>
        IRandom Create(int seed);
    }
}
