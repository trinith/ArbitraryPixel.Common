using ArbitraryPixel.Common.Graphics.Factory;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace ArbitraryPixel.Common.Graphics.MonoGame.Factory
{
    public class MonoGameRenderTargetFactory : IRenderTargetFactory
    {
        public IRenderTarget2D Create(IGrfxDevice device, int width, int height, RenderTargetUsage usage)
        {
            return new MonoGameRenderTarget2D(new RenderTarget2D(device.GetWrappedObject<GraphicsDevice>(), width, height, false, SurfaceFormat.Color, DepthFormat.None, 0, usage));
        }
    }
}
