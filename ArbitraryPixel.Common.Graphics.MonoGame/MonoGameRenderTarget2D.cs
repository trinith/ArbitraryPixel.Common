using Microsoft.Xna.Framework.Graphics;

namespace ArbitraryPixel.Common.Graphics.MonoGame
{
    public class MonoGameRenderTarget2D : MonoGameTexture2D, IRenderTarget2D
    {
        public MonoGameRenderTarget2D(RenderTarget2D objectToWrap)
            : base(objectToWrap)
        {
        }
    }
}
