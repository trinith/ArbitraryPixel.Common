using System;

namespace ArbitraryPixel.Common
{
    /// <summary>
    /// An exception is thrown when an object in read only mode has a property set.
    /// </summary>
    public class PropertyIsReadOnlyException : Exception { }

    /// <summary>
    /// Represents an object whose properties can be set to read only. If a property is set while the object is in read only mode, an exception is thrown.
    /// </summary>
    public interface IReadOnly
    {
        /// <summary>
        /// Whether or not the object is in read only mode.
        /// </summary>
        bool IsReadOnly { get; }
    }
}
