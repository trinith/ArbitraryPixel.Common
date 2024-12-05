using Android.Gms.Ads;
using System;

namespace ArbitraryPixel.Common.Advertising.Android.Wrappers
{
    /// <summary>
    /// An object responsible for managing an ad that shows full screen to the user.
    /// </summary>
    public class AndroidInterstitialAd : WrapperBase<InterstitialAd>, IInterstitialAd
    {
        private IAdListener _adListener = null;

        /// <summary>
        /// Create a new object.
        /// </summary>
        /// <param name="objectToWrap">The Android InterstitialAd object to wrap.</param>
        public AndroidInterstitialAd(InterstitialAd objectToWrap)
            : base(objectToWrap)
        {
        }

        /// <summary>
        /// Whether or not an ad has been loaded.
        /// </summary>
        public bool IsLoaded
        {
            get { return this.WrappedObject.IsLoaded; }
        }

        /// <summary>
        /// The listener object that will listen for events on the ad.
        /// </summary>
        public IAdListener AdListener
        {
            get { return _adListener; }
            set
            {
                _adListener = value;

                if (value != null)
                    this.WrappedObject.AdListener = value.GetWrappedObject<AdListener>();
            }
        }

        /// <summary>
        /// The ad unit id for this ad.
        /// </summary>
        public string AdUnitId
        {
            get { return this.WrappedObject.AdUnitId; }
            set { this.WrappedObject.AdUnitId = value; }
        }

        /// <summary>
        /// Load an ad into this object using the specified request.
        /// </summary>
        /// <param name="adRequest">The object responsible for handling an ad request.</param>
        public void LoadAd(IAdRequest adRequest)
        {
            this.WrappedObject.LoadAd(adRequest.GetWrappedObject<AdRequest>());
        }

        /// <summary>
        /// Show the ad that has been loaded into this object.
        /// </summary>
        public void Show()
        {
            this.WrappedObject.Show();
        }

        /// <summary>
        /// Dispose of this object and the objects it contains.
        /// </summary>
        public void Dispose()
        {
            if (_adListener != null)
            {
                _adListener.Dispose();
                _adListener = null;
            }

            this.WrappedObject.Dispose();
        }
    }
}