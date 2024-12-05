using Android.Gms.Ads;

namespace ArbitraryPixel.Common.Advertising.Android.Wrappers
{
    /// <summary>
    /// An object responsible for building ad request objects on the Android platform.
    /// </summary>
    public class AndroidAdRequestBuilder : WrapperBase<AdRequest.Builder>, IAdRequestBuilder
    {
        /// <summary>
        /// Create a new object.
        /// </summary>
        /// <param name="objectToWrap">The Android AdRequest.Builder object to be wrapped by this object.</param>
        public AndroidAdRequestBuilder(AdRequest.Builder objectToWrap)
            : base(objectToWrap)
        {
        }

        /// <summary>
        /// Add a test device id to this builder.
        /// </summary>
        /// <param name="deviceId">The test device id to add.</param>
        public void AddTestDevice(string deviceId)
        {
            this.WrappedObject.AddTestDevice(deviceId);
        }

        /// <summary>
        /// Build an IAdRequest object using the information stored in this builder.
        /// </summary>
        /// <returns>The newly created object.</returns>
        public IAdRequest Build()
        {
            return new AndroidAdRequest(this.WrappedObject.Build());
        }
    }
}