namespace ArbitraryPixel.Common.Graphics.Factory
{
    /// <summary>
    /// An object responsible for creating graphics objects.
    /// </summary>
    public interface IGrfxFactory
    {
        /// <summary>
        /// An object responsible for creating ITexture2D objects.
        /// </summary>
        ITexture2DFactory Texture2DFactory { get; }

        /// <summary>
        /// An object responsible for creating ISpriteBatch objects.
        /// </summary>
        ISpriteBatchFactory SpriteBatchFactory { get; }

        /// <summary>
        /// An object responsible for creating ISpriteFont objects.
        /// </summary>
        ISpriteFontFactory SpriteFontFactory { get; }

        /// <summary>
        /// An object responsiblef or creating IBitmapFont objects.
        /// </summary>
        IBitmapFontFactory BitmapFontFactory { get; }

        /// <summary>
        /// An object responsible for creating IEffect objects.
        /// </summary>
        IEffectFactory EffectFactory { get; }

        /// <summary>
        /// An object responsible for creating render target objects.
        /// </summary>
        IRenderTargetFactory RenderTargetFactory { get; }
    }
}
