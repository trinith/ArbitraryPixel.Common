using Microsoft.Xna.Framework;

namespace ArbitraryPixel.Common.Graphics
{
    /// <summary>
    /// Represents an object that applies an effect to a sprite batch.
    /// </summary>
    public interface IEffect : IGraphicsWrapper
    {
        /// <summary>
        /// Apply all passes in all techniques that belong to this effect.
        /// </summary>
        void ApplyAll();

        /// <summary>
        /// Set a parameter on this effect.
        /// </summary>
        /// <param name="paramName">The name of the parameter to set.</param>
        /// <param name="paramValue">The value to set on the parameter.</param>
        void SetParameter(string paramName, Vector2 paramValue);

        /// <summary>
        /// Set a parameter on this effect.
        /// </summary>
        /// <param name="paramName">The name of the parameter to set.</param>
        /// <param name="paramValue">The value to set on the parameter.</param>
        void SetParameter(string paramName, Vector4 paramValue);

        /// <summary>
        /// Set a parameter on this effect.
        /// </summary>
        /// <param name="paramName">The name of the parameter to set.</param>
        /// <param name="paramValue">The value to set on the parameter.</param>
        void SetParameter(string paramName, float paramValue);
    }
}
