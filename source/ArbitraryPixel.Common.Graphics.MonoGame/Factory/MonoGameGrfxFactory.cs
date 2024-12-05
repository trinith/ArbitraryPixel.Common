using ArbitraryPixel.Common.Graphics.Factory;

namespace ArbitraryPixel.Common.Graphics.MonoGame.Factory
{
    public class MonoGameGrfxFactory : IGrfxFactory
    {
        public ITexture2DFactory Texture2DFactory { get; } = new MonoGameTexture2DFactory();
        public ISpriteBatchFactory SpriteBatchFactory { get; } = new MonoGameSpriteBatchFactory();
        public ISpriteFontFactory SpriteFontFactory { get; } = new MonoGameSpriteFontFactory();
        public IEffectFactory EffectFactory { get; } = new MonoGameEffectFactory();
        public IRenderTargetFactory RenderTargetFactory { get; } = new MonoGameRenderTargetFactory();
        public IBitmapFontFactory BitmapFontFactory { get; } = new MonoGameBitmapFontFactory();
    }
}
