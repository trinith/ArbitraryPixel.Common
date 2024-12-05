using Android.Gms.Ads;

namespace ArbitraryPixel.Common.Advertising.Android.Wrappers
{
    /// <summary>
    /// An object responsible for handling an ad request on the Android platform.
    /// </summary>
    public class AndroidAdRequest : WrapperBase<AdRequest>, IAdRequest
    {
        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="objectToWrap">The Android AdRequest object to wrap.</param>
        public AndroidAdRequest(AdRequest objectToWrap)
            : base(objectToWrap)
        {
        }
    }
}