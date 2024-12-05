namespace ArbitraryPixel.Common.Advertising.Android.Wrappers
{
    /// <summary>
    /// Represents an object that creates ad objects.
    /// </summary>
    public interface IAdObjectFactory
    {
        /// <summary>
        /// Create an InterstitialAd object.
        /// </summary>
        /// <param name="context">An object providing context.</param>
        /// <returns>The newly created object.</returns>
        IInterstitialAd CreateInterstitialAd(IAdContext context);

        /// <summary>
        /// Create a new AdListener object.
        /// </summary>
        /// <returns>The newly created object.</returns>
        IAdListener CreateAdListener();

        /// <summary>
        /// Create a new AdRequestBuilder object.
        /// </summary>
        /// <returns>The newly created object.</returns>
        IAdRequestBuilder CreateAdRequestBuilder();
    }
}