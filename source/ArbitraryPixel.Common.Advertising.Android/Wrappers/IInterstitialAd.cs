using System;

namespace ArbitraryPixel.Common.Advertising.Android.Wrappers
{
    /// <summary>
    /// Represents an object that manages an ad that shows full screen.
    /// </summary>
    public interface IInterstitialAd : IWrapper, IDisposable
    {
        /// <summary>
        /// Whether or not an ad has been loaded.
        /// </summary>
        bool IsLoaded { get; }

        /// <summary>
        /// The listener object that will listen for events on the ad.
        /// </summary>
        IAdListener AdListener { get; set; }

        /// <summary>
        /// The ad unit id for this ad.
        /// </summary>
        string AdUnitId { get; set; }

        /// <summary>
        /// Load an ad into this object using the specified request.
        /// </summary>
        /// <param name="adRequest">The object responsible for handling an ad request.</param>
        void LoadAd(IAdRequest adRequest);

        /// <summary>
        /// Show the ad that has been loaded into this object.
        /// </summary>
        void Show();
    }
}