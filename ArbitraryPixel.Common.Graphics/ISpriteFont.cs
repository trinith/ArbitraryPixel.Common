using ArbitraryPixel.Common.Drawing;

namespace ArbitraryPixel.Common.Graphics
{
    /// <summary>
    /// Represents an object that stores information about a font used for rendering.
    /// </summary>
    public interface ISpriteFont : IGraphicsWrapper
    {
        /// <summary>
        /// The amount of pixels that a line of text will take up.
        /// </summary>
        int LineSpacing { get; }

        /// <summary>
        /// Get a size for a given string using this font.
        /// </summary>
        /// <param name="text">The text to get the size of.</param>
        /// <returns>A SizeF object that contains the dimensions of the specified text.</returns>
        SizeF MeasureString(string text);
    }
}
