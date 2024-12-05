using ArbitraryPixel.Common.ContentManagement;
using ArbitraryPixel.Common.Graphics.Factory;
using Microsoft.Xna.Framework.Graphics;

namespace ArbitraryPixel.Common.Graphics.MonoGame.Factory
{
    public class MonoGameSpriteFontFactory : ISpriteFontFactory
    {
        public ISpriteFont Create(IContentManager contentManager, string assetName)
        {
            SpriteFont newFont = contentManager.Load<SpriteFont>(assetName);
            return new MonoGameSpriteFont(newFont);
        }
    }
}
