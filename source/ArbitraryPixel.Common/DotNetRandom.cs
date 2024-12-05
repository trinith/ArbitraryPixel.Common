using System;

namespace ArbitraryPixel.Common
{
    /// <summary>
    /// An implementation of IRandom using System.Random.
    /// </summary>
    public class DotNetRandom : IRandom
    {
        private Random _random = null;

        /// <summary>
        /// Create a new instance with a seed based on the current time.
        /// </summary>
        public DotNetRandom()
        {
            _random = new Random();
        }

        /// <summary>
        /// Create a new instance using the specified seed.
        /// </summary>
        /// <param name="seed">The seed to use.</param>
        public DotNetRandom(int seed)
        {
            _random = new Random(seed);
        }

        /// <summary>
        /// Returns a random number within the specified range.
        /// </summary>
        /// <param name="minValue">The minimum, inclusive lower bound of the range.</param>
        /// <param name="maxValue">The maximum, exclusive upper bound of the rannge.</param>
        /// <returns>The randomly generated number.</returns>
        public int Next(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue);
        }
    }
}
