using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ArbitraryPixel.Common.Graphics
{
    /// <summary>
    /// Represents an object that renders to a screen.
    /// </summary>
    public interface IGrfxDevice : IGraphicsWrapper
    {
        /// <summary>
        /// The view bounds for this device.
        /// </summary>
        Viewport Viewport { get; set; }

        /// <summary>
        /// Clear this device with the specified colour.
        /// </summary>
        /// <param name="color">The colour to clear with.</param>
        void Clear(Color color);

        /// <summary>
        /// Set the current render target to the specified parameter.
        /// </summary>
        /// <param name="target">The render target to set. If null, the screen will be used.</param>
        void SetRenderTarget(IRenderTarget2D target);
    }
}
