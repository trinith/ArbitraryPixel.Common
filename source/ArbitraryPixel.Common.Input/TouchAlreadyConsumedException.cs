using System;

namespace ArbitraryPixel.Common.Input
{
    /// <summary>
    /// An exception that is thrown when setting a consumer for a touch that is already consumed by another object.
    /// </summary>
    public class TouchAlreadyConsumedException : Exception
    {
        /// <summary>
        /// Create a new instance.
        /// </summary>
        public TouchAlreadyConsumedException()
        {
        }

        /// <summary>
        /// Create a new instance with the specified message.
        /// </summary>
        /// <param name="message">A message describing the details of the exception.</param>
        public TouchAlreadyConsumedException(string message) : base(message)
        {
        }
    }
}
