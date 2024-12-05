using System;

namespace ArbitraryPixel.Common
{
    /// <summary>
    /// An implementation of IDateTime, wrapping System.DateTime.
    /// </summary>
    public class DotNetDateTime : WrapperBase<DateTime>, IDateTime
    {
        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="objectToWrap">The object that will be wrapped.</param>
        public DotNetDateTime(DateTime objectToWrap)
            : base(objectToWrap)
        {
        }

        /// <summary>
        /// Gets the number of ticks that represent the date and time of this instance.
        /// </summary>
        public long Ticks => this.WrappedObject.Ticks;

        /// <summary>
        /// Convert this object into its equivalent string representation.
        /// </summary>
        /// <returns>The string representation of this object.</returns>
        public override string ToString()
        {
            return this.WrappedObject.ToString();
        }

        /// <summary>
        /// Convert this object into its equivalent string representation using the specified format.
        /// </summary>
        /// <param name="format">The format string to use.</param>
        /// <returns>The string representation of this object.</returns>
        public string ToString(string format)
        {
            return this.WrappedObject.ToString(format);
        }

        /// <summary>
        /// Subtract the specified IDateTime object from this one to generate a span of time.
        /// </summary>
        /// <param name="other">The object to subtract from this one.</param>
        /// <returns>A TimeSpan object representing the span of time between this object and the other.</returns>
        public TimeSpan Subtract(IDateTime other)
        {
            return this.WrappedObject - (DateTime)other.GetWrappedObject();
        }
    }
}
