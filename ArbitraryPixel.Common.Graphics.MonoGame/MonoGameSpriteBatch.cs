using ArbitraryPixel.Common.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.BitmapFonts;

namespace ArbitraryPixel.Common.Graphics.MonoGame
{
    public class MonoGameSpriteBatch : WrapperBase<SpriteBatch>, ISpriteBatch
    {
        public MonoGameSpriteBatch(SpriteBatch objectToWrap)
            : base(objectToWrap)
        {
        }

        public float Opacity { get; set; } = 1f;

        public void Begin()
        {
            this.WrappedObject.Begin();
        }

        public void Begin(SpriteSortMode sortMode = SpriteSortMode.Deferred, BlendState blendState = null, SamplerState samplerState = null, DepthStencilState depthStencilState = null, RasterizerState rasterizerState = null, IEffect effect = null, Matrix? transformMatrix = default(Matrix?))
        {
            this.WrappedObject.Begin(sortMode, blendState, samplerState, depthStencilState, rasterizerState, effect?.GetWrappedObject<Effect>(), transformMatrix);
        }

        public void Draw(ITexture2D texture, Vector2 position, Color colourMask)
        {
            colourMask.A = (byte)(this.Opacity * colourMask.A);
            this.WrappedObject.Draw(texture.GetWrappedObject<Texture2D>(), position, colourMask);
        }

        public void Draw(ITexture2D texture, Rectangle destinationRectangle, Color colourMask)
        {
            colourMask.A = (byte)(this.Opacity * colourMask.A);
            this.WrappedObject.Draw(texture.GetWrappedObject<Texture2D>(), destinationRectangle, colourMask);
        }

        public void Draw(ITexture2D texture, RectangleF destinationRectangle, Color colourMask)
        {
            colourMask.A = (byte)(this.Opacity * colourMask.A);

            // Calculate scale relative to the texture size.
            Vector2 scale = new Vector2(destinationRectangle.Width / (float)texture.Width, destinationRectangle.Height / (float)texture.Height);
            this.WrappedObject.Draw(texture.GetWrappedObject<Texture2D>(), destinationRectangle.Location, null, colourMask, 0, Vector2.Zero, scale, SpriteEffects.None, 0);
        }

        public void Draw(ITexture2D texture, Vector2 position, Rectangle? sourceRectangle, Color colourMask)
        {
            colourMask.A = (byte)(this.Opacity * colourMask.A);
            this.WrappedObject.Draw(texture.GetWrappedObject<Texture2D>(), position, sourceRectangle, colourMask);
        }

        public void Draw(ITexture2D texture, Vector2 position, Rectangle? sourceRectangle, Color colourMask, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            colourMask.A = (byte)(this.Opacity * colourMask.A);
            this.WrappedObject.Draw(texture.GetWrappedObject<Texture2D>(), position, sourceRectangle, colourMask, rotation, origin, scale, effects, layerDepth);
        }

        public void Draw(ITexture2D texture, RectangleF destinationRectangle, Rectangle? sourceRectangle, Color colourMask, float rotation, Vector2 origin, SpriteEffects effects, float layerDepth)
        {
            colourMask.A = (byte)(this.Opacity * colourMask.A);

            // If no source rectangle, calculate scale relative to the texture, otherwise calculate scale relative to the source rectangle.
            Vector2 scale = (sourceRectangle == null)
                ? new Vector2(destinationRectangle.Width / (float)texture.Width, destinationRectangle.Height / (float)texture.Height)
                : new Vector2(destinationRectangle.Width / (float)sourceRectangle.Value.Width, destinationRectangle.Height / (float)sourceRectangle.Value.Height);

            this.WrappedObject.Draw(texture.GetWrappedObject<Texture2D>(), destinationRectangle.Location, sourceRectangle, colourMask, rotation, origin, scale, effects, layerDepth);
        }

        public void Draw(ISprite sprite, SpriteDrawInfo info)
        {
            Color colourMask = info.Mask;
            colourMask.A = (byte)(this.Opacity * colourMask.A);
            this.Draw(sprite.Texture, info.Position, sprite.SourceRectangle, colourMask, info.Rotation, info.Origin, info.Scale, info.Effects, info.LayerDepth);
        }

        public void DrawString(ISpriteFont spriteFont, string text, Vector2 position, Color colourMask)
        {
            colourMask.A = (byte)(this.Opacity * colourMask.A);
            this.WrappedObject.DrawString(spriteFont.GetWrappedObject<SpriteFont>(), text, position, colourMask);
        }

        public void DrawString(IBitmapFont bitmapFont, string text, Vector2 position, Color colourMask)
        {
            colourMask.A = (byte)(this.Opacity * colourMask.A);
            this.WrappedObject.DrawString(bitmapFont.GetWrappedObject<BitmapFont>(), text, position, colourMask);
        }

        public void End()
        {
            this.WrappedObject.End();
        }
    }
}
