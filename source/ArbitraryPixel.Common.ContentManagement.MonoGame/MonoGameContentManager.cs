using Microsoft.Xna.Framework.Content;
using System;

namespace ArbitraryPixel.Common.ContentManagement.MonoGame
{
    /// <summary>
    /// An implementation of IContentManager that wraps a MonoGame ContentManager object.
    /// </summary>
    public class MonoGameContentManager : IContentManager
    {
        private ContentManager _wrappedObject = null;

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="objectToWrap">The MonoGame content manager to wrap.</param>
        public MonoGameContentManager(ContentManager objectToWrap)
        {
            _wrappedObject = objectToWrap ?? throw new ArgumentNullException();
        }

        /// <summary>
        /// Load an asset from the content manager for the specified type.
        /// </summary>
        /// <typeparam name="T">The asset type to load as.</typeparam>
        /// <param name="assetName">The name of the asset to load.</param>
        /// <returns>The asset, loaded as the specified type.</returns>
        public T Load<T>(string assetName)
        {
            return _wrappedObject.Load<T>(assetName);
        }
    }
}
