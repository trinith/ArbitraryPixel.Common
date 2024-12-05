using ArbitraryPixel.Common.ContentManagement;

namespace ArbitraryPixel.Common.Audio.Factory
{
    /// <summary>
    /// Represents an object that can create ISoundResource objects.
    /// </summary>
    public interface ISoundResourceFactory
    {
        /// <summary>
        /// Create a new sound resource.
        /// </summary>
        /// <param name="content">An object responsible for managing content and loading the sound resource.</param>
        /// <param name="assetName">The name of the sound resource to load.</param>
        /// <returns>The newly created sound resource.</returns>
        ISoundResource Create(IContentManager content, string assetName);
    }
}
