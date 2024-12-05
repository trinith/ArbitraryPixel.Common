using System;

namespace ArbitraryPixel.Common.Advertising.Android.Wrappers
{
    /// <summary>
    /// Represents an object that listens for responds from an ad.
    /// </summary>
    public interface IAdListener : IWrapper, IDisposable
    {
        /// <summary>
        /// An event that occurs when an ad is loaded.
        /// </summary>
        event EventHandler<EventArgs> AdLoaded;

        /// <summary>
        /// An event that occurs when an ad is closed.
        /// </summary>
        event EventHandler<EventArgs> AdClosed;
    }
}