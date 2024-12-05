using ArbitraryPixel.Common.ContentManagement;

namespace ArbitraryPixel.Common.Graphics.Factory
{
    /// <summary>
    /// Represents an object responsible for creating IBitmapFont objects.
    /// </summary>
    public interface IBitmapFontFactory
    {
        /// <summary>
        /// Create a new ISpriteFont using the provided IContentManager.
        /// </summary>
        /// <param name="contentManager">The content manager to load the sprite font from.</param>
        /// <param name="assetName">The asset name that the font is stored under.</param>
        /// <returns>The requested ISpriteFont object.</returns>
        IBitmapFont Create(IContentManager contentManager, string assetName);
    }
}
