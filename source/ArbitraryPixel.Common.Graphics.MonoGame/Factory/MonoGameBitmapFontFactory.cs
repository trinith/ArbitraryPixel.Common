using ArbitraryPixel.Common.ContentManagement;
using ArbitraryPixel.Common.Graphics.Factory;
using MonoGame.Extended.BitmapFonts;

namespace ArbitraryPixel.Common.Graphics.MonoGame.Factory
{
    public class MonoGameBitmapFontFactory : IBitmapFontFactory
    {
        public IBitmapFont Create(IContentManager contentManager, string assetName)
        {
            BitmapFont newFont = contentManager.Load<BitmapFont>(assetName);
            return new MonoGameBitmapFont(newFont);
        }
    }
}
