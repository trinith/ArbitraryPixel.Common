using ArbitraryPixel.Common.Drawing;
using MonoGame.Extended;
using MonoGame.Extended.BitmapFonts;

namespace ArbitraryPixel.Common.Graphics.MonoGame
{
    public class MonoGameBitmapFont : WrapperBase<BitmapFont>, IBitmapFont
    {
        public MonoGameBitmapFont(BitmapFont objectToWrap)
            : base(objectToWrap)
        {
        }

        public int LineSpacing => this.WrappedObject.LineHeight;

        public SizeF MeasureString(string text)
        {
            Size2 textSize = this.WrappedObject.MeasureString(text);
            return new SizeF(textSize.Width, textSize.Height);
        }
    }
}
