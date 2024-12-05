namespace ArbitraryPixel.Common.Advertising.Android.Wrappers
{
    /// <summary>
    /// Represents an object responsible for building an IAdRequest object.
    /// </summary>
    public interface IAdRequestBuilder : IWrapper
    {
        /// <summary>
        /// Add a test device id to this builder.
        /// </summary>
        /// <param name="deviceId">The test device id to add.</param>
        void AddTestDevice(string deviceId);

        /// <summary>
        /// Build an IAdRequest object using the information stored in this builder.
        /// </summary>
        /// <returns>The newly created object.</returns>
        IAdRequest Build();
    }
}