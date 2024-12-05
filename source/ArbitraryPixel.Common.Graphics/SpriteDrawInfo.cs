using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace ArbitraryPixel.Common.Graphics
{
    /// <summary>
    /// Contains information about how a sprite should draw.
    /// </summary>
    public struct SpriteDrawInfo
    {
        #region Factory
        /// <summary>
        /// Get the default set for this sprite.
        /// </summary>
        public static SpriteDrawInfo Default
        {
            get { return new SpriteDrawInfo(Vector2.Zero, Color.White, 0f, Vector2.Zero, new Vector2(1), SpriteEffects.None, 0f); }
        }

        /// <summary>
        /// Create a new SpriteDrawInfo object with the specified position and default values for the rest of the fields.
        /// </summary>
        /// <param name="position">The position of the sprite.</param>
        /// <returns>The newly created object.</returns>
        public static SpriteDrawInfo Create(Vector2 position) { return new SpriteDrawInfo(position, Color.White, 0f, Vector2.Zero, new Vector2(1), SpriteEffects.None, 0f); }
        #endregion

        #region Public Members
        /// <summary>
        /// The position for this sprite.
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// The colour mask to apply to the texture.
        /// </summary>
        public Color Mask { get; set; }

        /// <summary>
        /// The rotation of the sprite.
        /// </summary>
        public float Rotation { get; set; }

        /// <summary>
        /// The origin of the sprite.
        /// </summary>
        public Vector2 Origin { get; set; }

        /// <summary>
        /// The scale of the sprite.
        /// </summary>
        public Vector2 Scale { get; set; }

        /// <summary>
        /// Effects to be applied to the sprite upon drawing.
        /// </summary>
        public SpriteEffects Effects { get; set; }

        /// <summary>
        /// The layer depth for the sprite.
        /// </summary>
        public float LayerDepth { get; set; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Initialize with the specified values.
        /// </summary>
        /// <param name="position">The position for this sprite.</param>
        /// <param name="mask">The colour mask to apply to the texture.</param>
        /// <param name="rotation">The rotation of the sprite.</param>
        /// <param name="origin">The origin of the sprite.</param>
        /// <param name="scale">The scale of the sprite.</param>
        /// <param name="effects">Effects to be applied to the sprite upon drawing.</param>
        /// <param name="layerDepth">The layer depth for the sprite.</param>
        public SpriteDrawInfo(Vector2 position, Color mask, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            this.Position = position;
            this.Mask = mask;
            this.Rotation = rotation;
            this.Origin = origin;
            this.Scale = scale;
            this.Effects = effects;
            this.LayerDepth = layerDepth;
        }
        #endregion

        #region Operator Overloads
        /// <summary>
        /// Checks to see if an object is equal to this object.
        /// </summary>
        /// <param name="obj">The object to test.</param>
        /// <returns>True if the supplied object is equal to this one, false otherwise.</returns>
        public override bool Equals(object obj)
        {
            bool equals = false;

            if (obj != null && obj is SpriteDrawInfo)
            {
                SpriteDrawInfo other = (SpriteDrawInfo)obj;
                equals =
                    this.Position.Equals(other.Position)
                    && this.Mask.Equals(other.Mask)
                    && this.Rotation.Equals(other.Rotation)
                    && this.Origin.Equals(other.Origin)
                    && this.Scale.Equals(other.Scale)
                    && this.Effects.Equals(other.Effects)
                    && this.LayerDepth.Equals(other.LayerDepth);
            }

            return equals;
        }

        /// <summary>
        /// Get the hash code for this object.
        /// </summary>
        /// <returns>The hash code for this object.</returns>
        public override int GetHashCode()
        {
            int hash = 17;
            unchecked
            {
                hash = hash * 29 + this.Position.GetHashCode();
                hash = hash * 29 + this.Mask.GetHashCode();
                hash = hash * 29 + this.Rotation.GetHashCode();
                hash = hash * 29 + this.Origin.GetHashCode();
                hash = hash * 29 + this.Scale.GetHashCode();
                hash = hash * 29 + this.Effects.GetHashCode();
                hash = hash * 29 + this.LayerDepth.GetHashCode();
            }

            return hash;
        }

        /// <summary>
        /// Compare two SpriteDrawInfo objects for equality.
        /// </summary>
        /// <param name="left">The left object.</param>
        /// <param name="right">The right object.</param>
        /// <returns>True if the properties of both objects are equivalent, false otherwise.</returns>
        public static bool operator ==(SpriteDrawInfo left, SpriteDrawInfo right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compare two SpriteDrawInfo objects for inequality.
        /// </summary>
        /// <param name="left">The left object.</param>
        /// <param name="right">The right object.</param>
        /// <returns>True if any of the properties of objects are not equivalent, false otherwise.</returns>
        public static bool operator !=(SpriteDrawInfo left, SpriteDrawInfo right)
        {
            return !(left.Equals(right));
        }
        #endregion
    }
}
