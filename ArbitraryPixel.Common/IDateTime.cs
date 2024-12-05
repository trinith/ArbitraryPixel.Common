using System;

namespace ArbitraryPixel.Common
{
    /// <summary>
    /// Represents an instant in time, typically expressed as a date and time of day.
    /// </summary>
    public interface IDateTime : IWrapper
    {
        /// <summary>
        /// Gets the number of ticks that represent the date and time of this instance.
        /// </summary>
        long Ticks { get; }

        /// <summary>
        /// Get a string representation of this object using the specified format.
        /// </summary>
        /// <param name="format">A standard or custom date and time format string.</param>
        /// <returns>A string representation of this object as specified by format.</returns>
        string ToString(string format);

        /// <summary>
        /// Subtract the specified IDateTime object from this one to generate a span of time.
        /// </summary>
        /// <param name="other">The object to subtract from this one.</param>
        /// <returns>A TimeSpan object representing the span of time between this object and the other.</returns>
        TimeSpan Subtract(IDateTime other);
    }
}
