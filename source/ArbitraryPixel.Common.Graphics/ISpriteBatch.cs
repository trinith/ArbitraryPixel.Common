using ArbitraryPixel.Common.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ArbitraryPixel.Common.Graphics
{
    /// <summary>
    /// Represents an object responsible for drawing textures on an IGrfxDevice object.
    /// </summary>
    public interface ISpriteBatch : IGraphicsWrapper
    {
        /// <summary>
        /// An opacity factory that will be applied to all colour masks used by this SpriteBatch.
        /// <para>NOTE: Only works when the batch has been opened using a BlendState that supports alpha blending.</para>
        /// </summary>
        float Opacity { get; set; }

        /// <summary>
        /// Begin drawing.
        /// </summary>
        void Begin();

        /// <summary>
        /// Finish drawing.
        /// </summary>
        void End();

        /// <summary>
        /// Begins a new sprite and text batch with the specified render state.
        /// </summary>
        /// <param name="sortMode">The drawing order for sprite and text drawing. Microsoft.Xna.Framework.Graphics.SpriteSortMode.Deferred by default</param>
        /// <param name="blendState">State of the blending. Uses Microsoft.Xna.Framework.Graphics.BlendState.AlphaBlend if null.</param>
        /// <param name="samplerState">State of the sampler. Uses Microsoft.Xna.Framework.Graphics.SamplerState.LinearClamp if null.</param>
        /// <param name="depthStencilState">State of the depth-stencil buffer. Uses Microsoft.Xna.Framework.Graphics.DepthStencilState.None if null.</param>
        /// <param name="rasterizerState">State of the rasterization. Uses Microsoft.Xna.Framework.Graphics.RasterizerState.CullCounterClockwise if null.</param>
        /// <param name="effect">An object responsible for applying a sprite effect. Uses default sprite effect if null.</param>
        /// <param name="transformMatrix">An optional matrix used to transform the sprite geometry. Uses Microsoft.Xna.Framework.Matrix.Identity if null.</param>
        void Begin(SpriteSortMode sortMode = SpriteSortMode.Deferred, BlendState blendState = null, SamplerState samplerState = null, DepthStencilState depthStencilState = null, RasterizerState rasterizerState = null, IEffect effect = null, Matrix? transformMatrix = default(Matrix?));

        /// <summary>
        /// Draw with the supplied parameters.
        /// </summary>
        /// <param name="texture">The texture to draw.</param>
        /// <param name="position">The location to draw the texture at.</param>
        /// <param name="colourMask">A colour mask applied to each pixel in the texture.</param>
        void Draw(ITexture2D texture, Vector2 position, Color colourMask);

        /// <summary>
        /// Draw with the supplied parameters.
        /// </summary>
        /// <param name="texture">The texture to draw.</param>
        /// <param name="destinationRectangle">The rectangle to draw the rectangle in. The texture will be stretched to fit.</param>
        /// <param name="colourMask">A colour mask applied to each pixel in the texture.</param>
        void Draw(ITexture2D texture, Rectangle destinationRectangle, Color colourMask);

        /// <summary>
        /// Draw with the supplied parameters.
        /// </summary>
        /// <param name="texture">The texture to draw.</param>
        /// <param name="destinationRectangle">The rectangle to draw the rectangle in. The texture will be stretched to fit.</param>
        /// <param name="colourMask">A colour mask applied to each pixel in the texture.</param>
        void Draw(ITexture2D texture, RectangleF destinationRectangle, Color colourMask);

        /// <summary>
        /// Draw with the supplied parameters.
        /// </summary>
        /// <param name="texture">The texture to draw.</param>
        /// <param name="position">The position to start drawing at.</param>
        /// <param name="sourceRectangle">The rectangle to draw to. If null, the full texture will be drawn.</param>
        /// <param name="colourMask">A colour mask applied to each pixel in the texture.</param>
        void Draw(ITexture2D texture, Vector2 position, Rectangle? sourceRectangle, Color colourMask);

        /// <summary>
        /// Draw with the supplied parameters.
        /// </summary>
        /// <param name="texture">The texture to draw.</param>
        /// <param name="position">The position to start drawing at.</param>
        /// <param name="sourceRectangle">The rectangle to draw to. If null, the full texture will be drawn.</param>
        /// <param name="colourMask">A colour mask applied to each pixel in the texture.</param>
        /// <param name="rotation">The rotation, with respect to the origin.</param>
        /// <param name="origin">The origin of drawing, with respect to the top left.</param>
        /// <param name="scale">The scale to draw at, with respect to the origin.</param>
        /// <param name="effects">Effects to apply to drawing.</param>
        /// <param name="layerDepth">The layer depth.</param>
        void Draw(ITexture2D texture, Vector2 position, Rectangle? sourceRectangle, Color colourMask, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth);

        /// <summary>
        /// Draw with the supplied parameters.
        /// </summary>
        /// <param name="texture">The texture to draw.</param>
        /// <param name="destinationRectangle">The rectangle to draw the rectangle in. The texture will be stretched to fit.</param>
        /// <param name="sourceRectangle">The rectangle to draw to. If null, the full texture will be drawn.</param>
        /// <param name="colourMask">A colour mask applied to each pixel in the texture.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="origin">The origin of drawing, with respect to the top left.</param>
        /// <param name="effects">Effects to apply to drawing.</param>
        /// <param name="layerDepth">The layer depth.</param>
        void Draw(ITexture2D texture, RectangleF destinationRectangle, Rectangle? sourceRectangle, Color colourMask, float rotation, Vector2 origin, SpriteEffects effects, float layerDepth);

        /// <summary>
        /// Draw a sprite to the screen.
        /// </summary>
        /// <param name="sprite">The sprite to draw.</param>
        /// <param name="info">An object that describes how the sprite should be drawn.</param>
        void Draw(ISprite sprite, SpriteDrawInfo info);

        /// <summary>
        /// Draw a string with the supplied parameters.
        /// </summary>
        /// <param name="spriteFont">The font to draw with.</param>
        /// <param name="text">The text to draw.</param>
        /// <param name="position">The position to draw the text at.</param>
        /// <param name="colourMask">The colour to draw the text with.</param>
        void DrawString(ISpriteFont spriteFont, string text, Vector2 position, Color colourMask);

        /// <summary>
        /// Draw a string with the supplied parameters.
        /// </summary>
        /// <param name="bitmapFont">The font to draw with.</param>
        /// <param name="text">The text to draw.</param>
        /// <param name="position">The position to draw the text at.</param>
        /// <param name="colourMask">The colour to draw the text with.</param>
        void DrawString(IBitmapFont bitmapFont, string text, Vector2 position, Color colourMask);
    }
}
