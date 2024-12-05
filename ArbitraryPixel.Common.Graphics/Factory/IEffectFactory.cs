using ArbitraryPixel.Common.ContentManagement;

namespace ArbitraryPixel.Common.Graphics.Factory
{
    /// <summary>
    /// Represents an object that creats IEffect objects.
    /// </summary>
    public interface IEffectFactory
    {
        /// <summary>
        /// Create a new IEffect object using a content manager.
        /// </summary>
        /// <param name="contentManager">The content manager that can load the effect.</param>
        /// <param name="assetName">The asset name the effect is stored as.</param>
        /// <returns>A newly created IEffect object</returns>
        IEffect Create(IContentManager contentManager, string assetName);
    }
}
