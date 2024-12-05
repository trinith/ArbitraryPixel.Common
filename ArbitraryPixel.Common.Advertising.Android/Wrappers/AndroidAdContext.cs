using Android.Content;

namespace ArbitraryPixel.Common.Advertising.Android.Wrappers
{
    /// <summary>
    /// An object wrapping an Android Context object.
    /// </summary>
    public class AndroidAdContext : WrapperBase<Context>, IAdContext
    {
        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="objectToWrap">The Android Context object to wrap.</param>
        public AndroidAdContext(Context objectToWrap)
            : base(objectToWrap)
        {
        }
    }
}