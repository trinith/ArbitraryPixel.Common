using ArbitraryPixel.Common.ContentManagement;
using ArbitraryPixel.Common.Graphics.Factory;
using Microsoft.Xna.Framework.Graphics;

namespace ArbitraryPixel.Common.Graphics.MonoGame.Factory
{
    public class MonoGameEffectFactory : IEffectFactory
    {
        public IEffect Create(IContentManager contentManager, string assetName)
        {
            Effect newEffect = contentManager.Load<Effect>(assetName);
            return new MonoGameEffect(newEffect);
        }
    }
}
