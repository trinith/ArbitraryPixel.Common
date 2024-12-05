using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ArbitraryPixel.Common.Graphics.MonoGame
{
    public class MonoGameGraphicsDevice : WrapperBase<GraphicsDevice>, IGrfxDevice
    {
        public MonoGameGraphicsDevice(GraphicsDevice objectToWrap)
            : base(objectToWrap)
        {
        }

        public Viewport Viewport
        {
            get { return this.WrappedObject.Viewport; }
            set { this.WrappedObject.Viewport = value; }
        }

        public void Clear(Color color)
        {
            this.WrappedObject.Clear(color);
        }

        public void SetRenderTarget(IRenderTarget2D target)
        {
            this.WrappedObject.SetRenderTarget((target == null) ? null : target.GetWrappedObject<RenderTarget2D>());
        }
    }
}
