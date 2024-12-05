namespace ArbitraryPixel.Common.Graphics
{
    /// <summary>
    /// Represents an object that wraps another object.
    /// </summary>
    public interface IGraphicsWrapper
    {
        /// <summary>
        /// Get the object that is wrapped.
        /// </summary>
        /// <typeparam name="T">The type to convert the wrapped object to.</typeparam>
        /// <returns>The wrapped object, cast to the specified type parameter.</returns>
        T GetWrappedObject<T>() where T : class;
    }
}
