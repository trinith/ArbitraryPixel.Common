using ArbitraryPixel.Common.Drawing;
using Microsoft.Xna.Framework.Graphics;

namespace ArbitraryPixel.Common.Graphics.MonoGame
{
    public class MonoGameSpriteFont : WrapperBase<SpriteFont>, ISpriteFont
    {
        public MonoGameSpriteFont(SpriteFont objectToWrap)
            : base(objectToWrap)
        {
        }

        public int LineSpacing => this.WrappedObject.LineSpacing;

        public SizeF MeasureString(string text)
        {
            return (SizeF)this.WrappedObject.MeasureString(text);
        }
    }
}
