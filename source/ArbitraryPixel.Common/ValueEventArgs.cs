using System;

namespace ArbitraryPixel.Common
{
    /// <summary>
    /// Event argument data that contains a value for a specified type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ValueEventArgs<T> : EventArgs
    {
        /// <summary>
        /// The value for this event argument.
        /// </summary>
        public T Value { get; }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="value">The value for this object.</param>
        public ValueEventArgs(T value)
        {
            this.Value = value;
        }
    }
}
