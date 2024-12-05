using System;
using System.Collections.Generic;

namespace ArbitraryPixel.Common.Advertising
{
    /// <summary>
    /// Represents an object that will show advertisements.
    /// </summary>
    public interface IAdProvider : IDisposable
    {
        /// <summary>
        /// An event that is fired when a new ad has been loaded.
        /// </summary>
        event EventHandler<EventArgs> AdLoaded;

        /// <summary>
        /// An event that is fired when the user closes an ad.
        /// </summary>
        event EventHandler<EventArgs> AdClosed;

        /// <summary>
        /// A list of test devices associated with this ad provider.
        /// </summary>
        IList<string> TestDeviceIds { get; }

        /// <summary>
        /// Whether or not ads are enabled for this provider.
        /// </summary>
        bool AdsEnabled { get; }

        /// <summary>
        /// Whether or not an ad is currently ready to be shown.
        /// </summary>
        bool AdReady { get; }

        /// <summary>
        /// Initialize ads for this provider.
        /// </summary>
        void InitializeAds();

        /// <summary>
        /// Show a full screen ad to the user.
        /// </summary>
        void ShowAd();

        /// <summary>
        /// Request an ad to be loaded.
        /// </summary>
        void RequestAd();
    }
}
