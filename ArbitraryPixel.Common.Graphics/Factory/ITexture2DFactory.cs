using ArbitraryPixel.Common.ContentManagement;

namespace ArbitraryPixel.Common.Graphics.Factory
{
    /// <summary>
    /// Represents an object that creates ITexture2D objects.
    /// </summary>
    public interface ITexture2DFactory
    {
        /// <summary>
        /// Create a new ITexture2D object.
        /// </summary>
        /// <param name="device">An object representing a graphics device.</param>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <returns></returns>
        ITexture2D Create(IGrfxDevice device, int width, int height);

        /// <summary>
        /// Create a new ITexture2D object using a content manager.
        /// </summary>
        /// <param name="contentManager">The content manager that can load the texture.</param>
        /// <param name="assetName">The asset name the texture is stored as.</param>
        /// <returns>A newly created ITexture2D object</returns>
        ITexture2D Create(IContentManager contentManager, string assetName);
    }
}
