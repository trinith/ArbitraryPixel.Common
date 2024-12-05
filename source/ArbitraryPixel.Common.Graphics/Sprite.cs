using Microsoft.Xna.Framework;
using System;

namespace ArbitraryPixel.Common.Graphics
{
    /// <summary>
    /// An object responsible for storing information about a sprite texture.
    /// </summary>
    public class Sprite : ISprite
    {
        /// <summary>
        /// The texture for this sprite.
        /// </summary>
        public ITexture2D Texture { get; set; }

        /// <summary>
        /// The source rectangle, within the texture, to draw. If set to null, the entire texture will be drawn.
        /// </summary>
        public Rectangle? SourceRectangle { get; set; } = null;

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="texture">The texture for this sprite.</param>
        /// <param name="sourceRectangle">The source rectangle, within the texture, to draw. Use null for the entire texture.</param>
        public Sprite(ITexture2D texture, Rectangle? sourceRectangle)
        {
            this.Texture = texture ?? throw new ArgumentNullException();
            this.SourceRectangle = sourceRectangle;
        }
    }
}
