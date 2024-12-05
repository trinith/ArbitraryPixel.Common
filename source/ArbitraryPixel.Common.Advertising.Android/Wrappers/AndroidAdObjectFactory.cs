using Android.Content;
using Android.Gms.Ads;

namespace ArbitraryPixel.Common.Advertising.Android.Wrappers
{
    /// <summary>
    /// An object responsible for creating AdObjects for the Android platform.
    /// </summary>
    public class AndroidAdObjectFactory : IAdObjectFactory
    {
        /// <summary>
        /// Create an InterstitialAd object.
        /// </summary>
        /// <param name="context">An object providing context.</param>
        /// <returns>The newly created object.</returns>
        public IInterstitialAd CreateInterstitialAd(IAdContext context)
        {
            return new AndroidInterstitialAd(new InterstitialAd(context.GetWrappedObject<Context>()));
        }

        /// <summary>
        /// Create a new AdListener object.
        /// </summary>
        /// <returns>The newly created object.</returns>
        public IAdListener CreateAdListener()
        {
            return new AndroidAdListener(new AdListenerImpl());
        }

        /// <summary>
        /// Create a new AdRequestBuilder object.
        /// </summary>
        /// <returns>The newly created object.</returns>
        public IAdRequestBuilder CreateAdRequestBuilder()
        {
            return new AndroidAdRequestBuilder(new AdRequest.Builder());
        }
    }
}