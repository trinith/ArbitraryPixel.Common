namespace ArbitraryPixel.Common
{
    /// <summary>
    /// Represents an object that wraps another object.
    /// </summary>
    public interface IWrapper
    {
        /// <summary>
        /// Get the object that is wrapped.
        /// </summary>
        /// <typeparam name="TOutputType">The type to convert the wrapped object to.</typeparam>
        /// <returns>The wrapped object, cast to the specified type parameter.</returns>
        TOutputType GetWrappedObject<TOutputType>() where TOutputType : class;

        /// <summary>
        /// Get the object that is wrapped.
        /// </summary>
        /// <returns>The wrapped object, as an object.</returns>
        object GetWrappedObject();
    }
}
