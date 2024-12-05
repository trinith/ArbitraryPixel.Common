using Microsoft.Xna.Framework.Graphics;

namespace ArbitraryPixel.Common.Graphics.Factory
{
    /// <summary>
    /// Represents an object that will create render target objects.
    /// </summary>
    public interface IRenderTargetFactory
    {
        /// <summary>
        /// Create a new 2D render target object.
        /// </summary>
        /// <param name="device">An object responsible for rendering.</param>
        /// <param name="width">The width of the render target buffer.</param>
        /// <param name="height">The height of the render target buffer.</param>
        /// <param name="usage">Usage parameters.</param>
        /// <returns>A newly created 2D render target object.</returns>
        IRenderTarget2D Create(IGrfxDevice device, int width, int height, RenderTargetUsage usage);
    }
}
