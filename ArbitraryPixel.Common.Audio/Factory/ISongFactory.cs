using ArbitraryPixel.Common.ContentManagement;

namespace ArbitraryPixel.Common.Audio.Factory
{
    /// <summary>
    /// Represents an object that can create ISong objects.
    /// </summary>
    public interface ISongFactory
    {
        /// <summary>
        /// Create a new song object.
        /// </summary>
        /// <param name="content">A content manager object used to load the song data.</param>
        /// <param name="assetName">Asset name for the song file.</param>
        /// <returns>A newly created ISong object.</returns>
        ISong Create(IContentManager content, string assetName);
    }
}
