using System;
using Microsoft.Xna.Framework.Graphics;

namespace ArbitraryPixel.Common.Graphics.MonoGame
{
    public class MonoGameTexture2D : WrapperBase<Texture2D>, ITexture2D
    {
        public MonoGameTexture2D(Texture2D objectToWrap)
            : base(objectToWrap)
        {
        }

        public int Height => this.WrappedObject.Height;
        public int Width => this.WrappedObject.Width;

        public void SetData<T>(T[] data) where T : struct
        {
            this.WrappedObject.SetData<T>(data);
        }

        public void SetData<T>(T data) where T : struct
        {
            T[] dataArray = new T[this.Width * this.Height];
            for (int i = 0; i < dataArray.Length; i++)
                dataArray[i] = data;

            this.WrappedObject.SetData<T>(dataArray);
        }
    }
}
