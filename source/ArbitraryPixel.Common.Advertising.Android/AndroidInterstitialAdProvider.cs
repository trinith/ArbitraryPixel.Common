using ArbitraryPixel.Common.Advertising.Android.Wrappers;
using System;
using System.Collections.Generic;

namespace ArbitraryPixel.Common.Advertising.Android
{
    /// <summary>
    /// An object responsible for providing interstitial ads on the Android platform.
    /// </summary>
    public class AndroidInterstitialAdProvider : IAdProvider
    {
        private IAdObjectFactory _adObjectFactory;
        private IAdContext _context;
        private IInterstitialAd _interstitialAd;
        private string _adUnitId;

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="adObjectFactory">An object responsible for creating ad objects.</param>
        /// <param name="adContext">An object providing context to ads.</param>
        /// <param name="adUnitId">The ad unit id for ads.</param>
        public AndroidInterstitialAdProvider(IAdObjectFactory adObjectFactory, IAdContext adContext, string adUnitId)
        {
            _adObjectFactory = adObjectFactory ?? throw new ArgumentNullException();
            _context = adContext ?? throw new ArgumentNullException();
            _adUnitId = adUnitId;
        }

        #region IDisposable Implementation
        /// <summary>
        /// Dispose of this object's resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region IAdProvider Implementation
        /// <summary>
        /// Whether or not an ad is currently ready to be shown.
        /// </summary>
        public bool AdReady { get; private set; } = false;

        /// <summary>
        /// Whether or not ads are enabled for this provider.
        /// </summary>
        public bool AdsEnabled { get; private set; } = true;

        /// <summary>
        /// A list of test devices associated with this ad provider.
        /// </summary>
        public IList<string> TestDeviceIds { get; private set; } = new List<string>();

        /// <summary>
        /// An event that is fired when a new ad has been loaded.
        /// </summary>
        public event EventHandler<EventArgs> AdLoaded;

        /// <summary>
        /// An event that is fired when the user closes an ad.
        /// </summary>
        public event EventHandler<EventArgs> AdClosed;

        /// <summary>
        /// Initialize ads for this provider.
        /// </summary>
        public void InitializeAds()
        {
            CreateAndLoadAd();
        }

        /// <summary>
        /// Show a full screen ad to the user.
        /// </summary>
        public void ShowAd()
        {
            if (_interstitialAd == null)
                throw new AdProviderNotInitializedException();

            if (_interstitialAd.IsLoaded == false)
                throw new AdsNotLoadedException();

            _interstitialAd.Show();
        }

        /// <summary>
        /// Request an ad to be loaded.
        /// </summary>
        public void RequestAd()
        {
            this.AdReady = false;

            if (_interstitialAd == null)
                throw new AdProviderNotInitializedException();

            IAdRequestBuilder requestBuilder = _adObjectFactory.CreateAdRequestBuilder();
            foreach (string testDeviceId in this.TestDeviceIds)
                requestBuilder.AddTestDevice(testDeviceId);

            IAdRequest request = requestBuilder.Build();

            _interstitialAd.LoadAd(request);
        }
        #endregion

        #region Protected Methods
        /// <summary>
        /// Dispose of this object's resources.
        /// </summary>
        /// <param name="disposing">Whether or not we are disposing.</param>
        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_interstitialAd != null)
                {
                    if (_interstitialAd.AdListener != null)
                    {
                        _interstitialAd.AdListener.Dispose();
                        _interstitialAd.AdListener = null;
                    }

                    _interstitialAd.Dispose();
                    _interstitialAd = null;
                }
            }
        }

        /// <summary>
        /// Fire an AdLoaded event with the specified event arguments.
        /// </summary>
        /// <param name="e">The arguments for the event.</param>
        protected void OnAdLoaded(EventArgs e)
        {
            if (this.AdLoaded != null)
                this.AdLoaded(this, e);
        }

        /// <summary>
        /// Fire an AdClosed event with the specified event arguments.
        /// </summary>
        /// <param name="e">The arguments for the event.</param>
        protected void OnAdClosed(EventArgs e)
        {
            if (this.AdClosed != null)
                this.AdClosed(this, e);
        }
        #endregion

        #region Private Methods
        private void CreateAndLoadAd()
        {
            // Dispose of any existing resources we have.
            this.Dispose(true);

            // Allocate new resources.
            _interstitialAd = _adObjectFactory.CreateInterstitialAd(_context);
            _interstitialAd.AdUnitId = _adUnitId;

            IAdListener adListener = _adObjectFactory.CreateAdListener();
            adListener.AdLoaded += Handle_ListenerAdLoaded;
            adListener.AdClosed += Handle_ListenerAdClosed;

            _interstitialAd.AdListener = adListener;
        }
        #endregion

        #region Event Handlers
        private void Handle_ListenerAdLoaded(object sender, EventArgs e)
        {
            this.AdReady = true;
            OnAdLoaded(new EventArgs());
        }

        private void Handle_ListenerAdClosed(object sender, EventArgs e)
        {
            this.AdReady = false;
            RequestAd();
            OnAdClosed(new EventArgs());
        }
        #endregion
    }
}