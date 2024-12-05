namespace ArbitraryPixel.Common.Graphics.Factory
{
    /// <summary>
    /// Represents an object that creates ISpriteBatch objects.
    /// </summary>
    public interface ISpriteBatchFactory
    {
        /// <summary>
        /// Create a new SpriteBatch using the specified device.
        /// </summary>
        /// <param name="device">A graphics device used to create the new SpriteBatch.</param>
        /// <returns>The newly created object.</returns>
        ISpriteBatch Create(IGrfxDevice device);
    }
}
