using ArbitraryPixel.Common.ContentManagement;
using ArbitraryPixel.Common.Graphics.Factory;
using Microsoft.Xna.Framework.Graphics;

namespace ArbitraryPixel.Common.Graphics.MonoGame.Factory
{
    public class MonoGameTexture2DFactory : ITexture2DFactory
    {
        public ITexture2D Create(IGrfxDevice device, int width, int height)
        {
            Texture2D newTexture = new Texture2D(((MonoGameGraphicsDevice)device).WrappedObject, width, height);
            return new MonoGameTexture2D(newTexture);
        }

        public ITexture2D Create(IContentManager contentManager, string assetName)
        {
            Texture2D newTexture = contentManager.Load<Texture2D>(assetName);
            return new MonoGameTexture2D(newTexture);
        }
    }
}
