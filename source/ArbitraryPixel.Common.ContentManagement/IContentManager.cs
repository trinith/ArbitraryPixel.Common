using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbitraryPixel.Common.ContentManagement
{
    /// <summary>
    /// Represents functionality for managing content.
    /// </summary>
    public interface IContentManager
    {
        /// <summary>
        /// Load an asset from the content manager for the specified type.
        /// </summary>
        /// <typeparam name="T">The asset type to load as.</typeparam>
        /// <param name="assetName">The name of the asset to load.</param>
        /// <returns>The asset, loaded as the specified type.</returns>
        T Load<T>(string assetName);
    }
}
