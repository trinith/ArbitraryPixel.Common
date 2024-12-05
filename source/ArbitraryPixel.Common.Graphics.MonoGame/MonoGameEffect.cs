using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ArbitraryPixel.Common.Graphics.MonoGame
{
    public class MonoGameEffect : WrapperBase<Effect>, IEffect
    {
        public MonoGameEffect(Effect objectToWrap)
            : base(objectToWrap)
        {
        }

        public void ApplyAll()
        {
            foreach (EffectTechnique technique in this.WrappedObject.Techniques)
            {
                foreach (EffectPass pass in technique.Passes)
                {
                    pass.Apply();
                }
            }
        }

        public void SetParameter(string paramName, Vector2 paramValue)
        {
            this.WrappedObject.Parameters[paramName].SetValue(paramValue);
        }

        public void SetParameter(string paramName, Vector4 paramValue)
        {
            this.WrappedObject.Parameters[paramName].SetValue(paramValue);
        }

        public void SetParameter(string paramName, float paramValue)
        {
            this.WrappedObject.Parameters[paramName].SetValue(paramValue);
        }
    }
}
