using Microsoft.Xna.Framework;
using System;

namespace ArbitraryPixel.Common.Graphics.MonoGame
{
    public class MonoGameGraphicsDeviceManager : WrapperBase<GraphicsDeviceManager>, IGrfxDeviceManager
    {
        private MonoGameGraphicsDevice _device = null;

        public MonoGameGraphicsDeviceManager(GraphicsDeviceManager objectToWrap)
            : base(objectToWrap)
        {
            _device = new MonoGameGraphicsDevice(objectToWrap.GraphicsDevice);
        }

        public IGrfxDevice GraphicsDevice => _device;

        public bool IsFullScreen
        {
            get { return this.WrappedObject.IsFullScreen; }
            set { this.WrappedObject.IsFullScreen = value; }
        }

        public int PreferredBackBufferHeight
        {
            get { return this.WrappedObject.PreferredBackBufferHeight; }
            set { this.WrappedObject.PreferredBackBufferHeight = value; }
        }

        public int PreferredBackBufferWidth
        {
            get { return this.WrappedObject.PreferredBackBufferWidth; }
            set { this.WrappedObject.PreferredBackBufferWidth = value; }
        }

        public void ApplyChanges()
        {
            this.WrappedObject.ApplyChanges();

            if (_device == null || _device.WrappedObject != this.WrappedObject.GraphicsDevice)
                _device = new MonoGameGraphicsDevice(this.WrappedObject.GraphicsDevice);
        }
    }
}
