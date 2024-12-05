using ArbitraryPixel.Common.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace ArbitraryPixel.Common.Screen
{
    /// <summary>
    /// Implements ITextureDefinition.
    /// </summary>
    public class BackgroundTextureDefinition
    {
        /// <summary>
        /// The texture data.
        /// </summary>
        public ITexture2D Texture { get; private set; } = null;

        /// <summary>
        /// A mask to apply to the texture when drawn, multiplying each texture RGB value by the mask RGB value.
        /// </summary>
        public Color Mask { get; private set; } = Color.Black;

        /// <summary>
        /// Create a new object.
        /// </summary>
        /// <param name="texture">The texure to use.</param>
        /// <param name="mask">The mask to use.</param>
        public BackgroundTextureDefinition(ITexture2D texture, Color mask)
        {
            this.Texture = texture ?? throw new ArgumentNullException();
            this.Mask = mask;
        }
    }
}
