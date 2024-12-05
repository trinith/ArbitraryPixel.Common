using ArbitraryPixel.Common.Graphics.Factory;
using Microsoft.Xna.Framework.Graphics;

namespace ArbitraryPixel.Common.Graphics.MonoGame.Factory
{
    public class MonoGameSpriteBatchFactory : ISpriteBatchFactory
    {
        public ISpriteBatch Create(IGrfxDevice device)
        {
            ISpriteBatch spriteBatch = new MonoGameSpriteBatch(
                new SpriteBatch(
                    device.GetWrappedObject<GraphicsDevice>()
                )
            );

            return spriteBatch;
        }
    }
}
