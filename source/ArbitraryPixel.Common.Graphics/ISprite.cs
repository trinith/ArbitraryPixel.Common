using Microsoft.Xna.Framework;

namespace ArbitraryPixel.Common.Graphics
{
    /// <summary>
    /// Represents an object responsible for storing information about a sprite texture.
    /// </summary>
    public interface ISprite
    {
        /// <summary>
        /// The texture for this sprite.
        /// </summary>
        ITexture2D Texture { get; set; }

        /// <summary>
        /// The source rectangle, within the texture, to draw. If set to null, the entire texture will be drawn.
        /// </summary>
        Rectangle? SourceRectangle { get; set; }
    }
}
