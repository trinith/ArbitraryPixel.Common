using ArbitraryPixel.Common.Audio.Factory;
using ArbitraryPixel.Common.ContentManagement;
using Microsoft.Xna.Framework.Audio;

#pragma warning disable 1591

namespace ArbitraryPixel.Common.Audio.MonoGame.Factory
{
    public class MonoGameSoundResourceFactory : ISoundResourceFactory
    {
        public ISoundResource Create(IContentManager content, string assetName)
        {
            return new SoundResource(new MonoGameSoundResource(content.Load<SoundEffect>(assetName)));
        }
    }
}
