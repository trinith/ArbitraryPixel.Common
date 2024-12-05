namespace ArbitraryPixel.Common.Graphics
{
    /// <summary>
    /// Represents an object that stores information about a texture.
    /// </summary>
    public interface ITexture2D : IGraphicsWrapper
    {
        /// <summary>
        /// Set the pixel data for this texture.
        /// </summary>
        /// <typeparam name="T">The type of data representing the type for each pixel.</typeparam>
        /// <param name="data">An array of data representing the pixels</param>
        void SetData<T>(T[] data) where T : struct;

        /// <summary>
        /// Set the pixel data for all pixels in this texture to the specified value.
        /// </summary>
        /// <typeparam name="T">The type of data representing the type for each pixel.</typeparam>
        /// <param name="data">A value that all pixels will be set to.</param>
        void SetData<T>(T data) where T : struct;

        /// <summary>
        /// The width, in pixels, of this texture.
        /// </summary>
        int Width { get; }

        /// <summary>
        /// The height, in pixels, of this texture.
        /// </summary>
        int Height { get; }
    }
}
