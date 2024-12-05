using Microsoft.Xna.Framework.Media;

#pragma warning disable 1591

namespace ArbitraryPixel.Common.Audio.MonoGame
{
    public class MonoGameSong : WrapperBase<Song>, ISong
    {
        public MonoGameSong(Song objectToWrap)
            : base(objectToWrap)
        {
        }
    }
}
