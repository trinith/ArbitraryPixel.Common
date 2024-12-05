using ArbitraryPixel.Common.Graphics;
using System;

namespace ArbitraryPixel.Common.Screen
{
    /// <summary>
    /// Represents options for an IScreenManager object.
    /// </summary>
    public class ScreenManagerOptions
    {
        /// <summary>
        /// An object responsible for drawing drawing ScreenBackground and WorldBackground.
        /// </summary>
        public ISpriteBatch SpriteBatch { get; private set; }

        /// <summary>
        /// If set, draws a background that encompasses the screen dimensions during BeginDraw.
        /// </summary>
        public BackgroundTextureDefinition ScreenBackground { get; set; }

        /// <summary>
        /// If set, draws a background that encompasses the scaled world dimensions during BeginDraw.
        /// </summary>
        public BackgroundTextureDefinition WorldBackground { get; set; }

        /// <summary>
        /// Create a new object with the specified spritebatch.
        /// </summary>
        /// <param name="spriteBatch">The spritebatch that will be used to draw the texture definitions, if they are set.</param>
        public ScreenManagerOptions(ISpriteBatch spriteBatch)
        {
            this.SpriteBatch = spriteBatch ?? throw new ArgumentNullException();
        }
    }
}
